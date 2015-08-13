﻿using System;
using Xamarin.Forms;
using XamarinCRM.Statics;
using XamarinCRM.Cells;
using XamarinCRM.Views.Base;

namespace XamarinCRM.Views.Customers
{
    public class CustomerOrderListView : BaseNonPersistentSelectedItemListView
    {
        public CustomerOrderListView()
        {
            HasUnevenRows = false; // Circumvents calculating heights for each cell individually. The rows of this list view will have a static height.
            RowHeight = (int)Sizes.LargeRowHeight; // set the row height for the list view items
            SeparatorVisibility = SeparatorVisibility.None;
            ItemTemplate = new DataTemplate(typeof(OrderListItemCell));
            SeparatorColor = Palette._014;
        }
    }
}
