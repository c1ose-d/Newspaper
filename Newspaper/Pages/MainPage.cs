using Newspaper.Styles;
using System.Windows;
using System.Windows.Controls;

namespace Newspaper.Pages
{
    internal class MainPage : Page
    {
        private StackPanel StackPanel { get; } = new();
        private StackPanel CommandMenu { get; } = new() { Orientation = Orientation.Horizontal };

        private Button Insert { get; } = new InsertButton();
        private class InsertButton : Button
        {
            public InsertButton()
            {
                Style = new Button_Style();
                Content = "Insert";

                Click += InsertButton_Click;
            }

            private void InsertButton_Click(object sender, RoutedEventArgs e)
            {
                
            }
        }
        private Button Update { get; } = new UpdateButton();
        private class UpdateButton : Button
        {
            public UpdateButton()
            {
                Style = new Button_Style();
                Content = "Update";

                Click += UpdateButton_Click;
            }

            private void UpdateButton_Click(object sender, RoutedEventArgs e)
            {

            }
        }
        private Button Delete { get; } = new DeleteButton();
        private class DeleteButton : Button
        {
            public DeleteButton()
            {
                Style = new Button_Style();
                Content = "Delete";

                Click += DeleteButton_Click;
            }

            private void DeleteButton_Click(object sender, RoutedEventArgs e)
            {

            }
        }

        private DataGrid DataGrid { get; } = new();

        public MainPage()
        {
            // Properties
            // Common
            Content = StackPanel;

            // Event handlers
            Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            CommandMenu.Children.Add(Insert);
            CommandMenu.Children.Add(Update);
            CommandMenu.Children.Add(Delete);

            StackPanel.Children.Add(CommandMenu);
            StackPanel.Children.Add(DataGrid);
        }
    }
}