using CoderaShopping.Domain;

namespace CoderaShopping.DataNHibernate.Repositories
{
    public interface IUserRepository : IRepository<User>
    {

    }

    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }


    }
}
