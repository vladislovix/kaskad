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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace kaskad
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        kaskadEntities database = new kaskadEntities();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_auto_Click(object sender, RoutedEventArgs e)
        {
            string login = txtboxLogin.Text;
            string pass = txtboxPass.Password;

            if (database.admin.Any(u => u.login == login && u.pass == pass))

            {
                foreach (var client in database.admin)
                {
                    if (client.login == login && client.pass == pass)

                    {


                        this.Visibility = Visibility.Collapsed;
                        Window1 window = new Window1();
                        window.Show();

                    }
                }

            }
        }
    }
}
