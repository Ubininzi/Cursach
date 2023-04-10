using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace cursach
{
	public partial class TestWindow : Window
	{
		private Dictionary<string,string> answers = new();
		private Dictionary<string, string> RightAnswers = new();
		private Dictionary<int, int> marks;


		public TestWindow(Test testObj)
		{
			InitializeComponent();
			TestName.Text = testObj.testName;
			TimeBlock.Text = testObj.time;
			marks = testObj.marks;
			QuestionsPanel.Children.Add(CreateVisualOfQuestions(testObj));

			
			//DispatcherTimer TestTimer = new DispatcherTimer();
			//TestTimer.Tick += new EventHandler(TestTimer_Tick);
			//TestTimer.Interval = new TimeSpan(0, 0, 1);
			//TestTimer.Start();
		}
		//private void TestTimer_Tick(object sender, EventArgs e)
		//{
		//	// Updating the Label which displays the current second
		//	//TimeBlock.Text

		//	// Forcing the CommandManager to raise the RequerySuggested event
		//	CommandManager.InvalidateRequerySuggested();
		//}

		private StackPanel CreateVisualOfQuestions(Test test)					
		{
			StackPanel questionsPanel = new();
			foreach (Question question in test.questions)
			{
				QuestionVisual que = new();
				que.QuestionName.Text = question.questionName; 
				foreach (string option in question.options)
				{
					RadioButton answer = new()
					{
						GroupName = question.questionName,
						Content = option,
						Margin = new Thickness(5),
					};
					answer.Checked += Answer_Checked;
					que.OptionsPanel.Children.Add(answer);
				}
				questionsPanel.Children.Add(que);

				RightAnswers.Add(question.questionName, question.rightAnswers[0]);

			}
			return questionsPanel;
		}
		private int AcceptAnswers() {
			int points = 0;
			foreach (string Answer in answers.Keys)
			{
				if (answers[Answer] == RightAnswers[Answer]) {
					points++;
				}
			}
			foreach (int mark in marks.Keys)
			{
				if (points >= marks[mark])
				{
					MessageBox.Show(mark.ToString(),"Ваша оценка");		//ДОБАВИТЬ ЗАКРЫТИЕ ОКНА ПОСЛЕ ЗАКРЫТИЯ МЕСЕДЖБОКСА
					return mark;
				}
			}
			MessageBox.Show("2","Ваша оценка");
			return 2;
		}
		private void Answer_Checked(object sender, RoutedEventArgs e)				
		{
			answers.Remove(((RadioButton)sender).GroupName);
			answers.Add(((RadioButton)sender).GroupName,((RadioButton)sender).Content.ToString());
		}
		private void Confirm_Click(object sender, RoutedEventArgs e)
		{
			TestClass.CreateNewRecordOfCompletedTest(Surname.Text,Name.Text,GroupName.Text, TestName.Text, AcceptAnswers());
		}
	}
}
