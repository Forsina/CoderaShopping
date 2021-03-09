using CoderaShopping.Domain;
using FluentNHibernate.Mapping;

namespace CoderaShopping.DataNHibernate.Mappings
{
    public class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Schema("dbo");
            Table("Categories");

            Id(x => x.CategoryId)
                .Column("CategoryId"); ;

            Map(x => x.Name)
                .Not.Nullable();

            Map(x => x.IsDefault)
                .Not.Nullable();

            Map(x => x.Status)
                .Not.Nullable();

            HasMany(x => x.Products)
                .Inverse()
                .Cascade.AllDeleteOrphan();
        }
    }
}