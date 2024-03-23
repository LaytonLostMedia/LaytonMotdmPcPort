using Serilog;

namespace DocomoCsJavaBridge
{
    public static class System
    {
        public static class Out
        {
            private static ILogger _logger;

            public static void Debug(string msg, params object[] args)
            {
                _logger.Debug(msg, args);
            }

            public static void Information(string msg, params object[] args)
            {
                _logger.Information(msg, args);
            }

            public static void Error(string msg, params object[] args)
            {
                _logger.Error(msg, args);
            }

            public static void Fatal(Exception ex, string msg, params object[] args)
            {
                _logger.Fatal(ex, msg, args);
            }

            public static void Setup(ILogger logger)
            {
                _logger = logger;
            }
        }
    }
}
