using Autofac;
using Logic.Interfaces;
using Logic.Services;
using DAL;
using Logic.Models;

namespace DuelSys_inc
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<TournamentDB>().As<ITournamentDB>();
            builder.RegisterType<SportDB>().As<ISportDB>();
            builder.RegisterType<TournamentSystemDB>().As<ITournamentSystemDB>();
            builder.RegisterType<UserDB>().As<IUserDB>();
            //builder.RegisterType<TournamentSystem>().As<ITournamentSystem>();
            builder.RegisterType<MatchDB>().As<IMatchDB>();
            builder.RegisterType<ResultDB>().As<IResultDB>();

            builder.RegisterType<TournamentService>().AsSelf().SingleInstance();
            builder.RegisterType<SportService>().AsSelf().SingleInstance();
            builder.RegisterType<TournamentSystemService>().AsSelf().SingleInstance();
            builder.RegisterType<UserService>().AsSelf().SingleInstance();
            builder.RegisterType<MatchService>().AsSelf().SingleInstance();
            builder.RegisterType<ResultService>().AsSelf().SingleInstance();
            
            builder.RegisterType<MainForm>();
            builder.RegisterType<AddResult>();

            return builder.Build();
        }
    }
}
