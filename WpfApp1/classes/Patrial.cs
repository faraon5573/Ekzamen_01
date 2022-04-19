using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.page;
using WpfApp1.classes;

namespace WpfApp1
{
    public partial class BookShop
    {
        public Uri ImageUri
        {
            get
            {
                return new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, cover ?? ""));
            }
        }
        public string NameGenreString
        {
            get
            {
                return "Название: " + name.ToString() + " | " + "Жанр: " + Genre.name.ToString();
            }
        }
        public string authorString
        {
            get
            {
                return "Автор: " + author.ToString();
            }
        }
        public string priceString
        {
            get
            {
                return "Цена: " + price.ToString() + " руб.";
            }
        }
        public string quantity_storeString
        {
            get
            {
                if (quantity_store >= 5)
                {
                    return "Количество в магазине: много";
                }
                else if (quantity_store == 0)
                {
                    return "Количество в магазине: нет";
                }
                else
                {
                    return "Количество в магазине: " + quantity_store.ToString();
                }
            }
        }
        public string quantity_stockString
        {
            get
            {
                if (quantity_stock >= 5)
                {
                    return "Количество на складе: много";
                }
                else if (quantity_stock == 0)
                {
                    return "Количество на складе: нет";
                }
                else
                {
                    return "Количество на складе: " + quantity_stock.ToString();
                }
            }
        }
        public string descriptionString
        {
            get
            {
                return "Описание: " + description.ToString();
            }
        }
    }
    public partial class Basket
    {
        public Uri ImageUri
        {
            get
            {
                return new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, cover ?? ""));
            }
        }
        public string NameGenreString
        {
            get
            {
                return "Название: " + name.ToString() + " | " + "Жанр: " + Genre.name.ToString();
            }
        }
        public string authorString
        {
            get
            {
                return "Автор: " + author.ToString();
            }
        }

        public string quantityString
        {
            get
            {
                return "Количество: " + quantity.ToString() + " шт.";
            }
        }
        public int priceint
        {
            get
            {
                return Convert.ToInt32(price ?? 0);
            }
        }
        public string PriceWithDiscount
        {
            get
            {
                if(HasDiscount)
                {
                    if (quantity >= 10)
                    {
                        return (priceint * Convert.ToDecimal(1 - 0.15)).ToString(" #.##");
                    }
                    else if (quantity >= 5)
                    {
                        return (priceint * Convert.ToDecimal(1 - 0.10)).ToString(" #.##");
                    }
                    else if (quantity >= 3)
                    {
                        return (priceint * Convert.ToDecimal(1 - 0.05)).ToString(" #.##");
                    }
                    else
                    {
                        return priceint.ToString(" #.##");
                    }
                }
                else
                {
                    return "";
                }

            }
        }
        public Boolean HasDiscount
        {
            get
            {
                return quantity >= 3;
            }
        }
        public string PriceTextDecoration
        {
            get
            {
                return !HasDiscount ? "None" : "Strikethrough";
            }
        }
    }
}
