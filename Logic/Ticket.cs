using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{

    public class Ticket
    {
        public int TicketNumber { get; set; }
        public string TicketDescription { get; set; }
        public Entity TicketHolder { get; set; }
        public Urgency TicketUrgency { get; set; }
        public ObservableCollection<Technician> TicketTechnician { get; set; }
        public ObservableCollection<DateTime> TicketOpenDates { get; set; }
        public DateTime TicketRequested { get; set; }
        public ObservableCollection<DateTime> TicketCloseDates { get; set; }


    }
}
