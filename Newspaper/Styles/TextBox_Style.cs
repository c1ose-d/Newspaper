using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using static Newspaper.Properties.Resources;

namespace Newspaper.Styles
{
    internal class TextBox_Style : Style
    {
        private readonly struct Values
        {
            public readonly struct Static
            {
                public static SolidColorBrush Background { get; } = Primary;
                public static SolidColorBrush BorderBrush { get; } = Black;
                public static SolidColorBrush Foreground { get; } = Black;
            }
            public readonly struct MouseOver
            {
                public static SolidColorBrush BorderBrush { get; } = Secondary;
            }
            public readonly struct Focused
            {
                public static SolidColorBrush BorderBrush { get; } = Accent;
            }
            public static SolidColorBrush CaretBrush { get; } = Accent;
            public static double MinWidth { get; } = 300;
            public static double MaxWidth { get; } = 300;
            public static double MinHeight { get; } = 0;
            public static Thickness Margin { get; } = new Thickness(10, 5, 10, 5);
            public static Thickness Padding { get; } = new Thickness(10, 0, 10, 0);
            public static Thickness BorderThickness { get; } = new Thickness(1);
            public static KeyboardNavigationMode TabNavigation { get; } = KeyboardNavigationMode.None;
            public static HorizontalAlignment HorizontalContentAlignment { get; } = HorizontalAlignment.Left;
            public static VerticalAlignment VerticalContentAlignment { get; } = VerticalAlignment.Center;
            public static Style? FocusVisualStyle { get; } = null;
            public static bool AllowDrop { get; } = true;
            public static PanningMode PanningMode { get; } = PanningMode.VerticalFirst;
            public static bool IsFlicksEnabled { get; } = false;
            public static FontFamily FontFamily { get; } = Newspaper.Properties.Resources.FontFamily;
            public static double FontSize { get; } = 16;
            public static ControlTemplate Template { get; } = new TemplateValue();

            private class TemplateValue : ControlTemplate
            {
                private static FrameworkElementFactory Border { get; } = new(typeof(Border), "border");
                private static FrameworkElementFactory PART_ContentHost { get; } = new(typeof(ScrollViewer), "PART_ContentHost");

                private struct Values
                {
                    public readonly struct Border
                    {
                        public static SolidColorBrush Background { get; } = Static.Background;
                        public static SolidColorBrush BorderBrush { get; } = Static.BorderBrush;
                        public static Thickness BorderThickness { get; } = TextBox_Style.Values.BorderThickness;
                        public static bool SnapsToDevicePixels { get; } = true;
                        public static CornerRadius CornerRadius { get; } = new CornerRadius(10);
                    }

                    public readonly struct PART_ContentHost
                    {
                        public static bool Focusable { get; } = false;
                        public static ScrollBarVisibility HorizontalScrollBarVisibility { get; } = ScrollBarVisibility.Hidden;
                        public static ScrollBarVisibility VerticalScrollBarVisibility { get; } = ScrollBarVisibility.Hidden;
                    }

                    public readonly struct Trigger
                    {
                        public static string BorderTargetName { get; } = TemplateValue.Border.Name;
                        public static string PART_ContentHostTargetName { get; } = TemplateValue.PART_ContentHost.Name;
                        public static double Opacity { get; } = 0.56;
                    }
                }

                public TemplateValue()
                {
                    TargetType = typeof(TextBox);

                    PART_ContentHost.SetValue(Properties.Focusable, Values.PART_ContentHost.Focusable);
                    PART_ContentHost.SetValue(Properties.HorizontalScrollBarVisibility, Values.PART_ContentHost.HorizontalScrollBarVisibility);
                    PART_ContentHost.SetValue(Properties.VerticalScrollBarVisibility, Values.PART_ContentHost.VerticalScrollBarVisibility);

                    Border.SetValue(Properties.Background, Values.Border.Background);
                    Border.SetValue(Properties.BorderBrush, Values.Border.BorderBrush);
                    Border.SetValue(Properties.BorderThickness, Values.Border.BorderThickness);
                    Border.SetValue(Properties.SnapsToDevicePixels, Values.Border.SnapsToDevicePixels);
                    Border.SetValue(Properties.CornerRadius, Values.Border.CornerRadius);
                    Border.AppendChild(PART_ContentHost);

                    VisualTree = Border;

                    Trigger isEnabled = new() { Property = Properties.IsEnabled, Value = false };
                    isEnabled.Setters.Add(new Setter(Properties.Opacity, Values.Trigger.Opacity, Values.Trigger.BorderTargetName));
                    Triggers.Add(isEnabled);

                    Trigger isMouseOver = new() { Property = Properties.IsMouseOver, Value = true };
                    isMouseOver.Setters.Add(new Setter(Properties.BorderBrush, MouseOver.BorderBrush, Values.Trigger.BorderTargetName));
                    Triggers.Add(isMouseOver);

                    Trigger isFocused = new() { Property = Properties.IsFocused, Value = true };
                    isFocused.Setters.Add(new Setter(Properties.BorderBrush, Focused.BorderBrush, Values.Trigger.BorderTargetName));
                    Triggers.Add(isFocused);

                    MultiTrigger multiTrigger = new();
                    multiTrigger.Conditions.Add(new Condition(Properties.IsInactiveSelectionHighlightEnabled, true));
                    multiTrigger.Conditions.Add(new Condition(Properties.IsSelectionActive, false));
                    multiTrigger.Setters.Add(new Setter(Properties.BorderBrush, Static.BorderBrush));
                    Triggers.Add(multiTrigger);
                }
            }
        }

        public TextBox_Style()
        {
            TargetType = typeof(TextBox);

            Setters.Add(new Setter(Properties.Background, Values.Static.Background));
            Setters.Add(new Setter(Properties.BorderBrush, Values.Static.BorderBrush));
            Setters.Add(new Setter(Properties.Foreground, Values.Static.Foreground));
            Setters.Add(new Setter(Properties.CaretBrush, Values.CaretBrush));
            Setters.Add(new Setter(Properties.MinWidth, Values.MinWidth));
            Setters.Add(new Setter(Properties.MaxWidth, Values.MaxWidth));
            Setters.Add(new Setter(Properties.MinHeight, Values.MinHeight));
            Setters.Add(new Setter(Properties.Margin, Values.Margin));
            Setters.Add(new Setter(Properties.Padding, Values.Padding));
            Setters.Add(new Setter(Properties.BorderThickness, Values.BorderThickness));
            Setters.Add(new Setter(Properties.TabNavigation, Values.TabNavigation));
            Setters.Add(new Setter(Properties.HorizontalContentAlignment, Values.HorizontalContentAlignment));
            Setters.Add(new Setter(Properties.VerticalContentAlignment, Values.VerticalContentAlignment));
            Setters.Add(new Setter(Properties.FocusVisualStyle, Values.FocusVisualStyle));
            Setters.Add(new Setter(Properties.AllowDrop, Values.AllowDrop));
            Setters.Add(new Setter(Properties.PanningMode, Values.PanningMode));
            Setters.Add(new Setter(Properties.IsFlicksEnabled, Values.IsFlicksEnabled));
            Setters.Add(new Setter(Properties.FontFamily, Values.FontFamily));
            Setters.Add(new Setter(Properties.FontSize, Values.FontSize));
            Setters.Add(new Setter(Properties.FontSize, Values.FontSize));
            Setters.Add(new Setter(Properties.Template, Values.Template));
        }
    }
}