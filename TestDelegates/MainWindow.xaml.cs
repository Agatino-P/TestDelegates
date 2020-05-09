using System;
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
        readonly Action<double> doubleDelegate;
        readonly  Func<double,double> twicePlease;

        public MainWindow()
        {
            InitializeComponent();

            testDelegate = new TestDelegate(OnTestDelegate1);
            testDelegate += OnTestDelegate2;

            doubleDelegate= OnDoubleDelegate;
            twicePlease = OnTwicePlease;

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

        private void OnDoubleDelegate(double numero)
        {
            if (numero!=0)
            {
                MessageBox.Show((numero/7).ToString(),"divided by 7");
            }
            else
            {
                MessageBox.Show("Zero/ -> infinito");
            }
        }

       private double OnTwicePlease(double val)
        {
            return val * 2;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            testDelegate(txt.Text);
            if (double.TryParse(txt.Text, out double quanto))
            {
                doubleDelegate(quanto);
                
                
                MessageBox.Show(twicePlease(quanto).ToString(), "TwicePlaseReturned");
            }

        }


    }
}
