using Autofac;

namespace DuelSys_inc
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            var container = ContainerConfig.Configure();
            ApplicationConfiguration.Initialize();
            Application.Run(container.Resolve<AddResult>());
        }
    }
}