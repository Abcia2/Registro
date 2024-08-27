using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registro
{
    public partial class LoginPage2 : Form
    {
        private List<Student> Students;
        public Student TempStudentDetails;
        public LoginPage2()
        {
            InitializeComponent();
            LoadJson();
        }

        public void LoadJson()
        {
            string JsonPath = @"..\..\assets\students.json";
            string Data = File.ReadAllText(JsonPath);
            Students = JsonConvert.DeserializeObject<List<Student>>(Data);

            var ListToAdd = new BindingList<Student>(Students);
            var source = new BindingSource(ListToAdd, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var student in Students)
            {
                if(student.Matricola == numericUpDown1.Value)
                {
                    MessageBox.Show("Singed In Sucessfully");
                    var detailsForm = new DetailsStudentTeacher(SelectedStudent, Students, false, 0);
                    detailsForm.Show();
                    return;
                }

                MessageBox.Show("Invalid ID");
                numericUpDown1.Value = 0;
                return;
            }
        }
    }
}
