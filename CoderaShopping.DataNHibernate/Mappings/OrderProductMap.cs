using CoderaShopping.Domain;
using FluentNHibernate.Mapping;

namespace CoderaShopping.DataNHibernate.Mappings
{
    public class OrderProductMap : ClassMap<OrderProduct>
    {
        public OrderProductMap()
        {
            Schema("dbo");
            Table("OrderProducts");

            Id(x => x.Id)
                .Column("OrderProductId");

            Map(x => x.Quantity)
                .Not.Nullable();

            Map(x => x.DateOfProductOrder)
                .Not.Nullable();

            References(x => x.Order)
                .Column("OrderProduct_Order_Id");
            //.Cascade.All();

            References(x => x.Product)
                .Column("OrderProduct_Product_Id");

            //HasMany(x => x.Products)
            //    .Inverse()
            //    .ForeignKeyCascadeOnDelete();
        }
    }
}
