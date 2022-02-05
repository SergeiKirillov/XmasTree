using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Shapes;

namespace FirTree
{
    /// <summary>
    /// Логика взаимодействия для EditMessageDatabase.xaml
    /// </summary>
    /// 

    public class Zadacha
    {
        public int id { get; set; }
        public string dtTask { get; set;}
        public string strTask { get; set;}
        public string Categoria { get; set; }
    }

    public class ZadachContext : DbContext
    {
        public DbSet<Zadacha> Zadachas { get; set; }
    }

    public partial class EditMessageDatabase : Window
    {
       
        public EditMessageDatabase()
        {
            InitializeComponent();

            this.Loaded += My_Loaded; 

        }

        private void My_Loaded(object sender, RoutedEventArgs e)
        {
            ZadachContext context = new ZadachContext();

            //context.Zadachas.OrderBy(c => c.dtTask).Load();
            context.Zadachas.Load();
            this.dataGrid.ItemsSource = context.Zadachas.Local;
        }
    }
}
