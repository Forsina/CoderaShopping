using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CoderaShopping.Domain
{
    public class User
    {
        private Guid _userId;
        private string _firstName;
        private string _lastName;
        private string _country;
        private string _city;
        private string _zip;
        private string _address;
        private string _contactNumber;
        private string _email;
        private string _password;
        private bool _isAdmin;   // where thrue is admin and false is regular user
        private UserStat _userStatus;
        private DateTime _memberSince;

        private IList<Order> _orders;

        public User()
        {
            _isAdmin = false;
            _userStatus = UserStat.Active;
            _orders = new List<Order>();
            _memberSince = DateTime.Now;
        }

        public virtual Guid UserId { get => _userId; set => _userId = value; }
        public virtual string FirstName { get => _firstName; set => _firstName = value; }
        public virtual string LastName { get => _lastName; set => _lastName = value; }
        public virtual string Country { get => _country; set => _country = value; }
        public virtual string City { get => _city; set => _city = value; }
        public virtual string Zip { get => _zip; set => _zip = value; }
        public virtual string Address { get => _address; set => _address = value; }
        public virtual string ContactNumber { get => _contactNumber; set => _contactNumber = value; }
        public virtual string Email { get => _email; set => _email = value; }
        public virtual string Password { get => _password; set => _password = value; }
        public virtual bool IsAdmin { get => _isAdmin; set => _isAdmin = value; }
        public virtual UserStat UserStatus { get => _userStatus; set => _userStatus = value; }
        public virtual DateTime MemberSince { get => _memberSince; set => _memberSince = value; }

        public virtual IList<Order> Orders { get => _orders; set => _orders = value; }

        public enum UserStat
        {
            Active = 1,
            InActive = 2,
            Blocked = 3,
            Locked = 4
        };
    }
}
