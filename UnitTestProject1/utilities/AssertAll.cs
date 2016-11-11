using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace UnitTestProject1.utilities
{

    public static class AssertAll
    {
        public static void Succeed(params Action[] assertions)
        {
            var errors = new List<Exception>();

            foreach (var assertion in assertions)
                try
                {
                    assertion();
                }
                catch (Exception ex)
                {
                    errors.Add(ex);
                }

            if (errors.Any())
            {
                var ex = new AssertionException(
                    string.Join(Environment.NewLine, errors.Select(e => e.Message)),
                    errors.First());

                // Use stack trace from the first exception to ensure first
                // failed Assert is one click away
                ReplaceStackTrace(ex, errors.First().StackTrace);

                throw ex;
            }
        }

        static void ReplaceStackTrace(Exception exception, string stackTrace)
        {
            var remoteStackTraceString = typeof(Exception)
                .GetField("_remoteStackTraceString",
                    BindingFlags.Instance | BindingFlags.NonPublic);

            remoteStackTraceString.SetValue(exception, stackTrace);
        }
    }
}
