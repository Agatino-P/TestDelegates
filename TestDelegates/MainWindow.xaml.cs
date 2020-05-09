using System.Windows;

namespace TestDelegates
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public delegate void TestDelegate(string testo);

    public partial class MainWindow : Window
    {
        private TestDelegate testDelegate;

        public MainWindow()
        {
            InitializeComponent();

            testDelegate = new TestDelegate(OnTestDelegate1);
            testDelegate += OnTestDelegate2;
        }

        private void OnTestDelegate1(string messaggio)
        {
            MessageBox.Show(messaggio);
        }

        private void OnTestDelegate2(string messaggio)
        {
            if (int.TryParse(messaggio, out int quanto))
            {
                MessageBox.Show((quanto + 1).ToString());
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            testDelegate(txt.Text);
        }


    }
}
