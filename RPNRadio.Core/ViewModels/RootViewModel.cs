using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RPNRadio.Core.ViewModels
{
    public class RootViewModel : BaseViewModel
    {
        public RootViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService) : base(logProvider, navigationService)
        {
            ShowInitialViewModelsCommand = new MvxAsyncCommand(ShowInitialViewModels);
        }

        private string _title;
        public new string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public IMvxAsyncCommand ShowInitialViewModelsCommand { get; private set; }

        private async Task ShowInitialViewModels()
        {
            var tasks = new List<Task>();
            tasks.Add(NavigationService.Navigate<TuneInViewModel>());
            tasks.Add(NavigationService.Navigate<NewsFeedViewModel>());
            tasks.Add(NavigationService.Navigate<AboutViewModel>());
            await Task.WhenAll(tasks);
        }
    }
}
