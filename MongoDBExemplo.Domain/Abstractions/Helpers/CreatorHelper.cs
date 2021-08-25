using System;
using System.Reflection;

namespace MongoDBExemplo.Domain.Abstractions.Helpers
{
    public static class CreatorHelper
    {
        private static readonly string _application = Assembly.GetEntryAssembly().GetName().Name;
        private static readonly string _host = Environment.MachineName;

        public static string GetCreatorBy() => $"{_application} - {_host}";
    }
}