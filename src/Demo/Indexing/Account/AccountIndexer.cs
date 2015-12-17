// Copyright (C) 2015 EventDay, Inc

using Akka.Actor;
using Akka.Event;
using Demo.Indexing.Account.Entities;
using Demo.Indexing.Account.Messages;
using Demo.Messages;

namespace Demo.Indexing.Account
{
    public class AccountIndexer : ReceiveActor
    {
        public AccountIndexer()
        {
            IActorRef store = GetStore();
            var log = Context.GetLogger();

            Receive<AccountCreated>(x => store.Tell(new StoreAccount(new AccountIndexEntry
            {
                UserId = x.UserId,
                Name = x.Name,
                Email = x.Email
            })));

            Receive<AccountRemoved>(x => store.Tell(new DeleteAccount(x.UserId)));

            Receive<AccountStored>(x => log.Info($"account '{x.Entry.UserId}' stored in the index"));
            Receive<AccountStorageFailed>(x => log.Error(x.Reason, $"failed to store account '{x.Entry.UserId}' in the index"));

            Receive<AccountDeleted>(x => log.Info($"account '{x.Entry.UserId}' deleted from the index"));
            Receive<AccountDeletionFailed>(x => log.Error(x.Reason, $"failed to delete account '{x.UserId}' from the index"));
        }

        private IActorRef GetStore()
        {
            //probably use an extension to get configured store;
            return Context.ActorOf<MemoryStore>();
        }

        protected override void PreStart()
        {
            Context.System.EventStream.Subscribe<IIndexAccounts>(Self);
            base.PreStart();
        }

        protected override void PostStop()
        {
            Context.System.EventStream.Unsubscribe<IIndexAccounts>(Self);
            base.PostStop();
        }
    }
}
