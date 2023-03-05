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
    class Test
    {
        public string nameOfTest;
        public List<Question> questions;
        public Test(string name, List<Question> questions)
        {
            this.nameOfTest = name;
            this.questions = questions;
        }
    }
    class Question
    {
        public string questionName;
        public List<string> options;
        public List<string> rightAnswers;
        public Question(string questionName, List<string> answers, List<string> rightAnswers)
        {
            this.questionName = questionName;
            this.options = answers;
            this.rightAnswers = rightAnswers;
        }
    }
    class WorkWithTestAndFiles
    {
        //public static void createJsonFromTestClass(Test testObj)
        //{
        //    string json = JsonConvert.SerializeObject(testObj);
        //    if (!File.Exists("D:\\amalgama.json"))
        //        File.Create("D:\\amalgama.json");
        //    File.WriteAllText("D:\\amalgama.json", json);
        //}
        public static Test createTestClassFromJson(string path)
        {
            string json = File.ReadAllText(path);
            Test testobj = JsonConvert.DeserializeObject<Test>(json);
            return testobj;
        }
        public static TreeView convertTestClassToTreeView(Test testClassObj)
        {
            TreeView treeViewObj = new TreeView();
            TreeViewItem testTreeViewItem = new TreeViewItem();
            testTreeViewItem.Header = testClassObj.nameOfTest;
            foreach(Question que in testClassObj.questions)
            {
                TreeViewItem optionsTreeView = new TreeViewItem();
                optionsTreeView.Header = "Варианты";
                foreach(string option in que.options)
                {
                    optionsTreeView.Items.Add(option);
                }

                TreeViewItem rightAnswersTreeView = new TreeViewItem();
                rightAnswersTreeView.Header = "Правильные варианты";
                foreach (string rightAnswer in que.rightAnswers)
                {
                    rightAnswersTreeView.Items.Add(rightAnswer);
                }

                TreeViewItem questionTreeViewItem = new TreeViewItem();
                questionTreeViewItem.Header = que.questionName;
                questionTreeViewItem.Items.Add(optionsTreeView);
                questionTreeViewItem.Items.Add(rightAnswersTreeView);

                testTreeViewItem.Items.Add(questionTreeViewItem);
            }

            treeViewObj.Items.Add(testTreeViewItem);
            treeViewObj.Height = 300;
            treeViewObj.Width = 200;
            return treeViewObj;
        }


    }
}
