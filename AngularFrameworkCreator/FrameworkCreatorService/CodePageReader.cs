using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FrameworkCreatorService
{
    public class CodePageReader : ICodePageReader
    {
        /// <summary>
        /// Assumes content is in regular .page.js format
        /// </summary>
        /// <param name="fileContent"></param>
        /// <returns></returns>
        public List<UIComponentModel> GetModels(string filePath)
        {
            string fileContent = LoadFile(filePath);
            List<UIComponentModel> models = new List<UIComponentModel>();
            List<string> lines = fileContent.Split('\r').ToList();

            //Find each line with "by.", save component
            lines.ForEach(n =>
            {
                if (n.Contains("by."))
                {
                    var parts = n.Split(':');
                    if (parts.Length == 2)
                    {
                        UIComponentModel model = new UIComponentModel();
                        model.VariableName = parts[0];
                        if (parts[1].Contains("element.all"))
                        {
                            model.IsList = true;
                        }
                        Regex reg = new Regex("by\\.(.*)\\(");
                        model.SelectorType = reg.Match(parts[1]).Groups[1].Value;
                        reg = new Regex("\'(.*)\'");
                        model.SelectorValue =reg.Match(parts[1]).Groups[1].Value;
                        models.Add(model);
                    }
                }
            });

            return models;
        }

        string LoadFile(string filename)
        {
            StreamReader fileStream = new StreamReader(File.OpenRead(filename));
            string contents = fileStream.ReadToEnd();
            return contents;
        }
    }
}
