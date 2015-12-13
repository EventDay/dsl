// Copyright (C) 2015 EventDay, Inc

using System;
using System.Collections.Generic;
using Akka;
using Akka.Actor;
using Akka.Persistence;
using Demo.Messages;

namespace Demo.Domain
{
    public class AccountAggregate : PersistentActor
    {
        private readonly Guid _id;
        private AccountEntity _state;
        private readonly AccountStateHandler _stateHandler;

        public AccountAggregate(Guid id)
        {
            _id = id;
            _state = new AccountEntity(id);
            _stateHandler = new AccountStateHandler(() => _state);
        }

        public override string PersistenceId => $"account-{_id:n}";

        protected override bool ReceiveRecover(object message)
        {
            var offer = message as SnapshotOffer;
            var offeredState = offer?.Snapshot as AccountEntity;

            if (offeredState != null)
            {
                _state = offeredState;
                return true;
            }

            var domainEvent = message as IEvent;
            if (domainEvent != null)
            {
                UpdateState(domainEvent);
                return true;
            }
            return false;
        }


        protected override bool ReceiveCommand(object message)
        {
            return message.Match()
                .With<CreateAccount>(x => Persist(new AccountCreated(Guid.NewGuid(), x.Name, x.Email)))
                .With<RemoveAccount>(x => Persist(new AccountRemoved(_id)))
                .With<AddFriend>(x => Persist(new FriendAdded(_id, x.FriendId)))
                .WasHandled;
        }

        private void UpdateState(IEvent domainEvent)
        {
            _stateHandler.Receive(domainEvent);
        }

        private void Persist(IEvent domainEvent, IActorRef sender = null)
        {
            Persist(domainEvent, e =>
            {
                UpdateState(domainEvent);
                Context.System.EventStream.Publish(domainEvent);
                (sender ?? Sender)?.Tell(domainEvent);
            });
        }
    }

    public class AccountEntity
    {
        public AccountEntity(Guid id)
        {
            Id = id;
            Friends = new HashSet<Guid>();
        }

        public Guid Id { get; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Created { get; set; }
        public ISet<Guid> Friends { get; set; }
    }
}