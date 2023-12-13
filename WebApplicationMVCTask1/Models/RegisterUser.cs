using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationMVCTask1.Models
{
    public class RegisterUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public string encryptedPassword { get; set; }
        public string decryptedPassword { get; set; }
    }
}
