using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VezaVI.Light.Shared
{

    public static class VezaVIBase64Utils
    {
        public const string AllowedBase64Chars = "_.";
        public const string RemovedBase64Chars = "+/";

        public static string Encode(this string s)
        {
            var bytes = Encoding.UTF8.GetBytes(s);
            string base64 = SanitiseBase64(Convert.ToBase64String(bytes));
            return base64;
        }

        public static string Decode(this string s)
        {
            var base64 = DesanitiseBase64(s);
            var bytes = Convert.FromBase64String(base64);
            var retStr = Encoding.UTF8.GetString(bytes);
            return retStr;
        }
       
        public static string SanitiseBase64(string s)
        {
            var retStr = s;
            for (int i = 0; i < RemovedBase64Chars.Length; i++)
            {
                retStr = retStr.Replace(RemovedBase64Chars[i], AllowedBase64Chars[i]);
            }
            return retStr;
        }

        public static string DesanitiseBase64(string s)
        {
            var retStr = s;
            for (int i = 0; i < RemovedBase64Chars.Length; i++)
            {
                retStr = retStr.Replace(AllowedBase64Chars[i], RemovedBase64Chars[i]);
            }
            return retStr;
        }

    }
}
