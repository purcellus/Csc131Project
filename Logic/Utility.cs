using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Utility
    {
        public static ObservableCollection<Ticket> GenerateTestTickets() {
            ObservableCollection<Ticket> tickets = new ObservableCollection<Ticket>();
            
            Customer companyA = new Customer { 
            CustomerAddress = "123 Blow lane",
            CustomerDescription = "A Tech Company",
            CustomerEmail = "bob@tech.net",
            CustomerName = "Sam's Electronics",
            CustomerWebsite = "tech.net" };

            Entity entityA = new Entity
            {
                EntityDescription = "This is A computer that is messed up",
                EntityName = "Computer A",
                EntityOwner = companyA
            };

            Entity entityB = new Entity
            {
                EntityDescription = "This is A router that is screwing up",
                EntityName = "Router A",
                EntityOwner = companyA
            };
            Entity entityC = new Entity
            {
                EntityDescription = "This is A hard drive that is filled up",
                EntityName = "Hard Drive A",
                EntityOwner = companyA
            };

            Entity entityD = new Entity
            {
                EntityDescription = "This is A printer that is screwed up",
                EntityName = "Printer A",
                EntityOwner = companyA
            };

            for (int i = 1; i < 4; ++i)
            {
                Ticket ticketA = new Ticket
                {
                    TicketDescription = "A ticket for a bug in the comptuer" + i,
                    TicketHolder = entityA,
                    TicketNumber = i,
                    TicketUrgency = Urgency.Urgent,
                    TicketRequested = DateTime.Now
                };
                Ticket ticketB = new Ticket
                {
                    TicketDescription = "A ticket for a bug in the Router " + i,
                    TicketHolder = entityB,
                    TicketNumber = i + 3,
                    TicketUrgency = Urgency.Medium,
                    TicketRequested = DateTime.Now
                };
                Ticket ticketC = new Ticket
                {
                    TicketDescription = "A ticket for a bug in the Hard Drive " + i,
                    TicketHolder = entityC,
                    TicketNumber = i + 6,
                    TicketUrgency = Urgency.High,
                    TicketRequested = DateTime.Now
                };
                Ticket ticketD = new Ticket
                {
                    TicketDescription = "A ticket for a bug in the Printer " + i,
                    TicketHolder = entityD,
                    TicketNumber = i + 9,
                    TicketUrgency = Urgency.Low,
                    TicketRequested = DateTime.Now
                };

                tickets.Add(ticketA);
                tickets.Add(ticketB);
                tickets.Add(ticketC);
                tickets.Add(ticketD);
            }


            return tickets;
        }
    }
}
