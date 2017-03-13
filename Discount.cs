using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    public class Discount
    {
        public string DiscountCode { get; set; }
        public double DiscountMultiplier { get; set; }

        public Discount(string DiscountCode, double DiscountMultiplier)
        {
            this.DiscountCode = DiscountCode;
            this.DiscountMultiplier = DiscountMultiplier;
        }
    }
}
