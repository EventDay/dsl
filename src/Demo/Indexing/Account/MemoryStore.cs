// Copyright (C) 2015 EventDay, Inc

using System;
using System.Collections.Concurrent;
using Akka.Actor;
using Demo.Indexing.Account.Entities;
using Demo.Indexing.Account.Messages;
using Demo.Indexing.Account.State;

namespace Demo.Indexing.Account
{
    public class MemoryStore : ActorBase, IAccountIndexStore
    {
        private readonly ConcurrentDictionary<Guid, AccountIndexEntry> _index;
        private readonly StoreReceiver _receiver;

        public MemoryStore()
        {
            _index = new ConcurrentDictionary<Guid, AccountIndexEntry>();
            _receiver = new StoreReceiver(this);
        }

        protected override bool Receive(object message)
        {
            return _receiver.Receive(message);
        }

        public void When(StoreAccount message)
        {
            var entry = message.Entry;

            if (_index.TryAdd(entry.UserId, entry))
            {
                Sender.Tell(new AccountStored(entry));
            }
            else
            {
                Sender.Tell(new AccountStorageFailed(entry));
            }
        }

        public void When(DeleteAccount message)
        {
            AccountIndexEntry entry;
            if (_index.TryRemove(message.UserId, out entry))
            {
                Sender.Tell(new AccountDeleted(entry));
            }
            else
            {
                Sender.Tell(new AccountDeletionFailed(message.UserId, new Exception("Couldn't bring myself to delete ya.")));
            }
        }
    }
}