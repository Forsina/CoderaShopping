using CoderaShopping.Domain;
using FluentNHibernate.Mapping;

namespace CoderaShopping.DataNHibernate.Mappings
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Schema("dbo");
            Table("Products");

            Id(x => x.ProductId)
                .Column("ProductId");

            Map(x => x.Name)
                .Not.Nullable();

            Map(x => x.Description);

            Map(x => x.Size);

            Map(x => x.Color);

            Map(x => x.Material);

            Map(x => x.Brand);

            Map(x => x.Suplier);

            Map(x => x.Quantity)
                .Not.Nullable();

            Map(x => x.Price)
                .Not.Nullable();

            Map(x => x.Tax)
                .Not.Nullable();

            Map(x => x.PriceWithTax)
                .Not.Nullable();

            Map(x => x.DiscountAvailable)
                .Not.Nullable();

            Map(x => x.DiscountPrice)
                .Not.Nullable();

            Map(x => x.Image);

            References(x => x.CategoryId)
                .Column("Product_Categories_Id")
                .Not.Nullable();

            HasMany(x => x.OrderProducts)
                .Inverse()
                //.ForeignKeyCascadeOnDelete();
                .Cascade.AllDeleteOrphan();
        }
    }
}
