using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class InvoiceGeneratorSummary
    {
        public int numberOfRides;
        public double totalFare;
        public double avgFare;

        public InvoiceGeneratorSummary(int numberOfRides, double totalFare)
        {
            this.numberOfRides = numberOfRides;
            this.totalFare = totalFare;
            this.avgFare = totalFare / numberOfRides;
        }
    }
}
