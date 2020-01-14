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
using System.IO;


namespace NoteAppUI
{
    public partial class MainForm : Form
    {
        private Project _project = new Project();

        private List<Note> _notes = new List<Note>();




        public MainForm()
        {
            InitializeComponent();
            ProjectLoad();
            ShowCategoryComboBox.Items.Add(TheCategory.Work);
            ShowCategoryComboBox.Items.Add(TheCategory.Home);
            ShowCategoryComboBox.Items.Add(TheCategory.Health);
            ShowCategoryComboBox.Items.Add(TheCategory.People);
            ShowCategoryComboBox.Items.Add(TheCategory.Documents);
            ShowCategoryComboBox.Items.Add(TheCategory.Phinances);
            ShowCategoryComboBox.Items.Add(TheCategory.Misc);
            ShowCategoryComboBox.Items.Add(TheCategory.All);
            this.Text = "Главное окно программы";
            this.Size = new Size(800, 450);

        }

        private void ProjectLoad()
        {
            _project = ProjectManager.LoadFromFile(@"NoteApp.Notes");
            if(_project == null)
            {
                _project = new Project();
            }
            var fileInf = new FileInfo(@"NoteApp.Notes");
            if (!fileInf.Exists)
                fileInf.Create().Close();
            if (_project != null)
            {
                _project.Note1 = _project.SortedList();

                NotesListBox.Items.Clear();
                var titles = _project.SortedList(TheCategory.All);
                NotesListBox.Items.AddRange(titles.ToArray());
            }
        }

        private void ProjectSave()
        {
            ProjectManager.SaveToFile(_project, @"NoteApp.Notes");
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
            var Result = Add.ShowDialog();
            if (Result == DialogResult.OK)
            {
                var updatedData = Add.Data;
                _project.Note1.Add(updatedData);
                var time = updatedData.Changed.ToLongTimeString();
                var title = updatedData.Name;
                NotesListBox.Items.Add(title);
                ProjectSave();
            }
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
            //inner.ShowDialog(); //Отображаем форму для редактирования  
            var Res = inner.ShowDialog();
            if (Res == DialogResult.OK)
            {
                var updatedData = inner.Data; //Забираем измененные данные 

                //Осталось удалить старые данные по выбранному индексу
                //и заменить их на обновленные
                NotesListBox.Items.RemoveAt(selectedIndex);
                _project.Note1.RemoveAt(selectedIndex);

                _project.Note1.Insert(selectedIndex, updatedData);
                var time = updatedData.Changed.ToLongTimeString();
                var text = updatedData.Name;
                NotesListBox.Items.Insert(selectedIndex, text);
                ProjectSave();
            }

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
            ProjectSave();
        }

        private void abotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout Help = new FormAbout();
            Help.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            ProjectSave();
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

        private void ShowCategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            NotesListBox.Items.Clear();
            var titles = _project.SortedList((TheCategory)ShowCategoryComboBox.SelectedItem);
            NotesListBox.Items.AddRange(titles.ToArray());

        }
    }
}
