using Doxi.Service.UsersManager.Abstraction.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Doxi.Domain.Models.FrontModels
{
    public class User
    {
        public string UserName { get; set; }

        [Column(Order = 1)]

        public string FirstName { get; set; }

        [Column(Order = 2)]

        public string LastName { get; set; }

        [Column(Order = 3)]

        public string Email { get; set; }

        [Column(Order = 5)]

        public string Title { get; set; }

        [Column(Order = 6)]

        public string Company { get; set; }

        [Column(Order = 4)]

        public string PhoneNumber { get; set; }

        public bool IsExternal { get; set; }


        public string TwoFactorPassword { get; set; }
        public UMUserPermission UserPermission { get; set; }

        public string ToString(bool isWithMail = true)
        {
            if (isWithMail)
                return $"{FirstName} {LastName} ({Email})";
            else
                return $"{FirstName} {LastName}";
        }
        public string CreatorName { get; set; }
        public bool Deleted { get; set; }
    }
}