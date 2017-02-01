namespace AngularFrameworkCreator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sourceTextBox = new System.Windows.Forms.TextBox();
            this.codeFileTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.copyButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.specFileListBox = new System.Windows.Forms.ListBox();
            this.excludedFileListBox = new System.Windows.Forms.ListBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.txtMergeWithTextBox = new System.Windows.Forms.TextBox();
            this.mergeFileButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.excludeAll = new System.Windows.Forms.Button();
            this.unexcludeAll = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sourceTextBox
            // 
            this.sourceTextBox.AllowDrop = true;
            this.sourceTextBox.Location = new System.Drawing.Point(20, 52);
            this.sourceTextBox.Multiline = true;
            this.sourceTextBox.Name = "sourceTextBox";
            this.sourceTextBox.Size = new System.Drawing.Size(450, 467);
            this.sourceTextBox.TabIndex = 0;
            // 
            // codeFileTextBox
            // 
            this.codeFileTextBox.Enabled = false;
            this.codeFileTextBox.Location = new System.Drawing.Point(546, 87);
            this.codeFileTextBox.Multiline = true;
            this.codeFileTextBox.Name = "codeFileTextBox";
            this.codeFileTextBox.Size = new System.Drawing.Size(371, 432);
            this.codeFileTextBox.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(476, 200);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Translate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Translate_Click);
            // 
            // copyButton
            // 
            this.copyButton.Location = new System.Drawing.Point(590, 537);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(75, 23);
            this.copyButton.TabIndex = 3;
            this.copyButton.Text = "Copy";
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(20, 537);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.clear_Click);
            // 
            // specFileListBox
            // 
            this.specFileListBox.FormattingEnabled = true;
            this.specFileListBox.Location = new System.Drawing.Point(968, 52);
            this.specFileListBox.Name = "specFileListBox";
            this.specFileListBox.Size = new System.Drawing.Size(170, 472);
            this.specFileListBox.TabIndex = 5;
            // 
            // excludedFileListBox
            // 
            this.excludedFileListBox.FormattingEnabled = true;
            this.excludedFileListBox.Location = new System.Drawing.Point(1179, 52);
            this.excludedFileListBox.Name = "excludedFileListBox";
            this.excludedFileListBox.Size = new System.Drawing.Size(272, 472);
            this.excludedFileListBox.TabIndex = 6;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1144, 133);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(29, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = ">";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.exclude_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1144, 176);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(29, 23);
            this.button5.TabIndex = 9;
            this.button5.Text = "<";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.unexclude_Click);
            // 
            // txtMergeWithTextBox
            // 
            this.txtMergeWithTextBox.AllowDrop = true;
            this.txtMergeWithTextBox.Location = new System.Drawing.Point(546, 52);
            this.txtMergeWithTextBox.Name = "txtMergeWithTextBox";
            this.txtMergeWithTextBox.Size = new System.Drawing.Size(371, 20);
            this.txtMergeWithTextBox.TabIndex = 10;
            // 
            // mergeFileButton
            // 
            this.mergeFileButton.Location = new System.Drawing.Point(923, 52);
            this.mergeFileButton.Name = "mergeFileButton";
            this.mergeFileButton.Size = new System.Drawing.Size(39, 23);
            this.mergeFileButton.TabIndex = 12;
            this.mergeFileButton.Text = "<";
            this.mergeFileButton.UseVisualStyleBackColor = true;
            this.mergeFileButton.Click += new System.EventHandler(this.addRemoveFileToMergeWith_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "HTML";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(543, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "File To Merge With";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(965, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Page files";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1176, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Files To Exclude";
            // 
            // excludeAll
            // 
            this.excludeAll.Location = new System.Drawing.Point(1144, 87);
            this.excludeAll.Name = "excludeAll";
            this.excludeAll.Size = new System.Drawing.Size(29, 23);
            this.excludeAll.TabIndex = 17;
            this.excludeAll.Text = ">>";
            this.excludeAll.UseVisualStyleBackColor = true;
            this.excludeAll.Click += new System.EventHandler(this.excludeAll_Click);
            // 
            // unexcludeAll
            // 
            this.unexcludeAll.Location = new System.Drawing.Point(1144, 224);
            this.unexcludeAll.Name = "unexcludeAll";
            this.unexcludeAll.Size = new System.Drawing.Size(29, 23);
            this.unexcludeAll.TabIndex = 18;
            this.unexcludeAll.Text = "<<";
            this.unexcludeAll.UseVisualStyleBackColor = true;
            this.unexcludeAll.Click += new System.EventHandler(this.unexcludeAll_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(968, 552);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(99, 23);
            this.loadButton.TabIndex = 20;
            this.loadButton.Text = "Load From Folder";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1494, 658);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.unexcludeAll);
            this.Controls.Add(this.excludeAll);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mergeFileButton);
            this.Controls.Add(this.txtMergeWithTextBox);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.excludedFileListBox);
            this.Controls.Add(this.specFileListBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.copyButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.codeFileTextBox);
            this.Controls.Add(this.sourceTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox sourceTextBox;
        private System.Windows.Forms.TextBox codeFileTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox specFileListBox;
        private System.Windows.Forms.ListBox excludedFileListBox;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox txtMergeWithTextBox;
        private System.Windows.Forms.Button mergeFileButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button excludeAll;
        private System.Windows.Forms.Button unexcludeAll;
        private System.Windows.Forms.Button loadButton;
    }
}

