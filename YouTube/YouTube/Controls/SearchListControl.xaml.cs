using DataBinding;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using YouTubeControls.GoogleAPI.YouTube.Video;
using YouTubeControls.GoogleAPI.YouTube.Video.Entries;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace YouTube.Controls
{
    public sealed partial class SearchListControl : UserControl
    {
        public SearchListControl()
        {
            this.InitializeComponent();
        }

        
        public void Search(string q)
        {           

           try
            {
                var v = new GeneratorIncrementalLoadingClass<Entry>(200, q, (count) => { return new Entry(); });
                itemListView.ItemsSource = v;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }

        }
        public void Clear()
        {
            itemListView.ItemsSource = null;
        }
        private void itemListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frame = (Frame)Window.Current.Content;
            var page = (MainPage)frame.Content;

            page.SetContent(new ViewVideo((e.ClickedItem as Entry)));
        }
    }
    public class GeneratorIncrementalLoadingClass<T> : IncrementalLoadingBase
    {
        public GeneratorIncrementalLoadingClass(uint maxCount, string query, Func<int, T> generator)
        {
            _generator = generator;
            _maxCount = maxCount;
            this.qry = query;
        }

        protected async override Task<IList<object>> LoadMoreItemsOverrideAsync(System.Threading.CancellationToken c, uint count)
        {
            try
            {
                uint toGenerate = System.Math.Min(count, _maxCount - _count);

                Video video = new Video();


                // This code simply generates
                var data = await video.Search(new SearchParameters() { q = qry, start_index = (_count + 1).ToString() });

                List<object> o = new List<object>();
                foreach (Entry v in data.feed.entry)
                {
                    o.Add(v);
                }
                if (data != null)
                    _count += (uint)data.feed.entry.Count;
                return o;
            }
            catch { return null; }
        }

        protected override bool HasMoreItemsOverride()
        {
            return _count < _maxCount;
        }

        #region State

        Func<int, T> _generator;
        uint _count = 0;
        uint _maxCount;
        string qry;

        #endregion
    }
}
