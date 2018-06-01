using System;

namespace ConsoleApp1.Domain
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public int positionId { get; set; }
        public string email { get; set; }
        public int companyId { get; set; }

        public User(int id, string name, string surname, int positionId, string email, int companyId)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.positionId = positionId;
            this.email = email;
            this.companyId = companyId;
        }

        public override bool Equals(Object obj)
        {
            // Check for null values and compare run-time types.
            if (obj == null || GetType() != obj.GetType())
                return false;

            User u = (User)obj;
            return (id == u.id) && (name == u.name) && (surname == u.surname) &&
                (positionId == u.positionId) && (email == u.email) && (companyId == u.companyId);
        }
    }
}