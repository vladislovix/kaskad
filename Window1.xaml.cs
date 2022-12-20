using Microsoft.Win32;
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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        kaskadEntities context;
        public Window1()
        {
            InitializeComponent();
            context = new kaskadEntities();
            TableProduct.ItemsSource = context.product.ToList();
            //TableProduct.ItemsSource = Class1.model.product.ToList();


        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            context = new kaskadEntities();
            product item = TableProduct.SelectedItem as product;
            try
            {
                product service = context.product.Where(c => c.id == item.id).Single();
                context.product.Remove(service);
                context.SaveChanges();

                MessageBox.Show("Клиент успешно удалён!");
                //Метод обновления таблицы после удаления
                refreshdatagrid();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Button reda = sender as Button;
            var reda1 = reda.DataContext as product;
            OpenFileDialog das = new OpenFileDialog();
            das.Title = "Выберите изображение";
            das.Filter = "All supported graphics|*.jpeg;*.jpg;*.png|" + " JPEG(*.jpeg;*.jpg)|*.jpeg;*.jpg|" +
            "Portable Network Graphic (*.png)|*.png";
            if (das.ShowDialog() == true)
            {
                reda1.Image = new Image { ImagePath = das.FileName };
            }
            WindowAd newClientWindow = new WindowAd(context, reda1);
            newClientWindow.ShowDialog();
        }

        private void Button_add_u(object sender, RoutedEventArgs e)
        {
            var NewDob = new product();
            context.product.Add(NewDob);
            OpenFileDialog das = new OpenFileDialog();
            das.Title = "Выберите изображение";
            das.Filter = "All supported graphics|*.jpeg;*.jpg;*.png|" + " JPEG(*.jpeg;*.jpg)|*.jpeg;*.jpg|" +
            "Portable Network Graphic (*.png)|*.png";
            if (das.ShowDialog() == true)
            {
                NewDob.Image = new Image { ImagePath = das.FileName };
            }
            WindowAd newClientWindow = new WindowAd(context, NewDob);
            newClientWindow.ShowDialog();

            refreshdatagrid();
        }
        private void refreshdatagrid()
        {
            TableProduct.ItemsSource = context.product.ToList();
            TableProduct.Items.Refresh();
        }

        private void tboxsearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var cur = context.product.ToList();
            cur = cur.Where(x => x.producttitle.ToLower().StartsWith(tboxsearch.Text.ToLower()) ||
            x.quantityofgoods.ToString().ToLower().StartsWith(tboxsearch.Text.ToLower()) ||
            x.cost.ToString().ToLower().StartsWith(tboxsearch.Text.ToLower())).ToList();
            TableProduct.ItemsSource = cur.ToList();

            
        }

        private void updateprod()
        {
            var NewDob = new product();

        }
    }
}
