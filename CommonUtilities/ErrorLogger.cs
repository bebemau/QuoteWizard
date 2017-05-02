using NLog;
using System;

namespace CommonUtilities
{
    public static class ErrorLogger
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static void LogError(Exception ex, string additionalInfo = "")
        {
            logger.Error("Message: " + ex.Message);
            logger.Error("Stack:" + ex.StackTrace);
            if (additionalInfo != string.Empty)
                logger.Error("AdditionalInfo: " + additionalInfo);
        }

    }
}