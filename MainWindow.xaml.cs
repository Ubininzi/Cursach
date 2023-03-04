using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using workWithFiles;

namespace cursach
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            Test testobj = new Test("тестовый", new List<Question>() {
            new Question("2 + 2 = ?",new List<string>{"3","4","5"},new List<string>{"4"}),
            new Question("5 x 3 = ?",new List<string>{"12","13","15"},new List<string>{"15"}),
            new Question("10 - 6 = ?",new List<string>{"2","3","4"},new List<string>{"4"}),
            new Question("20 / 4 = ?",new List<string>{"4","5","6"},new List<string>{"5"}),
            new Question("12 + 8 x 2 = ?",new List<string>{"28","32","40"},new List<string>{"28"})
            });
            WorkWithFiles.createJsonFromTestClass(testobj);
        }
    }
}
