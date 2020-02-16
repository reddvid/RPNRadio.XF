using Acr.UserDialogs;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using RPNRadio.Core.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RPNRadio.Core.ViewModels
{
    public class NewsFeedViewModel : BaseViewModel
    {

        public NewsFeedViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService) : base(logProvider, navigationService)
        {
            Title = "News Feed";
        }

        public MvxObservableCollection<NewsItem> NewsItems { get; set; } = new MvxObservableCollection<NewsItem>();

        private NewsItem _selectedNewsItem;
        public NewsItem SelectedNewsItem
        {
            get => _selectedNewsItem;
            set => SetProperty(ref _selectedNewsItem, value);
        }

        private IMvxAsyncCommand<NewsItem> _readCommand;
        public IMvxAsyncCommand<NewsItem> ReadCommand => _readCommand ?? (_readCommand = new MvxAsyncCommand<NewsItem>(ReadNews));

        private IMvxAsyncCommand _reloadNewsCommand;
        public IMvxAsyncCommand ReloadNewsCommand => _reloadNewsCommand ?? (_reloadNewsCommand = new MvxAsyncCommand(ReloadNews));

        private static IUserDialogs _userDialogs => UserDialogs.Instance;

        public override async Task Initialize()
        {
            IsLoading = true;

            var result = ReloadNews().GetAwaiter();

            await _userDialogs.ConfirmAsync(result.ToString());

            IsLoading = false;
        }

        public override void ViewAppearing()
        {
            Title = "News Feed";

            base.ViewAppearing();
        }

        public override void ViewAppeared()
        {
            base.ViewAppeared();
        }

        public override void ViewDisappeared()
        {
            base.ViewDisappeared();
        }

        public override void ViewDisappearing()
        {
            base.ViewDisappearing();
        }

        private async Task ReadNews(NewsItem newsItem)
        {
            await NavigationService.Navigate<ReadingViewModel, NewsItem>(_selectedNewsItem);
            _selectedNewsItem = null;
        }

        private bool _isRefreshing;

        public bool IsRefreshing
        {
            get => _isRefreshing;
            set => SetProperty(ref _isRefreshing, value);
        }


        private async Task ReloadNews()
        {
            IsLoading = IsRefreshing = true;

            var httpClient = new HttpClient();
            XNamespace nsContent = "http://purl.org/rss/1.0/modules/content/";
            var feed = "http://rpnradio.com/category/provincial-news/feed/";
            var responseString = await httpClient.GetStringAsync(feed);

            if (responseString != null)
            {
                NewsItems.Clear();
                var items = await ParseFeed(responseString);
                for (int i = 0; i < items.Count; i++)
                {
                    NewsItem item = items[i];
                    NewsItems.Add(item);
                }
            }

            IsLoading = IsRefreshing = false;
        }



        private async Task<List<NewsItem>> ParseFeed(string rss)
        {
            return await Task.Run(() =>
            {
                var xdoc = XDocument.Parse(rss);
                XNamespace nsContent = "http://purl.org/rss/1.0/modules/content/";
                return (from item in xdoc.Descendants("item")
                        select new NewsItem
                        {
                            Title = (string)item.Element("title"),
                            Content = (string)item.Element("{http://purl.org/rss/1.0/modules/content/}encoded"),
                            Author = (string)item.Element("category"),
                            Link = (string)item.Element("link"),
                            Date = (string)item.Element("pubDate"),
                            ImagePath = GetImagePath((string)item.Element("description")).Replace("?resize=150%2c150", string.Empty).Replace("?resize=150%2C150", string.Empty).Replace("-150x150", string.Empty),
                            ThumbPath = GetImagePath((string)item.Element("description"))
                        }).Take(35).ToList();               
            });
        }

        private string GetImagePath(string text)
        {
            string path = string.Empty;

            int _start, _end;
            string start = "src=\"";
            string end = "\" class=\"";
            if (text.Contains(start) && text.Contains(end))
            {
                _start = text.IndexOf(start, 0) + start.Length;
                _end = text.IndexOf(end, _start);
                path = text.Substring(_start, _end - _start);
            }

            return path;
        }

    }
}
