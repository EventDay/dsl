namespace Demo;

commands    are ICommand;
events      are IEvent;

marker IIndexAccounts;
state AccountState;

const userId    is Guid;
const name      is string;
const email     is string;

command CreateAccount(name, email)
    event AccountCreated(userId, name, email)
        mark IIndexAccounts
        tell AccountState        


command RemoveAccount(userId)
    event AccountRemoved(userId)
        mark IIndexAccounts
        tell AccountState

command AddFriend(userId, Guid friendId)
    event FriendAdded(userId, Guid friendId)
        tell AccountState
