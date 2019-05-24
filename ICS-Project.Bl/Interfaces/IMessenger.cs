using System;
using System.Collections.Generic;
using System.Text;

namespace ICS_Project.Bl.Interfaces
{
    public interface IMessenger
    {
        void Register<TMessage>(Action<TMessage> action);
        void Send<TMessage>(TMessage message);
        void UnRegister<TMessage>(Action<TMessage> action);
    }
}
