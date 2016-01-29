#EventDay DSL

A handy DSL for creating [Akka.net](http://getakka.net/) actor protocols and reducing boilerplate.

Heavily influenced by the Lokad DSL.

For a brief video description and demo of usage by Chris Martin, watch the [Akka.NET Virtual Meetup 1/26/2016](https://www.youtube.com/watch?v=G3ZafPNI-hk), 
specifically the time between 6:05 and 30:30.

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


