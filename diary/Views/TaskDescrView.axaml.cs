using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using diary.ViewModels;

namespace diary.Views
{
    public partial class TaskDescrView : UserControl
    {
        public TaskDescrView()
        {
            InitializeComponent();

            this.FindControl<Button>("Ok").Click += delegate
            {
                var context = this.DataContext as TaskDescrViewModel;
                if (this.FindControl<TextBox>("header").Text != "")
                {
                    context.Header = this.FindControl<TextBox>("header").Text;
                    context.Description = this.FindControl<TextBox>("description").Text;
                }
            };
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
