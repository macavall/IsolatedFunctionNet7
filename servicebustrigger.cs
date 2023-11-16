using System;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace testfunctionapp
{
    public class servicebustrigger
    {
        private readonly ILogger<servicebustrigger> _logger;

        public servicebustrigger(ILogger<servicebustrigger> logger)
        {
            _logger = logger;
        }

        [Function(nameof(servicebustrigger))]
        public void Run([ServiceBusTrigger("queue", Connection = "sbconnstring")] ServiceBusReceivedMessage message)
        {
            _logger.LogInformation("Message ID: {id}", message.MessageId);
            _logger.LogInformation("Message Body: {body}", message.Body);
            _logger.LogInformation("Message Content-Type: {contentType}", message.ContentType);
        }
    }
}
