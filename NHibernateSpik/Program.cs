using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Cfg;
using NHibernateSpik.EntityModeMap;
using System.Data.SQLite;
using NHibernate;
using NHibernate.Linq;

namespace NHibernateSpik
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var customer = new Customer
                    {
                        //Id = new Guid("B9A69907-4B1B-4B67-8D04-247920C75F0D"),
                        FirstName = "Allan1",
                        LastName = "Bomer1",
                        Products = new List<Product>
                        {
                            new Product {  ProductName = "Moshe1"},
                            new Product {  ProductName = "Liraz1"},
                            new Product {  ProductName = "David1"},
                            new Product {  ProductName = "Naor1"},
                        }
                    };

                    ImageFileObject str = new ImageFileObject();
                    str.Map = new Dictionary<string, string>();
                    str.Map.Add("Name", "Liraz1");
                    //str.Map.Add("Customer", customer);


                    session.Save(customer);
                    session.Save(str);

                    transaction.Commit();
                    Console.WriteLine("Customer Created: " + customer.FirstName + "\t" +
                        customer.LastName);
                }

                Console.ReadKey();
            }

            using (var session = NHibernateHelper.OpenSession())
            {
                var cases = session.Query<ImageFileObject>().ToList();
                //var a = cases.Select(x => x.Map);
            }
        }
    }
}
