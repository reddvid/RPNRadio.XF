using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using RPNRadio.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RPNRadio.Core.ViewModels
{
    public class ReadingViewModel : BaseViewModel<NewsItem>
    {
        public ReadingViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService) : base(logProvider, navigationService)
        {

        }

        private NewsItem _source;
        public NewsItem Source
        {
            get => _source;
            set => SetProperty(ref _source, value);
        }

        public override void Prepare(NewsItem p)
        {
            Source = p;
        }

        private IMvxAsyncCommand _shareNewsItemCommand;
        public IMvxAsyncCommand ShareNewsItemCommand => _shareNewsItemCommand ?? (_shareNewsItemCommand = new MvxAsyncCommand(ShareNewsItem));

        private IMvxAsyncCommand _openNewsInBrowserCommand;
        public IMvxAsyncCommand OpenNewsInBrowserCommand => _openNewsInBrowserCommand ?? (_openNewsInBrowserCommand = new MvxAsyncCommand(OpenInBrowser));

        private async Task OpenInBrowser()
        {
            await Browser.OpenAsync(Source.Link);
        }
        private async Task ShareNewsItem()
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Uri = Source.Link,
                Title = "Share " + Source.Author,
                Text = String.Format("{0}\n#RPNRadyoRonda #{1}\n\n", Source.Title, Source.Author.Replace(" ", string.Empty)),
                Subject = "Latest news from " + Source.Author.Replace(" News", string.Empty)
            });
        }
    }
}
