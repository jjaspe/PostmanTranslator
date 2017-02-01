using FrameworkCreatorService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AngularFrameworkCreator
{
    public partial class Form1 : Form
    {
        public class FileModel
        {
            public string Name { get; set; }
            public string FullPath { get; set; }
        }

        public IWebPageReader webPageReader;
        public ICodeFileCreatorService codeFileCreatorService;
        public string SpecFolderPath = "C:\\development\\atlas\\Research\\ProtractorAutomation\\src\\pages";
        private BindingList<FileModel> unexcludedSpecs=new BindingList<FileModel>();
        private BindingList<FileModel> excludedSpecs = new BindingList<FileModel>();
        private FileModel mergeFile = new FileModel();
        private List<string> specPaths;

        public Form1()
        {
            InitializeComponent();
            this.specFileListBox.DataSource = unexcludedSpecs;
            this.specFileListBox.DisplayMember = "Name";
            this.excludedFileListBox.DataSource = excludedSpecs;
            this.excludedFileListBox.DisplayMember = "Name";
        }

        private void Translate_Click(object sender, EventArgs e)
        {
            string source = this.sourceTextBox.Text,code="";
            List<UIComponentModel> components = webPageReader.GetComponents(source);
            List<string> excludedFiles = excludedSpecs.ToList().Select(n => n.FullPath).ToList();
            if (String.IsNullOrEmpty(this.txtMergeWithTextBox.Text))
            {
                code = codeFileCreatorService.CreateCodeFile(components);
            }
            else
            {
                code = codeFileCreatorService.MergeCodeFile(components, mergeFile.FullPath, excludedFiles);
            }
            this.codeFileTextBox.Text = code;
            copyButton.Focus();
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.codeFileTextBox.Text);
        }

        private void clear_Click(object sender, EventArgs e)
        {
            this.sourceTextBox.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadSpecsIntoList(this.SpecFolderPath);
        }

        void LoadSpecsIntoList(string folderPath)
        {
            clearAll();
            specPaths = LoadFilesSpecFilesFromFolder(folderPath);
            List<FileModel> fileNames = ParseFileNameFromPath(specPaths);
            fileNames.ForEach(n => unexcludedSpecs.Add(n));
        }

        List<FileModel> ParseFileNameFromPath(List<string> fullFilePaths)
        {
            List<FileModel> fileNames = new List<FileModel>();
            fullFilePaths.ForEach(n =>
            {
                var parts = n.Split('\\');
                fileNames.Add(new FileModel() { FullPath = n, Name = parts.Last() });
            });
            return fileNames;
        }
        List<string> LoadFilesSpecFilesFromFolder(string folderPath)
        {
            return Directory.GetFiles(folderPath,"*.js",SearchOption.AllDirectories).ToList();
        }

        private void exclude_Click(object sender, EventArgs e)
        {
            if (this.specFileListBox.SelectedItem != null)
            {
                var selected = (FileModel)this.specFileListBox.SelectedItem;
                unexcludedSpecs.Remove(selected);
                excludedSpecs.Add(selected);
            }
        }

        private void unexclude_Click(object sender, EventArgs e)
        {
            if (this.excludedFileListBox.SelectedItem != null)
            {
                var selected = (FileModel)this.excludedFileListBox.SelectedItem;
                unexcludedSpecs.Add(selected);
                excludedSpecs.Remove(selected);
            }
        }

        private void addRemoveFileToMergeWith_Click(object sender, EventArgs e)
        {
            if (this.mergeFileButton.Text.Equals("<"))
            {
                if (this.specFileListBox.SelectedItem != null)
                {
                    var selected = (FileModel)this.specFileListBox.SelectedItem;
                    unexcludedSpecs.Remove(selected);
                    mergeFile = selected;
                    this.mergeFileButton.Text = ">";
                }
            }
            else
            {
                var selected = mergeFile;
                unexcludedSpecs.Add(selected);
                mergeFile = new FileModel();
                this.mergeFileButton.Text = "<";
            }
            this.txtMergeWithTextBox.Text = mergeFile.Name;
        }

        private void excludeAll_Click(object sender, EventArgs e)
        {
            while(unexcludedSpecs.Count>0)
            {
                excludedSpecs.Add(unexcludedSpecs[0]);
                unexcludedSpecs.Remove(unexcludedSpecs[0]);
            }            
        }

        private void unexcludeAll_Click(object sender, EventArgs e)
        {
            while (excludedSpecs.Count > 0)
            {
                unexcludedSpecs.Add(excludedSpecs[0]);
                excludedSpecs.Remove(excludedSpecs[0]);
            }
        }

        private void clearAll()
        {
            while (unexcludedSpecs.Count > 0)
            {
                unexcludedSpecs.Remove(unexcludedSpecs[0]);
            }
            while (excludedSpecs.Count > 0)
            {
                excludedSpecs.Remove(excludedSpecs[0]);
            }
        }
        

        private void loadButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            var result = dlg.ShowDialog();
            if (!String.IsNullOrWhiteSpace(dlg.SelectedPath))
                LoadSpecsIntoList(dlg.SelectedPath);
        }
    }
}
