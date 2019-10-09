using Android.Widget;
using MediaManager;
using MediaManager.Library;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using Newtonsoft.Json;
using RPNRadio.Core.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace RPNRadio.Core.ViewModels
{
    public class PlayerViewModel : BaseViewModel<IMediaItem>
    {
        public IMediaManager MediaManager { get; }

        public PlayerViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService, IMediaManager mediaManager) : base(logProvider, navigationService)
        {
            MediaManager = mediaManager ?? throw new ArgumentNullException(nameof(mediaManager));
            MediaManager.MediaItemFailed += MediaManager_MediaItemFailed;
        }

        private void MediaManager_MediaItemFailed(object sender, MediaManager.Media.MediaItemFailedEventArgs e)
        {
            Toast.MakeText(Android.App.Application.Context,
                $"Failed to load stream. Station may be offline.",
                ToastLength.Long).Show();
        }

        private IMediaItem _source;
        public IMediaItem Source
        {
            get => _source;
            set => SetProperty(ref _source, value);
        }

        public IList<Metadata> Metadata { get; set; }

        private bool _showControls;
        public bool ShowControls
        {
            get => _showControls;
            set => SetProperty(ref _showControls, value);
        }

        private ImageSource _playPauseImage = ImageSource.FromFile("puase_button_120");
        public ImageSource PlayPauseImage
        {
            get => _playPauseImage;
            set => SetProperty(ref _playPauseImage, value);
        }

        private IMvxCommand _playpauseCommand;
        public IMvxCommand PlayPauseCommand => _playpauseCommand ?? (_playpauseCommand = new MvxCommand(PlayPause));

        public override void Prepare(IMediaItem parameter)
        {
            Source = parameter;

            StationName = parameter.Title;

            SetBannerImage();

            SetMediaLinks();
        }

        private void SetMediaLinks()
        {
            var assembly = Assembly.GetExecutingAssembly();
            Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.Resources.stations.json");

            List<Social> stations;
            using (var reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                var rootobject = JsonConvert.DeserializeObject<RootObject>(json);
                stations = rootobject.social;
            }

            foreach (var s in stations)
            {
                if (s.callsign.ToLower(new CultureInfo("en-US", false)) == StationName.Substring(0, 4).ToLower(new CultureInfo("en-US", false)))
                {
                    FacebookLink = "https://facebook.com/" + s.facebook.id;
                    TwitterLink = "https://twitter.com/" + s.twitter.id;
                    YouTubeLink = "https://youtube.com/channel/" + s.youtube.id;
                }
            }
        }

        private string _twitterLink;

        public string TwitterLink
        {
            get => _twitterLink;
            set => SetProperty(ref _twitterLink, value);
        }

        private string _facebookLink;

        public string FacebookLink
        {
            get => _facebookLink;
            set => SetProperty(ref _facebookLink, value);
        }

        private string _webLink;

        public string WebLink
        {
            get => _webLink;
            set => SetProperty(ref _webLink, value);
        }

        private string _youtubeLink;

        public string YouTubeLink
        {
            get => _youtubeLink;
            set => SetProperty(ref _youtubeLink, value);
        }

        private void SetBannerImage()
        {
            switch (StationName)
            {
                case "DXDX General Santos":
                    BannerImage = ImageSource.FromFile("dxdx_gensan");
                    WebLink = "http://rpnradio.com/dxdx-gensan/";
                    break;
                case "DXKO Cagayan de Oro":
                    BannerImage = ImageSource.FromFile("dxko_cdo");
                    WebLink = "http://rpnradio.com/dxko-cdo/";
                    break;
                default:
                    string[] words = StationName.ToLower(new CultureInfo("en-US", false)).Split(' ');
                    string fileName = string.Join("_", words);
                    string web = string.Join("-", words);
                    BannerImage = ImageSource.FromFile(fileName);
                    WebLink = "http://rpnradio.com/" + web + "/";
                    break;
            }
        }

        private string _stationName;
        public string StationName
        {
            get => _stationName;
            set => SetProperty(ref _stationName, value);
        }

        private ImageSource _bannerImage;
        public ImageSource BannerImage
        {
            get => _bannerImage;
            set => SetProperty(ref _bannerImage, value);
        }

        public override Task Initialize()
        {
            return base.Initialize();
        }

        private void ShowHideControls()
        {
            ShowControls = !ShowControls;
        }

        private async void PlayPause()
        {
            if (MediaManager.IsPlaying())
                PlayPauseImage = ImageSource.FromFile("play_button_120");
            else
                PlayPauseImage = ImageSource.FromFile("pause_button_120");

            await MediaManager.PlayPause();
        }

        private IMvxAsyncCommand _openTwitterCommand;
        public IMvxAsyncCommand OpenTwitterCommand => _openTwitterCommand ?? (_openTwitterCommand = new MvxAsyncCommand(OpenTwitter));

        private async Task OpenTwitter()
        {
            if (!string.IsNullOrEmpty(TwitterLink)) await Browser.OpenAsync(TwitterLink);
        }

        private IMvxAsyncCommand _openFacebookCommand;
        public IMvxAsyncCommand OpenFacebookCommand => _openFacebookCommand ?? (_openFacebookCommand = new MvxAsyncCommand(OpenFacebook));

        private async Task OpenFacebook()
        {
            if (!string.IsNullOrEmpty(FacebookLink)) await Browser.OpenAsync(FacebookLink);
        }

        private IMvxAsyncCommand _openYouTubeCommand;
        public IMvxAsyncCommand OpenYouTubeCommand => _openYouTubeCommand ?? (_openYouTubeCommand = new MvxAsyncCommand(OpenYouTube));

        private async Task OpenYouTube()
        {
            if (!string.IsNullOrEmpty(YouTubeLink)) await Browser.OpenAsync(YouTubeLink);
        }

        private IMvxAsyncCommand _openWebsiteCommand;
        public IMvxAsyncCommand OpenWebsiteCommand => _openWebsiteCommand ?? (_openWebsiteCommand = new MvxAsyncCommand(OpenWebsite));

        private async Task OpenWebsite()
        {
            if (!string.IsNullOrEmpty(WebLink)) await Browser.OpenAsync(WebLink);
        }
    }

    public class Metadata
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

}
