namespace Registro
{
    partial class DetailsPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetailsPage));
            this.StudentNameText = new System.Windows.Forms.Label();
            this.StudentTextBox = new System.Windows.Forms.TextBox();
            this.TextBoxCognome = new System.Windows.Forms.TextBox();
            this.EditSaveButton = new System.Windows.Forms.Button();
            this.BirthdayText = new System.Windows.Forms.Label();
            this.BirthDayPicker = new System.Windows.Forms.DateTimePicker();
            this.MatricolaTextBox = new System.Windows.Forms.NumericUpDown();
            this.ClassTextBox = new System.Windows.Forms.TextBox();
            this.dataGridViewVoti = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.MatricolaTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVoti)).BeginInit();
            this.SuspendLayout();
            // 
            // StudentNameText
            // 
            this.StudentNameText.AutoSize = true;
            this.StudentNameText.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StudentNameText.Location = new System.Drawing.Point(19, 45);
            this.StudentNameText.Name = "StudentNameText";
            this.StudentNameText.Size = new System.Drawing.Size(134, 36);
            this.StudentNameText.TabIndex = 0;
            this.StudentNameText.Text = "Student: ";
            // 
            // StudentTextBox
            // 
            this.StudentTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StudentTextBox.Location = new System.Drawing.Point(141, 45);
            this.StudentTextBox.Name = "StudentTextBox";
            this.StudentTextBox.ReadOnly = true;
            this.StudentTextBox.Size = new System.Drawing.Size(206, 41);
            this.StudentTextBox.TabIndex = 2;
            // 
            // TextBoxCognome
            // 
            this.TextBoxCognome.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxCognome.Location = new System.Drawing.Point(353, 45);
            this.TextBoxCognome.Name = "TextBoxCognome";
            this.TextBoxCognome.ReadOnly = true;
            this.TextBoxCognome.Size = new System.Drawing.Size(206, 41);
            this.TextBoxCognome.TabIndex = 3;
            // 
            // EditSaveButton
            // 
            this.EditSaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditSaveButton.Location = new System.Drawing.Point(628, 385);
            this.EditSaveButton.Name = "EditSaveButton";
            this.EditSaveButton.Size = new System.Drawing.Size(160, 53);
            this.EditSaveButton.TabIndex = 4;
            this.EditSaveButton.Text = "Edit";
            this.EditSaveButton.UseVisualStyleBackColor = true;
            this.EditSaveButton.Click += new System.EventHandler(this.EditSaveButton_Click);
            // 
            // BirthdayText
            // 
            this.BirthdayText.AutoSize = true;
            this.BirthdayText.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BirthdayText.Location = new System.Drawing.Point(19, 99);
            this.BirthdayText.Name = "BirthdayText";
            this.BirthdayText.Size = new System.Drawing.Size(137, 36);
            this.BirthdayText.TabIndex = 5;
            this.BirthdayText.Text = "BirthDay:";
            // 
            // BirthDayPicker
            // 
            this.BirthDayPicker.Enabled = false;
            this.BirthDayPicker.Location = new System.Drawing.Point(162, 110);
            this.BirthDayPicker.Name = "BirthDayPicker";
            this.BirthDayPicker.Size = new System.Drawing.Size(221, 22);
            this.BirthDayPicker.TabIndex = 6;
            // 
            // MatricolaTextBox
            // 
            this.MatricolaTextBox.Enabled = false;
            this.MatricolaTextBox.Location = new System.Drawing.Point(25, 13);
            this.MatricolaTextBox.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.MatricolaTextBox.Name = "MatricolaTextBox";
            this.MatricolaTextBox.ReadOnly = true;
            this.MatricolaTextBox.Size = new System.Drawing.Size(120, 22);
            this.MatricolaTextBox.TabIndex = 7;
            // 
            // ClassTextBox
            // 
            this.ClassTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClassTextBox.Location = new System.Drawing.Point(151, 12);
            this.ClassTextBox.Name = "ClassTextBox";
            this.ClassTextBox.ReadOnly = true;
            this.ClassTextBox.Size = new System.Drawing.Size(78, 26);
            this.ClassTextBox.TabIndex = 8;
            // 
            // dataGridViewVoti
            // 
            this.dataGridViewVoti.AllowUserToOrderColumns = true;
            this.dataGridViewVoti.BackgroundColor = System.Drawing.Color.Firebrick;
            this.dataGridViewVoti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewVoti.GridColor = System.Drawing.Color.DarkRed;
            this.dataGridViewVoti.Location = new System.Drawing.Point(25, 147);
            this.dataGridViewVoti.Name = "dataGridViewVoti";
            this.dataGridViewVoti.RowHeadersWidth = 51;
            this.dataGridViewVoti.RowTemplate.Height = 24;
            this.dataGridViewVoti.Size = new System.Drawing.Size(763, 232);
            this.dataGridViewVoti.TabIndex = 9;
            // 
            // DetailsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.IndianRed;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewVoti);
            this.Controls.Add(this.ClassTextBox);
            this.Controls.Add(this.MatricolaTextBox);
            this.Controls.Add(this.BirthDayPicker);
            this.Controls.Add(this.BirthdayText);
            this.Controls.Add(this.EditSaveButton);
            this.Controls.Add(this.TextBoxCognome);
            this.Controls.Add(this.StudentTextBox);
            this.Controls.Add(this.StudentNameText);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DetailsPage";
            this.Text = "DetailsStudentTeacher";
            ((System.ComponentModel.ISupportInitialize)(this.MatricolaTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVoti)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label StudentNameText;
        private System.Windows.Forms.TextBox StudentTextBox;
        private System.Windows.Forms.TextBox TextBoxCognome;
        private System.Windows.Forms.Button EditSaveButton;
        private System.Windows.Forms.Label BirthdayText;
        private System.Windows.Forms.DateTimePicker BirthDayPicker;
        private System.Windows.Forms.NumericUpDown MatricolaTextBox;
        private System.Windows.Forms.TextBox ClassTextBox;
        private System.Windows.Forms.DataGridView dataGridViewVoti;
    }
}