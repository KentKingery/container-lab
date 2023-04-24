// See https://aka.ms/new-console-template for more information
using System;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

ServiceProvider serviceProvider = new ServiceCollection()
    .AddLogging((loggingBuilder) => loggingBuilder
        .SetMinimumLevel(LogLevel.Trace)
        .AddSystemdConsole( options =>
        {
            options.IncludeScopes = true;
            options.TimestampFormat = "yyyy-mm-dd HH:mm:ss.fff ";
        })
    )
    .BuildServiceProvider();

var logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger<Program>();

//Now both are working
logger.LogDebug("Debug World");
logger.LogInformation("Hello World");

