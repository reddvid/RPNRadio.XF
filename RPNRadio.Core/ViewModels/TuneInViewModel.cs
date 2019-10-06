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

namespace RPNRadio.Core.ViewModels
{
    public class TuneInViewModel : BaseViewModel<IPlaylist>
    {
        private IMediaManager _mediaManager;
        public IMediaManager MediaManager { get; }

        public TuneInViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService, IMediaManager mediaManager, IBrowseService browseService) : base(logProvider, navigationService)
        {
            _mediaManager = mediaManager ?? throw new ArgumentNullException(nameof(mediaManager));
            _browseService = browseService ?? throw new ArgumentNullException(nameof(browseService));
        }

         private IMediaItem _selectedMediaItem;
        public IMediaItem SelectedMediaItem
        {
            get => _selectedMediaItem;
            set => SetProperty(ref _selectedMediaItem, value);
        }

        private MvxObservableCollection<IMediaItem> _recentlyPlayedItems = new MvxObservableCollection<IMediaItem>();
        public MvxObservableCollection<IMediaItem> RecentlyPlayedItems
        {
            get => _recentlyPlayedItems;
            set => SetProperty(ref _recentlyPlayedItems, value);
        }

        private IMvxAsyncCommand<IMediaItem> _playerCommand;
        public IMvxAsyncCommand<IMediaItem> PlayerCommand => _playerCommand ?? (_playerCommand = new MvxAsyncCommand<IMediaItem>(Play));

        public override async Task Initialize()
        {
            RecentlyPlayedItems.ReplaceWith(await _browseService.GetMedia());
        }


        private async Task Play(IMediaItem mediaItem)
        {
            await NavigationService.Navigate<PlayerViewModel, IMediaItem>(mediaItem);
            SelectedMediaItem = null;
        }
    }
}
