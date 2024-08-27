using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Registro
{
    public partial class DetailsPage : Form
    {
        private Student SelectedStudent;
        private List<Student> Students;
        private bool StudentMode;
        private int ID;
        private bool AddStudent;
        private bool EditState = false;

        public DetailsPage(Student SelectedStudent, List<Student> Students,  bool StudentMode, int ID, bool AddStudent)
        {
            this.SelectedStudent = SelectedStudent;
            this.Students = Students;
            this.StudentMode = StudentMode;
            this.ID = ID;
            this.AddStudent = AddStudent;

            InitializeComponent();
            UpdateStudentInfos(true);
            VotiGridUpdate();
            UpdateGridEditState(EditState);

            if (AddStudent)
            {
                ChangeToEditable();
            }
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

            if (StudentMode)
            {
                EditSaveButton.Text = "Log Out";
            }
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
            if (!StudentMode)
            {
                if (!EditState)
                {
                    EditState = true;
                    ChangeToEditable();
                    UpdateGridEditState(EditState);
                }
                else
                {
                    if (ValidateInputs())
                    {
                        EditState = false;
                        UpdateStudentInfos(false);
                        UpdateGridEditState(EditState);
                    }
                }
            }
            else
            {
                MessageBox.Show("Logged Out Successfully");
                var LoginForm = new LoginPage1();
                LoginForm.Show();
                this.Close();
                return;
            }
        }

        private bool ValidateInputs()
        {
            if (StudentTextBox.Text == "")
            {
                MessageBox.Show("Nome cannot be empty.");
                return false;
            }

            if (TextBoxCognome.Text == "")
            {
                MessageBox.Show("Cognome cannot be empty.");
                return false;
            }

            if (ClassTextBox.Text == "")
            {
                MessageBox.Show("Classe cannot be empty.");
                return false;
            }

            if (MatricolaTextBox.Value <= 0)
            {
                MessageBox.Show("Matricola must be a positive number.");
                return false;
            }

            if (BirthDayPicker.Value == DateTime.MinValue)
            {
                MessageBox.Show("Please select a valid birth date.");
                return false;
            }

            return true;
        }


        private void VotiGridUpdate()
        {
            DataTable dt = CreateVotiDataTable(SelectedStudent.Voti);
            dataGridViewVoti.DataSource = dt;
        }

        private DataTable CreateVotiDataTable(Dictionary<string, List<int>> voti)
        {
            DataTable dt = new DataTable();

            if (voti == null || voti.Count == 0)
            {
                voti = InitializeEmptyVoti();
            }

            Dictionary<string, List<int>> InitializeEmptyVoti()
            {
                return new Dictionary<string, List<int>>
    {
        { "Italiano", new List<int>() },
        { "Storia", new List<int>() },
        { "Matematica", new List<int>() },
        { "Inglese", new List<int>() },
        { "Informatica", new List<int>() },
        { "Sistemi e Reti", new List<int>() },
        { "Tpsit", new List<int>() },
        { "Telecomunicazioni", new List<int>() }
    };
            }

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
