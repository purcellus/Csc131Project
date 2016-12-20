using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Customer
    {
        public int CustomerID { get; private set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerDescription { get; set; }
        public string CustomerWebsite { get; set; }

    }
}
