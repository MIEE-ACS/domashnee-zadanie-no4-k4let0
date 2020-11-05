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

namespace hometask4_2
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
            int m;
            if (int.TryParse(tbSize1.Text, out n) && int.TryParse(tbSize2.Text, out m) && n > 0 && m > 0)
            {
                // генерация массива
                Random rand = new Random();
                int[,] arr = new int[n, m];
                for (int i = 0; i < n; ++i)
                {
                    for (int j = 0; j < m; ++j) arr[i, j] = rand.Next(10) - 5;
                }
                // вывод массива
                string[] textarr = new string[n];
                for (int i = 0; i < n; ++i) textarr[i] = "";
                for (int i = 0; i < n; ++i)
                {
                    for (int j = 0; j < m; ++j) textarr[i] = textarr[i].Insert(textarr[i].Length, $"{arr[i, j],-5}");
                }
                tbArray0.Text = string.Join("\n", textarr);
                
                // поиск первого столбца с нулевым элементом
                int column = -1;
                for (int j = 0; j < m; ++j)
                {
                    for (int i = 0; i < n; ++i) if (arr[i, j] == 0 && column == -1) column = j;
                }
                tbAns.Text = column == -1 ? "В матрице нет нулевых элементов" : (column+1).ToString();

                // преобразование массива
                int[] characteristics = new int[n];
                for (int i = 0; i < n; ++i) characteristics[i] = 0;
                for (int i = 0; i < n; ++i)
                {
                    for (int j = 0; j < m; ++j) if (arr[i, j] < 0 && arr[i, j] % 2 == 0) characteristics[i] += arr[i, j];
                }
                for(int i = 0; i < n; ++i)
                {
                    for (int ii = i; ii < n; ++ii)
                    {
                        if (characteristics[ii] > characteristics[i])
                        {
                            int temp = characteristics[i];
                            characteristics[i] = characteristics[ii];
                            characteristics[ii] = temp;
                            for (int j = 0; j < m; ++j)
                            {
                                temp = arr[i, j];
                                arr[i, j] = arr[ii, j];
                                arr[ii, j] = temp;
                            }
                        }
                    }
                }

                // вывод массива
                for (int i = 0; i < n; ++i) textarr[i] = "";
                for (int i = 0; i < n; ++i)
                {
                    for (int j = 0; j < m; ++j) textarr[i] = textarr[i].Insert(textarr[i].Length, $"{arr[i, j],-5}");
                }
                tbArray1.Text = string.Join("\n", textarr);
            }
            else MessageBox.Show("Размеры матрицы должны быть положительными целыми числами");
        }
    }
}
