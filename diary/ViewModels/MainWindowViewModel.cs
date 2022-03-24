using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using diary.Models;
using ReactiveUI;
using System.Reactive;
using System.Reactive.Linq;
using System.Linq;

namespace diary.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        ViewModelBase content;
        public MainWindowViewModel()
        {
            Content = Tl = new TaskListViewModel();
            Descr = ReactiveCommand.Create<Note, int>((task) => OpenTaskDescr(task));
            Delete = ReactiveCommand.Create<Note, int>((task) => DeleteTask(task));
        }
        public ReactiveCommand<Note, int> Descr { get; }
        public ReactiveCommand<Note, int> Delete { get; }

        public ViewModelBase Content
        {
            set => this.RaiseAndSetIfChanged(ref content, value);
            get => content;
        }

        public TaskListViewModel Tl
        {
            get;
        }
        public void NewTask()
        {
            var td = new TaskDescrViewModel(new Note("", ""));
            Content = td;
            Observable.Merge(td.Add, td.Cancel).Take(1)
                .Subscribe((note) =>
                {
                    if (note.header != "")
                    {
                        bool added = Tl.Tasks.TryAdd(Tl.CurrentDate, new List<Note> { note });
                        if (!added)
                        {
                            Tl.Tasks[Tl.CurrentDate].Add(note);
                        }
                    }
                    Tl.TasksList = new ObservableCollection<Note>(Tl.Tasks[Tl.CurrentDate]);
                    Content = Tl;   
                });
        }

        public int OpenTaskDescr(Note currentNote)
        {
            var taskDescr = new TaskDescrViewModel(currentNote);
            Content = taskDescr;
            Observable.Merge(taskDescr.Add, taskDescr.Cancel).Take(1)
                .Subscribe((note) =>
                {
                    if (note.header != "")
                    {
                        currentNote.Header = note.Header;
                        currentNote.Description = note.Description;
                    }
                    Tl.TasksList = new ObservableCollection<Note>(Tl.Tasks[Tl.CurrentDate]);
                    Content = Tl;
                });
            return 1;
        }

        public int DeleteTask(Note currentNote)
        {
            Tl.Tasks[Tl.CurrentDate].Remove(currentNote);
            Tl.TasksList = new ObservableCollection<Note>(Tl.Tasks[Tl.CurrentDate]);
            return 1;
        }
    }
}
