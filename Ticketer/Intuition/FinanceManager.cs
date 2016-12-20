using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;
using Parse;

namespace Intuition
{
    public class FinanceManager
    {
        private static readonly string FINANCE = "Finance";
        private static readonly string OWE = "owe";
        private static readonly string DESCRIPTION = "description";
        private static readonly string CUSTOMER = "customer";

        private static ObservableCollection<Finance> _finances;
        public static void AddFinance(Finance finance)
        {
            ParseObject pObject = new ParseObject(FINANCE);
            pObject[OWE] = finance.FinanceOwe;
            pObject[DESCRIPTION] = finance.FinanceDescription;
            pObject[CUSTOMER] = CustomerManager.GetCustomerObject(finance.FinanceCustomer.CustomerName);

            // Save it
            pObject.SaveAsync();
        }

        public static ObservableCollection<Finance> GetFinances()
        {
            if (_finances == null) _finances = new ObservableCollection<Finance>();
            _finances.Clear();

            var query = from fincance in ParseObject.GetQuery(FINANCE)
                        where fincance.Get<string>(OWE) != ""
                        select fincance;

            // Convert to observ coll
            foreach (ParseObject pObject in query.FindAsync().Result)
            {
                _finances.Add(new Finance { 
                    FinanceDescription = pObject.Get<string>(DESCRIPTION),
                    FinanceOwe = pObject.Get<string>(OWE),
                    FinanceCustomer = CustomerManager.GetCustomer(pObject.Get<ParseObject>(CUSTOMER).Get<string>(CustomerManager.NAME))
                });
            }
            return _finances;
        }
    }
}
