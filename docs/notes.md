## Functional Design in C#
* Mostly based on discipline

### Start with Prototying
* Create Types which are transformed from primitive .NET Types by using Extension Methods
* By designing small isolated functions we are late open to decide which chain of operations will define a larger process.
* Pure Functions
  * Immutable operations
  * No observable side effects
  * Repeated call produces equal result
  * Supports referential transparency (no difference between calling a function one or multiple times) -> Idempotent
* Don't be afraid to define an empty method to buy yourself time for thinking.

### The Functional Designing Process
* Identify *<b>names</b>* in the domain specification.
  * try submitting tuples (created during prototyping) with records.
* Represent each with a *<b>type</b>*
* Represent processes with *<b>functions</b>*
* Return a result from every function