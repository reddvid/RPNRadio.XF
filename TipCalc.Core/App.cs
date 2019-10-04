using TipCalc.Core.Services;
using TipCalc.Core.ViewModels;
using MvvmCross;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.IoC;

namespace TipCalc.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                  .EndingWith("Service")
                  .AsInterfaces()
                  .RegisterAsLazySingleton();

            Mvx.IoCProvider.RegisterType<ICalculationService, CalculationService>();

            RegisterAppStart<TipViewModel>();
        }
    }
}
