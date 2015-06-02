using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Queue.Models.Repository;
using Queue.Models.Interface;
using Autofac;
using Autofac.Core;
using System.Web.Mvc;
using Autofac.Integration.Mvc;

namespace Queue.App_Start
{
    public class AutofacConfig
    {        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<AdminRepo>().As<IAdminRepository>();
            builder.RegisterType<ClientRepo>().As<IClientRepository>();
            builder.RegisterType<ExpertRepo>().As<IExpertRepository>();
            builder.RegisterType<ViewListRepo>().As<IViewRepo>();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}