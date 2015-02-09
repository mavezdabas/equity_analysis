using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Login.Helpers
{
    public class HandleExceptions
    {

        public static bool ShowMessage(string code)
       {
           IDictionary<string,string> hashMap =  ErrorCodeHashMap.getInstance().errorCodesHashMap;
           string value="";
           string caption = "Error";
           string message=" ";

           foreach (KeyValuePair<string, string> pair in hashMap)
	       {
	        if(pair.Key==code)
                message+=pair.Value;
	       }   
           
           MessageBoxResult res = MessageBox.Show(message,caption, MessageBoxButton.OKCancel);

           if (res == MessageBoxResult.OK)
               return true;
           else
               return false;
       }
    }
}
