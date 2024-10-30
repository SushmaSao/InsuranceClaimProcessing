using AutoMapper;
using ClaimProcessingService.Application.Command.Create;
using Common.Application.Contracts.Kafka;
using Confluent.Kafka;
using MediatR;
using System.Text.Json;

namespace ClaimProcessingService.Application.Services
{
    public class ClaimService : IClaimService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IKafkaProducer _kafkaProducer;

        public ClaimService(IMediator mediator, IMapper mapper, IKafkaProducer kafkaProducer)
        {
            this._mediator = mediator;
            this._mapper = mapper;
            this._kafkaProducer = kafkaProducer;
        }
        public async Task<bool> CreateClaim(string email, Guid userId, ClaimDTO claimDTO)
        {
            var createClaimCommand = _mapper.Map<CreateClaimCommand>(claimDTO);
            createClaimCommand.Email = email;
            createClaimCommand.UserId = userId;

            bool result = await _mediator.Send(createClaimCommand);

            if (result)
            {
                var message = new Message<string, string>
                {
                    Key = createClaimCommand.UserId.ToString(),
                    Value = JsonSerializer.Serialize(createClaimCommand)
                };

                await _kafkaProducer.ProduceAsync("claim-created-topic", message);

            }

            return result;
        }

    }
}
