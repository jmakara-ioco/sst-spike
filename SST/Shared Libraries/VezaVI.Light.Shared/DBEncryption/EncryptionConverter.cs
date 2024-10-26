using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace VezaVI.Light.Shared
{
    internal sealed class EncryptionConverter : ValueConverter<string, string>
    {
        public EncryptionConverter(IEncryptionProvider encryptionProvider, ConverterMappingHints mappingHints = null) : base(x => encryptionProvider.Encrypt(x), x => encryptionProvider.Decrypt(x), mappingHints)
        {
        }
    }
}
