using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Entity
    {
        public int EntityID { get; private set; }
        public string EntityName { get; set; }
        public Customer EntityOwner { get; set; }
        public string EntityDescription { get; set; }
        // TODO: Add JSON Property for EntityProperties
    }
}
