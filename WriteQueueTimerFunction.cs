using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.ServiceBus;
using Microsoft.Extensions.Logging;

namespace TaskCanceledFunctionApp
{
    public static class WriteQueueTimerFunction
    {
        [FunctionName("WriteQueueTimerFunction")]
        public static void Run([TimerTrigger(" */1 * * * * *")]TimerInfo myTimer, 
            ILogger log,
            [ServiceBus("taskcanceledqueue", Connection = "ServiceBusConnectionString", EntityType = EntityType.Queue)]out string queueMessage)
        {
            queueMessage = DateTime.UtcNow.ToString();
            log.LogInformation($"<<WriteQueueFunction: [{queueMessage}]");
        }
    }
}
