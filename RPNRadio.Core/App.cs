using MediaManager;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.Localization;
using MvvmCross.ViewModels;
using RPNRadio.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPNRadio.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {  
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            Mvx.IoCProvider.RegisterSingleton<IMediaManager>(CrossMediaManager.Current);
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IBrowseService, BrowseService>();                     

            RegisterCustomAppStart<AppStart>();

        }
    }
}
