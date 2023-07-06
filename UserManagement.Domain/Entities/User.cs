using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Domain.Entities
{
    public class User
    {
        public string Id { get; private set; }
        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;
        public int Age { get; private set; }
        public string Gender { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public bool IsDeleted { get; private set; } = false;

        public User() {}

        public User(string firstName, string LastName, int Age, string Gender, DateTime dateOfBirth)
        {
            this.Id = Guid.NewGuid().ToString();
            this.FirstName = firstName;
            this.LastName = LastName;
            this.Age = Age;
            this.Gender = Gender;
            this.DateOfBirth = dateOfBirth;
        }

        public void IdNumbering()
        {
            this.Id = Guid.NewGuid().ToString("N");
        }

        public User UpdateUserInfo(User beforeUserInfo)
        {
            this.FirstName = beforeUserInfo.FirstName;
            this.LastName = beforeUserInfo.LastName;
            this.Age = beforeUserInfo.Age;
            this.Gender = beforeUserInfo.Gender;
            this.DateOfBirth = beforeUserInfo.DateOfBirth;
            return this;
        }
    }
}
