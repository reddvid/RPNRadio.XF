using MediaManager;
using MediaManager.Library;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RPNRadio.Core.ViewModels
{
    public class PlayerViewModel : BaseViewModel<IMediaItem>
    {
        public IMediaManager MediaManager { get; }

        public PlayerViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService, IMediaManager mediaManager) : base(logProvider, navigationService)
        {
            MediaManager = mediaManager ?? throw new ArgumentNullException(nameof(mediaManager));
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

        private ImageSource _playPauseImage = ImageSource.FromFile("baseline_pause_24");
        public ImageSource PlayPauseImage
        {
            get => _playPauseImage;
            set => SetProperty(ref _playPauseImage, value);
        }

        private IMvxAsyncCommand _playpauseCommand;
        public IMvxAsyncCommand PlayPauseCommand => _playpauseCommand ?? (_playpauseCommand = new MvxAsyncCommand(PlayPause));

        public override void Prepare(IMediaItem parameter)
        {
            Source = parameter;
        }

        public override Task Initialize()
        {
            return base.Initialize();
        }

        private void ShowHideControls()
        {
            ShowControls = !ShowControls;
        }

        private async Task PlayPause()
        {
            if (MediaManager.IsPlaying())
                PlayPauseImage = ImageSource.FromFile("baseline_play_arrow_24");
            else
                PlayPauseImage = ImageSource.FromFile("baseline_pause_24");

            await MediaManager.PlayPause();
        }
    }

    public class Metadata
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

}
