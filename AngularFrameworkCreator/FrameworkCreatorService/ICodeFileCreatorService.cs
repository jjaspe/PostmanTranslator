using System.Collections.Generic;

namespace FrameworkCreatorService
{
    public interface ICodeFileCreatorService
    {
        string CreateCodeFile(List<UIComponentModel> components,string pageName="page");

        string MergeCodeFile(List<UIComponentModel> newComponents, string fileToMergeWith, List<string> filesToExclude);
    }
}