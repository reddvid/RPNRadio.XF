using MediaManager;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.Localization;
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
            Mvx.IoCProvider.RegisterSingleton<IMediaManager>(CrossMediaManager.Current);

            //// Register Text provider
            //var textProviderBuilder = new TextProviderBuilder();
            //Mvx.IoCProvider.RegisterSingleton<IMvxTextProviderBuilder>(textProviderBuilder);
            //Mvx.IoCProvider.RegisterSingleton<IMvxTextProvider>(textProviderBuilder.TextProvider);

            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterCustomAppStart<AppStart>();

        }
    }
}
