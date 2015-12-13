// Copyright (C) 2015 EventDay, Inc

namespace Demo
{
    public interface IStateHandler
    {
        bool Receive(object message);
    }
    public interface IMessage
    {
    }

    public interface ICommand : IMessage
    {
    }

    public interface IEvent : IMessage
    {
    }
}