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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace YouTube.Controls
{
    public sealed partial class ContentControl : UserControl
    {
        public ContentControl()
        {
            this.InitializeComponent();
            history = new List<object>();
        }
        private List<object> history;
        public void Back()
        {
            if (history.Count > 1)
            {
                UserContent.Content = history[history.Count - 2];
                history.RemoveAt(history.Count - 1);
            }
        }
        
        public object ContentUser
        {
            get { return UserContent.Content; }
            set 
            { 
                UserContent.Content = value;
                history.Add(value);
            }
        }
    }
}
