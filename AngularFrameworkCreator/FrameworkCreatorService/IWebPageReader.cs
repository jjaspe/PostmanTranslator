using HtmlAgilityPack;
using System.Collections.Generic;
using System.Xml.Linq;

namespace FrameworkCreatorService
{
    public interface IWebPageReader
    {
        string CamelCaseAtClass(string atClass);
        UIComponentModel CreateComponentIfValid(HtmlNode el);
        string GetAtClassOnly(string classes);
        List<UIComponentModel> GetComponents(string rawPage);
    }
}