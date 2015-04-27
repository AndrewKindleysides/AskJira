using System;

namespace App
{
    public class User
    {
        public string Username;
        public string Password;

        public User()
        {
            Console.Write("Username: ");
            Username = Console.ReadLine();
            Console.Write("Password: ");
            Password = ReturnPassword();
            Console.WriteLine();
        }

        public string AuthenticationToken()
        {
            return Base64Encode(string.Format("{0}:{1}", Username, Password));
        }

        private string Base64Encode(string plainText)
        {
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(plainText));
        }

        private static string ReturnPassword()
        {
            var password = "";
            var info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter)
            {
                if (info.Key != ConsoleKey.Backspace)
                {
                    password += info.KeyChar;
                    info = Console.ReadKey(true);
                }
                else if (info.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(password))
                    {
                        password = password.Substring
                        (0, password.Length - 1);
                    }
                    info = Console.ReadKey(true);
                }
            }
            for (var i = 0; i < password.Length; i++)
                Console.Write("*");
            return password;
        }
    }
}