using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VezaVI.Light.Shared
{
    public static class Initialize
    {
        public static string EncryptionKey = string.Empty;

        public static void Key(string key) => EncryptionKey = key;
    }
}
