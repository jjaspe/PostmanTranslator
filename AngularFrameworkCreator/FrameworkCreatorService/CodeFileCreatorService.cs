using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkCreatorService
{
    public class CodeFileCreatorService : ICodeFileCreatorService
    {
        static string header = @"export const {0} = {{
    {1}
    }};\r\n";
        static string singleDeclaration = "{0}: element(by.className('{1}'))";
        static string listDeclaration = "{0}: element.all(by.className('{1}'))";

        public ICodePageReader codePageReader;
        public string CreateCodeFile(List<UIComponentModel> components,string pageName="page")
        {
            string fileCode = createDeclarationStrings(components);
            fileCode = String.Format(header, pageName, fileCode);
            return fileCode;
        }

        public string MergeCodeFile(List<UIComponentModel> newComponents, string fileToMergeWith,List<string> filesToExclude)
        {
            List<UIComponentModel> exclusionList = new List<UIComponentModel>();
            filesToExclude.ForEach(n =>
            {
                exclusionList.AddRange(this.codePageReader.GetModels(n));

            });
            exclusionList.AddRange(this.codePageReader.GetModels(fileToMergeWith));
            var toRemove = newComponents.Where(n => exclusionList.Where(m => m.SelectorValue.Equals(n.SelectorValue)).Count() > 0);
            
            newComponents = newComponents.Except(toRemove).ToList();

            string declarations = createDeclarationStrings(newComponents);
            string fileCode = InsertDeclarationsIntoCodeFile(fileToMergeWith, declarations);
            return fileCode;
        }        

        private List<UIComponentModel> UpdateElementType(List<UIComponentModel> components)
        {
            var firstOfMultiple = components.
                GroupBy(n=>n.VariableName).
                Where(group=>group.Count()>1).
                Select(group=>group.First()).ToList();
            firstOfMultiple.ForEach(n => n.IsList = true);
            var singles = components.GroupBy(n => n.VariableName).
                Where(group => group.Count() == 1).Select(group => group.First()).ToList();
            singles.AddRange(firstOfMultiple);
            return singles;
        }

        private string createDeclarationStrings(List<UIComponentModel> components)
        {
            List<string> declarations = new List<string>();

            components = UpdateElementType(components);
            components.ForEach(n =>
            {
                declarations.Add(String.Format(n.IsList ? listDeclaration : singleDeclaration, n.VariableName, n.SelectorValue));
            });
            string fileCode = String.Join(",\r\n  ", declarations);
            return fileCode;
        }

        private string InsertDeclarationsIntoCodeFile(string filename,string declarations)
        {
            StreamReader fileStream = new StreamReader(File.OpenRead(filename));
            string contents = fileStream.ReadToEnd();
            fileStream.Close();
            List<string> lines = contents.Split('\r').ToList();

            //We will insert before the last line
            string part1 = String.Join("\r", lines.Take(lines.Count - 2).ToArray());
            string[] allparts = new string[] { part1+",", "\n  " + declarations, lines[lines.Count - 2] };

            return String.Join("\r", allparts);
        }
        
    }
}
