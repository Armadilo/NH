using FluentNHibernate.Mapping;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateSpik.EntityModeMap
{
    public class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            Id(x=> x.Id);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            HasMany(x => x.Products).Table("Products")
                .Component(p =>
                {
                    p.Map(x => x.ProductName);

                }).AsSet();
            Table("Customer");
        }
    }

    public class ImageFileObjectMap : ClassMap<ImageFileObject>
    {
        public ImageFileObjectMap()
        {
            Id(x=>x.Id);
            DynamicComponent(x => x.Map
                , c =>
                {
                    c.References(x => (Customer)x["Customer"]);
                    c.Map("Name").Column("name");
                    //c.HasOne(x=> (Customer)x["Customer"],v=>
                    //    {
                    //        Table("Customer");
                    //    }
                    //).References(x=>x.Id,"id");

                }
                );
            Table("ImageFiles");
        }
    }

    public class StringObjectMapMap //: ClassMap<StringObjectMap>
    {
        public StringObjectMapMap()
        {

            //DynamicComponent(x => x
            //, c =>
            //{
            //    c.Map("Name").Column("name").CustomType<string>();
            //    c.HasOne<Customer>(x => x["Customer"]);
            //}
            //);
            //Table("ImageFiles");
        }
    }

}
