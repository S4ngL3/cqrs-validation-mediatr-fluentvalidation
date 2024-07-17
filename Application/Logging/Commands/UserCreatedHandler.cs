using Application.Constants;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
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
        private readonly IDistributedCache _cache;
        public UserCreatedHandler(ILogger<UserCreatedHandler> logger, IDistributedCache cache) {
            _logger = logger;
            _cache = cache;
        }
        Task INotificationHandler<UserCreatedNotification>.Handle(UserCreatedNotification notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"User created");

            _cache.Remove(Constant.CACHE_USER_LIST_KEY);

            return Task.CompletedTask;
        }
    }
}
