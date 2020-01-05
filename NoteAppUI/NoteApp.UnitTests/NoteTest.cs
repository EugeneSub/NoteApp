using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace NoteApp.UnitTests
{
    [TestFixture]
    public class NoteTest
    {
        [Test(Description = "Позитивный тест геттера Name")]
        public void NoteNameGet_CorrectValue()
        {
            var expected = "Заголовок";
            var note = new Note("", "", TheCategory.Documents, DateTime.Now, DateTime.Now);
            note.Name = expected;
            var actual = note.Name;
            Assert.AreEqual(expected, actual, "Геттер Name возвращает неправильный заголовок");
        }

        [Test(Description = "Позитивный тест сеттера Name")]
        public void NoteNameSet_CorrectValue()
        {
            var expected = "Заголовок_книжки";
            var note = new Note("Заголовок_книжки", "", TheCategory.Documents, DateTime.Now, DateTime.Now);
            note.Name = expected;
            Assert.AreEqual(expected, note.Name, "Сеттер Name устанавливает неправильное значение");
        }

        [Test(Description = "Негативный тест сеттера Name, присваивение более 50 значений")]
        public void NoteNameSet_InCorrectValue()
        {
            var wrongName = "000000000000000000000000000000000000000000000000000";
            var note = new Note("", "", TheCategory.Documents, DateTime.Now, DateTime.Now);
            Assert.Throws<ArgumentException>(() => { note.Name = wrongName; }, "-");
        }

        [Test(Description = "Позитивный тест сеттера Text")]
        public void TitleTextSet_CorrectValue()
        {
            var expected = "Заголовок_книжки";
            var note = new Note("Заголовок_книжки", "Текст", TheCategory.Documents, DateTime.Now, DateTime.Now);
            note.Text = expected;
            Assert.AreEqual(expected, note.Text, "Сеттер Text устанавливает неправильное значение");
        }

        [Test(Description = "Позитивный тест сеттера Category")]
        public void NoteCategorySet_CorrectValue()
        {
            var expected = TheCategory.Misc;
            var note = new Note("Заголовок_книжки", "Текст", TheCategory.Documents, DateTime.Now, DateTime.Now);
            note.theCategory = TheCategory.Work;
            note.theCategory = expected;
            Assert.AreEqual(expected, note.theCategory, "Сеттер TheCategory устанавливает неправильное значение");
        }


    }
}
