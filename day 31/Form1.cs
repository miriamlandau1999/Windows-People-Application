using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace day_31
{
    public partial class Form1 : Form
    {
        private List<Person> _people = new List<Person>();
        public Form1()
        {
            InitializeComponent();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;

            DesignGrid();
        }
        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            AddPersonDialog form = new AddPersonDialog();
            form.ShowDialog();
            if(form.Person != null)
            {
                _people.Add(form.Person);
                FillRows();
            }  
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<Person> results = new List<Person>();
            foreach (Person p in _people)
            {
                if (p.FirstName.Contains(txtSearch.Text) || p.LastName.Contains(txtSearch.Text))
                {
                    results.Add(p);
                }
            }
            FillRows(results);
        }
        private void DesignGrid()
        {
            dataGridView1.Columns.Add("FirstName", "First Name");
            dataGridView1.Columns.Add("LastName", "Last Name");
            dataGridView1.Columns.Add("Age", "Age");
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            Person SelectedPerson = _people[selectedRow.Index];
            AddPersonDialog EditForm = new AddPersonDialog(true, SelectedPerson);
            EditForm.ShowDialog();
            Person editedPerson = EditForm.Person;
            _people[selectedRow.Index] = EditForm.Person;
            if(editedPerson == null)
            {
                return;
            }
            FillRows();
        }
        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            FillRows();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }
            _people.RemoveAt(dataGridView1.SelectedRows[0].Index);
            FillRows();
        }
        private void FillRows(List<Person> people)
        {
            dataGridView1.Rows.Clear();
            foreach (Person p in people)
            {
                dataGridView1.Rows.Add(p.FirstName, p.LastName, p.Age);
            }
        }
        private void FillRows()
        {
            FillRows(_people);
        }
    }
}
