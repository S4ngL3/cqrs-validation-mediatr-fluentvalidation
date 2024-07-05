using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Logging.Commands
{
    public class UserCreatedHandler : INotificationHandler<UserCreatedNotification>
    {
        private readonly ILogger<UserCreatedHandler> _logger;
        public UserCreatedHandler(ILogger<UserCreatedHandler> logger) {
            _logger = logger;
        }
        Task INotificationHandler<UserCreatedNotification>.Handle(UserCreatedNotification notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"User created");

            return Task.CompletedTask;
        }
    }
}
