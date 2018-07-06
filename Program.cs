using System;
using System.Text;
using System.Data.SqlClient;

namespace PasswordHashing
{
    class Program
    {
        static void Main(string[] args)
        {
            string UserPassword;
            Console.WriteLine("Enter a password");
            UserPassword = Console.ReadLine();
            Console.WriteLine("HashedPassword is : " + HashPassword(UserPassword));
            Console.ReadKey();
        }
        public static string HashPassword(string pwd)
        {
            var RandomValue = System.Security.Cryptography.RNGCryptoServiceProvider.Create();
            byte[] data = new byte[10];
            RandomValue.GetBytes(data);
            int val = BitConverter.ToInt32(data, 0);
            string ModifiedPassword = pwd + val;
            var sha1 = System.Security.Cryptography.SHA256.Create();
            var inputBytes = Encoding.ASCII.GetBytes(ModifiedPassword);
            var hash = sha1.ComputeHash(inputBytes);
            var sb = new StringBuilder();
            for (var i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
