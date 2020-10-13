using System;
using Autofac;
using TextBoxGenerationTool.Navigation;
using TextBoxGenerationTool.Pages;
using TextBoxGenerationTool.Services;
using TextBoxGenerationTool.ViewModels;

namespace TextBoxGenerationTool
{
    public static class IoC
    {
        public static IContainer _container;

        public static void Publish(this ContainerBuilder builder)
        {
            _container = builder.Build();
        }

        public static void RegisterCoreDependencies(this ContainerBuilder builder)
        {
            builder.RegisterType<MainViewModel>();
            builder.RegisterType<TextBoxViewModel>();

            // pages
            builder.RegisterType<TextBoxPage>();

            // services
            builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
            builder.RegisterType<RestService>().As<IRestService>().SingleInstance();
            builder.RegisterType<DialogService>().As<IDialogService>().SingleInstance();
        }

        public static T Resolve<T>() => _container.Resolve<T>();

        public static object Resolve(Type serviceType) => _container.Resolve(serviceType);
    }
}
