using Microsoft.Extensions.Logging;

namespace AuthorizeNet.Util
{
    using System;
    using System.Globalization;

    /// <summary>
    /// 
    /// 
    /// </summary>
    public static class LogHelper {

	    static LogHelper() {
	    }

	    public static void debug(Log logger, string format, params object[] arguments) {
		    string logMessage = getMessage(logger, format, arguments);
		    if ( null != logMessage) { logger.debug(logMessage); }
	    }

	    public static void error(Log logger, string format, params object[]  arguments) {
		    string logMessage = getMessage(logger, format, arguments);
		    if ( null != logMessage) { logger.error(logMessage); }
	    }
	
	    public static void info(Log logger, string format, params object[]  arguments) {
		    string logMessage = getMessage(logger, format, arguments);
		    if ( null != logMessage) { logger.info(logMessage); }
	    }

	    public static void warn(Log logger, string format, params object[]  arguments) {
		    string logMessage = getMessage(logger, format, arguments);
		    if ( null != logMessage) { logger.warn(logMessage); }
	    }

	    private static string getMessage(Log logger, string format, params object[]  arguments) {
		    string logMessage = null;
		
		    if ( null != logger && null != format && 0 < format.Trim().Length) {
			    logMessage = string.Format(CultureInfo.InvariantCulture, format, arguments);
			    //do encoding etc here or output neutralization as necessary 
		    }
		    return logMessage;
	    }
    }

    public class Log
    {
        private ILogger _logger;
        public Log(ILogger logger)
        {
            _logger = logger;
        }

        public void error(string logMessage) { _logger.LogError(logMessage); }
        public void info(string logMessage)  { _logger.LogInformation(logMessage); }
        public void debug(string logMessage) { _logger.LogDebug(logMessage); }
        public void warn(string logMessage)  { _logger.LogWarning(logMessage); }

        public void error(object logMessage) { error(logMessage.ToString()); }
        public void info(object logMessage)  { info(logMessage.ToString());  }
        public void debug(object logMessage) { debug(logMessage.ToString()); }
        public void warn(object logMessage)  { warn(logMessage.ToString());  }
    }

    public class LogFactory
    {
        public LogFactory(ILoggerFactory factory)
        {
            Logger = new Log(factory.CreateLogger("LogFactory"));
        }

        private static Log Logger;
        public static Log getLog(Type classType)
        {
            return Logger;
        }
    }
}