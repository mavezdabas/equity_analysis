using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;


namespace EquityTradingApplication
{
   
    public class UserModel
    {
      
       
        public int UserID
        {
            get;
            set;
        }


     
        public string UserName
        {
            get;
            set;
        }


      
        public string Name
        {
            get;
            set;
        }

       
       public int RoleID
       {
           get;
           set;
       }

         
       public string Password
       {
           get;
           set;
       }
    }
}
