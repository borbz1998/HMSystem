using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace Grades
{
    class SMS
    {
        public static string emailadd = "";
        public static string password = "";
        public void email(string email)
        {
            emailadd = email;
        }
        public void pass(string pass)
        {
            password = pass;
        }
        public void SendMessage(string api_name, string num, string msg, string credential, string pass)
        {
            try
            {
                ASCIIEncoding encoding = new ASCIIEncoding();
                string postData = "num=" + num + "&msg=" + msg + "&user=" + credential + "&pass=" + pass;
                byte[] data = encoding.GetBytes(postData);

                WebRequest req = WebRequest.Create("http://localhost/sms/" + api_name + ".php");
                req.Method = "POST";
                req.ContentType = "application/x-www-form-urlencoded";
                req.ContentLength = data.Length;

                Stream str = req.GetRequestStream();
                str.Write(data, 0, data.Length);
                str.Close();

                WebResponse webres = req.GetResponse();
                str = webres.GetResponseStream();

                StreamReader stread = new StreamReader(str);


                stread.Close();
                str.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
