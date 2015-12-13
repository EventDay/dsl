#EventDay DSL

A handy DSL for creating Akka actor protocols and reducing boilerplate.

Heavily influenced by the Lokad DSL
##Installation
- A) Compile
- B) Install `EventDayDsl.vsix` from `EventDayDsl\bin\Debug` (Built in Step A)

## [Demo](src/Demo)

##Features

###Immutable Messages by default
`Message(parameter1, parameter2, etc.)`

###Mutable Messages can be generated too
`entity MyEntity(string parameter1, string parameter2, etc.)`
will generate

```
	public MyEntity(parameter1 = default(String), parameter2 = default(String)){
		
	}
```
###Optional parameters
`Message(parameter1, parameter2, parameter3?)`

###[DDD/CQRS helpers](src/Demo/Account.dsl)

##Example
[Demo DSL File](src/Demo/Indexing/Account/Indexer.dsl)
generates
[Entities](src/Demo/Indexing/Account/IndexerEntities.cs), 
[Messages](src/Demo/Indexing/Account/IndexerMessages.cs), and 
[Receivers](src/Demo/Indexing/Account/IndexerStateSubscriptions.cs)


