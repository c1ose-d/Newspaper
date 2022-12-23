using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Shapes;

namespace Newspaper.Styles
{
    internal readonly struct Properties
    {
        public static DependencyProperty AllowDrop { get; } = UIElement.AllowDropProperty;
        public static DependencyProperty Background { get; } = Control.BackgroundProperty;
        public static DependencyProperty BorderBrush { get; } = Control.BorderBrushProperty;
        public static DependencyProperty BorderThickness { get; } = Control.BorderThicknessProperty;
        public static DependencyProperty CaretBrush { get; } = TextBoxBase.CaretBrushProperty;
        public static DependencyProperty CornerRadius { get; } = Border.CornerRadiusProperty;
        public static DependencyProperty Cursor { get; } = FrameworkElement.CursorProperty;
        public static DependencyProperty Focusable { get; } = UIElement.FocusableProperty;
        public static DependencyProperty FocusVisualStyle { get; } = FrameworkElement.FocusVisualStyleProperty;
        public static DependencyProperty FontFamily { get; } = Control.FontFamilyProperty;
        public static DependencyProperty FontSize { get; } = Control.FontSizeProperty;
        public static DependencyProperty Foreground { get; } = Control.ForegroundProperty;
        public static DependencyProperty HorizontalAlignment { get; } = FrameworkElement.HorizontalAlignmentProperty;
        public static DependencyProperty HorizontalContentAlignment { get; } = Control.HorizontalContentAlignmentProperty;
        public static DependencyProperty HorizontalScrollBarVisibility { get; } = ScrollViewer.HorizontalScrollBarVisibilityProperty;
        public static DependencyProperty IsDefaulted { get; } = Button.IsDefaultedProperty;
        public static DependencyProperty IsEnabled { get; } = UIElement.IsEnabledProperty;
        public static DependencyProperty IsFlicksEnabled { get; } = Stylus.IsFlicksEnabledProperty;
        public static DependencyProperty IsFocused { get; } = UIElement.IsFocusedProperty;
        public static DependencyProperty IsInactiveSelectionHighlightEnabled { get; } = TextBoxBase.IsInactiveSelectionHighlightEnabledProperty;
        public static DependencyProperty IsMouseOver { get; } = UIElement.IsMouseOverProperty;
        public static DependencyProperty IsPressed { get; } = ButtonBase.IsPressedProperty;
        public static DependencyProperty IsSelectionActive { get; } = TextBoxBase.IsSelectionActiveProperty;
        public static DependencyProperty Margin { get; } = FrameworkElement.MarginProperty;
        public static DependencyProperty MaxWidth { get; } = FrameworkElement.MaxWidthProperty;
        public static DependencyProperty MinHeight { get; } = FrameworkElement.MinHeightProperty;
        public static DependencyProperty MinWidth { get; } = FrameworkElement.MinWidthProperty;
        public static DependencyProperty Opacity { get; } = UIElement.OpacityProperty;
        public static DependencyProperty Padding { get; } = Control.PaddingProperty;
        public static DependencyProperty PanningMode { get; } = ScrollViewer.PanningModeProperty;
        public static DependencyProperty RecognizesAccessKey { get; } = ContentPresenter.RecognizesAccessKeyProperty;
        public static DependencyProperty SnapsToDevicePixels { get; } = UIElement.SnapsToDevicePixelsProperty;
        public static DependencyProperty Stroke { get; } = Shape.StrokeProperty;
        public static DependencyProperty StrokeDashArray { get; } = Shape.StrokeDashArrayProperty;
        public static DependencyProperty StrokeThickness { get; } = Shape.StrokeThicknessProperty;
        public static DependencyProperty TabNavigation { get; } = KeyboardNavigation.TabNavigationProperty;
        public static DependencyProperty Template { get; } = Control.TemplateProperty;
        public static DependencyProperty VerticalAlignment { get; } = FrameworkElement.VerticalAlignmentProperty;
        public static DependencyProperty VerticalContentAlignment { get; } = Control.VerticalContentAlignmentProperty;
        public static DependencyProperty VerticalScrollBarVisibility { get; } = ScrollViewer.VerticalScrollBarVisibilityProperty;

    }
}