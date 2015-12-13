namespace Demo.Indexing.Account;

const userId    is Guid;
const name      is string;
const email     is string;
const entry     is AccountIndexEntry;

state Index:IAccountIndexStore

entity AccountIndexEntry(userId, name, email)

StoreAccount(entry)
    tell Index

AccountStored(entry)
AccountStorageFailed(entry, Exception? reason)

DeleteAccount(userId)
    tell Index

AccountDeleted(entry)
AccountDeletionFailed(userId, Exception? reason)