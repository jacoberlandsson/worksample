using System;
using System.Globalization;
using TollFeeCalculator;

//Refaktorering av metoder.
//Använder IVehicle istället för Vehicle.


namespace TollFeeCalculator //alla filer ligger inom samma namspace för nåbarhet
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

        //Använder och tittar på VehicleType-propertyn i IVehicle så att samma används överallt.

        private readonly HashSet<VehicleType> tollFreeVehicles = new HashSet<VehicleType>
        {
            VehicleType.Motorbike,
            VehicleType.Tractor,
            VehicleType.Emergency,
            VehicleType.Diplomat,
            VehicleType.Foreign,
            VehicleType.Military,
        };

        // Tänker att det är samma datum varje år, så bortser från år och gör en lista med de "hårda" datumen.
        private readonly HashSet<(int Month, int Day)> tollFreeMonthDays = new HashSet<(int, int)>
        {
            (1, 1),
            (3, 28),
            (3, 29),
            (5, 1),
            (5, 8),
            (5, 9),
            (6, 5),
            (6, 6),
            (6, 21),
            (11, 1),
            (12, 24),
            (12, 25),
            (12, 26),
            (12, 31),
        };

        //Tänker att det är lättare att ändra i denna lista än att ändra logiken i metoden GetTollFee()
        private readonly List<(TimeSpan Start, TimeSpan End, int Fee)> tollFees = new List<(TimeSpan, TimeSpan, int)>
        {
            (TimeSpan.Parse("06:00"), TimeSpan.Parse("06:29"), 8),
            (TimeSpan.Parse("06:30"), TimeSpan.Parse("06:59"), 13),
            (TimeSpan.Parse("07:00"), TimeSpan.Parse("07:59"), 18),
            (TimeSpan.Parse("08:00"), TimeSpan.Parse("08:29"), 13),
            (TimeSpan.Parse("08:30"), TimeSpan.Parse("14:59"), 13),
            (TimeSpan.Parse("15:00"), TimeSpan.Parse("15:29"), 13),
            (TimeSpan.Parse("15:30"), TimeSpan.Parse("16:59"), 18),
            (TimeSpan.Parse("17:00"), TimeSpan.Parse("17:59"), 13),
            (TimeSpan.Parse("18:00"), TimeSpan.Parse("18:29"), 8),
        };

        public int GetTollFee(IVehicle vehicle, DateTime[] dates)
        {
            if (dates == null || dates.Length == 0) return 0; // Kontrollerar att "dates" inte är null eller att det inte finns några
            Array.Sort(dates); // Sortera "dates" för att hantera dem i kronologisk ordning

            int maxTotalFee = 60; //sätter maxavgift per dag
            DateTime intervalStart = dates[0];
            int totalFee = 0;
            int highestFeeInInterval = 0; //Variabel som ska hålla koll på högsta avgiften om fordon får flera avgifter under 60min.

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

        public int GetTollFee(DateTime date, IVehicle vehicle)
        {
            if (IsTollFreeDate(date) || IsTollFreeVehicle(vehicle))
            {
                return 0;
            }

            var timeOfDay = date.TimeOfDay;

            foreach (var (Start, End, Fee) in tollFees)
            {
                if (timeOfDay >= Start && timeOfDay <= End)
                {
                    return Fee;
                }
            }

            return 0; 
        }
    }

    //Använder och tittar på VehicleType-propertyn i IVehicle så att samma används överallt.
    public bool IsTollFreeVehicle(IVehicle vehicle)
    {
        if (vehicle == null) return false;
        return tollFreeVehicles.Contains(vehicle.Type);
    }

    
    private bool IsTollFreeDate(DateTime date)
    {
        if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
        {
            return true;
        }
        
        if(date.Month == 7) 
        { 
            return true; 
        }

        if (tollFreeMonthDays.Contains((date.Month, date.Day)))
        {
            return true;
        }

        DateTime previousDay = date.AddDays(-1);

        // Check if the previous day is a toll-free day
        if (tollFreeMonthDays.Contains((previousDay.Month, previousDay.Day)))
        {
            return true;
        }

        return false;
    }
}


