using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace Crater.UI.Controls
{
    public partial class FilteredList : UserControl
    {
        public string Title { get; set; } = "Title";

        public ObservableCollection<object> Data { get; private set; } = new ObservableCollection<object>();
        public CollectionViewSource FilteredData { get; private set; } = new CollectionViewSource();
        public DataTemplate ItemTemplate 
        {
            get => ListBox.ItemTemplate;
            set => ListBox.ItemTemplate = value;
        }


        public FilteredList()
        {
            InitializeComponent();
            this.DataContext = this;
            FilteredData.Source = this.Data;
        }
        
        public void Add(object item)
        {
            Data.Add(item);
        }

        public void Refresh()
        {
            FilteredData.View.Refresh();
        }

        private void FilterTextBox_TextChanged(object sender, TextChangedEventArgs args)
        {
            FilteredData.View.Refresh();
        }
    }
}