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
    public class CustomerManager
    {
        public static readonly string CUSTOMER = "Customer";
        public static readonly string NAME = "name";
        private static readonly string ADDRESS = "address";
        private static readonly string DESCRIPTION = "description";
        private static readonly string EMAIL = "email";
        private static readonly string WEBSITE = "website";

        private static ObservableCollection<Customer> _customers;

        // Adds a customer on parse
        public async static void AddCustomer(Customer customer) {
            ParseObject pObject = new ParseObject(CUSTOMER);
            pObject[NAME] = customer.CustomerName;
            pObject[ADDRESS] = customer.CustomerAddress;
            pObject[DESCRIPTION] = customer.CustomerDescription;
            pObject[EMAIL] = customer.CustomerEmail;
            pObject[WEBSITE] = customer.CustomerWebsite;
            await pObject.SaveAsync();
            if (_customers != null) _customers.Add(customer);
        }

        public static Customer GetCustomer(string p)
        {
            var query = from customer in ParseObject.GetQuery(CUSTOMER)
                        where customer.Get<string>(NAME) == p
                        select customer;

            ParseObject pObject = query.FirstAsync().Result;

            return new Customer { 
                CustomerName = pObject.Get<string>(NAME),
                CustomerAddress = pObject.Get<string>(ADDRESS),
                CustomerDescription = pObject.Get<string>(DESCRIPTION),
                CustomerEmail = pObject.Get<string>(EMAIL),
                CustomerWebsite = pObject.Get<string>(WEBSITE)
            };
        }

        public static ParseObject GetCustomerObject(string p)
        {
            var query = from customer in ParseObject.GetQuery(CUSTOMER)
                        where customer.Get<string>(NAME) == p
                        select customer;

            return query.FirstAsync().Result;
        }

        public static ObservableCollection<Customer> GetCustomers()
        {
            if (_customers == null) {
                _customers = new ObservableCollection<Customer>();
            }
            _customers.Clear();

            var query = from customer in ParseObject.GetQuery(CUSTOMER)
                        where customer.Get<string>(NAME) != ""
                        select customer;

            IEnumerable<ParseObject> results = query.FindAsync().Result;
            foreach (ParseObject result in results) {
                _customers.Add(new Customer
                {
                    CustomerName = result.Get<string>(NAME),
                    CustomerAddress = result.Get<string>(ADDRESS),
                    CustomerDescription = result.Get<string>(DESCRIPTION),
                    CustomerEmail = result.Get<string>(EMAIL),
                    CustomerWebsite = result.Get<string>(WEBSITE)
                });
            }

            return _customers;
        }
    }
}
