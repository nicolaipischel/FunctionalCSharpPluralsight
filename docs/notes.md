## Functional Design in C#
* Mostly based on discipline
* We don't like to throw exceptions.

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

Hint: record struct comes with generated equality members.

#### Using Records
1. Do not call bare constructor on records -> use factory functions instead.
2. Think of a record as a value. It attains a meaning from the context which it is used.

Hint: Closure cannot capture a value type from *this*

### Functional Programming Fundamentals
* Separate types from functions
    * use static and extensions methods in C#
* Do not allow redefining of functions
  * Forbid method overriding
* Function applies to a type and its subtypes
  * Method's location becomes less important
  * Move functions to types that it belongs to

### Using Objects in a Functional Design
* Everything is an object in C#
  * Even a lambda is an object
* Do not try to avoid using objects
  * Extension methods should not hold domain logic!
  * Instance-level methods can still be functional!
* Object-oriented vs functional design
  * Object-oriented design composes objects
  * Functional design composes functions
* *<b>Define small, non-virtual, self-contained methods that return results that can be used in subsequent function composition</b>*.
  * Using Call Chaining
* *<b>Feel free to define primitives on the class to which they apply</b>.*
* *<b>Move specialized transforms to a dedicated extension class</b>*

### Principles of Functional Modeling
* Separate types from functions
  * There are types to describe elements of the business
  * There are functions to describe business processes

* The number of types is bounded in any business domain
  * Adding more types to the model at first
  * No more types to add beyond a certain point.

* Modeling included defining functiongs to model behaviour
  * Functions apply to instances of types, returning instances of types
  * There will always be new behaviour to add to the system

#### Object-oriented vs. Functional Modeling

Object Oriented:
* It is hard to add a new method to a hierarchy of classes
* Working actively to keep the design maintainable -> Requires knowledge

Functional:
* It is easy to add a new function to existing functions.
* Forced to separate concepts by design

Modern OOP:
* Favors object composition over inheritance