using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using BoardGamesNook.Controllers;
using BoardGamesNook.MapperProfiles;
using BoardGamesNook.Repository;
using BoardGamesNook.Repository.Generators;
using BoardGamesNook.Repository.Interfaces;
using BoardGamesNook.Services;
using BoardGamesNook.Services.Interfaces;
using FluentValidation.Mvc;
using SimpleAuthentication.Core;
using SimpleAuthentication.Mvc;
using SimpleAuthentication.Mvc.Caching;

namespace BoardGamesNook
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            FluentValidationModelValidatorProvider.Configure();

            var builder = new ContainerBuilder();

            builder.RegisterType<AuthenticationCallbackProvider>().As<IAuthenticationCallbackProvider>();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterControllers(typeof(SimpleAuthenticationController).Assembly);
            builder.RegisterType<CookieCache>().As<ICache>();

            builder.RegisterType<BoardGameService>().As<IBoardGameService>();
            builder.RegisterType<GamerService>().As<IGamerService>();
            builder.RegisterType<GameParticipationService>().As<IGameParticipationService>();
            builder.RegisterType<GamerBoardGameService>().As<IGamerBoardGameService>();
            builder.RegisterType<GameResultService>().As<IGameResultService>();
            builder.RegisterType<GameTableService>().As<IGameTableService>();

            builder.RegisterType<GamerRepository>().As<IGamerRepository>();
            builder.RegisterType<BoardGameRepository>().As<IBoardGameRepository>();
            builder.RegisterType<GameParticipationRepository>().As<IGameParticipationRepository>();
            builder.RegisterType<GamerBoardGameRepository>().As<IGamerBoardGameRepository>();
            builder.RegisterType<GameResultRepository>().As<IGameResultRepository>();
            builder.RegisterType<GameTableRepository>().As<IGameTableRepository>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            RelationsUpdateGenerator.FillRelationsForBoardGameTable();

            InitializeAutoMapper();
        }

        public static void InitializeAutoMapper()
        {
            Mapper.Initialize(cfg =>
                {
                    cfg.AddProfile<GamerBoardGameProfile>();
                    cfg.AddProfile<GamerProfile>();
                    cfg.AddProfile<UserProfile>();
                    cfg.AddProfile<GamerBoardGameProfile>();
                    cfg.AddProfile<GameResultProfile>();
                    cfg.AddProfile<BoardGameProfile>();
                    cfg.AddProfile<GameTableProfile>();
                    cfg.AddServicesProfiles();
                }
            );
        }
    }
}