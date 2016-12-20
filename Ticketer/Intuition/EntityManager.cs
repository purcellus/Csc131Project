using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;
using Parse;

namespace Intuition
{
    public class EntityManager
    {
        private static readonly string ENTITY = "Entity";
        private static readonly string NAME = "name";
        private static readonly string OWNER = "owner";
        private static readonly string DESCRIPTION = "description";
        public static void AddEntity(Entity Entity)
        {
            ParseObject pObject = new ParseObject(ENTITY);
            pObject[NAME] = Entity.EntityName;
            pObject[OWNER] = CustomerManager.GetCustomerObject(Entity.EntityOwner.CustomerName);
            pObject[DESCRIPTION] = Entity.EntityDescription;

            pObject.SaveAsync();
        }

        public static ObservableCollection<Entity> GetEntities(Customer customer)
        {
            ObservableCollection<Entity> entities = new ObservableCollection<Entity>();

            // Get customer
            ParseObject pCust = CustomerManager.GetCustomerObject(customer.CustomerName);

            // Get all entities associated with them
            var query = from entity in ParseObject.GetQuery(ENTITY)
                        where entity[OWNER] == pCust
                        select entity;

            // Put into a observable collection
            foreach (ParseObject pObject in query.FindAsync().Result) {
                entities.Add(new Entity
                {
                    EntityDescription = pObject.Get<string>(DESCRIPTION),
                    EntityName = pObject.Get<string>(NAME),
                    EntityOwner = customer
                });
            }

            return entities;
        }
    }
}
