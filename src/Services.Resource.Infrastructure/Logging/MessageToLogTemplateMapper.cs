﻿using System;
using System.Collections.Generic;
using Convey.Logging.CQRS;
using Services.Resource.Application.Events.External;
using Services.Resource.Application.Exceptions;

namespace Services.Resource.Infrastructure.Logging
{
   internal sealed class MessageToLogTemplateMapper : IMessageToLogTemplateMapper
    {
        private static IReadOnlyDictionary<Type, HandlerLogTemplate> MessageTemplates 
            => new Dictionary<Type, HandlerLogTemplate>
            {
                {
                    typeof(UserCreated),     
                    new HandlerLogTemplate
                    {
                        After = "Added a user with id: {UserId}.",
                        OnError = new Dictionary<Type, string>
                        {
                            {
                                typeof(UserAlreadyExistsException), "User with id: {UserId} already exists."
                            }
                        }
                    }
                },
                {
                    typeof(UserStateChanged),
                    new HandlerLogTemplate
                    {
                        After = "Changed state of a user with id: {UserId} from {PreviousState} to {CurrentState}.",
                        OnError = new Dictionary<Type, string>
                        {
                            {
                                typeof(UserNotFoundException), "User with id: {UserId} was not found."
                            },
                            {
                                typeof(CannotChangeUserStateException), "Cannot change user: {userId} state to: {state}."
                            }
                        }
                    }
                }
            };
        
        public HandlerLogTemplate Map<TMessage>(TMessage message) where TMessage : class
        {
            var key = message.GetType();
            return MessageTemplates.TryGetValue(key, out var template) ? template : null;
        }
    }
}