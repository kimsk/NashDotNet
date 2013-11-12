using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using CaliburnMicroPcl;

namespace CaliburnMicroPhoneApp
{
    public class PhoneBootstrapper : PhoneBootstrapperBase
    {
        PhoneContainer _container;

        public PhoneBootstrapper()
        {
            LogManager.GetLog = type => new DebugLog();
            Start();
        }

        protected override void Configure()
        {
            _container = new PhoneContainer();

            _container.RegisterPhoneServices(RootFrame);

            _container.PerRequest<HomePageViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
    }
}
