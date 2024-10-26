using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp;
using System;
namespace VezaVI.Light.Shared
{
    public class ImageCroppedResult
    {
        public string Base64{get;set;}
        public byte[] GetBytes()
        {
            return Convert.FromBase64String(Base64.Substring(Base64.IndexOf(',')+1));
        }
    }
}