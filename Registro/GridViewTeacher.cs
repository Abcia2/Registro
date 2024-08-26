using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Registro
{
    public partial class GridViewTeacher : Form
    {
        private List<Student> Students;
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

        private void LoadButton_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string JsonPath = @"..\..\assets\students.json";
            string Data = JsonConvert.SerializeObject(Students, Formatting.Indented);
            File.WriteAllText(JsonPath, Data);
            MessageBox.Show("Data saved successfully!");
        }
    }
}
