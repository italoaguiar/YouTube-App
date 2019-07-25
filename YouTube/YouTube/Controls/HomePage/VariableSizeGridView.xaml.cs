using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace YouTube.Controls.HomePage
{
    public sealed partial class VariableSizeGridView : UserControl
    {
        public VariableSizeGridView()
        {
            this.InitializeComponent();
        }
        public event ItemClickEventHandler ItemClick;
        public object ItemsSource
        {
            get { return GridView1.ItemsSource; }
            set { GridView1.ItemsSource = value; }
        }
        public string Title
        {
            get { return txtTitle.Text; }
            set { txtTitle.Text = value; }
        }
        public Image Image
        {
            get { return Img1; }
            set { Img1 = value; }
        }

        private void Button_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
        }

        private void Button_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 1);
        }
        private void LeftSlideGrid()
        {

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var scrollViewer = GridView1.GetFirstDescendantOfType<ScrollViewer>();

            int s = (int)scrollViewer.HorizontalOffset;

            for (int i = s; i > s - 220; i = i - 10)
            {
                await Task.Delay(2);
                scrollViewer.ScrollToHorizontalOffset(i);
            }
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var scrollViewer = GridView1.GetFirstDescendantOfType<ScrollViewer>();

            int s = (int)scrollViewer.HorizontalOffset;

            for (int i = s; i < s + 216; i = i + 2)
            {
                if (i % 5 == 0)
                    await Task.Delay(1);
                scrollViewer.ScrollToHorizontalOffset(i);
            }
        }

        private void GridView1_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ItemClick != null)
                ItemClick(this, e);
        }
    }
    public static class VisualTreeHelperExtensions
    {
        public static T GetFirstDescendantOfType<T>(this DependencyObject start) where T : DependencyObject
        {
            return start.GetDescendantsOfType<T>().FirstOrDefault();
        }

        public static IEnumerable<T> GetDescendantsOfType<T>(this DependencyObject start) where T : DependencyObject
        {
            return start.GetDescendants().OfType<T>();
        }

        public static IEnumerable<DependencyObject> GetDescendants(this DependencyObject start)
        {
            var queue = new Queue<DependencyObject>();
            var count = VisualTreeHelper.GetChildrenCount(start);

            for (int i = 0; i < count; i++)
            {
                var child = VisualTreeHelper.GetChild(start, i);
                yield return child;
                queue.Enqueue(child);
            }

            while (queue.Count > 0)
            {
                var parent = queue.Dequeue();
                var count2 = VisualTreeHelper.GetChildrenCount(parent);

                for (int i = 0; i < count2; i++)
                {
                    var child = VisualTreeHelper.GetChild(parent, i);
                    yield return child;
                    queue.Enqueue(child);
                }
            }
        }

        public static T GetFirstAncestorOfType<T>(this DependencyObject start) where T : DependencyObject
        {
            return start.GetAncestorsOfType<T>().FirstOrDefault();
        }

        public static IEnumerable<T> GetAncestorsOfType<T>(this DependencyObject start) where T : DependencyObject
        {
            return start.GetAncestors().OfType<T>();
        }

        public static IEnumerable<DependencyObject> GetAncestors(this DependencyObject start)
        {
            var parent = VisualTreeHelper.GetParent(start);

            while (parent != null)
            {
                yield return parent;
                parent = VisualTreeHelper.GetParent(parent);
            }
        }

        public static bool IsInVisualTree(this DependencyObject dob)
        {
            return Window.Current.Content != null && dob.GetAncestors().Contains(Window.Current.Content);
        }

        public static Rect GetBoundingRect(this FrameworkElement dob, FrameworkElement relativeTo = null)
        {
            if (relativeTo == null)
            {
                relativeTo = Window.Current.Content as FrameworkElement;
            }

            if (relativeTo == null)
            {
                throw new InvalidOperationException("Element not in visual tree.");
            }

            if (dob == relativeTo)
                return new Rect(0, 0, relativeTo.ActualWidth, relativeTo.ActualHeight);

            var ancestors = dob.GetAncestors().ToArray();

            if (!ancestors.Contains(relativeTo))
            {
                throw new InvalidOperationException("Element not in visual tree.");
            }

            var pos =
                dob
                    .TransformToVisual(relativeTo)
                    .TransformPoint(new Point());
            var pos2 =
                dob
                    .TransformToVisual(relativeTo)
                    .TransformPoint(
                        new Point(
                            dob.ActualWidth,
                            dob.ActualHeight));

            return new Rect(pos, pos2);
        }
    }
    public class VariableSizedGridView : GridView
    {
        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            try
            {
                dynamic localItem = item;
                if (localItem.IsSpecialSize)
                {
                    element.SetValue(VariableSizedWrapGrid.RowSpanProperty, 2);
                    element.SetValue(VariableSizedWrapGrid.ColumnSpanProperty, 2);
                }
            }
            catch
            {
                element.SetValue(VariableSizedWrapGrid.RowSpanProperty, 1);
                element.SetValue(VariableSizedWrapGrid.ColumnSpanProperty, 1);
            }

            base.PrepareContainerForItemOverride(element, item);
        }
    }
    public class VariableSizedStyleSelector : StyleSelector
    {
        public Style NormalStyle { get; set; }
        public Style DoubleHeightStyle { get; set; }

        protected override Style SelectStyleCore(object item, DependencyObject container)
        {
            if (this.NormalStyle == null || this.DoubleHeightStyle == null)
                return base.SelectStyleCore(item, container);

            //if (((Video)item).IsSpecialSize == false)
            //    return NormalStyle;

            //if (((Video)item).IsSpecialSize)
            //    return DoubleHeightStyle;

            return base.SelectStyleCore(item, container);
        }
    }
    public class CustomDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DefaultTemplete { get; set; }
        public DataTemplate CustomTemplate { get; set; }
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;

            //if (element != null && item != null)
            //{
            //    Video taskitem = item as Video;

            //    if (taskitem.IsSpecialSize)
            //        return CustomTemplate;
            //    else
            //        return DefaultTemplete;


            //}
            return null;
        }
    }
}
