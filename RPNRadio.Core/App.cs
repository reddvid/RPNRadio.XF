using MvvmCross;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPNRadio.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            //Mvx.IoCProvider.RegisterSingleton<IMediaManager>(CrossMediaManager.Current);

            //FFImageLoading.ImageService.Instance.Initialize();

            RegisterCustomAppStart<AppStart>();

        }
    }
}
