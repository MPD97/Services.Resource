using System;
using System.Threading.Tasks;
using Convey.CQRS.Commands;
using Services.Resource.Application.Events;
using Services.Resource.Application.Exceptions;
using Services.Resource.Application.Services;
using Services.Resource.Application.Services.Route;
using Services.Resource.Core.Entities;
using Services.Resource.Core.Events;
using Services.Resource.Core.Repositories;

namespace Services.Resource.Application.Commands.Handler
{
    public class CreateTextResourceHandler : ICommandHandler<CreateTextResource>
    {
        private readonly ITextResourceRepository _textResourceRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMessageBroker _messageBroker;
        private readonly IRouteServiceClient _routeService;
        private readonly IDateTimeProvider _dateTimeProvider;

        public CreateTextResourceHandler(ITextResourceRepository textResourceRepository, IUserRepository userRepository,
            IMessageBroker messageBroker, IRouteServiceClient routeService, IDateTimeProvider dateTimeProvider)
        {
            _textResourceRepository = textResourceRepository;
            _userRepository = userRepository;
            _messageBroker = messageBroker;
            _routeService = routeService;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task HandleAsync(CreateTextResource command)
        {
            var user = await _userRepository.GetAsync(command.UserId);
            if (user is null)
                throw new UserNotFoundException(command.UserId);

            if (user.State != State.Valid)
                throw new InvalidUserStateException(command.UserId, user.State);

            var route = await _routeService.GetAsync(command.RouteId);
            if (route is null)
                throw new RouteNotFoundException(command.RouteId);

            if (!Enum.TryParse<RouteStatus>(route.Status, true, out var routeStatus))
                throw new InvalidRouteStatusException(user.Id, RouteStatus.Unknown);
            
            if (routeStatus != RouteStatus.Accepted)
                throw new RouteStatusIsNotAcceptedException(routeStatus);

            var textResource = new TextResource(Guid.NewGuid(), user.Id, route.Id,
                _dateTimeProvider.Now, command.Text);
            
            await _textResourceRepository.AddAsync(textResource);
            await _messageBroker.PublishAsync(new TextResourceCreated(user.Id, route.Id));
        }
    }
}