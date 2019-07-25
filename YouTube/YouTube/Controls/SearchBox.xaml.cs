using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

namespace YouTube.Controls
{
    public sealed partial class SearchBox : UserControl
    {
        public SearchBox()
        {
            this.InitializeComponent();
            
        }
        public event EventHandler Click;
        private void click()
        {
            if (Click != null)
            {
                Click(this, null);
            }
        }
        public string Text
        {
            get { return SearchBoxField.Text; }
            set { SearchBoxField.Text = value; }
        }
        public int Largura
        {
            set
            {
                SearchBoxField.Width = value;
            }
        }
        public void Focus()
        {
            SearchBoxField.Focus(FocusState.Pointer);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            click();
        }

        private void SearchBoxField_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                click();
            }
        }
    }
}
