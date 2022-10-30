using System.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Lib_8;
using LibArray;

namespace Практическая_2_Косичкин
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

        Array<int> list = new Array<int>(0);
             
        private void Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Clear_TB(object sender, RoutedEventArgs e)
        {
            Razmer_Box.Clear();
            add_elements_Box.Clear();
            Removing.Clear();
        }

        private void Information(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(" Вычислить косинус (cos) суммы чисел < 3. \r\n Результат вывести на экран \r\n \r\n Разработчик: Косичкин Илья \r\n ИСП - 34");
        }

        private void Fill(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(Razmer_Box.Text, out int count))
            {
                MessageBox.Show("Введите значение");
                Razmer_Box.Clear();
                return;
            }
            list = new Array<int>(count);
            list.Fill();
            DataGrid.ItemsSource = list.ToDataTable().DefaultView;

        }
        private void Difference(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(add_elements_Box.Text, out int count))
            {
                MessageBox.Show("Введите значение");
                add_elements_Box.Clear();
                return;
            }
            list = new Array<int>(count);
            list.Difference();
            DataGrid.ItemsSource = list.ToDataTable().DefaultView;
        }

        private void Add_An_Element(object sender, RoutedEventArgs e)
        {
            if (list.Capacity != 0)
            {
                string[] massiveString = add_elements_Box.Text.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                int[] numbers = new int[massiveString.Length];

                for (int i = 0; i < massiveString.Length; i++)
                {
                    int.TryParse(massiveString[i], out int value);
                    numbers[i] = value;
                }

                list.AddRange(numbers);
                DataGrid.ItemsSource = list.ToDataTable().DefaultView;
            }
            else
            {
                MessageBox.Show("Массив не создан, создайте его!");
            }
        }

        private void Delete_Element(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(Removing.Text, out int item))
            {
                if (list.Remove(item))
                {
                    DataGrid.ItemsSource = list.ToDataTable().DefaultView;
                }
                else MessageBox.Show("Такого элемента нет");
            }
            else MessageBox.Show("Некорректные значения");
        }
    }  
}
