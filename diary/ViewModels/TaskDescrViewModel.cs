using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive;
using diary.Models;
using ReactiveUI;

namespace diary.ViewModels
{
    public class TaskDescrViewModel : ViewModelBase
    {
        string header;
        string description;
        public TaskDescrViewModel(Note note)
        {
            var Enabled = this.WhenAnyValue(
                    input => input.Header,
                    input => !string.IsNullOrWhiteSpace(input)
                );

            Header = note.header;
            Description = note.description;
            Add = ReactiveCommand.Create(() => new Note(Header, Description), Enabled);
            Cancel = ReactiveCommand.Create(() => new Note("", ""));
        }

        public ReactiveCommand<Unit, Note> Add { get; }
        public ReactiveCommand<Unit, Note> Cancel { get; }
        public string Header
        {
            set => this.RaiseAndSetIfChanged(ref header, value);
            get => header;
        }

        public string Description
        {
            set => this.RaiseAndSetIfChanged(ref description, value);
            get => description;
        }
    }
}
