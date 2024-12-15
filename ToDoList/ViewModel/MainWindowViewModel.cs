

using System;
using System.IO;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using ToDoList.Model;
using ToDoList.MVVM;
using System.Windows.Shapes;

namespace ToDoList.ViewModel
{
    internal class MainWindowViewModel : VievModelBase
    {
        public ObservableCollection<Item> Items { get; set; }

        public ReleyCommand AddCommand => new ReleyCommand(execute => AddTask());
        public ReleyCommand DeleteCommand => new ReleyCommand(execute => DeleteTask(), canExecute => SelectedItem != null);
        public ReleyCommand DoneCommand => new ReleyCommand(execute => Done(), canExecute => ItemStatusCheck(false));
        public ReleyCommand UndoneCommand => new ReleyCommand(execute => Undone(), canExecute => ItemStatusCheck(true));
        public ReleyCommand SaveCommand => new ReleyCommand(execute => SaveToFile());

        public MainWindowViewModel() { 
        Items = new ObservableCollection<Item>();
            LoadFromFile();
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

        private void LoadFromFile()
        {
        try
            {
                const string SourceFileName = "TaskList.txt";
                const string EndOfRecordStybol = ";";
                StreamReader dataFile = new StreamReader(SourceFileName);
                Console.WriteLine("File " + SourceFileName + " found");
                string line;
                while (!dataFile.EndOfStream) { 
                    line = dataFile.ReadLine();
                    Console.WriteLine("Line read: " + line);
                    string taks, place, strDate;
                    bool status;
                    const string searchngSybol = ",";
                    int startIndex = 0, lastIndex = line.IndexOf(searchngSybol);
                    taks = line.Substring(0, lastIndex);
                    Console.WriteLine("Task read: " + taks);
                    startIndex = lastIndex + 1;
                    lastIndex = line.IndexOf(searchngSybol, startIndex);
                    place= line.Substring(startIndex, lastIndex - startIndex);
                    Console.WriteLine("Place read: " + place);
                    startIndex = lastIndex + 1;
                    lastIndex = line.IndexOf(searchngSybol, startIndex);
                    strDate = line.Substring(startIndex, lastIndex - startIndex);
                    Console.WriteLine("Date read: " + strDate);
                    startIndex = lastIndex + 1;
                    lastIndex = line.IndexOf(EndOfRecordStybol, startIndex);
                    status = (line.Substring(startIndex, lastIndex - startIndex) == "true") ? true : false;
                    Console.WriteLine("Status read: " + status);

                    DateTime? date = null;
                    if (DateTime.TryParse(strDate, out DateTime parsedDate))
                    {
                        date = parsedDate;
                    }

                    Items.Add(new Item
                    {
                        Task = taks,
                        Place = place,
                        Date = (DateTime)date,
                        Status = status
                    });
                }
                Console.WriteLine("End of file "+ SourceFileName);
                dataFile.Close();

            }
            catch ( Exception e)
            {
                Console.WriteLine("File could not be read: ");
                Console.WriteLine( e.Message );

            }
        }

        private void SaveToFile()
        {
            try
            {
                const string SourceFileName = "TaskList.txt";
                const string EndOfRecordStybol = ";";
                StreamWriter dataFile = new StreamWriter(SourceFileName);
                Console.WriteLine("File " + SourceFileName + " found");
                foreach (var item in Items) { 
                    string task, place, date, status;
                    task = item.Task;
                    place = item.Place;
                    date = item.Date.ToString();
                    if (item.Status == true)
                    {
                        status = "true";
                    }
                    else
                    {
                        status = "false";
                    }
                    string line = task + "," + place + "," + date + "," + status + ";";
                    dataFile.WriteLine(line);
                    
                }
                dataFile.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("File could not be read: ");
                Console.WriteLine(e.Message);

            }
        }


        private void AddTask()
        {
            Items.Add(new Item
            {
                Task = "empty",
                Place = "empty",
                Date = DateTime.Now,
                Status = false
            });
        }

        private void DeleteTask()
        {
            Items.Remove(selectedItem);
        }

        private bool ItemStatusCheck(bool variable)
        {
            int slecetedItemIndex = Items.IndexOf(selectedItem);
            if ( (SelectedItem != null) && (Items[slecetedItemIndex].Status == variable)){
                return true;
            }
            return false;
        }

        private void Done()
        {
            int slecetedItemIndex = Items.IndexOf(selectedItem);
            Items[slecetedItemIndex].Status = true;
            OnPropertChanged(nameof(Items));
        }
        private void Undone()
        {
            int slecetedItemIndex = Items.IndexOf(selectedItem);
            Items[slecetedItemIndex].Status = false;
            OnPropertChanged(nameof(Items));
        }
    }
}
