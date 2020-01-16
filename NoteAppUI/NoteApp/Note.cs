using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp
{
    /// <summary>
    /// Класс записной книжки, содержащий поля для записей.
    /// </summary>
    public class Note
    {
        /// <summary>
        /// Класс, содержащий заголовок записной книжки.
        /// </summary>
        private string _name;
        /// <summary>
        /// Класс, содержащий категорию записной книжки.
        /// </summary>
        private TheCategory _theCategory;
        /// <summary>
        /// Класс, содержащий текст записной книжки.
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Класс, содержащий дату создания записной книжки.
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// Класс, содержащий дату изменения записной книжки.
        /// </summary>
        public DateTime Changed { get; set; }

        public Note()
        {
            
        }

        /// <summary>
        /// Конструктор класса Note.
        /// </summary>
        /// <param name="name"> Заголовок </param>
        /// <param name="text"> Текст заметки </param>
        /// <param name="thecategory"> Категория заметки </param>
        /// <param name="created"> Дата создания заметки </param>
        /// <param name="changed"> Дата изменения заметки </param>
        public Note(string name, string text, TheCategory thecategory, DateTime created, DateTime changed)
        {
            Name = name;
            Text = text;
            _theCategory = thecategory;
            Created = created;
            Changed = changed;
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value.Length < 50)
                    _name = value;
                else
                    throw new ArgumentException();
            }
        }
        public TheCategory theCategory
        { 
            get
            {
                return _theCategory;
            }
            set
            {
                _theCategory = value; 
            }
         }   

            
    

    }

    


}
