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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FirTree
{
    /// <summary>
    /// Логика взаимодействия для AddMessageInDatabase.xaml
    /// </summary>
    /// 

    

    public partial class AddMessageInDatabase : Window
    {

        //*****************************************************
        //Функции винапи
        //*****************************************************
        const int KL_NAMELENGTH = 9;
        const int KLF_ACTIVATE = 1;

        [DllImport("user32.dll")]
        public static extern long LoadKeyboardLayout(string pwszKLID, uint Flags);
        [DllImport("user32.dll")]
        public static extern long GetKeyboardLayoutName(System.Text.StringBuilder pwszKLID);

        public static string getKLName()
        {
            System.Text.StringBuilder name = new System.Text.StringBuilder(KL_NAMELENGTH);
            GetKeyboardLayoutName(name);
            return name.ToString();
        }

        private static void setKLName(string pwszKLID)
        {
            LoadKeyboardLayout(pwszKLID, KLF_ACTIVATE);
        }


        public AddMessageInDatabase(DateTime SelectDate)
        {
            InitializeComponent();
            //lblDT.Content = SelectDate.ToString();
            Picker.Text= SelectDate.ToString();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            //MessageBox.Show(selectedItem.Content.ToString());
        }

        

        private void txtZadacha_GotFocus(object sender, RoutedEventArgs e)
        {
            setKLName("00000419");
        }

        // SQLite в WPF https://metanit.com/sharp/wpf/21.1.php

        private void btnSaveInDB_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult dr = MessageBox.Show("Вы уверены что хотите сохранить эти данные","Добавление данных", MessageBoxButton.YesNo,MessageBoxImage.Question);

            if (dr == MessageBoxResult.Yes)
            {
                Task dbNewTask = new Task();

                if (dbNewTask.SaveNewTask())
                {
                    MessageBox.Show("Данные записаны", "Добавление данных", MessageBoxButton.OK, MessageBoxImage.Information);

                }
            }

            

        }
    }
}
