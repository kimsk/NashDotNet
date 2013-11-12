using System;
using System.Collections.Generic;
using Windows.ApplicationModel.Activation;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Caliburn.Micro;
using InstantBingo.Logging;
using InstantBingo.Models;
using InstantBingo.Views;
using InstantBingo.ViewModels;

namespace InstantBingo
{
    sealed partial class App
    {
        private WinRTContainer _container;

        public App()
        {
            InitializeComponent();            
        }

        protected override void Configure()
        {
            // set logger
            // TODO: demo customization only
            LogManager.GetLog = type => new DebugLog();

            _container = new WinRTContainer();
            _container.RegisterWinRTServices();

            // all are singleton, so they won't be recreated
            _container.Singleton<MainViewModel>()
                .Singleton<PatternsViewModel>()
                .Singleton<SoundViewModel>()
                .Singleton<BingoCardViewModel>()
                .Singleton<BallCallsViewModel>()
                .Singleton<PlayerInfoViewModel>()
                .PerRequest<PatternCountViewModel>();

            // need this to allow sharing
            _container.RegisterSharingService();

            // avoid static class
            _container.RegisterInstance(typeof(Bookkeeper), "Bookkeeper", new Bookkeeper(_container.GetInstance<IEventAggregator>()));

            PrepareSettings();
        }

        private void PrepareSettings()
        {
            _container.Singleton<OptionsViewModel>();

            var viewSettings = new Dictionary<string, object>
            {
                {"width", 400},
                {"headerbackground", new SolidColorBrush(Colors.Blue)}
            };

            var settings = _container.RegisterSettingsService();
            settings.RegisterFlyoutCommand<OptionsViewModel>("Options", viewSettings);
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override void PrepareViewFirst(Frame rootFrame)
        {
            _container.RegisterNavigationService(rootFrame);
        }        

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {            
            DisplayRootView<MainView>();            
        }
    }
}
