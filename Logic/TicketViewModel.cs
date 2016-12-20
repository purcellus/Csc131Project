using System;
using System.Collections;
using System.Collections.ObjectModel;

namespace Logic
{
    public class TicketViewModel
    {
        public ObservableCollection<Ticket> Tickets { get; private set;}

        public TicketViewModel()
        {
            Tickets = Utility.GenerateTestTickets();
        }

        public void AddTicket(Ticket ticket){
            if (ticket != null)
            {
                Tickets.Add(ticket);
            }
            else
            {
                Console.Error.WriteLine("Tried to add null ticket!");
            }
        }
    }
}

