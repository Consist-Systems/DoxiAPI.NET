using NUnit.Framework;
using System;
using System.IO;
using System.Linq;

namespace Doxi.APIClient.Tests
{
    public class CopyFiles
    {
        [Test]
        public void Copy()
        {
            var referenceFile = @"C:\dev\DoxiAPI.NET\Doxi.APIClient\Doxi.APIClient\IDoxiClient.cs";
            AddFiles(referenceFile);
        }

        private static void AddFiles(string referenceFile)
        {
            var referenceText = File.ReadAllText(referenceFile);
            referenceText = referenceText
                            .Replace("Task", String.Empty)
                            .Replace("<", " ")
                            .Replace(">", String.Empty)
                            .Replace("/", String.Empty)
                            .Replace("[", String.Empty)
                            .Replace("]", String.Empty)
                            .Replace("(", " ")
                            .Replace(Environment.NewLine, " ");

            var words = referenceText.Split(' ');
            foreach (var word in words)
            {
                var file = Directory.GetFiles(@"C:\dev\Doxi_old\Doxi.Domain\Models", $"{word}.cs", SearchOption.AllDirectories).FirstOrDefault();

                if (file == null)
                    file = Directory.GetFiles(@"C:\dev\Doxi_old\Services\Doxi.Services.Interfaces", $"{word}.cs", SearchOption.AllDirectories).FirstOrDefault();
                if (file == null)
                    file = Directory.GetFiles(@"C:\dev\Doxi_old\DoxiAPI.Core\Models", $"{word}.cs", SearchOption.AllDirectories).FirstOrDefault();
                if (file == null)
                    file = Directory.GetFiles(@"C:\dev\Doxi_old\Doxi.Domain\Attributes", $"{word}.cs", SearchOption.AllDirectories).FirstOrDefault();


                if (file != null)
                {
                    var targetFile = Path.Combine(@"C:\dev\DoxiAPI.NET\Doxi.APIClient\Doxi.APIClient\Models", Path.GetFileName(file));
                    if (!File.Exists(targetFile))
                    {
                        File.Copy(file, targetFile);
                        AddFiles(targetFile);
                    }
                }
            }

        }

        [Test]
        public void REmoveUnused()
        {

        }
    }
}
