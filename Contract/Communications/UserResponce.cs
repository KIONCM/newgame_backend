using Entities.Models;

namespace Contract.Communications
{
    public partial class UserResponce : BaseResponce
    {
        public User User { get; private set; }
        public UserResponce(bool success, string message, User user) : base(success, message)
        {
            User = user;
        }

        public UserResponce(User user) : this(true, string.Empty, user)
        {

        }

        public UserResponce(string message) : this(false, message, null)
        {

        }
    }

    public partial class RoleResponce : BaseResponce
    {
        public UserRoles UserRole { get; private set; }
        public RoleResponce(bool success, string message, UserRoles role) : base(success, message)
        {
            UserRole = role;
        }

        public RoleResponce(UserRoles userRoles) : this(true, string.Empty, userRoles)
        {

        }

        public RoleResponce(string message) : this(false, message, null)
        {

        }
    }
}
