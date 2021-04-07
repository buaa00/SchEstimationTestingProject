using System;
using SchEstimationTestingProject.Core.Users.ValueObjects;

namespace SchEstimationTestingProject.Core.Users.Entities
{
    public class User
    {
        public string Id { get; private set; }
        public UserInfo Informations { get; private set; }
        public string PasswordHash { get; private set; }

        public User(UserInfo info, string passwordHash)
        {
            Id = Guid.NewGuid().ToString();
            Informations = info;
            PasswordHash = passwordHash;
        }

        public User()
        {
            
        }
    }
}
