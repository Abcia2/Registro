using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Registro
{
    public partial class DetailsStudentTeacher : Form
    {
        private Student SelectedStudent;
        private List<Student> Students;
        private bool EditState = false;

        public DetailsStudentTeacher(Student SelectedStudent, List<Student> Students)
        {
            this.SelectedStudent = SelectedStudent;
            this.Students = Students;
            InitializeComponent();
            UpdateStudentInfos(true);
            VotiGridUpdate();
            UpdateGridEditState(EditState); // Set initial grid state
        }

        private void UpdateStudentInfos(bool Timing)
        {
            if (!Timing)
            {
                EditSaveButton.Text = "Edit";
                StudentTextBox.ReadOnly = true;
                TextBoxCognome.ReadOnly = true;
                ClassTextBox.ReadOnly = true;
                MatricolaTextBox.ReadOnly = true;
                MatricolaTextBox.Enabled = false;

                SelectedStudent.Nome = StudentTextBox.Text;
                SelectedStudent.Cognome = TextBoxCognome.Text;
                SelectedStudent.Classe = ClassTextBox.Text;
                SelectedStudent.Matricola = (int)MatricolaTextBox.Value;
                SelectedStudent.DataNascita = BirthDayPicker.Value;

                string JsonPath = @"..\..\assets\students.json";
                string Data = JsonConvert.SerializeObject(Students, Formatting.Indented);
                File.WriteAllText(JsonPath, Data);
                MessageBox.Show("Data saved successfully!");

                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }

            StudentTextBox.Text = SelectedStudent.Nome;
            TextBoxCognome.Text = SelectedStudent.Cognome;
            ClassTextBox.Text = SelectedStudent.Classe;
            MatricolaTextBox.Value = SelectedStudent.Matricola;
            BirthDayPicker.Value = SelectedStudent.DataNascita;
        }

        private void ChangeToEditable()
        {
            EditSaveButton.Text = "Save";
            StudentTextBox.ReadOnly = false;
            TextBoxCognome.ReadOnly = false;
            ClassTextBox.ReadOnly = false;
            MatricolaTextBox.ReadOnly = false;
            MatricolaTextBox.Enabled = true;
            BirthDayPicker.Enabled = true;
        }

        private void EditSaveButton_Click(object sender, EventArgs e)
        {
            if (!EditState)
            {
                EditState = true;
                ChangeToEditable();
                UpdateGridEditState(EditState); // Update grid state when entering edit mode
            }
            else
            {
                EditState = false;
                UpdateStudentInfos(false);
                UpdateGridEditState(EditState); // Update grid state when saving
            }
        }

        private void VotiGridUpdate()
        {
            DataTable dt = CreateVotiDataTable(SelectedStudent.Voti);
            dataGridViewVoti.DataSource = dt;
        }

        private DataTable CreateVotiDataTable(Dictionary<string, List<int>> voti)
        {
            DataTable dt = new DataTable();

            foreach (var subject in voti.Keys)
            {
                dt.Columns.Add(subject, typeof(int));
            }

            int maxRows = voti.Values.Max(grades => grades.Count);
            for (int rowIndex = 0; rowIndex < maxRows; rowIndex++)
            {
                DataRow row = dt.NewRow();
                foreach (var subject in voti.Keys)
                {
                    var grades = voti[subject];
                    row[subject] = (rowIndex < grades.Count) ? grades[rowIndex] : (object)DBNull.Value;
                }
                dt.Rows.Add(row);
            }

            return dt;
        }

        private void UpdateGridEditState(bool Editable)
        {
            dataGridViewVoti.ReadOnly = !Editable;
            foreach (DataGridViewColumn column in dataGridViewVoti.Columns)
            {
                column.ReadOnly = !Editable;
            }
        }
    }
}
