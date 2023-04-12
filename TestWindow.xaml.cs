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

		private bool CanAcceptAnswers = true;

        DispatcherTimer TestTimer = new DispatcherTimer();
        private DateTime StartTime; 
		private TimeSpan TimeToEnd;

		public TestWindow(Test testObj)
		{
			InitializeComponent();
			TestName.Text = testObj.testName;
			TimeBlock.Text = testObj.time;
			marks = testObj.marks;
			QuestionsPanel.Children.Add(CreateVisualOfQuestions(testObj));
			string[] splittedTime = testObj.time.Split(':');
			TimeSpan TestTime = new(Convert.ToInt32(splittedTime[0]), Convert.ToInt32(splittedTime[1]), Convert.ToInt32(splittedTime[2]));
			StartTime = DateTime.Now;

			TestTimer.Interval = TimeSpan.FromMilliseconds(5);
			TestTimer.Start();
			TestTimer.Tick += delegate
			{
				TimeToEnd = TestTime.Subtract(DateTime.Now.Subtract(StartTime));
				TimeBlock.Text = TimeToEnd.Hours.ToString()+":"+ TimeToEnd.Minutes.ToString()+":"+ TimeToEnd.Seconds.ToString();
				if (TimeToEnd.TotalMilliseconds <= 30) {
                    TestTimer.Stop();
                    MessageBox.Show("Пожалуйста введите фамилию, имя, группу и подтвердите завершение теста, введенные ответы более не учитываются","Время вышло!",MessageBoxButton.OK,MessageBoxImage.Warning);
					CanAcceptAnswers = false;
				}
			};
		}

        private void TestWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TestTimer.Stop();
        }

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
				RightAnswers.Add(question.questionName, question.rightAnswer);
			}
			return questionsPanel;
		}

		private void AcceptAnswers() {
			this.Close();
			TestClass.CreateNewRecordOfCompletedTest(Surname.Text, Name.Text, GroupName.Text, TestName.Text, Rating());
		}

		private int Rating() {
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
					return mark;
				}
			}
			return 2;
		}
		private void Answer_Checked(object sender, RoutedEventArgs e)				
		{
			if (CanAcceptAnswers)
			{
				answers.Remove(((RadioButton)sender).GroupName);
				answers.Add(((RadioButton)sender).GroupName,((RadioButton)sender).Content.ToString());
			}
		}
		private void Confirm_Click(object sender, RoutedEventArgs e)
		{
			AcceptAnswers();
		}
    }
}
