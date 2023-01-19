using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kassasystem
{
    public class TypedListViewItem : ListViewItem
    {
        public Dictionary<string, Type> TypeDictionary { get; set; } = new();

        private static CultureInfo culture = new CultureInfo("en-US");
        public TypedListViewItem(params dynamic[] items) : base(ItemsToStringArray(items))
        {
            foreach (var item in items)
            {
                string string_item;
                if (item.GetType() == typeof(decimal))
                    string_item = item.ToString("0.00", culture);
                else
                    string_item = Convert.ToString(item, culture); if (string_item == null)
                    throw new NullReferenceException("Couldn't convert item to string");
                TypeDictionary[string_item] = item.GetType();
            }
        }

        private static string[] ItemsToStringArray(params dynamic[] items)
        {
            List<string> string_items = new();
            foreach (var item in items)
            {
                string string_item;
                if (item.GetType() == typeof(decimal))
                    string_item = item.ToString("0.00", culture);
                else
                    string_item = Convert.ToString(item, culture); if (string_item == null)
                    throw new NullReferenceException("Couldn't convert item to string");
                string_items.Add(string_item);
            }
            return string_items.ToArray();
        }
    }
}
