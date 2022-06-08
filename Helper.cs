using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManagerApplication
{
    enum ActionType
    {
        Add = 1, Modify, Delete
    }
    class Helper
    {
       
        public static string ConnectionString
        {
            get
            {
                return ContactsManagerApplication.Properties.Settings.Default.ContactsManagerApplicationDbConnectionString;
            }
        }

    }
}
