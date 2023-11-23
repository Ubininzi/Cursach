using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace cursach
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            StackPanel1.Children.Add(CreateVisualOfTests());
        }
        private StackPanel CreateVisualOfTests()
        {
            List<TestStruct> listOfTests = TestClass.CreateListOfTestsFromLocalDirectory();
            StackPanel testsPanel = new StackPanel();

            foreach (TestStruct test in listOfTests)
            {
                TestClassVisual TestObj = new TestClassVisual();
                TestObj.TestName.Text = test.TestName;
                TestObj.BeginButton.Tag = test;
                testsPanel.Children.Add(TestObj);
            }
            return testsPanel;
        }
    }
}
