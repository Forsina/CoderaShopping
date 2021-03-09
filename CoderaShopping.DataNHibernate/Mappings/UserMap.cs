using CoderaShopping.Domain;
using FluentNHibernate.Mapping;

namespace CoderaShopping.DataNHibernate.Mappings
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Schema("dbo");
            Table("Users");

            Id(x => x.UserId)
                .Column("UserId");

            Map(x => x.FirstName)
                .Not.Nullable();

            Map(x => x.LastName)
                .Not.Nullable();

            Map(x => x.Country)
                .Not.Nullable();

            Map(x => x.City)
                .Not.Nullable();

            Map(x => x.Zip)
                .Not.Nullable();

            Map(x => x.Address)
                .Not.Nullable();

            Map(x => x.ContactNumber)
                .Not.Nullable();

            Map(x => x.Email)
                .Not.Nullable();

            Map(x => x.Password)
                .Not.Nullable();

            Map(x => x.IsAdmin)
                .Not.Nullable();

            Map(x => x.UserStatus)
                .Not.Nullable()
                .CustomType<User.UserStat>();

            Map(x => x.MemberSince)
                .Not.Nullable();

            HasMany(x => x.Orders)
                .Inverse()
                .Cascade.AllDeleteOrphan();
        }
    }
}
