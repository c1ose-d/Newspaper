using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using static Newspaper.Properties.Resources;

namespace Newspaper.Styles
{
    internal class Button_Style : Style
    {
        private readonly struct Values
        {
            public static Style FocusVisual { get; } = new FocusVisualStyleValue();
            public readonly struct Static
            {
                public static SolidColorBrush Background { get; } = Primary;
                public static SolidColorBrush BorderBrush { get; } = Secondary;
                public static SolidColorBrush Foreground { get; } = Black;
            }
            public readonly struct MouseOver
            {
                public static SolidColorBrush Background { get; } = Secondary;
                public static SolidColorBrush BorderBrush { get; } = Secondary;
                public static SolidColorBrush Foreground { get; } = Black;
            }
            public readonly struct Pressed
            {
                public static SolidColorBrush Background { get; } = Accent;
                public static SolidColorBrush BorderBrush { get; } = Accent;
                public static SolidColorBrush Foreground { get; } = Black;
            }
            public static double MinWidth { get; } = 150;
            public static double MaxWidth { get; } = 150;
            public static Thickness Margin { get; } = new Thickness(10, 5, 10, 5);
            public static Thickness BorderThickness { get; } = new Thickness(1);
            public static HorizontalAlignment HorizontalContentAlignment { get; } = HorizontalAlignment.Center;
            public static VerticalAlignment VerticalContentAlignment { get; } = VerticalAlignment.Center;
            public static Thickness Padding { get; } = new Thickness(1);
            public static Cursor Cursor { get; } = Cursors.Hand;
            public static FontFamily FontFamily { get; } = Newspaper.Properties.Resources.FontFamily;
            public static double FontSize { get; } = 24;
            public static ControlTemplate Template { get; } = new TemplateValue();

            private class FocusVisualStyleValue : Style
            {
                private struct Values
                {
                    public struct Rectangle
                    {
                        public static Thickness Margin = new(2);
                        public static DoubleCollection StrokeDashArray = new(new double[] { 1, 2 });
                        public static SolidColorBrush Stroke = Accent;
                        public static bool SnapsToDevicePixels = true;
                        public static double StrokeThickness = 1;
                    }
                }

                private ControlTemplate Template { get; } = new();
                private FrameworkElementFactory Rectangle { get; } = new(typeof(Rectangle));

                public FocusVisualStyleValue()
                {
                    Rectangle.SetValue(Properties.Margin, Values.Rectangle.Margin);
                    Rectangle.SetValue(Properties.StrokeDashArray, Values.Rectangle.StrokeDashArray);
                    Rectangle.SetValue(Properties.Stroke, Values.Rectangle.Stroke);
                    Rectangle.SetValue(Properties.SnapsToDevicePixels, Values.Rectangle.SnapsToDevicePixels);
                    Rectangle.SetValue(Properties.StrokeThickness, Values.Rectangle.StrokeThickness);

                    Template.VisualTree = Rectangle;

                    Setters.Add(new Setter(Properties.Template, Template));
                }
            }

            private class TemplateValue : ControlTemplate
            {
                private static FrameworkElementFactory Border { get; } = new(typeof(Border), "border");
                private static FrameworkElementFactory ContentPresenter { get; } = new(typeof(ContentPresenter), "contentPresenter");

                private struct Values
                {
                    public readonly struct Border
                    {
                        public static SolidColorBrush Background { get; } = Static.Background;
                        public static SolidColorBrush BorderBrush { get; } = Static.BorderBrush;
                        public static Thickness BorderThickness { get; } = Button_Style.Values.BorderThickness;
                        public static bool SnapsToDevicePixels { get; } = true;
                        public static CornerRadius CornerRadius { get; } = new CornerRadius(10);
                    }

                    public readonly struct ContentPresenter
                    {
                        public static bool Focusable { get; } = false;
                        public static HorizontalAlignment HorizontalAlignment { get; } = HorizontalContentAlignment;
                        public static Thickness Margin { get; } = Padding;
                        public static bool RecognizesAccessKey { get; } = true;
                        public static bool SnapsToDevicePixels { get; } = Border.SnapsToDevicePixels;
                        public static VerticalAlignment VerticalAlignment { get; } = VerticalContentAlignment;
                    }

                    public readonly struct Trigger
                    {
                        public static string BorderTargetName { get; } = TemplateValue.Border.Name;
                        public static string ContentPresenterTargetName { get; } = TemplateValue.ContentPresenter.Name;
                    }
                }

                public TemplateValue()
                {
                    TargetType = typeof(Button);

                    ContentPresenter.SetValue(Properties.Focusable, Values.ContentPresenter.Focusable);
                    ContentPresenter.SetValue(Properties.HorizontalAlignment, Values.ContentPresenter.HorizontalAlignment);
                    ContentPresenter.SetValue(Properties.Margin, Values.ContentPresenter.Margin);
                    ContentPresenter.SetValue(Properties.RecognizesAccessKey, Values.ContentPresenter.RecognizesAccessKey);
                    ContentPresenter.SetValue(Properties.SnapsToDevicePixels, Values.ContentPresenter.SnapsToDevicePixels);
                    ContentPresenter.SetValue(Properties.VerticalAlignment, Values.ContentPresenter.VerticalAlignment);

                    Border.SetValue(Properties.Background, Values.Border.Background);
                    Border.SetValue(Properties.BorderBrush, Values.Border.BorderBrush);
                    Border.SetValue(Properties.BorderThickness, Values.Border.BorderThickness);
                    Border.SetValue(Properties.SnapsToDevicePixels, Values.Border.SnapsToDevicePixels);
                    Border.SetValue(Properties.CornerRadius, Values.Border.CornerRadius);
                    Border.AppendChild(ContentPresenter);

                    VisualTree = Border;

                    Trigger isDefaulted = new() { Property = Properties.IsDefaulted, Value = true };
                    isDefaulted.Setters.Add(new Setter(Properties.BorderBrush, Static.BorderBrush, Values.Trigger.BorderTargetName));
                    Triggers.Add(isDefaulted);

                    Trigger isMouseOver = new() { Property = Properties.IsMouseOver, Value = true };
                    isMouseOver.Setters.Add(new Setter(Properties.Background, MouseOver.Background, Values.Trigger.BorderTargetName));
                    isMouseOver.Setters.Add(new Setter(Properties.BorderBrush, MouseOver.BorderBrush, Values.Trigger.BorderTargetName));
                    Triggers.Add(isMouseOver);

                    Trigger isPressed = new() { Property = Properties.IsPressed, Value = true };
                    isPressed.Setters.Add(new Setter(Properties.Background, Pressed.Background, Values.Trigger.BorderTargetName));
                    isPressed.Setters.Add(new Setter(Properties.BorderBrush, Pressed.BorderBrush, Values.Trigger.BorderTargetName));
                    isPressed.Setters.Add(new Setter(Properties.Foreground, Pressed.Foreground, Values.Trigger.ContentPresenterTargetName));
                    Triggers.Add(isPressed);

                    Trigger isEnabled = new() { Property = Properties.IsEnabled, Value = false };
                    isEnabled.Setters.Add(new Setter(Properties.Background, Transparent, Values.Trigger.BorderTargetName));
                    isEnabled.Setters.Add(new Setter(Properties.BorderBrush, Transparent, Values.Trigger.BorderTargetName));
                    Triggers.Add(isEnabled);
                }
            }
        }

