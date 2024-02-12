using System;
using System.Globalization;
using TollFeeCalculator;


namespace TollFeeCalculator
{ 

    public class TollCalculator
    {

        /**
         * Calculate the total toll fee for one day
         *
         * @param vehicle - the vehicle
         * @param dates   - date and time of all passes on one day
         * @return - the total toll fee for that day
         */

        public GetTollFee(Vehicle vehicle, DateTime[] dates)
        {
            if (dates == null || dates.Length == 0) return 0; // Kontrollerar att "dates" inte är null eller att det inte finns några
            Array.Sort(dates); // Sortera "dates" för att hantera dem i kronologisk ordning

            const int maxTotalFee = 60; //setting the max fee/ day
            DateTime intervalStart = dates[0];
            int totalFee = 0;
            foreach (DateTime date in dates)
            {
                int currentFee = GetTollFee(date, vehicle);
                TimeSpan timeDiff = date - intervalStart;

                if (timeDiff.TotalMinutes <= 60)
                {
                    highestFeeInInterval = Math.Max(highestFeeInInterval, currentFee);
                }
                else
                {
                    totalFee += highestFeeInInterval;
                    intervalStart = date;
                    highestFeeInInterval = currentFee;
                }
            }
            totalFee += highestFeeInInterval; 
            return Math.Min(totalFee, maxTotalFee);
        }




        private readonly HashSet<VehicleType> tollFreeVehicles = new HashSet<VehicleType>
        {
            VehicleType.Motorbike,
            VehicleType.Tractor,
            VehicleType.Emergency,
            VehicleType.Diplomat,
            VehicleType.Foreign,
            VehicleType.Military,
        };

        public bool IsTollFreeVehicle(Vehicle vehicle)
        {
            if (vehicle == null) return false;
            return tollFreeVehicles.Contains(vehicle.Type);
        }

    //    public int GetTollFee(DateTime date, Vehicle vehicle)
    //    {
    //        if (IsTollFreeDate(date) || IsTollFreeVehicle(vehicle)) return 0;

    //        int hour = date.Hour;
    //        int minute = date.Minute;

    //        if (hour == 6 && minute >= 0 && minute <= 29) return 8;
    //        else if (hour == 6 && minute >= 30 && minute <= 59) return 13;
    //        else if (hour == 7 && minute >= 0 && minute <= 59) return 18;
    //        else if (hour == 8 && minute >= 0 && minute <= 29) return 13;
    //        else if (hour >= 8 && hour <= 14 && minute >= 30 && minute <= 59) return 8;
    //        else if (hour == 15 && minute >= 0 && minute <= 29) return 13;
    //        else if (hour == 15 && minute >= 0 || hour == 16 && minute <= 59) return 18;
    //        else if (hour == 17 && minute >= 0 && minute <= 59) return 13;
    //        else if (hour == 18 && minute >= 0 && minute <= 29) return 8;
    //        else return 0;
    //    }



    //    private bool IsTollFreeDate(DateTime date)
    //    {
    //        int year = date.Year;
    //        int month = date.Month;
    //        int day = date.Day;

    //        if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) return true;

    //        if (year == 2013)
    //        {
    //            if (month == 1 && day == 1 ||
    //                month == 3 && (day == 28 || day == 29) ||
    //                month == 4 && (day == 1 || day == 30) ||
    //                month == 5 && (day == 1 || day == 8 || day == 9) ||
    //                month == 6 && (day == 5 || day == 6 || day == 21) ||
    //                month == 7 ||
    //                month == 11 && day == 1 ||
    //                month == 12 && (day == 24 || day == 25 || day == 26 || day == 31))
    //            {
    //                return true;
    //            }
    //        }
    //        return false;
    //    }

    //    private enum TollFreeVehicles
    //    {
    //        Motorbike = 0,
    //        Tractor = 1,
    //        Emergency = 2,
    //        Diplomat = 3,
    //        Foreign = 4,
    //        Military = 5
    //    }
    //}

}