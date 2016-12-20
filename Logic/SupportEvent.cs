using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class SupportEvent
    {
        public int SupportEventID { get; private set; }
        public string SupportEventName { get; set; }
        public string SupportEventDescription { get; set; }
        public DateTime SupportEventStart { get; set; }
        public DateTime SupportEventStop { get; set; }
    }
}
