using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace FirTree
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport("user32.dll")]
        public static extern bool SetWindowPos(int hWnd, int hWndInsertAfter, int X, int Y,int cx, int cy, uint uFlags);
        public const int HWND_BOTTOM = 0x1;
        public const uint SWP_NOSIZE = 0x1;
        public const uint SWP_NOMOVE = 0x2;
        public const uint SWP_SHOWWINDOW = 0x40;



        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            

            addSelectedDates();
            ShoveToBackground();

        }

       

        private IntPtr Handle
        {
            get
            {
                return new WindowInteropHelper(this).Handle;
            }
        }

        private void ShoveToBackground()
        {
            SetWindowPos((int)this.Handle, HWND_BOTTOM, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);
        }


        private void addSelectedDates()
        {
            MyCalendar.SelectedDates.Add(new DateTime(2021, 1, 31));
            MyCalendar.SelectedDates.Add(new DateTime(2021, 2, 3));
        }

        private void MyCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            //SelectedDataTextBox.Text = MyCalendar.SelectedDate.ToString();
            //ViewMessage vmDay = new ViewMessage();
            //vmDay.Show();
            
        }

        private void MyCalendar_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //SelectedDataTextBox.Text = "Add";
            //DateTime selectDay = Convert.ToDateTime(MyCalendar.SelectedDate.ToString());
            DateTime selectDay = (DateTime)MyCalendar.SelectedDate;
            AddMessageInDatabase addMess = new AddMessageInDatabase(selectDay);
            addMess.Show();
        }

        #region Вывод всплывающего сообщения
        private void ShowCustomBallon()
        {
            string title = "WPF NotifyIcon";
            string text = "This is a standard ballon";

            myNotifyIcon.ShowBalloonTip(title, text, myNotifyIcon.Icon);
            myNotifyIcon.HideBalloonTip();


        }


        #endregion

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            AddMessageInDatabase addMessage = new AddMessageInDatabase((DateTime)MyCalendar.SelectedDate);
            addMessage.Show();

        }

        private void SettingTask_Click(object sender, RoutedEventArgs e)
        {

        }

        
        private void ExitTask_Click(object sender, RoutedEventArgs e)
        {
            myNotifyIcon.Dispose();
            System.Windows.Application.Current.Shutdown();


        }

        private void btnTrayPopup_Click(object sender, RoutedEventArgs e)
        {
            ShowCustomBallon();
        }

        private void EditTask_Click(object sender, RoutedEventArgs e)
        {
            EditMessageDatabase editMessageDatabase = new EditMessageDatabase();
            editMessageDatabase.Show();
        }
    }

    #region Нажатие на TrayIcon 


    public class ShowMessageCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
          //  MessageBox.Show(parameter.ToString());
        }
    }

    #endregion
}
