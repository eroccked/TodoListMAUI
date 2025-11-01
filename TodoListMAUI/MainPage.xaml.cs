using System.Collections.ObjectModel;

namespace TodoListMAUI;

public partial class MainPage : ContentPage
{
    public ObservableCollection<ToDoItem> Items { get; set; }
    
    public MainPage()
    {
        InitializeComponent();

        Items = new ObservableCollection<ToDoItem>();
        TasksCollectionView.ItemsSource = Items;
    }

    private void OnAddButtonClicked(object? sender, EventArgs e)
    {
        string taskName = NewTaskEntry.Text?.Trim();

        if (!string.IsNullOrWhiteSpace(taskName))
        {
            Items.Add(new ToDoItem() {Name = taskName, IsCompleted = false});
            
            NewTaskEntry.Text = string.Empty;
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
        }
    }
}