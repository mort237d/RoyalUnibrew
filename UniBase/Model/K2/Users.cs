using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniBase.Model.K2
{
    class Users
    {
        public Users()
        {
            
        }

        public Users(int user_ID, string name, string email, string telephone_No, string password, string imageSource)
        {
            User_ID = user_ID;
            Name = name;
            Email = email;
            Telephone_No = telephone_No;
            Password = password;
            ImageSource = imageSource;
        }

        public int User_ID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
        
        public string Telephone_No { get; set; }
        
        public string Password { get; set; }
        
        public string ImageSource { get; set; }
    }
}
