using System;

namespace App
{
    public class User
    {
        public static string Authenticate()
        {
            Console.WriteLine("Username: ");
            var username = Console.ReadLine();
            Console.WriteLine("Password: ");
            var password = Console.ReadLine();
            var auth = Base64Encode(string.Format("{0}:{1}", username, password));
            return auth;
        }

        public static string Base64Encode(string plainText)
        {
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(plainText));
        }
    }
}