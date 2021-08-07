using System;
using Services.Resource.Core;

namespace Services.Resource.Application.Services
{
    public interface IDateTimeProvider
    {
        DateTime Now { get; }
    }
}