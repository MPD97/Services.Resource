using System;
using Convey.MessageBrokers.RabbitMQ;

namespace Services.Resource.Infrastructure.Exceptions
{
    public class ExceptionToMessageMapper : IExceptionToMessageMapper
    {
        public object Map(Exception exception, object message)
            => exception switch
            {
                _ => null
            };
    }
}