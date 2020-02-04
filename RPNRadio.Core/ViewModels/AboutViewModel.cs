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
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService) : base(logProvider, navigationService)
        {
          
        }

        private IMvxAsyncCommand<string> _openLinkCommand;
        public IMvxAsyncCommand<string> OpenLinkCommand => _openLinkCommand ?? (_openLinkCommand = new MvxAsyncCommand<string>(OpenCommand));

        private async Task OpenCommand(string arg)
        {
            await Browser.OpenAsync(arg);
        }

        private IMvxAsyncCommand _followCommand;
        public IMvxAsyncCommand FollowCommand => _followCommand ?? (_followCommand = new MvxAsyncCommand(FollowOnTwitter));

        private IMvxAsyncCommand _reportCommand;
        public IMvxAsyncCommand ReportCommand => _reportCommand ?? (_reportCommand = new MvxAsyncCommand(ReportProblem));

        private async Task ReportProblem()
        {
            await Launcher.TryOpenAsync(new Uri("mailto:feedback@reddvid.xyz?SUBJECT=[FEEDBACK - RPN News & Radio for Android]"));
        }

        private async Task FollowOnTwitter()
        {
            await Browser.OpenAsync("https://twitter.com/reddvid/");
        }
    }
}
