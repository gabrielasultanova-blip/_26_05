using _26_05.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forma
{
    public static class ShoppingCart
    {
        // dyrji knigite i broikite na porebitelq
        public static List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public static void Clear() => Items.Clear();
    }
}
