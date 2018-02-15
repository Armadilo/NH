using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateSpik.EntityModeMap
{
    public class Customer
    {
        public virtual string FirstName { get; set; }
        public virtual int Id { get; set; }
        public virtual string LastName { get; set; }

        public virtual IEnumerable<Product> Products { get; set; }
    }

    public class Product
    {
        public virtual string ProductName { get; set; }
    }
}
