// Copyright (C) 2015 EventDay, Inc

using Akka;
using Demo.Indexing.Account.Messages;
using Demo.Indexing.Account.State;

namespace Demo.Indexing.Account
{
    public class StoreReceiver
    {
        private readonly IAccountIndexStore _store;

        public StoreReceiver(IAccountIndexStore store)
        {
            _store = store;
        }
        public bool Receive(object message)
        {
            return message.Match()
                .With<StoreAccount>(_store.When)
                .With<DeleteAccount>(_store.When)
                .WasHandled;
        }

    }
}