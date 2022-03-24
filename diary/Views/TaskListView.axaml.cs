using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using diary.ViewModels;
using System;
using Avalonia.Interactivity;

namespace diary.Views
{
    public partial class TaskListView : UserControl
    {
        public TaskListView()
        {
            InitializeComponent();

            this.FindControl<DatePicker>("datePicker").SelectedDateChanged += delegate
            {
                DateTimeOffset? selectedDate = this.FindControl<DatePicker>("datePicker").SelectedDate;
                var context = this.DataContext as TaskListViewModel;
                if (context != null)
                    context.CurrentDate = selectedDate;
            };
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
