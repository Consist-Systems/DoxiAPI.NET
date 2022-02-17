using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

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
            var rootType = typeof(IDoxiClient);
            var types = Assembly.GetAssembly(rootType).GetTypes();
            var removeList = new List<string>();

            var typesList = new List<Type>();
            var oneTimeRootGurd = new List<Type>(); 

            AddTypes(rootType, typesList, oneTimeRootGurd);
            var distinctTypes = typesList.Distinct().ToArray();

            foreach (var type in types)
            {
                if (!distinctTypes.Contains(type))
                {
                    removeList.Add(type.ToString());
                }
            }
            var result = string.Join(Environment.NewLine,removeList);
        }

        private static void AddTypes(Type rootType, List<Type> typesList, List<Type> oneTimeRootGurd)
        {
            if(oneTimeRootGurd.Contains(rootType))
                return;
            oneTimeRootGurd.Add(rootType);

            var curentTypeRefTypes = new List<Type>();
            var methods = rootType.GetMethods();
            curentTypeRefTypes.AddRange(methods.SelectMany(m => m.GetParameters()).Select(p => p.ParameterType));
            curentTypeRefTypes.AddRange(methods.Select(m => m.ReturnType));
            curentTypeRefTypes.AddRange(methods.SelectMany(m => m.GetCustomAttributes().Select(a => a.GetType())));

            var properies = rootType.GetProperties();
            curentTypeRefTypes.AddRange(properies.Select(p => p.PropertyType));
            typesList.AddRange(curentTypeRefTypes);

            foreach (var type in curentTypeRefTypes)
            {
                AddTypes(type, typesList, oneTimeRootGurd);
            }
        }
    }
}
