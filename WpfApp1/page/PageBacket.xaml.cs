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
    /// Логика взаимодействия для PageBacket.xaml
    /// </summary>
    public partial class PageBacket : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private List<Basket> _BasketList;
        public List<Basket> BasketList
        {
            get { return _BasketList; }
            set { _BasketList = value; }
        }
        public PageBacket()
        {
            this.DataContext = this;
            BasketList = Core.DB.Basket.ToList();
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            LoadPages.MainFrame.Navigate(new PageStore());
        }

        private void order_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteBacket_Click(object sender, RoutedEventArgs e)
        {
            Button BTN = (Button)sender;
            int ind = Convert.ToInt32(BTN.Uid);
            var item = MainGrid.SelectedItem as Basket;

            Core.DB.Basket.Remove(item);
            Core.DB.SaveChanges();
            BasketList = Core.DB.Basket.ToList();
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("BasketList"));
            }
        }
    }
}
