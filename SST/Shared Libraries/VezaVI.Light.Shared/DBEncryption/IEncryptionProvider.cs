using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VezaVI.Light.Shared
{
    public interface IEncryptionProvider
    {
        string Encrypt(string dataToEncrypt);
        string Decrypt(string dataToDecrypt);
    }
}
