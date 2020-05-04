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
using System.Reflection;

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
            ShowCategoryComboBox.SelectedIndex = 7;

        }
        /// <summary>
        /// Функция загрузки заметок
        /// </summary>
        private void ProjectLoad()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string file = $@"{path}\NoteApp.Notes";
            if (!File.Exists(file))
            {
                ProjectSave();
            }
            _project = ProjectManager.LoadFromFile(file);
            if(_project == null)
            {
                _project = new Project();
            }
            if (_project != null)
            {
                _project.Note1 = _project.SortedList();

                NotesListBox.Items.Clear();
                var titles = _project.SortedList(TheCategory.All);
                NotesListBox.Items.AddRange(titles.ToArray());
            }
        }
        /// <summary>
        /// Функция сохранения заметок
        /// </summary>
        private void ProjectSave()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string file = $@"{path}\NoteApp.Notes";
            ProjectManager.SaveToFile(_project, file);
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
        /// <summary>
        /// Функция добавления заметки
        /// </summary>
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
                CategorySort();
                ProjectSave();
            }
        }
        /// <summary>
        /// Функция редактирования заметки
        /// </summary>
        private void EditNote()
        {
            //Получаем текущую выбранную дату
            var selectedIndex = NotesListBox.SelectedIndex;
            if (selectedIndex == -1)
            {
                return;
            }
            var selectedData = _notes[selectedIndex];
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
                _notes.RemoveAt(selectedIndex);

                _notes.Insert(selectedIndex, updatedData);
                var time = updatedData.Changed.ToLongTimeString();
                var text = updatedData.Name;
                NotesListBox.Items.Insert(selectedIndex, text);
                CategorySort();
                ProjectSave();
            }

        }
        /// <summary>
        /// Функция удаления заметки
        /// </summary>
        private void RemoveNote()
        {
            var selectedIndex = NotesListBox.SelectedIndex;
            if (selectedIndex == -1)
            {
                return;
            }
            var select = _notes[selectedIndex];
            NotesListBox.Items.RemoveAt(selectedIndex);
            _project.Note1.Remove(select);
            CategorySort();
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
                Titlelabel.Text = _notes[selected].Name;
                Categorylabel.Text = _notes[selected].theCategory.ToString();
                NoteTextBox.Text = _notes[selected].Text;
                dateTimePicker1.Value = _notes[selected].Created;
                dateTimePicker2.Value = _notes[selected].Changed;
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
            CategorySort();
        }
        /// <summary>
        /// Функция фильтрации по категории
        /// </summary>
        public void CategorySort()
        {
            NotesListBox.Items.Clear();
            _notes.Clear();
            _notes = _project.SortedList((TheCategory)ShowCategoryComboBox.SelectedIndex);
            foreach (var note in _notes)
            {
                NotesListBox.Items.Add(note.Name);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (NotesListBox.SelectedIndex != -1)
                {
                    DialogResult result = MessageBox.Show("Удалить заметку?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    if (result == DialogResult.Yes)
                    RemoveNote();
                }
            }
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
    

