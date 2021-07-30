using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class InvoiceGenerator
    {
        //Declaring type of ride
        TypesOfRide type;
        //Declaring Varaibles
        private double MINIMUM_COST_PER_KM;
        private int COST_PER_TIME;
        private double MINIMUM_FARE;
        
        public InvoiceGenerator(TypesOfRide type)
        {
            this.type = type;
            //Initializing varaibles for Normal Ride
            if (type.Equals(TypesOfRide.NORMAL_RIDE))
            {
                this.MINIMUM_COST_PER_KM = 10;
                this.COST_PER_TIME = 1;
                this.MINIMUM_FARE = 5;
            }
            //Initializing varaibles for Premium Ride
            if (this.type.Equals(TypesOfRide.PREMIUM_RIDE))

            {
                this.MINIMUM_COST_PER_KM = 15;
                this.COST_PER_TIME = 1;
                this.MINIMUM_FARE = 20;

            }
        }
        //Method to Calculate the fare
        public double CalculateFare(double distance, int time)

        {
            double totalFare = 0.0;
            try
            {
                if (!(distance <= 0 && time <= 0))
                {
                    totalFare = distance * MINIMUM_COST_PER_KM + time * COST_PER_TIME;
                }

                else if (distance <= 0)
                {
                    throw new CustomException(CustomException.ExceptionType.INVALID_DISTANCE, "Distance should be positive integer");
                }
                else if (time <= 0)
                {
                    throw new CustomException(CustomException.ExceptionType.INVALID_DISTANCE, "Time should be positive integer");
                }

            }
            catch (CustomException ex)
            {
                Console.WriteLine(ex.message);
            }
            return Math.Max(totalFare, MINIMUM_FARE);
        }

        //Method to calculate the totalfare for multiple rides 
        public InvoiceGeneratorSummary CalculateFare(RideDetails[] rides)
        {
            double totalFare = 0;
            try
            {
                if (rides == null)
                {
                    throw new CustomException(CustomException.ExceptionType.NULL_RIDES, "No rides found");
                }
                foreach (RideDetails ride in rides)
                {
                    totalFare += this.CalculateFare(ride.distance, ride.time);
                }
            }
            catch (CustomException ex)
            {
                Console.WriteLine(ex.message);
            }
            return new InvoiceGeneratorSummary(rides.Length, totalFare);
        }
    }
}
