using System;

using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

using System.Windows;
using System.Windows.Controls;


namespace Calcutor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();

            Task = string.Empty;
            Result = 0;
        }

        private string _task;
        private double _result;
        private int counter = 0;
        private bool isAfterResult = false;
        private bool isFirstNumeber = true;
        public string Task 
        {
            get { return _task; }
            set
            {
                _task = value;
                OnPropertyChanged();
            }
        }

        public double Result
        {
            get { return _result; }
            set
            {
                _result = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            
            if (isFirstNumeber == false)
            { 
                
                Task += button.Content;
                counter = 1;
            }
            else
            {
                Task += button.Content;
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (ifContains() == false)
            {
                if (isFirstNumeber == false)
                {
                    

                    var button = sender as Button;
                    if (counter != 0)
                    {
                        Task += " + ";
                    }

                    counter = 0;
                }
                else
                {
                    Task += " + ";
                    isFirstNumeber = false;
                }
            }
            else
            {
                Result = Calculations();
                Task = Result.ToString() +  " + ";
                
            }
        }

        private void ButtonMinus_Click(object sender, RoutedEventArgs e)
        {
            if (ifContains() == false)
            {
                if (isFirstNumeber == false)
                {
                    

                    var button = sender as Button;
                    if (counter != 0)
                    {
                        Task += " - ";
                    }

                    counter = 0;
                }
                else
                {
                    Task += " - ";
                    isFirstNumeber = false;
                }
            }
            else
            {
                Result = Calculations();
                Task = Result.ToString() + " - ";

            }
        }

        private void ButtonMultiply_Click(object sender, RoutedEventArgs e)
        {
            if (ifContains() == false)
            {
                if (isFirstNumeber == false)
                {
                    //if (isAfterResult)
                    //{
                    //    Task = string.Empty;
                    //    isAfterResult = false;
                    //}

                    var button = sender as Button;
                    if (counter != 0)
                    {
                        Task += " * ";
                    }

                    counter = 0;
                }
                else
                {
                    Task += " * ";
                    isFirstNumeber = false;
                }
            }
            else
            {
                Result = Calculations();
                Task = Result.ToString() + " * ";

            }
        }

        private void ButtonDivide_Click(object sender, RoutedEventArgs e)
        {
            if (ifContains() == false)
            {
                if (isFirstNumeber == false)
                {

                    var button = sender as Button;
                    if (counter != 0)
                    {
                        Task += " / ";
                    }

                    counter = 0;
                }
                else
                {
                    Task += " / ";
                    isFirstNumeber = false;
                }
            }
            else
            {
                Result = Calculations();
                Task = Result.ToString() + " / ";

            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (isAfterResult)
            {
                Task = string.Empty;
                isAfterResult = false;
            }

            var button = sender as Button;
            if (Task != string.Empty)
            {

                if (Task.Last() == ' ')
                {
                    Task = Task.Remove(Task.LastIndexOf(Task.Last()) - 2);
                }
                else
                    Task = Task.Remove(Task.LastIndexOf(Task.Last()));
            }
            else counter = 0;
        }

        private void ButtonResult_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            Result = Calculations();
            Task = Result.ToString();
            isAfterResult = true;

        }

        private double Calculations()
        {
            if (Task.Contains('+'))
            {
                var elements = Task.Split('+');

                return Convert.ToDouble(elements[0]) + Convert.ToDouble(elements[1]);
            }
            else if (Task.Contains('-'))
            {
                var elements = Task.Split('-');

                return Convert.ToDouble(elements[0]) - Convert.ToDouble(elements[1]);
            }
            else if (Task.Contains('*'))
            {
                var elements = Task.Split('*');

                return Convert.ToDouble(elements[0]) * Convert.ToDouble(elements[1]);
            }
            else if (Task.Contains('/'))
            {
                var elements = Task.Split('/');

                return Convert.ToDouble(elements[0]) / Convert.ToDouble(elements[1]);
            }
            else return default;
        }

        private bool ifContains()
        {
            if (Task.Contains('+') || Task.Contains('-') || Task.Contains('*') || Task.Contains('/'))
            {
                return true;
            }
            else return false;
         
        }

    }
}
