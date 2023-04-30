using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FlowerStore.Common
{
    public static class MD5Encryption
    {
        public static byte[] GetMD5Bytes(string str)
        {
            using MD5 md5 = MD5.Create();
            return md5.ComputeHash(Encoding.UTF8.GetBytes(str));
        }

        public static string GetMD5String(string str)
        {
            byte[] bytes = GetMD5Bytes(str);
            return string.Join("", bytes.Select(b => b.ToString("x2")));
        }

        public static string GetMD5(this string self)
        {
            return GetMD5String(self);
        }
    }
}
