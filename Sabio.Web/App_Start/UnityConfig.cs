using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using System.Web.Http;
using MediaForAll.Web.Core;
using MediaForAll.Web.Services;

namespace MediaForAll.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents(HttpConfiguration config)
        {
            UnityContainer container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            //ExpenseService e = new ExpenseService();
            //container.RegisterInstance<IExpenseService>(e);

            container.RegisterType<IApplicationService, ApplicationService>();
            container.RegisterType<IInterestService, InterestService>();
            container.RegisterType<IExperienceService, ExperienceService>();
            container.RegisterType<IJobService, JobService>();
            container.RegisterType<IJobApplicationService, JobApplicationService>();
            container.RegisterType<ICredentialService, CredentialService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            //  this line is needed so that the resolver can be used by api controllers 
            config.DependencyResolver = new MediaForAll.Web.Core.Injection.UnityResolver(container);

        }
    }
}