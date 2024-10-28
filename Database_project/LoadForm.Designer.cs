namespace Database_project
{
    partial class LoadForm
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
            this.PathTextBox = new System.Windows.Forms.TextBox();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.DescriptionLabel2 = new System.Windows.Forms.Label();
            this.PageNumberTextBox = new System.Windows.Forms.TextBox();
            this.DescriptionLabel3 = new System.Windows.Forms.Label();
            this.ImportButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PathTextBox
            // 
            this.PathTextBox.Location = new System.Drawing.Point(123, 47);
            this.PathTextBox.Name = "PathTextBox";
            this.PathTextBox.Size = new System.Drawing.Size(383, 22);
            this.PathTextBox.TabIndex = 0;
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(13, 13);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(493, 16);
            this.DescriptionLabel.TabIndex = 1;
            this.DescriptionLabel.Text = "Введите путь до документа и номер листа, на котором находится таблица";
            // 
            // DescriptionLabel2
            // 
            this.DescriptionLabel2.AutoSize = true;
            this.DescriptionLabel2.Location = new System.Drawing.Point(13, 50);
            this.DescriptionLabel2.Name = "DescriptionLabel2";
            this.DescriptionLabel2.Size = new System.Drawing.Size(104, 16);
            this.DescriptionLabel2.TabIndex = 2;
            this.DescriptionLabel2.Text = "Расположение";
            // 
            // PageNumberTextBox
            // 
            this.PageNumberTextBox.Location = new System.Drawing.Point(123, 88);
            this.PageNumberTextBox.MaxLength = 1;
            this.PageNumberTextBox.Name = "PageNumberTextBox";
            this.PageNumberTextBox.Size = new System.Drawing.Size(23, 22);
            this.PageNumberTextBox.TabIndex = 3;
            // 
            // DescriptionLabel3
            // 
            this.DescriptionLabel3.AutoSize = true;
            this.DescriptionLabel3.Location = new System.Drawing.Point(13, 91);
            this.DescriptionLabel3.Name = "DescriptionLabel3";
            this.DescriptionLabel3.Size = new System.Drawing.Size(91, 16);
            this.DescriptionLabel3.TabIndex = 4;
            this.DescriptionLabel3.Text = "Номер листа";
            // 
            // ImportButton
            // 
            this.ImportButton.Location = new System.Drawing.Point(16, 129);
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.Size = new System.Drawing.Size(130, 60);
            this.ImportButton.TabIndex = 5;
            this.ImportButton.Text = "Импортировать";
            this.ImportButton.UseVisualStyleBackColor = true;
            this.ImportButton.Click += new System.EventHandler(this.ImportButton_Click);
            // 
            // LoadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 253);
            this.Controls.Add(this.ImportButton);
            this.Controls.Add(this.DescriptionLabel3);
            this.Controls.Add(this.PageNumberTextBox);
            this.Controls.Add(this.DescriptionLabel2);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.PathTextBox);
            this.Name = "LoadForm";
            this.ShowIcon = false;
            this.Text = "Форма загрузки данных в базу данных";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox PathTextBox;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Label DescriptionLabel2;
        private System.Windows.Forms.TextBox PageNumberTextBox;
        private System.Windows.Forms.Label DescriptionLabel3;
        private System.Windows.Forms.Button ImportButton;
    }
}