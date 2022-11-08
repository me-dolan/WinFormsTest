namespace WinFormsTest
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.downloadButton = new System.Windows.Forms.Button();
            this.ReadTxtButton = new System.Windows.Forms.Button();
            this.Zip = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // downloadButton
            // 
            this.downloadButton.Location = new System.Drawing.Point(12, 12);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(79, 26);
            this.downloadButton.TabIndex = 0;
            this.downloadButton.Text = "Download";
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // ReadTxtButton
            // 
            this.ReadTxtButton.Location = new System.Drawing.Point(337, 12);
            this.ReadTxtButton.Name = "ReadTxtButton";
            this.ReadTxtButton.Size = new System.Drawing.Size(80, 26);
            this.ReadTxtButton.TabIndex = 2;
            this.ReadTxtButton.Text = "Read";
            this.ReadTxtButton.UseVisualStyleBackColor = true;
            this.ReadTxtButton.Click += new System.EventHandler(this.ReadTxtButton_Click);
            // 
            // Zip
            // 
            this.Zip.Location = new System.Drawing.Point(705, 12);
            this.Zip.Name = "Zip";
            this.Zip.Size = new System.Drawing.Size(83, 26);
            this.Zip.TabIndex = 3;
            this.Zip.Text = "Zip";
            this.Zip.UseVisualStyleBackColor = true;
            this.Zip.Click += new System.EventHandler(this.Zip_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 30);
            this.label1.TabIndex = 4;
            this.label1.Text = "Скачать и \r\nразархивировать файл";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(261, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(261, 30);
            this.label2.TabIndex = 5;
            this.label2.Text = "Обрабатывает txt файл и записывает\r\n их на 3 равные csv. Занимает где то секунд 2" +
    "0\r\n";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(651, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 30);
            this.label3.TabIndex = 6;
            this.label3.Text = "Создаёт архив\r\n с 3-мя созданными csv\r\n";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 30);
            this.label4.TabIndex = 7;
            this.label4.Text = "При дебаге, создаёт\r\n папку в \"bin/debug/..\"\r\n";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 198);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Zip);
            this.Controls.Add(this.ReadTxtButton);
            this.Controls.Add(this.downloadButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button downloadButton;
        private Button ReadTxtButton;
        private Button Zip;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}