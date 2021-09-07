using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using ServiceBusTopicSender.Models;

namespace ServiceBusTopicSender.Services
{
    public class AzureTopics : IAzureTopics
    {
        private readonly IConfiguration _config;

        public AzureTopics(IConfiguration config)
        {
            _config = config;

        }
        public async Task SendMessageAsync(Topics topicMessage, string topicName)
        {
            //Get Connection string
            var connectionString = _config.GetConnectionString("AzureServiceBusConnection");

            //Initialize the queue
            var qClient = new TopicClient(connectionString, topicName);

            //Serialize the message
            var msgBody = JsonSerializer.Serialize(topicMessage);

            //initialized q
            var msg = new Message(Encoding.UTF8.GetBytes(msgBody));

            //message sended

            await qClient.SendAsync(msg);
        }
    }
}
