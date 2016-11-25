using SampleFC.SharedKernel.Events.Interfaces;
using System;

namespace SampleFC.SharedKernel.Interfaces
{
    public interface IHandler<T> : IDisposable where T : IDomainEvent
    {
        void Handle(T args);
      
    }
}
