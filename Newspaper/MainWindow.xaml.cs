using Newspaper.Pages;
using Newspaper.Styles;
using System.Windows;
using System.Windows.Controls;
using static Newspaper.Properties.Resources;

namespace Newspaper
{
    public partial class MainWindow : Window
    {
        private Frame Frame { get; } = new() { NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden };

        public MainWindow()
        {
            InitializeComponent();

            Name = "MainWindow";

            // Properties
            // Brush
            Background = Primary;
            // Layout
            Width = 800;
            Height = 600;
            // Common
            Content = Frame;
            Icon = MainWindow_Icon;
            ResizeMode = ResizeMode.CanMinimize;
            Title = MainWindow_Title;

            // Event handlers
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e) => Frame.Navigate(new MainPage());
    }
}