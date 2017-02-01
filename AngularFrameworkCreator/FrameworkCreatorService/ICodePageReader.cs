using System.Collections.Generic;

namespace FrameworkCreatorService
{
    public interface ICodePageReader
    {
        List<UIComponentModel> GetModels(string fileContent);
    }
}