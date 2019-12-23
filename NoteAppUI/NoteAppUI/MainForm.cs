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
        private Project _project = new Project();
            
        private List<Note> _notes = new List<Note>();




        public MainForm()
        {
            InitializeComponent();
            this.Text = "Главное окно программы";
            this.Size = new Size(800, 450);
            
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddNote();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            RemoveNote();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {

            EditNote(); 
        }

        private void addNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNote();
        }

        private void AddNote()
        {
            AddForm Add = new AddForm();
            Add.ShowDialog();
            var updatedData = Add.Data;
            _project.Note1.Add(updatedData);
            //var time = updatedData.Changed.ToLongTimeString();
            var text = updatedData.Name;
            NotesListBox.Items.Add(text);
        }

        private void EditNote()
        {
            //Получаем текущую выбранную дату         
            var selectedIndex = NotesListBox.SelectedIndex;
            if (selectedIndex == -1)
            {
                return;
            }
            var selectedData = _project.Note1[selectedIndex];
            var inner = new AddForm(); //Создаем форму       

            inner.Data = selectedData;  //Передаем форме данные     
            inner.ShowDialog(); //Отображаем форму для редактирования   
            var updatedData = inner.Data; //Забираем измененные данные 



            //Осталось удалить старые данные по выбранному индексу         
            // и заменить их на обновленные         
            NotesListBox.Items.RemoveAt(selectedIndex);
            _project.Note1.RemoveAt(selectedIndex);

            _project.Note1.Insert(selectedIndex, updatedData);
            //var time = updatedData.Changed.ToLongTimeString();
            var text = updatedData.Name;
            NotesListBox.Items.Insert(selectedIndex, text);
        }

        private void RemoveNote()
        {
            var selectedIndex = NotesListBox.SelectedIndex;
            if (selectedIndex == -1)
            {
                return;
            }
            NotesListBox.Items.RemoveAt(selectedIndex);
            _project.Note1.RemoveAt(selectedIndex);
        }

        private void abotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout Help = new FormAbout();
            Help.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

 

        private void NotesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NotesListBox.SelectedIndex != -1)
            {
                int selected = (NotesListBox.SelectedIndex);
                Titlelabel.Text = _project.Note1[selected].Name;
                Categorylabel.Text = _project.Note1[selected].theCategory.ToString();
                NoteTextBox.Text = _project.Note1[selected].Text;
                dateTimePicker1.Value = _project.Note1[selected].Created;
                dateTimePicker2.Value = _project.Note1[selected].Changed;
            }
        }

        private void NoteTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Titlelabel_Click(object sender, EventArgs e)
        {

        }

        private void Categorylabel_Click(object sender, EventArgs e)
        {

        }

        private void editNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditNote();
        }

        private void removeNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveNote();
        }
    }
}
