using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class RideDetails
    {
        public double distance;
        public int time;

        public RideDetails(double distance, int time)
        {
            this.distance = distance;
            this.time = time;
        }
    }
}
