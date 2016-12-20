using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace Intuition
{
    public class SupportEventManager
    {
        public IEnumerable<SupportEvent> GetSupportEvent(int amount)
        {
            // TODO: Implement This ex grabs newest amount of tickets
            return null;
        }

        public void AddSupportEvent(SupportEvent supportevent)
        {

        }

        public static System.Collections.ObjectModel.ObservableCollection<SupportEvent> GetSupportEvents(Ticket _ticket)
        {
            throw new NotImplementedException();
        }
    }
}
