using NoteApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteAppUI
{
    public partial class AddForm : Form
    {

        private Note _note;

        public Note Data
        {
            get
           
            {
                return _note;
            }
            set
            {
                _note = value;
                if (_note != null)
                {
                    DatatextBox.Text = _note.Name;
                    CategorycomboBox.SelectedItem = _note.theCategory;
                    TexttextBox.Text = _note.Text;
                    dateTimePicker1.Value = _note.Created;
                    dateTimePicker2.Value = _note.Changed;
                }
            }
        }

        public AddForm()
        {
            InitializeComponent();
            CategorycomboBox.Items.Add(TheCategory.Work);
            CategorycomboBox.Items.Add(TheCategory.Home);
            CategorycomboBox.Items.Add(TheCategory.Health);
            CategorycomboBox.Items.Add(TheCategory.People);
            CategorycomboBox.Items.Add(TheCategory.Documents);
            CategorycomboBox.Items.Add(TheCategory.Phinances);
            CategorycomboBox.Items.Add(TheCategory.Misc);
        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            

            if(_note == null)
            {
                _note = new Note(DatatextBox.Text, TexttextBox.Text, (TheCategory)CategorycomboBox.SelectedIndex, DateTime.Now, DateTime.Now );
                _note.Name = DatatextBox.Text;
                _note.Text = TexttextBox.Text;
            }
                else
            {
                _note.Text = TexttextBox.Text;
                _note.Name = DatatextBox.Text;
                _note.Changed = DateTime.Now;
            }

            this.Close();
        }

        private void DatatextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void CategorycomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CategorycomboBox.SelectedIndex == -1)
            {
                return;
            }
            TheCategory selectedCategory;
            selectedCategory = (TheCategory)CategorycomboBox.SelectedItem; 
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TexttextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
