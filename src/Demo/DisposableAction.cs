// Copyright (C) 2015 EventDay, Inc

using System;

namespace Demo
{
    public sealed class DisposableAction : IDisposable
    {
        private readonly Action _action;
        private bool _disposed;

        public DisposableAction(Action action)
        {
            _action = action;
        }

        public void Dispose()
        {
            if (_disposed) return;

            _disposed = true;
            _action();
        }
    }

}