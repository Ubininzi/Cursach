using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using Newtonsoft.Json;


namespace cursach
{
	public struct TestStruct
	{
		public string TestName;
		public string time;
		public Dictionary<int, int> marks;
		public List<Question> questions;
	}
	public struct Question
	{
		public string questionName;
		public List<string> options;
		public string rightAnswer;
	}
	class TestClass
	{
		static string path = "C:/ProgramFiles/Ubininzi";
		internal static List<TestStruct> CreateListOfTestsFromLocalDirectory()
		{
			Directory.CreateDirectory(path);
			if (Directory.GetFiles(path).Length != 0) {
				string[] ListOfPathToTests = Directory.GetFiles(path,"*.json");
				List<TestStruct> listOfTests = new List<TestStruct>();
				if (ListOfPathToTests != null)
				{
					foreach (string testFilePath in ListOfPathToTests)
					{
						string jsonText = File.ReadAllText(testFilePath);
						listOfTests.Add(JsonConvert.DeserializeObject<TestStruct>(jsonText));
					}
				}
				return listOfTests;
			}
			return new List<TestStruct>();
		}
		internal static void CreateNewRecordOfCompletedTest(string surname, string name, string group, string testName, int mark)
		{
			TestsDbContext db = new TestsDbContext();
			Student ThisStudent = db.Students.First(x => x.Name == name && x.Surname == surname && x.Group == group);//проверки на существование студента и теста
			Test ThisTest = db.Tests.First(x => x.Name == testName);
            Testresult testresult = new Testresult() {StudentId = ThisStudent.Id,TestId = ThisTest.Id,Mark = mark };
			db.Testresults.Add(testresult);
			MessageBoxResult messageBoxResult = new();
			MessageBox.Show(mark.ToString(), "Ваша оценка", MessageBoxButton.OK, MessageBoxImage.Information, messageBoxResult);
			db.SaveChanges();
		}
	}
}
