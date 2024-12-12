

using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using ToDoList.Model;
using ToDoList.MVVM;

namespace ToDoList.ViewModel
{
    internal class MainWindowViewModel : VievModelBase
    {
        public ObservableCollection<Item> Items { get; set; }

        public ReleyCommand AddCommand => new ReleyCommand(execute => AddTask());
        public ReleyCommand DeleteCommand => new ReleyCommand(execute => DeleteTask(), canExecute => SelectedItem != null);

        public MainWindowViewModel() { 
        Items = new ObservableCollection<Item>();
            Items.Add(new Item
            {
                Task = "posprzataj",
                Place = "dom",
                Date = "1.1.2004",
                Status = true
            });
            
        }

        private Item selectedItem;

        public Item SelectedItem
        {
            get { return selectedItem; }
            set { 
                selectedItem = value;
                OnPropertChanged();
            }
        }

        private void AddTask()
        {
            Items.Add(new Item
            {
                Task = "empty",
                Place = "empty",
                Date = DateTime.Now.ToString(),
                Status = false
            });
        }

        private void DeleteTask()
        {
            Items.Remove(selectedItem);
        }
    }
}
