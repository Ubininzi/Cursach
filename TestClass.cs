using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using Newtonsoft.Json;


namespace cursach
{
	public struct Test
	{
		public string testName;
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
        internal static List<Test> CreateListOfTestsFromLocalDirectory()
		{
            Directory.CreateDirectory(path);
			if (Directory.GetFiles(path).Length != 0) {
				string[] ListOfPathToTests = Directory.GetFiles(path,"*.json");
				List<Test> listOfTests = new List<Test>();
				if (ListOfPathToTests != null)
				{
					foreach (string testFilePath in ListOfPathToTests)
					{
						string jsonText = File.ReadAllText(testFilePath);
						listOfTests.Add(JsonConvert.DeserializeObject<Test>(jsonText));
					}
				}
				return listOfTests;
			}
            return new List<Test>();
        }
		internal static void CreateNewRecordOfCompletedTest(string surname, string name, string group, string testName, int mark)
		{
            if (!File.Exists(path + "/Results.csv"))
				File.AppendAllText((path + "/Results.csv"), "Фамилия,Имя,Группа");

			List<string> results = File.ReadAllLines(path + "/Results.csv", System.Text.Encoding.UTF8).ToList();
			if (!results[0].Contains(testName))
			{
				results[0] += "," + testName;
			}
			int IndexOfTest = Array.IndexOf(results[0].Split(','), testName);

			bool IsRecordExists = false;
			for (int i = 0; i < results.Count; i++)
			{
				List<string> SplittedRecord = results[i].Split(',').ToList();
				if (SplittedRecord[0] == surname && SplittedRecord[1] == name && SplittedRecord[2] == group)
				{
					for (int j = 3; j < IndexOfTest; j++)
					{
						if (SplittedRecord[j] == null)
							SplittedRecord.Add(" ");
					}
					SplittedRecord.Add(mark.ToString());
					results[i] = String.Join(',', SplittedRecord);
					IsRecordExists = true;
				}
			}

			if (!IsRecordExists)
			{
				results.Add(surname + ',' + name + ',' + group + ',' + (new string(',', IndexOfTest - 3)) + mark.ToString());
			}

			File.WriteAllLines(path + "/Results.csv", results, System.Text.Encoding.UTF8);
			MessageBoxResult messageBoxResult = new();
			MessageBox.Show(mark.ToString(), "Ваша оценка", MessageBoxButton.OK, MessageBoxImage.Information, messageBoxResult);
        }
    }
}
