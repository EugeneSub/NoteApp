using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO;
using System.Reflection;
using NoteApp;


namespace NoteApp.UnitTests
{
    [TestFixture]
    class ProjectManagerTest
    {
        private Project _testproject1 = new Project();
        private Project _testproject2 = new Project();

        [Test(Description = "Тест сериализации")]
        public void SaveToFile()
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string testFilePath = $@"{path}\test.json";
            string expected = File.ReadAllText(testFilePath);
            Note note1 = new Note("Name", "Text", TheCategory.Misc, new DateTime(2020, 01, 05).Date, new DateTime(2020, 01, 05).Date);
            Note note2 = new Note("Name2", "Text2", TheCategory.Home, new DateTime(2020, 01, 05).Date, new DateTime(2020, 01, 05).Date);
            Note note3 = new Note("Name3", "Text3", TheCategory.Work, new DateTime(2020, 01, 05).Date, new DateTime(2020, 01, 05).Date);
            string filename = $@"{path}\test1.json";
            _testproject1.Note1.Add(note1);
            _testproject1.Note1.Add(note2);
            _testproject1.Note1.Add(note3);
            ProjectManager.SaveToFile(_testproject1, filename);
            string actual = File.ReadAllText(filename);
            Assert.AreEqual(expected, actual, "Файлы в сериализации различаются");
        }

        [Test(Description = "Тест десериализации")]
        public Note LoadFromFile()
        {
            Note note1 = new Note("Name", "Text", TheCategory.Misc, new DateTime(2020, 01, 05).Date, new DateTime(2020, 01, 05).Date);
            Note note2 = new Note("Name2", "Text2", TheCategory.Home, new DateTime(2020, 01, 05).Date, new DateTime(2020, 01, 05).Date);
            Note note3 = new Note("Name3", "Text3", TheCategory.Work, new DateTime(2020, 01, 05).Date, new DateTime(2020, 01, 05).Date);
            _testproject1.Note1.Add(note1);
            _testproject1.Note1.Add(note2);
            _testproject1.Note1.Add(note3);
            Project expected = _testproject2;
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string testFilePath = $@"{path}\test.json";
            Project preactual = ProjectManager.LoadFromFile(testFilePath);
            Project actual = preactual;
            int i = 0;
            foreach (var Note in _testproject2.Note1)
            {
                Assert.AreEqual(expected.Note1[i].Name, actual.Note1[i].Name, "Значения в десериализации различаются");
                Assert.AreEqual(expected.Note1[i].Text, actual.Note1[i].Text, "Значения в десериализации различаются");
                Assert.AreEqual(expected.Note1[i].theCategory, actual.Note1[i].theCategory, "Значения в десериализации различаются");
                Assert.AreEqual(expected.Note1[i].Created, actual.Note1[i].Created, "Значения в десериализации различаются");
                Assert.AreEqual(expected.Note1[i].Changed, actual.Note1[i].Changed, "Значения в десериализации различаются");
                i++;
            }
        }
    }
}
