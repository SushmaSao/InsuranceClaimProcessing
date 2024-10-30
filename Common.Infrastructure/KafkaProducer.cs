using Common.Application.Contracts.Kafka;
using Confluent.Kafka;

namespace Common.Infrastructure.Kafka
{
    public class KafkaProducer : IKafkaProducer
    {
        private readonly IProducer<string, string> _producer;
        public KafkaProducer()
        {
            ProducerConfig config = new()
            {
                BootstrapServers = "localhost:9092",
                AllowAutoCreateTopics = true,
            };
            _producer = new ProducerBuilder<string, string>(config).Build();

        }
        public async Task ProduceAsync(string topic, Message<string, string> message)
        {
            await _producer.ProduceAsync(topic, message);
        }
    }
}
