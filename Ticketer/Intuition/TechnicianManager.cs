using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace Intuition
{
    public class TechnicianManager
    {

        public static void AddTechnician(Technician Technician, string password) { 
            
        }

        public static IEnumerable<Ticket> AssignedTickets(Technician technician){
            return null;
        }

        public static ObservableCollection<Technician> GetTechnicians()
        {
            throw new NotImplementedException();
        }
    }
}
