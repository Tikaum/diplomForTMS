namespace FinalSurgeTests.Models
{
    public class User
    {
        public string UserEmail { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RePassword { get; set; }

        public User(string userEmail, string password)
        {
            UserEmail = userEmail;
            Password = password;
        }

        public User(string firstName, string lastName, string userEmail, string password, string repassword)
        {
            FirstName = firstName;
            LastName = lastName;
            UserEmail = userEmail;
            Password = password;
            RePassword = repassword;
        }
    }
}
