using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Obj_Common
{
    public static class Common
    {
        public static string Hash(string text)
        {
            MD5 md5 = MD5.Create();
            byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(text));
            StringBuilder hashSb = new StringBuilder();
            foreach (byte b in hash)
            {
                hashSb.Append(b.ToString("X2"));
            }
            return hashSb.ToString();
        }

        public static int iifInt(int obj1, int obj2) => obj1 != -1 ? obj1 : obj2;
        public static string iifString(string obj1, string obj2) => obj1 != null ? obj1 : obj2;
    }
}
