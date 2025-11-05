using FinalSurgeTests.Models;

namespace FinalSurgeTests.Builders
{
    public class UserBuilder
    {
        private string userEmail = "";
        private string userPassword = "";
        private string firstName = "";
        private string lastName = "";
        

        public UserBuilder WithEmail(string email = "")
        {
            userEmail = email;
            return this;
        }

        public UserBuilder WithPassword(string password = "")
        {
            userPassword = password;
            return this;
        }

        public User BuildUserForAutorization()
        {
            return new User(userEmail, userPassword);
        }

        public UserBuilder WithFirstName(string name1 = "")
        {
            firstName = name1;
            return this;
        }

        public UserBuilder WithLasttName(string name2 = "")
        {
            lastName = name2;
            return this;
        }

        public User BuildUserForRegistration()
        {
            return new User(firstName, lastName, userEmail, userPassword, userPassword);
        }
    }
}
