﻿using MediatR;
using Microsoft.Extensions.Logging;
using ScanCode.Repository.MediatRHandler.Events;

namespace ScanCode.Repository.MediatRHandler
{
    public class LoggerEventHnadler : INotificationHandler<LoggerEvent>
    {
        private readonly ILogger<LoggerEvent> _Logger;

        public LoggerEventHnadler(ILogger<LoggerEvent> logger)
        {
            _Logger = logger;
        }

        public async Task Handle(LoggerEvent loggerEvent, CancellationToken cancellationToken)
        {
            //在这里处理通知。例如，您可以发送电子邮件或记录事件

            await LogAsync(loggerEvent);
            return;
        }

        public async Task LogAsync(LoggerEvent loggerEvent)
        {
            var loggermsg =
                $"[{loggerEvent.CreateTime}]接收到[{loggerEvent.TypeData.Name}]->{loggerEvent.OperationType.ToString()} 数据[{loggerEvent.JsonData}]";
            _Logger.LogInformation(loggermsg);
            var directory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var fileName = $"{loggerEvent.TypeData.Name}_log_{DateTime.Now:yyyy-MM-dd}.txt";
            var path = Path.Combine(directory, fileName);
            using (var writer = File.AppendText(path))
            {
                await writer.WriteLineAsync($"{loggermsg}");
            }
        }
    }
}