using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CampaignManager>().As<ICampaignService>();
            builder.RegisterType<EfCampaignDal>().As<ICampaignDal>();

            builder.RegisterType<DealerManager>().As<IDealerService>();
            builder.RegisterType<EfDealerDal>().As<IDealerDal>();
            
            builder.RegisterType<DealerMemberManager>().As<IDealerMemberService>();
            builder.RegisterType<EfDealerMemberDal>().As<IDealerMemberDal>();

            builder.RegisterType<MemberManager>().As<IMemberService>();
            builder.RegisterType<EfMemberDal>().As<IMemberDal>();
            
            builder.RegisterType<SubscriptionManager>().As<ISubscriptionService>();
            builder.RegisterType<EfSubscriptionDal>().As<ISubscriptionDal>()
                ;
            builder.RegisterType<PackageManager>().As<IPackageService>();
            builder.RegisterType<EfPackageDal>().As<IPackageDal>();
            
            builder.RegisterType<TrainerManager>().As<ITrainerService>();
            builder.RegisterType<EfTrainerDal>().As<ITrainerDal>();
            
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();
            
            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
