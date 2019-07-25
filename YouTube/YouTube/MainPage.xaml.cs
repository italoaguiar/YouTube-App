using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using YouTube.Controls;
using YouTube.Controls.HomePage;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace YouTube
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            SetContent(new HomePage());
        }
        public void SetContent(UIElement u)
        {
            MainContent.ContentUser = u;
        }
        private void SearchBox_Click(object sender, EventArgs e)
        {
            SearchListControl srch = new SearchListControl();
            srch.Search(SearchFieldControl.Text);
            MainContent.ContentUser = srch;            
        }
        public UserMenu LoginControl
        {
            get { return loginMenu; }
        }
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Back();
        }
    }
}
