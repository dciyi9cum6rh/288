using System;
using System.Security.Cryptography;
using System.Text;

namespace Utility
{
    public static class Data
    {
        //將Guid 重新編碼成19碼 不重覆唯一值
        public static long IntGuid()
        {
            byte[] buffer = System.Guid.NewGuid().ToByteArray();
            long token = BitConverter.ToInt64(buffer, 0);
            return token;
        }

        // 將密碼編碼的方法
        public static string HashPassword(string str)
        {
            string rethash = "";
            using (var algorithm = SHA256.Create())
            {
                // Create the at_hash using the access token returned by CreateAccessTokenAsync.
                byte[] hash = algorithm.ComputeHash(Encoding.ASCII.GetBytes(str));
                rethash = Convert.ToBase64String(hash);
            }
            return rethash;
        }

        public static bool isNumber(string pId)
        {
            bool ret = true;
            for (int i = 0; i <= pId.Length - 1; i++)
            {
                if (!char.IsDigit(pId[i]))
                {
                    return false;
                }
            }
            return ret;
        }

        public static string GetNewId(String Id, int start, int length)
        {
            int tmp = int.Parse(Id.Substring(start, length)) + 1;
            return $"{Id.Substring(0, start)}{tmp:0000}";
        }

        public static string GetStartId(string first, DateTime dt)
        {
            return $"{first}{dt:yyyy}{dt:MM}{dt:dd}0201";
        }

        public static string GetSHA256(string ToLower)
        {
            SHA256 SHA256Hasher = SHA256.Create();
            byte[] data = SHA256Hasher.ComputeHash(Encoding.Default.GetBytes(ToLower));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("X2"));//MD5碼 大小寫
            }

            return sBuilder.ToString();
        }
    }
}