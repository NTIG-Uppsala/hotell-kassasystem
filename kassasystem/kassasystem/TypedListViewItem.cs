using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kassasystem
{
    public class TypedListViewItem : ListViewItem
    {
        public Dictionary<string, Type> TypeDictionary { get; set; } = new();

        public TypedListViewItem(params dynamic[] items) : base(ItemsToStringArray(items))
        {
            foreach (var item in items)
            {
                var string_item = Convert.ToString(item);
                if (string_item == null)
                    throw new NullReferenceException("Couldn't convert item to string");
                TypeDictionary[string_item] = item.GetType();
            }
        }

        private static string[] ItemsToStringArray(params dynamic[] items)
        {
            List<string> string_items = new();
            foreach (var item in items)
            {
                var string_item = Convert.ToString(item);
                if (string_item == null)
                    throw new NullReferenceException("Couldn't convert item to string");
                string_items.Add(string_item);
            }
            return string_items.ToArray();
        }
    }
}
