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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace YouTube.Controls.HomePage
{
    public sealed partial class SimpleGridView : UserControl
    {
        public SimpleGridView()
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
            Storyboard b = (Storyboard)FindName("NavigationControlInOut");
            b.Begin();

            var scrollViewer = GridView1.GetFirstDescendantOfType<ScrollViewer>();

            int s = (int)scrollViewer.HorizontalOffset;

            for (int i = s; i < s + 216; i = i+2)
            {
                if(i%5==0)
                await Task.Delay(1);
                scrollViewer.ScrollToHorizontalOffset(i);
            }
        }

        private void GridView1_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            Storyboard b = (Storyboard)FindName("NavigationControlInOut");
            b.Begin();
        }

        private void GridView1_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ItemClick != null)
                ItemClick(this, e);
        }
    }
    
}
