// Copyright (C) 2015 EventDay, Inc

using System;
using Demo.Messages;
using Demo.State;

namespace Demo.Domain
{
    public class AccountStateHandler : AccountStateSubscription
    {
        private readonly Func<AccountEntity> _state;

        public AccountStateHandler(Func<AccountEntity> state)
        {
            _state = state;
        }

        protected override void When(AccountCreated message)
        {
            var entity = _state();
            entity.Created = true;
            entity.Name = message.Name;
            entity.Email = message.Email;
        }

        protected override void When(AccountRemoved message)
        {
            var entity = _state();
            entity.Created = false;
        }

        protected override void When(FriendAdded message)
        {
            var entity = _state();
            entity.Friends.Add(message.FriendId);
        }
    }
}