        public Button_Style()
        {
            TargetType = typeof(Button);

            Setters.Add(new Setter(Properties.FocusVisualStyle, Values.FocusVisual));
            Setters.Add(new Setter(Properties.Background, Values.Static.Background));
            Setters.Add(new Setter(Properties.BorderBrush, Values.Static.BorderBrush));
            Setters.Add(new Setter(Properties.Foreground, Values.Static.Foreground));
            Setters.Add(new Setter(Properties.MinWidth, Values.MinWidth));
            Setters.Add(new Setter(Properties.MaxWidth, Values.MaxWidth));
            Setters.Add(new Setter(Properties.Margin, Values.Margin));
            Setters.Add(new Setter(Properties.BorderThickness, Values.BorderThickness));
            Setters.Add(new Setter(Properties.HorizontalContentAlignment, Values.HorizontalContentAlignment));
            Setters.Add(new Setter(Properties.VerticalContentAlignment, Values.VerticalContentAlignment));
            Setters.Add(new Setter(Properties.Padding, Values.Padding));
            Setters.Add(new Setter(Properties.Cursor, Values.Cursor));
            Setters.Add(new Setter(Properties.FontFamily, Values.FontFamily));
            Setters.Add(new Setter(Properties.FontSize, Values.FontSize));
            Setters.Add(new Setter(Properties.Template, Values.Template));
        }
    }
}