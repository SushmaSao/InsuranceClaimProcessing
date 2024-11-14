using Confluent.Kafka;

namespace Common.Application.Contracts.Kafka

{
    public interface IKafkaProducer
    {
        public Task ProduceAsync(string topic, Message<string, string> message);
    }
}
