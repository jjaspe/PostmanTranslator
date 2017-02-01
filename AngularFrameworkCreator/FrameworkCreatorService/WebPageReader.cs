using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace FrameworkCreatorService
{
    public class WebPageReader : IWebPageReader
    {
        public List<UIComponentModel> GetComponents(string rawPage)
        {
            List<UIComponentModel> components = new List<UIComponentModel>();
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(rawPage);
            var allElements = doc.DocumentNode.Descendants();
            allElements.ToList().ForEach(n =>
            {
                var component = CreateComponentIfValid(n);
                if (component != null)
                    components.Add(component);
            });
            return components;
        }

        public UIComponentModel CreateComponentIfValid(HtmlNode el)
        {
            try
            {
                HtmlAttribute classes = el.Attributes["class"];
                bool valid = classes != null && !String.IsNullOrEmpty(classes.Value) && classes.Value.Contains("at");
                if (valid)
                {
                    string atClass = GetAtClassOnly(classes.Value);
                    string variableName = CamelCaseAtClass(atClass);
                    return new UIComponentModel()
                    {
                        SelectorValue = atClass,
                        VariableName = variableName
                    };
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string GetAtClassOnly(string classes)
        {
            string[] classArray = classes.Split(' ');
            string atClass = classArray.Where(n => n.StartsWith("at")).FirstOrDefault();
            return atClass;
        }

        public string CamelCaseAtClass(string atClass)
        {
            string variableName = "";
            string[] parts=new string[0];
            
            if (atClass.Contains('_'))
            {
                atClass = atClass.Replace("--", "_");
                parts = atClass.Split('_');
                
            }else if (atClass.Contains('-'))
            {
                atClass = atClass.Replace("--", "-");
                parts = atClass.Split('-');
            }

            //Create camel case variable name
            parts[0] = "";//delete at from list
            parts[1] = Char.ToLower(parts[1][0]) + parts[1].Substring(1);//lowercase first letter
            for(int i = 2; i < parts.Length; i++)
            {
                parts[i] = Char.ToUpper(parts[i][0]) + parts[i].Substring(1);//uppercase first letter
            }
            variableName = String.Join("", parts);
            return variableName;
        }


    }
}
