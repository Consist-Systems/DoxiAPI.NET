using Doxi.APIClient.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Doxi.APIClient
{
    internal static class Extentions
    {
        internal static byte[] ToBytes(this Stream source)
        {
            using (var ms = new MemoryStream())
            {
                source.CopyTo(ms);
                return ms.ToArray();
            }
        }

        internal static string GetKeycloakAttributeValue(this Dictionary<string, IEnumerable<string>> source,string key)
        {
            if (!source.ContainsKey(key))
                return null;

            return source[key].FirstOrDefault();

        }
    }
}
