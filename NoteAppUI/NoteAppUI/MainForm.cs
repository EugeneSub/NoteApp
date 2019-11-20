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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            var note = new Note("sdfsdf", "sdfsdf", TheCategory.Documents, DateTime.Now, DateTime.Now);
            textBox1.Text = note.Text;
        }
    }
}
