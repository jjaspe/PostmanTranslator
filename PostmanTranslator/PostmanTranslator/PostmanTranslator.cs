
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PostmanTranslator
{
    public partial class PostmanTranslator : Form
    {
        public PostmanTranslator()
        {
            InitializeComponent();
        }

        class Variable
        {
            public string name;
            public string value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string callString = textBox1.Text,
               variablesString = textBox2.Text;
            int index;

            List<Variable> variables = new List<Variable>();
            List<string> lines = variablesString.Replace("\r","").Split('\n').ToList();

            foreach(string line in lines)
            {
                index = line.IndexOf('→');
                string name = line.Substring(0, index-1),
                         value = line.Substring(index+1);
                variables.Add(new Variable() { name = name, value = value });
            }

            while(callString.IndexOf("{{")>-1)
            {
                int startIndex = callString.IndexOf("{{"), endIndex = callString.IndexOf("}}");
                string name = callString.Substring(startIndex + 2, endIndex - startIndex-2);
                Variable correct = variables.Where(n => n.name.Equals(name)).FirstOrDefault();
                callString=callString.Replace(callString.Substring(startIndex, endIndex - startIndex + 2),correct.value);
            }

            textBox3.Text = callString; 
        }
    }
}
