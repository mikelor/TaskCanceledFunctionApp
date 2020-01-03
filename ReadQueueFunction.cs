using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace TaskCanceledFunctionApp
{
    public static class ReadQueueFunction
    {
        [FunctionName("ReadQueueFunction")]
        public static void Run([ServiceBusTrigger("taskcanceledqueue", Connection = "ServiceBusConnectionString")]string myQueueItem, ILogger log)
        {
            log.LogInformation($">>ReadQueueFunction:  [{myQueueItem}]");
        }
    }
}
