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
using Newtonsoft.Json;
using System.Diagnostics;

namespace Registro
{
    public partial class GridViewTeacher : Form
    {
        private List<Student> Students;
        public Student TempStudentDetails;
        public GridViewTeacher()
        {
            InitializeComponent();
            LoadGrid();
        }

        public void LoadGrid()
        {
            string JsonPath = @"..\..\assets\students.json";
            string Data = File.ReadAllText(JsonPath);
            Students = JsonConvert.DeserializeObject<List<Student>>(Data);

            var ListToAdd = new BindingList<Student>(Students);
            var source = new BindingSource(ListToAdd, null);
            dataGridView1.DataSource = source;

            dataGridView1.Columns["DataNascita"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView1.Columns["Voti"].Visible = false;
        }

        private void SaveJson()
        {
            string JsonPath = @"..\..\assets\students.json";
            string Data = JsonConvert.SerializeObject(Students, Formatting.Indented);
            File.WriteAllText(JsonPath, Data);
        }

        private void ShowStudentDetails(object sender, DataGridViewCellEventArgs e)
        {
                if (e.RowIndex >= 0)
            {
                Student SelectedStudent = Students[e.RowIndex];

                var detailsForm = new DetailsPage(SelectedStudent, Students, false, 0, false);

                if (detailsForm.ShowDialog() == DialogResult.OK)
                {
                    LoadGrid();
                }
              
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {

            var NewStudent = new Student
            {
                Matricola = 0,
                Nome = "",
                Cognome = "",
                DataNascita = DateTime.Today,
                LuogoNascita = "",
                Voti = new Dictionary<string, List<int>>()
            };


            var detailsForm = new DetailsPage(NewStudent, Students, false, 0, true);
            if (detailsForm.ShowDialog() == DialogResult.OK)
            {
                Students.Add(NewStudent);
                SaveJson();
                LoadGrid();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Logged Out Successfully");
            var LoginForm = new LoginPage1();
            LoginForm.Show();
            this.Close();
            return;
        }
    }
}
