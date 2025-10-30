using com.nttdocomo.ui;
using com.nttdocomostar;
using DocomoCsJavaBridge;
using DoCoMoPlayer.Models;
using java.lang;
using Serilog;
using System.Reflection;

namespace DoCoMoPlayer
{
    internal class AppLauncher
    {
        private static Type? _appType;
        private static bool _isStar;

        public static bool Setup(AppContainerData appContainer)
        {
            _appType = GetDocomoEntryType(appContainer);
            if (_appType == null)
            {
                _appType = GetDocomoStarEntryType(appContainer);
                _isStar = true;
            }

            return _appType != null;
        }

        public static void Launch()
        {
            if (_appType == null)
                throw new InvalidOperationException("Application was not set up.");

            if (_isStar)
                RunDocomoStarApp();
            else
                RunDocomoApp();
        }

        private static Type? GetDocomoEntryType(AppContainerData appContainer)
        {
            var mainType = GetEntryType(appContainer);
            if (mainType == null)
                return null;

            if (!mainType.IsAssignableTo(typeof(IApplication)))
                return null;

            return mainType;
        }

        private static async void RunDocomoApp()
        {
            var applicationInstance = (IApplication)Activator.CreateInstance(_appType)!;
            try
            {
                Task task = Task.Factory.StartNew(() =>
                    applicationInstance.Launch(1, AppInfo.GetAppParam().Select(s => (JavaString)s).ToArray()));

                await task;
            }
            catch (AggregateException e)
            {
                ;
            }
        }

        private static Type? GetDocomoStarEntryType(AppContainerData appContainer)
        {
            var mainType = GetEntryType(appContainer);
            if (mainType == null)
                return null;

            if (!mainType.IsAssignableTo(typeof(StarApplication)))
                return null;

            return mainType;
        }

        private static async void RunDocomoStarApp()
        {
            var applicationInstance = (StarApplication)Activator.CreateInstance(_appType)!;
            try
            {
                Task task = Task.Factory.StartNew(() =>
                    applicationInstance.Started(1));

                await task;
            }
            catch (AggregateException e)
            {
                ;
            }
        }

        private static Type? GetEntryType(AppContainerData appContainer)
        {
            Assembly gameAssembly = Assembly.LoadFile(Path.GetFullPath(appContainer.AppExecutablePath));
            return gameAssembly.GetExportedTypes().FirstOrDefault(t =>
                t.FullName == appContainer.AppData.AppClass ||
                t.FullName.EndsWith("." + appContainer.AppData.AppClass));
        }
    }
}
