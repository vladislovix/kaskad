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
using System.Windows.Shapes;

namespace kaskad
{
    /// <summary>
    /// Логика взаимодействия для WindowAd.xaml
    /// </summary>
    public partial class WindowAd : Window
    {
        kaskadEntities database;
        public WindowAd(kaskadEntities context1, product product)
        {
            InitializeComponent();
            this.database = context1;
            this.DataContext = product;
        }

        private void Button_dobav_Click(object sender, RoutedEventArgs e)
        {
            database.SaveChanges();
        }
    }
}
