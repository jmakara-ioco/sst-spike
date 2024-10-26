using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using PluralizeService.Core;

namespace VezaVI.Light.Shared
{
    public class VezaVIUtils
    {
        private static readonly string[] Vowels = new string[] { "A", "E", "I", "O", "U" };
        public static string CheckVowelA(string word)
        {
            foreach (string vowel in Vowels)
            {
                if (word.ToUpper().StartsWith(vowel))
                    return $"an {word}";
            }
            return $"a {word}";
        }

        public static string Plural(string word)
        {
            if (word == null)
                return string.Empty;
            if (word.ToLower().EndsWith("y"))
                return word[0..^1] + "ies";
            else if (word.ToLower().EndsWith("ss"))
                return word[0..^1] + "es";
            else if (word.ToLower().EndsWith("ch"))
                return $"{word}es";
            else
                return $"{word}s";
        }
        public static string Singular(string word)
        {
            return PluralizationProvider.Singularize(word);
        }

        public static int CastToInt32(object value)
        {
            if ((value == null) || (value == DBNull.Value))
                return 0;
            if (string.IsNullOrWhiteSpace(value.ToString()))
                return 0;
            try
            {
                return Convert.ToInt32(value);
            }
            catch
            {
                return 0;
            }
        }

        public static string CastToStr(object value)
        {
            if ((value == null) || (value == DBNull.Value))
                return string.Empty;
            try
            {
                return value.ToString();
            }
            catch
            {
                return string.Empty;
            }
        }

        public static DateTime? CastToNullableDate(object value)
        {
            if ((value == null) || (value == DBNull.Value))
                return null;
            try
            {
                return Convert.ToDateTime(value);
            }
            catch
            {
                return null;
            }
        }

        public static double CastToDouble(object value)
        {
            if ((value == null) || (value == DBNull.Value))
                return 0;
            try
            {
                return Convert.ToDouble(value);
            }
            catch
            {
                return 0;
            }
        }

        public static bool StrToBool(object value)
        {
            if ((value == null) || (value == DBNull.Value))
                return false;
            try
            {
                string option = value.ToString().ToUpper().Trim();
                return ((option == "YES") || (option == "Y") || (option == "TRUE") || (option == "1"));
            }
            catch
            {
                return false;
            }
        }

        public static bool IsActive(object value)
        {
            if (value == null)
                return false;
            if ((value.ToString().ToUpper() == "YES") || (value.ToString().ToUpper() == "TRUE") || (value.ToString().ToUpper() == "ACTIVE"))
                return true;
            return false;
        }

        public static uint SetBit(uint ANumber, int BitNum, bool BitOn)
        {
            if (BitNum < 0 || BitNum > 31) //64th bit reserved for negatives
                return 0;
            if (BitOn)
                ANumber |= (1u << (BitNum - 1));
            else
                if (IsBitSet(ANumber, BitNum))
                ANumber ^= (1u << (BitNum - 1));
            return ANumber;
        }

        public static bool IsBitSet(uint ANumber, int BitNum)
        {
            if (BitNum < 1 || BitNum > 31) //64th bit reserved for negatives
                return false;
            return (ANumber & 1L << (BitNum - 1)) != 0;
        }

        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Convert the byte array to hexadecimal string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                static string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch/* (RegexMatchTimeoutException e)*/
            {
                return false;
            }
            
            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        public static string Pad(string value, int length)
        {
            return value.PadLeft(length, '0');
        }

        public static string SplitBetweenCaps(string value)
        {
            var r = new Regex(@"
                (?<=[A-Z])(?=[A-Z][a-z]) |
                 (?<=[^A-Z])(?=[A-Z]) |
                 (?<=[A-Za-z])(?=[^A-Za-z])", RegexOptions.IgnorePatternWhitespace);
            return r.Replace(value, " ");
        }
        public static double ConvertBytesToKilobytes(long bytes)
        {
            return (bytes / 1024f) ;
        }

        public static double ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }

        public static double ConvertBytesToGigs(long bytes)
        {
            return ((bytes / 1024f) / 1024f) / 1024f;
        }
    }
}
