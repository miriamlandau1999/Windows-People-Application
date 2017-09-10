using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace day_31
{
    public partial class AddPersonDialog : Form
    {
        public AddPersonDialog()
        {
            InitializeComponent();  
        }
        public AddPersonDialog(bool isEditMode, Person person)
            :this()
        {
            if(isEditMode)
            {
                btnEnter.Text = "Update";
            }
            FirstNametxt.Text = person.FirstName;
            LastNameText.Text = person.LastName;
            AgeText.Text = person.Age.ToString();
            
        }
        public Person Person { get; private set; }
        public bool IsEditMode { private set; get; }
        private void btnEnter_Click(object sender, EventArgs e)
        {
            Person = new Person
            {
                FirstName = FirstNametxt.Text,
                LastName = LastNameText.Text,
                Age = int.Parse(AgeText.Text)
            };
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
