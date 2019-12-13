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
        private List<Note> _notes = new List<Note>();




        public MainForm()
        {
            InitializeComponent();
            this.Text = "Главное окно программы";
            this.Size = new Size(800, 450);
            ColorComboBox.Items.Add(Color.LightSalmon);
            ColorComboBox.Items.Add(Color.Green);
            ColorComboBox.Items.Add(Color.AliceBlue);
            ColorComboBox.Items.Add(Color.White);
            //Задать синий цвет по умолчанию 
            //ColorComboBox.SelectedIndex = 2;

            //Создаем кнопку             
            var button = new Button();
            button.Text = "Сменить заголовок окна";
            button.Size = new Size(150, 25);
            button.Location = new Point(150, 150);

            //Подписываем кнопку на обработчик             
            button.Click += Button_Click;

            //Помещаем кнопку на форму             
            this.Controls.Add(button);


            
        }


        //Обработчик события нажатия кнопки         
        private void Button_Click(object sender, EventArgs e)
        {
            //Здесь пишем код, который должен выполняться             
            // каждый раз при нажатии на кнопку.             
            this.Text = "Новый заголовок";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void NumberTextBox_TextChanged(object sender, EventArgs e)
        {
            string text = NumberTextBox.Text;
            int number;
            if (int.TryParse(text, out number))
            {
                if (number >= 0 && number <= 100)
                {
                    NumberTextBox.BackColor = Color.AliceBlue;
                    this.Text = number.ToString();
                }
                else
                {
                    NumberTextBox.BackColor = Color.LightSalmon;
                    this.Text = "Число не входит в диапазон";
                }
            }
            else
            {
                NumberTextBox.BackColor = Color.LightSalmon;
                this.Text = "Не число";
            }
        }

        private void ColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ColorComboBox.SelectedIndex == -1)
            {
                // Если ничего не выбрано, завершаем обработчик         
                return;
            }
            Color selectedColor;
            selectedColor = (Color)ColorComboBox.SelectedItem;
            this.BackColor = selectedColor;
        }

        private void VisibilityCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = VisibilityCheckBox.Checked;
            ColorComboBox.Visible = isChecked;
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // _contacts.Add(newContact);
           // ContactsListBox.Items.Add(newContact.Name);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Получаем текущую выбранную дату         
            var selectedIndex = NotesListBox.SelectedIndex;
            var selectedData = _notes[selectedIndex]; 
            var inner = new AddForm(); //Создаем форму       
            
            inner.Data = selectedData;  //Передаем форме данные     
            inner.ShowDialog(); //Отображаем форму для редактирования   
            var updatedData = inner.Data; //Забираем измененные данные 


            //Осталось удалить старые данные по выбранному индексу         
            // и заменить их на обновленные         
            NotesListBox.Items.RemoveAt(selectedIndex);
            _notes.RemoveAt(selectedIndex); 

            _notes.Insert(selectedIndex, updatedData);
            var time = updatedData.Changed.ToLongTimeString();
            var text = updatedData.Text;
            NotesListBox.Items.Insert(selectedIndex, time + " " + text);
        }
    }
}
