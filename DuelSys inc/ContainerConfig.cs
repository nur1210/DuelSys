using Autofac;
using Logic.Interfaces;
using Logic.Services;
using DAL;

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

            builder.RegisterType<TournamentService>().AsSelf().SingleInstance();
            builder.RegisterType<SportService>().AsSelf().SingleInstance();
            builder.RegisterType<TournamentSystemService>().AsSelf().SingleInstance();

            builder.RegisterType<MainForm>();

            return builder.Build();
        }
    }
}
