using MediaManager;
using MediaManager.Library;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RPNRadio.Core.ViewModels
{
    public class ControlsViewModel : BaseViewModel
    {
        public IMediaManager MediaManager { get; }

        public ControlsViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService, IMediaManager mediaManager) : base(logProvider, navigationService)
        {
            MediaManager = mediaManager ?? throw new ArgumentNullException(nameof(mediaManager));
        }

        private ImageSource _playPauseImage = "baseline_pause_24";
        public ImageSource PlayPauseImage
        {
            get => _playPauseImage;
            set => SetProperty(ref _playPauseImage, value);
        }

        private bool _isPlaying;
        public bool IsPlaying
        {
            get => _isPlaying;
            set => SetProperty(ref _isPlaying, value);
        }

        private FormattedString _currentStationText;
        public FormattedString CurrentStationText
        {
            get
            {
                var currentMediaItemText = new FormattedString();
                if (MediaManager.Queue.Current != null)
                {
                    currentMediaItemText.Spans.Add(new Span { Text = MediaManager.Queue.Current.Title, FontAttributes = FontAttributes.Bold, FontSize = 12 });
                }
                else
                    currentMediaItemText.Spans.Add(new Span { Text = "RPN Radio" });

                _currentStationText = currentMediaItemText;
                return currentMediaItemText;
            }
            set => SetProperty(ref _currentStationText, value);
        }

        public IMediaItem CurrentlyPlaying
        {
            get
            {
                var currentlyPlaying = MediaManager.Queue.Current;
                if (currentlyPlaying != null)
                    return currentlyPlaying;
                else
                    return new MediaItem();
            }
        }

        private IMvxAsyncCommand _playpauseCommand;
        public IMvxAsyncCommand PlayPauseCommand => _playpauseCommand ?? (_playpauseCommand = new MvxAsyncCommand(PlayPause));

        private IMvxAsyncCommand _openPlayerCommand;
        public IMvxAsyncCommand OpenPlayerCommand => _openPlayerCommand ?? (_openPlayerCommand = new MvxAsyncCommand(OpenPlayer));

        public override Task Initialize()
        {
            return base.Initialize();
        }

        public override void ViewAppearing()
        {
            base.ViewAppearing();

            if (MediaManager.IsPlaying())
                PlayPauseImage = ImageSource.FromFile("baseline_play_arrow_24");
            else
                PlayPauseImage = ImageSource.FromFile("baseline_pause_24");

            RaisePropertyChanged(nameof(CurrentStationText));
        }

        public override void ViewAppeared()
        {
            base.ViewAppeared();
        }

        public override void ViewDisappeared()
        {
            base.ViewDisappeared();
        }

        private async Task PlayPause()
        {
            if (MediaManager.IsPlaying())
                PlayPauseImage = ImageSource.FromFile("baseline_play_arrow_24");
            else
                PlayPauseImage = ImageSource.FromFile("baseline_pause_24");

            await MediaManager.PlayPause();
        }

        private async Task OpenPlayer()
        {
            await NavigationService.Navigate<PlayerViewModel>();
        }
    }
}
