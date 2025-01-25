using System;
using System.Globalization;
using TollCalculatorLib.Extensions;
using TollCalculatorLib.Model;

namespace TollCalculatorLib
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

        public int GetTollFee(IVehicle vehicle, DateTime[] dates)
        {
            DateTime intervalStart = dates[0];
            int totalFee = 0;
            foreach (DateTime date in dates)
            {
                int nextFee = GetTollFee(date, vehicle);
                int tempFee = GetTollFee(intervalStart, vehicle);

                long diffInMillies = date.Millisecond - intervalStart.Millisecond;
                long minutes = diffInMillies / 1000 / 60;

                if (minutes <= 60)
                {
                    if (totalFee > 0) totalFee -= tempFee;
                    if (nextFee >= tempFee) tempFee = nextFee;
                    totalFee += tempFee;
                }
                else
                {
                    totalFee += nextFee;
                }
            }
            if (totalFee > 60) totalFee = 60;
            return totalFee;
        }

        public int GetTollFee(DateTime date, IVehicle vehicle)
        {
            if (IsTollFreeDate(date) || IsTollFreeVehicle(vehicle)) return 0;
            
            var tollInterval = Constants.TollIntervals.Find(i => i.IsInInterval(date));

            if(tollInterval != null)            
                return tollInterval.Fee;


            return 0;
        }

        private static bool IsTollFreeDate(DateTime date) => date.IsPublicHolidayOrDayBefore();       


        private static bool IsTollFreeVehicle(IVehicle vehicle)
        {
            if (vehicle == null) return false;
            VehicleType vehicleType = vehicle.GetVehicleType();

            return Enum.TryParse(vehicleType.ToString(), out TollFreeVehicles _);
        }

        private enum TollFreeVehicles
        {
            Motorbike = 0,
            Tractor = 1,
            Emergency = 2,
            Diplomat = 3,
            Foreign = 4,
            Military = 5
        }
    }
}
