using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raccoon.Devkits.SerilogLoggerProvider
{
    public static class SerilogLoggerExtensions
    {
        public static IHostBuilder OverrideDefaultLogger<TSink>(this IHostBuilder hostBuilder,
            LogEventLevel logEventLevel,LogEventLevel consoleLogLevel = LogEventLevel.Warning)
            where TSink : ILogEventSink, new()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.Sink<TSink>(logEventLevel)
                .WriteTo.Console(consoleLogLevel)
                .CreateLogger();
            return hostBuilder.UseSerilog();
        }

        public static IHostBuilder OverrideDefaultLogger(this IHostBuilder hostBuilder,
            LogEventLevel consoleLogLevel = LogEventLevel.Warning)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.Console(consoleLogLevel)
                .CreateLogger();
            return hostBuilder.UseSerilog();
        }
    }
}
