using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceBusTopicSender.Models;

namespace ServiceBusTopicSender.Services
{
    public interface IAzureTopics
    {
        Task SendMessageAsync(Topics topicMessage, string topicName);
    }
}
