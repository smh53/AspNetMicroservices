using AutoMapper;
using EventBus.Messages.Events;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Features.Orders.Commands.CheckOutOrder;
using System.Threading.Tasks;

namespace Ordering.API.EventBusConsumer
{
    public class BasketCheckOutConsumer : IConsumer<BasketCheckoutEvent>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ILogger<BasketCheckOutConsumer> _logger;

        public BasketCheckOutConsumer(IMapper mapper, IMediator mediator, ILogger<BasketCheckOutConsumer> logger)
        {
            _mapper = mapper;
            _mediator = mediator;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
        {
            var command = _mapper.Map<CheckOutOrderCommand>(context.Message);
            var result = await _mediator.Send(command);
            _logger.LogInformation("BasketCheckoutEvent consumed. Created Order ID: { newOrderId}", result);
        }
    }
}
