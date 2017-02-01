using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkCreatorService
{
    public class UIComponentModel
    {
        public string VariableName { get; set; }
        public string SelectorValue { get; set; }
        public bool IsList { get; set; }
        public bool IsParent { get; set; }
        public string SelectorType { get; set;}
    }
}
