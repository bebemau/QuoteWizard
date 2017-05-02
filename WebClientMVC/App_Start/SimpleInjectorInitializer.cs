[assembly: WebActivator.PostApplicationStartMethod(typeof(WebClientMVC.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace WebClientMVC.App_Start
{
    using System.Reflection;
    using System.Web.Mvc;

    using SimpleInjector;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    using CommonUtilities.APIHelpers;
    using CommonUtilities;

    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            
            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            
            container.Verify();
            
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
     
        private static void InitializeContainer(Container container)
        {
//#error Register your services here (remove this line).

            // For instance:
            container.Register<IConfigurationHelper, ConfigurationHelper>(Lifestyle.Scoped);
            container.Register<IHttpClientHelper, HttpClientHelper>(Lifestyle.Scoped);
            container.Register<IRESTHelper, RESTHelper>(Lifestyle.Scoped);
        }
    }
}