using CoderaShopping.Domain;
using FluentNHibernate.Mapping;

namespace CoderaShopping.DataNHibernate.Mappings
{
    public class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {
            Schema("dbo");
            Table("Orders");

            Id(x => x.OrderId)
                .Column("OrderId");

            Map(x => x.TotalAmount)
                .Not.Nullable();

            Map(x => x.OrderStatus)
                .Not.Nullable();

            Map(x => x.DateOfOrder)
                .Not.Nullable();

            Map(x => x.DateOfSending);

            References(x => x.UserId)
                .Column("Order_User_Id")
                .Cascade.All();

            HasMany(x => x.OrderProduct)
                .Inverse()
                .Cascade.AllDeleteOrphan();
            //.ForeignKeyCascadeOnDelete();
        }
    }
}
