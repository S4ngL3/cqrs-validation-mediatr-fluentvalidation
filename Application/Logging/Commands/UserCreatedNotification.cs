using Contracts.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logging.Commands
{
    public class UserCreatedNotification : INotification
    {
        public User User { get; set; }
    }
}
