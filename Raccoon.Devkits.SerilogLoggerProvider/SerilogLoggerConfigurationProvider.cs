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
    public class SerilogLoggerConfigurationProvider
    {
        public LoggerConfiguration CreateLoggerConfiguration(LogEventLevel logEventLevel)
            => new LoggerConfiguration()
                .MinimumLevel.Is(logEventLevel)
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                .Enrich.FromLogContext();
    }
}
