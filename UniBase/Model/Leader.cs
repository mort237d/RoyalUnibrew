using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniBase.Model
{
    class Leader : User
    {
        public Leader(string name, string email, string telephoneNumber, string password, string imageSource) : base(name, email, telephoneNumber, password, imageSource)
        {

        }
    }
}
