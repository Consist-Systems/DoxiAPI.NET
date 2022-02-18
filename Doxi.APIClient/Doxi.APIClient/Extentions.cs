using System.IO;

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
    }
}
