using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Tools
{
    class Logger
    {
        private ILog _logger;

        public static void Init()
        {
            XmlConfigurator.Configure();
        }

        public Logger(Type type)
        {
            _logger = LogManager.GetLogger(type);
        }

        public void Info(string message)
        {
            _logger.Info(message);
        }

        public void Debug(string message)
        {
            _logger.Debug(message);
        }

        public void Warn(string message)
        {
            _logger.Warn(message);
        }

        public void Error(string message)
        {
            _logger.Error(message);
        }
    }
}
