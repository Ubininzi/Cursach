using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Controls;
using Newtonsoft.Json;


namespace workWithTestAndFiles
{
    struct Test
    {
        public string testName;
        public List<Question> questions;
    }
    struct Question
    {
        public string questionName;
        public List<string> options;
        public List<string> rightAnswers;
    }
    class WorkWithTestAndFiles
    {
        private static List<Test> createListOfTestsFromLocalDirectory()
        {
            string[] allTestFiles = Directory.GetFiles("C:\\Users\\Максим\\AppData\\Local\\Ubininzi", "*.json");
            List<Test> listOfTests = new List<Test>();
            if (allTestFiles != null) {
                foreach (string testFilePath in allTestFiles)
                {
                    string jsonText = File.ReadAllText(testFilePath);
                    listOfTests.Add(JsonConvert.DeserializeObject<Test>(jsonText));
                }
            }
            return listOfTests;
        }
        public static StackPanel createVisualPresentationOfTests()
        {
            List<Test> listOfTests = createListOfTestsFromLocalDirectory();
            StackPanel testPanel = new StackPanel();
            foreach(Test test in listOfTests)
            {
                StackPanel questionsPanel = new StackPanel(); 
                TextBlock testName = new TextBlock();
                testName.FontSize = 25;
                testName.Text = test.testName;
                foreach(Question question in test.questions)
                {
                    TextBlock questionName = new TextBlock();
                    questionName.Text = question.questionName;
                    questionName.FontSize = 15;
                    questionsPanel.Children.Add(questionName);

                    StackPanel optionsPanel = new StackPanel();
                    optionsPanel.Orientation = Orientation.Horizontal;
                    foreach(string option in question.options)
                    {
                        RadioButton answer = new RadioButton();
                        answer.Content = option;
                        answer.Margin = new System.Windows.Thickness(5);
                        optionsPanel.Children.Add(answer);
                    }
                    optionsPanel.Margin = new System.Windows.Thickness(10);
                    questionsPanel.Children.Add(optionsPanel);
                }
                testPanel.Children.Add(testName);
                testPanel.Children.Add(questionsPanel);
            }
            return testPanel;
        }
    }
}
