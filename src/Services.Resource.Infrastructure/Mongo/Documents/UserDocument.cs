using System;
using System.Runtime.Intrinsics.Arm;
using Convey.Types;
using Services.Resource.Core.Entities;

namespace Services.Resource.Infrastructure.Mongo.Documents
{
    public class UserDocument : IIdentifiable<Guid>
    {
        public Guid Id { get; set; }
        public State State { get; set; }
    }
}