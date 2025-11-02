using System.Collections.ObjectModel;
using System.Text.Json;

namespace TodoListMAUI;

public partial class MainPage : ContentPage
{
    private const string DataKey = "ToDoItemData";
    public ObservableCollection<ToDoItem> Items { get; set; }

    public MainPage()
    {
        InitializeComponent();
        
        LoadItems();
        
        TasksCollectionView.ItemsSource = Items;
    }

    public void SaveItems()
    {
        string json = JsonSerializer.Serialize(Items);
        Preferences.Default.Set(DataKey, json);
    }

    public void LoadItems()
    {
        string json = Preferences.Default.Get(DataKey, string.Empty);
        if (!string.IsNullOrWhiteSpace(json))
        {
            Items = JsonSerializer.Deserialize<ObservableCollection<ToDoItem>>(json);
        }
        else
        {
            Items = new ObservableCollection<ToDoItem>();
        }
    }


    private void OnAddButtonClicked(object? sender, EventArgs e)
    {
        string taskName = NewTaskEntry.Text?.Trim();

        if (!string.IsNullOrWhiteSpace(taskName))
        {
            Items.Add(new ToDoItem() { Name = taskName, IsCompleted = false });

            NewTaskEntry.Text = string.Empty;
            
            SaveItems();
        }
    }

    private void OnTaskStatusChange(object? sender, CheckedChangedEventArgs e)
    {
        var checkbox = sender as CheckBox;
        var item = checkbox?.BindingContext as ToDoItem;

        if (item != null)
        {
        }
    }

    private void OnDeleteButtonClicked(object? sender, EventArgs e)
    {
        var button = sender as Button;
        var item = button?.BindingContext as ToDoItem;

        if (item != null)
        {
            Items.Remove(item);
            SaveItems();
        }
    }

    private void OnDeleteInvoked(object? sender, EventArgs e)
    {
        var swipeItem = sender as SwipeItem;
        var item = swipeItem?.CommandParameter as ToDoItem;

        if (item != null)
        {
            Items.Remove(item);
            SaveItems();
        }

        if (swipeItem?.Parent is SwipeItem swipeItems && swipeItems.Parent is SwipeView swipeView)
        {
            swipeView.Close();
        }
    }
}