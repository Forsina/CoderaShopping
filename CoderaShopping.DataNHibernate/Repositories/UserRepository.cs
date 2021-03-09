using CoderaShopping.Domain;
using System.Linq;

namespace CoderaShopping.DataNHibernate.Repositories
{
    //Queries databse for "manipulation" of data and returning data koi ne se vo reposutory base

    public interface IUserRepository : IRepository<User>
    {
        bool IsUserUnique(User user);

        //IQueryable<User> GetActiveUsers();
    }

    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public bool IsUserUnique(User user)
        {
            if (user.UserId != null)
            {
                return !Session.Query<User>()
                 .Any(x => x.UserId != user.UserId && x.Email == user.Email);
            }

            return !Session.Query<User>().Any(x => x.Email == user.Email);
        }

        //public IQueryable<User> GetActiveUsers()
        //{
        //    return Session.Query<User>()
        //           .Where(x => x.Status.Equals(1));
        //}
    }
}
