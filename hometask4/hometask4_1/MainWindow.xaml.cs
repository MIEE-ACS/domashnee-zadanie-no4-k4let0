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

namespace hometask4_1
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

        private void BtStart_Click(object sender, RoutedEventArgs e)
        {
            int n;
            double c;
            if (int.TryParse(tbArraySize.Text, out n) && n > 0)
            { 
                if (double.TryParse(tbConstant.Text, out c))
                {
                    // генерация массива
                    Random rand = new Random();
                    double[] arr = new double[n];
                    for (int i = 0; i < n; ++i) arr[i] = Math.Round((rand.NextDouble() - 0.5) * 200, 2); // числа от -100 до 100,  2 знака после запятой
                    tbArray0.Text = string.Join(" ", arr); 

                    // количество элементов больших C
                    int k = 0;
                    foreach (double x in arr) if (x > c) ++k;
                    tbAns1.Text = k.ToString();

                    // поиск максимального по модулю элемента
                    int max = 0; 
                    for (int i = 0; i < n; ++i) if (Math.Abs(arr[i]) > arr[max]) max = i;
                    // произведение последующих членов
                    double p = max == n - 1 ? 0 : 1; // если последний элемент наибольший, то произведение последующих 0 членов есть 0
                    for (int i = max + 1; i < n; ++i) p *= arr[i];
                    tbAns2.Text = p.ToString();

                    // преобразование массива
                    double[] temp = new double[n];
                    int j = 0;
                    foreach (double x in arr) if (x < 0) 
                        {
                            temp[j] = x;
                            ++j;
                        }
                    foreach (double x in arr) if (x >= 0)
                        {
                            temp[j] = x;
                            ++j;
                        }
                    arr = temp;
                    tbArray1.Text = string.Join(" ", arr);

                }
                else MessageBox.Show("Константа должна быть действительным числом");
            }
            else MessageBox.Show("Длина массива должна быть целым положительным числом");
        }
    }
}
