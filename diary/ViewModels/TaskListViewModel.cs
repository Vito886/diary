using diary.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace diary.ViewModels
{
    public class TaskListViewModel : ViewModelBase
    {
        DateTimeOffset? currentDate;
        public TaskListViewModel() 
        {
            CurrentDate = DateTime.Today;
            TasksList = new ObservableCollection<Note>(tasks[currentDate]);
        }
        public DateTimeOffset? CurrentDate
        {
            set
            {
                this.RaiseAndSetIfChanged(ref currentDate, value);
                tasks.TryAdd(CurrentDate, new List<Note> { });
                TasksList = new ObservableCollection<Note>(tasks[currentDate]);
            }
            get => currentDate;
        }

        ObservableCollection<Note> tasksList;

        Dictionary<DateTimeOffset?, List<Note>> tasks = new Dictionary<DateTimeOffset?, List<Note>>() { { DateTime.Today, new List<Note>() } };

        public ObservableCollection<Note> TasksList
        {
            get => tasksList;
            set
            {
                this.RaiseAndSetIfChanged(ref tasksList, value);
            }
        }

        public Dictionary<DateTimeOffset?, List<Note>> Tasks
        {
            get => tasks;
        }
    }


}
