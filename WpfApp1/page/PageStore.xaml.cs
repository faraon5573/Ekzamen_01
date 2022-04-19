using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using WpfApp1.classes;

namespace WpfApp1.page
{
    /// <summary>
    /// Логика взаимодействия для PageStore.xaml
    /// </summary>
    public partial class PageStore : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private List<BookShop> _BookShopList;
        public List<BookShop> BookShopList
        {
            get { return _BookShopList; }
            set { _BookShopList = value; }
        }
        public PageStore()
        {
            this.DataContext = this;
            BookShopList = Core.DB.BookShop.ToList();
            InitializeComponent();
        }

        private void Backet_Click(object sender, RoutedEventArgs e)
        {
            LoadPages.MainFrame.Navigate(new PageBacket());
        }

        private void AddBacket_Click(object sender, RoutedEventArgs e)
        {

            var item = MainGrid.SelectedItem as BookShop;
            Basket basket_find = Core.DB.Basket.Find(item.id);
            if (basket_find != null)
            {
                Basket basket = Core.DB.Basket.Find(item.id);
                if (basket != null)
                {
                    basket.quantity = basket.quantity + 1;
                    Core.DB.SaveChanges();
                }
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("BookShopList"));
                }
            }
            else
            {
                Basket basket = new Basket();
                basket.id = item.id;
                basket.name = item.name;
                basket.id_genre = item.id_genre;
                basket.author = item.author;
                basket.price = item.price;
                basket.quantity = 1;
                basket.cover = item.cover;
                Basket dist_find_1 = Core.DB.Basket.Find(item.id);
                if (dist_find_1 == null)
                {
                    Core.DB.Basket.Add(basket);
                    Core.DB.SaveChanges();
                }
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("BookShopList"));
                }
            }
        }
    }
}
