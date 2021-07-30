using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class RideRepository
    {
        Dictionary<int, List<RideDetails>> userRides = null;
        public RideRepository()
        {
            this.userRides = new Dictionary<int, List<RideDetails>>();

        }
        public void AddRide(int userId, RideDetails[] rides)
        {
            bool rideList = this.userRides.ContainsKey(userId);
            try
            {
                if (!rideList)
                {
                    List<RideDetails> list = new List<RideDetails>();
                    list.AddRange(rides);
                    this.userRides.Add(userId, list);
                }
            }
            catch (CustomException)
            {
                throw new CustomException(CustomException.ExceptionType.NULL_RIDES, "No rides found");
            }
        }
        public RideDetails[] GetRides(int userId)
        {
            try
            {
                return this.userRides[userId].ToArray();
            }
            catch (CustomException)
            {
                throw new CustomException(CustomException.ExceptionType.INVALID_USER_ID, "User id should be valid from list");
            }
        }
    }
}
