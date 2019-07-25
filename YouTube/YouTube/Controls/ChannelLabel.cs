using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace YouTube.Controls
{
    public class ChannelLabel: HyperlinkButton
    {
        public ChannelLabel()
            : base()
        {
            Click += ChannelLabel_Click;
        }

        void ChannelLabel_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var frame = (Frame)Window.Current.Content;
            var page = (MainPage)frame.Content;

            if(!string.IsNullOrEmpty(ChannelId))
                page.SetContent(new Channel(ChannelId));
        }
        public static readonly DependencyProperty ChannelIdProperty = DependencyProperty.Register("ChannelId", typeof(string), typeof(ChannelLabel), new PropertyMetadata(false));

        
        public string ChannelId
        {
            get { return (string)GetValue(ChannelIdProperty); }
            set { SetValue(ChannelIdProperty, value); }
        }
        
    }
    
}
