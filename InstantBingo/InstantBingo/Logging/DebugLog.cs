using System;
using System.Diagnostics;
using Caliburn.Micro;

namespace InstantBingo.Logging
{
    internal class DebugLog : ILog
    {
        private const string BEGIN_END = "***********";
        public void Info(string format, params object[] args)
        {
            var line = BEGIN_END + "CM INFO: " + string.Format(format, args) + BEGIN_END;
            Debug.WriteLine(line);
        }

        public void Warn(string format, params object[] args)
        {
            var line = BEGIN_END + "CM WARN: " + string.Format(format, args) + BEGIN_END;
            Debug.WriteLine(line);
        }

        public void Error(Exception exception)
        {
            var line = BEGIN_END + "CM ERROR: " + exception.Message + BEGIN_END;
            Debug.WriteLine(line);
        }
    }
}