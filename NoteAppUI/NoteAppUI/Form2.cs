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
                    DatatextBox.Text = _note.Text;
                }
            }
        }

        public AddForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            if(_note == null)
            {
                int value = TheCategory;
                Note note = new Note(DatatextBox.Text , TexttextBox.Text, CategorycomboBox.SelectedIndex, DateTime.Now, DateTime.Now );
            }
                else
            {
                _note.Text = "Text is updated";

                _note.Text = DatatextBox.Text;
                _note.Changed = DateTime.Now;
            }

            this.Close();
        }

        private void DatatextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void CategorycomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TexttextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
