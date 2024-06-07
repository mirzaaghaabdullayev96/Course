using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyERP.Business.Services.Implementation
{
    public static class MyHelper
    {
        public static bool NameChecker(string name)
        {
            if (name.All(char.IsLetter))
            {
                return true;
            }
            return false;
        }


    }
}
