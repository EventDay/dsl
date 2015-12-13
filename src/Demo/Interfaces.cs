// Copyright (C) 2015 EventDay, Inc

namespace Demo
{
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