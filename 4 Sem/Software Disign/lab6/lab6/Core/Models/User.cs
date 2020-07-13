using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6.Core.Models
{
    enum UserType
    {
        Worker,
        Client
    }

    [Table("User")]
    public class User
    {
        public enum UserType
        {
            Worker,
            Client
        }

        public enum ClientLevel
        {
            Common,
            Regular,
            VIP
        }

        [Key]
        public int ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public long PhoneNumber { get; set; }
        public double AmountSpent { get; set; }
        public UserType TypeOfUser { get; set; }
        public ClientLevel LevelOfClient { get; set; }

        public User() { }
        public User(string login, long phoneNumber, string password)
        {
            Login = login;
            PhoneNumber = phoneNumber;
            Password = password;
            AmountSpent = 0;
            TypeOfUser = UserType.Client;
            LevelOfClient = ClientLevel.Common;
        }

    }
}
