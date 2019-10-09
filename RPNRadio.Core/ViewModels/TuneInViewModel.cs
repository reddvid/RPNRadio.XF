using MediaManager;
using MediaManager.Library;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using RPNRadio.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RPNRadio.Core.ViewModels
{
    public class TuneInViewModel : BaseViewModel
    {
        private readonly IMediaManager _mediaManager;
        private readonly IBrowseService _browseService;

        public TuneInViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService, IMediaManager mediaManager, IBrowseService browseService) : base(logProvider, navigationService)
        {
            _mediaManager = mediaManager ?? throw new ArgumentNullException(nameof(mediaManager));
            _browseService = browseService ?? throw new ArgumentNullException(nameof(browseService));
        }

        private IMediaItem _selectedMediaItem;
        public IMediaItem SelectedMediaItem
        {
            get => _selectedMediaItem;
            set 
            {
                SetProperty(ref _selectedMediaItem, value);
            }
        }

        private MvxObservableCollection<IMediaItem> _recentlyPlayedItems = new MvxObservableCollection<IMediaItem>();
        public MvxObservableCollection<IMediaItem> RecentlyPlayedItems
        {
            get => _recentlyPlayedItems;
            set => SetProperty(ref _recentlyPlayedItems, value);
        }

        private bool _isInitialized;
        public override async void ViewAppearing()
        {
            base.ViewAppearing();

            if (_isInitialized)
                await ReloadData().ConfigureAwait(false);

            IsPlaying = _mediaManager.Queue.Count > 0;

            _isInitialized = true;
        }

        private FormattedString _currentStationText;
        public FormattedString CurrentStationText
        {
            get
            {
                var currentMediaItemText = new FormattedString();
                if (_mediaManager.Queue.Current != null)
                {
                    currentMediaItemText.Spans.Add(new Span { Text = _mediaManager.Queue.Current.Title, FontAttributes = FontAttributes.Bold, FontSize = 12 });
                }
                else
                    currentMediaItemText.Spans.Add(new Span { Text = "RPN Radio" });

                _currentStationText = currentMediaItemText;
                return currentMediaItemText;
            }
            set => SetProperty(ref _currentStationText, value);
        }


        private IMvxAsyncCommand<IMediaItem> _playerCommand;
        public IMvxAsyncCommand<IMediaItem> PlayerCommand => _playerCommand ?? (_playerCommand = new MvxAsyncCommand<IMediaItem>(Play));

        public override async Task Initialize()
        {
            RecentlyPlayedItems.ReplaceWith(await _browseService.GetMedia());
        }

        private bool _isPlaying;
        public bool IsPlaying
        {
            get => _isPlaying;
            set => SetProperty(ref _isPlaying, value);
        }

        private string _stationText;

        public string CurrentStation
        {
            get => _stationText;
            set => SetProperty(ref _stationText, value);
        }

        private async Task Play(IMediaItem mediaItem)
        {
            CurrentStation = mediaItem.Title.ToUpper();
            await NavigationService.Navigate<PlayerViewModel, IMediaItem>(mediaItem);
            SelectedMediaItem = null;
        }

        ///
        ///

        private ImageSource _playPauseImage = "pause_button_60";
        public ImageSource PlayPauseImage
        {
            get => _playPauseImage;
            set => SetProperty(ref _playPauseImage, value);
        }

        public IMediaItem CurrentlyPlaying
        {
            get
            {
                var currentlyPlaying = _mediaManager.Queue.Current;
                if (currentlyPlaying != null)
                    return currentlyPlaying;
                else
                    return new MediaItem();
            }
        }

        private IMvxAsyncCommand _playpauseCommand;
        public IMvxAsyncCommand PlayPauseCommand => _playpauseCommand ?? (_playpauseCommand = new MvxAsyncCommand(PlayPause));


        private async Task PlayPause()
        {
            if (_mediaManager.IsPlaying())
                PlayPauseImage = ImageSource.FromFile("play_button_60");
            else
                PlayPauseImage = ImageSource.FromFile("pause_button_60");

            await _mediaManager.PlayPause();
        }


    }
}
