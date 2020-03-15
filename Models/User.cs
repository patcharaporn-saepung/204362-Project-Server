using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MheanMaa.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public int DeptNo { get; set; }
    }

    public class UserReturn
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public int DeptNo { get; set; }

        public string Token { get; set; }

        public static explicit operator UserReturn(User u)
        {
            return new UserReturn
            {
                FirstName = u.FirstName,
                LastName = u.LastName,
                Username = u.Username,
                DeptNo = u.DeptNo,
                Token = null
            };
        }
    }

    public class UserLogin
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
