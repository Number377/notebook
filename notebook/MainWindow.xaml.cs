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

namespace notebook
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        string filename = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Newbtn_Click(object sender, RoutedEventArgs e)
        {
            beginfontSize();
            GdflieName.Text = "Newfile";
            TextArea.Text = "";
        }

        private void Openbtn_Click(object sender, RoutedEventArgs e)
        {
            beginfontSize();
            // 產生開啟檔案視窗 OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // 顯示視窗
            Nullable<bool> result = dlg.ShowDialog();

            // 當按下開啟之後的反應 
            if (result == true)
            {
                filename = dlg.FileName;

                // 讀取檔案
                TextArea.Text = System.IO.File.ReadAllText(filename);
                GdflieName.Text = dlg.SafeFileName;
            }
        }

        private void Savebtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.IO.File.WriteAllText(filename, TextArea.Text);
                if (GdflieName.Text[GdflieName.Text.Length - 1] == '*')
                {
                    GdflieName.Text = GdflieName.Text.Substring(0, GdflieName.Text.Length - 1);
                }
                MessageBox.Show("已存檔");
            }
            catch
            {
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                
                Nullable<bool> result = dlg.ShowDialog();

                if (result == true)
                {
                    filename = dlg.FileName;
                    
                    System.IO.File.WriteAllText(dlg.FileName, TextArea.Text);
                }
            }
        }

        private void Saveasbtn_Click(object sender, RoutedEventArgs e)
        {
            // 產生開啟檔案視窗 SaveFileDialog 
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            //dlg.Filter = "Text files (*.txt)|*.txt|CSV files (*.csv)|*.csv";
            // 顯示視窗
            Nullable<bool> result = dlg.ShowDialog();
            // 當按下開啟之後的反應 
        if (result == true)
            {
                filename = dlg.FileName;

                // 儲存檔案
                System.IO.File.WriteAllText(dlg.FileName,TextArea.Text);
            }
        }

        private void Closebtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void max_Click(object sender, RoutedEventArgs e)
        {
            if(WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
            }
            else
            {
                WindowState = WindowState.Normal;
            }
        }

        void beginfontSize()
        {
            GdflieName.FontSize = 14;
            TextArea.FontSize = 14;
        }

        private void small_Click(object sender, RoutedEventArgs e)
        {
            beginfontSize();
        }

        private void mid_Click(object sender, RoutedEventArgs e)
        {
            GdflieName.FontSize = 18;
            TextArea.FontSize = 18;
        }

        private void big_Click(object sender, RoutedEventArgs e)
        {
            GdflieName.FontSize = 22;
            TextArea.FontSize = 22;
        }

        private void turnIntoblackbtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextArea.Background = Brushes.DimGray;
            TextArea.Foreground = Brushes.White;
            min.Background = Brushes.DimGray;
            min.Foreground = Brushes.White;
            max.Background = Brushes.DimGray;
            max.Foreground = Brushes.White;
            Closebtn.Background = Brushes.DimGray;
            Closebtn.Foreground = Brushes.White;
            notimportant.Background = Brushes.DimGray;
            GdflieName.Background = Brushes.DimGray;
            GdflieName.Foreground = Brushes.White;
        }

        private void turnIntowhitebtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextArea.Background = Brushes.White;
            TextArea.Foreground = Brushes.Gray;
            min.Background = Brushes.White;
            min.Foreground = Brushes.Gray;
            max.Background = Brushes.White;
            max.Foreground = Brushes.Gray;
            Closebtn.Background = Brushes.White;
            Closebtn.Foreground = Brushes.Gray;
            notimportant.Background = Brushes.White;
            GdflieName.Background = Brushes.White;
            GdflieName.Foreground = Brushes.Gray;
        }
    }
}
