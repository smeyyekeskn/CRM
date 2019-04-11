using Autofac;
using Autofac.Integration.Mvc;
using CRM.Data;
using CRM.Model;
using CRM.Service;
using CRM.Service.Services;
using CRM.Service.Services.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CRM.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();

            // Register your MVC controllers. (MvcApplication is the name of
            // the class in Global.asax.)
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();


            //db context 'i  mi scoped( yani request bazlı) olarak register et
            builder.RegisterType<ApplicationDbContext>().InstancePerRequest();

            // generic repository geçici instance olarak register et
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerDependency();
            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication.User.Identity).As<System.Security.Principal.IIdentity>();
            builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork)).InstancePerRequest();
            //servisleri register et
            builder.RegisterType(typeof(CustomerService)).As(typeof(ICustomerService)).InstancePerDependency();
            builder.RegisterType(typeof(CategoryService)).As(typeof(ICategoryService)).InstancePerDependency();
            builder.RegisterType(typeof(EmployeeService)).As(typeof(IEmployeeService)).InstancePerDependency();
            builder.RegisterType(typeof(OfferService)).As(typeof(IOfferService)).InstancePerDependency();
            builder.RegisterType(typeof(OrderService)).As(typeof(IOrderService)).InstancePerDependency();
            builder.RegisterType(typeof(ProductService)).As(typeof(IProductService)).InstancePerDependency();
            builder.RegisterType(typeof(RegionService)).As(typeof(IRegionService)).InstancePerDependency();
            builder.RegisterType(typeof(OrderItemService)).As(typeof(IOrderItemService)).InstancePerDependency();
            builder.RegisterType(typeof(OfferItemService)).As(typeof(IOfferItemService)).InstancePerDependency();


            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerRequest();
            builder.Register(c => new UserStore<ApplicationUser>(c.Resolve<ApplicationDbContext>())).AsImplementedInterfaces().InstancePerRequest();


            builder.Register(c => new RoleStore<IdentityRole>(c.Resolve<ApplicationDbContext>())).InstancePerRequest();
            //builder.RegisterType<ApplicationRoleManager>().AsSelf().InstancePerRequest();
            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).As<IAuthenticationManager>();
            builder.Register(c => new IdentityFactoryOptions<ApplicationUserManager>
            {
                DataProtectionProvider = new Microsoft.Owin.Security.DataProtection.DpapiDataProtectionProvider("Application​")
            });

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
    }

