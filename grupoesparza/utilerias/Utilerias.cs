using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web.Helpers;
using System.Web;
using System.Text;
using grupoesparza.Models;
using System.Net;
using Newtonsoft.Json.Linq;

namespace grupoesparza.utilerias
{
    public class Utilerias
    {

        private string secretKey = "6LePLUAUAAAAAGytzJY2yHOs9rJuoRbLU71BKOi2";

        public static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
        //-----------------------------------------------------------

        public bool ValidRecaptcha(string request)
        {
            var response = request;
            
            var client = new WebClient();
            var result = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", this.secretKey, response));
            var obj = JObject.Parse(result);
            var status = (bool)obj.SelectToken("success");

            if (!status)
                return false;

            return true;
        }
        //-----------------------------------------------------------

    }
}