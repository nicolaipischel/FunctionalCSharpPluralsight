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
  * Like a mathematical function (but computable)
  * Must no access global properties (time, database, email etc.)
  * Must not make any observable side effects.
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

#### Functional Decomposition:
* Decompose a problem into small ones -> Enables function composition
* Address subproblems in isolation
  * Easier then addressing the original problem
  * Functions are applicable in other contexts -> Helps reuse code, reduces duplication

Ask Yourself: *"Am I able to further decompose this function?"*
* Theres a gap between the definition of inputs and the output
* This function is a candidate for *<b>decomposition</b>*
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

#### Functional Core - Imperative Shell

Core:
* Immutable types
* Pure functions
* Applies functions to the shell

Shell:
* Networking
* Persistence
* Instantiates types from the core

### Fighting Bloated Classes in Modern OOP
* Define bare minimum of functions on class
* Add some functions as extension methods
* Use the class as a field in other classes -> Favor object composition over class inheritance

### Partial Functional Application
Functional Code should not mix <b>substatial data</b> with <b>ephemeral data</b>
* Configuration is the duty of the composition root *NOT* the function.
* * The argument that is most likely to change comes last.
* We can inject a Func/Action delegate like a dependency into any class.
  * Delegate is an object, like any other (it may include captured variables (the closure))
  * Call the delegate's <b>Invoke</b> method to execute it or use shorthand syntax for the call (using just parentheses)
  * Downsides:
    * Func delegate arguments have no names, but only types
      * Argument types can help avoid mistakes (if you made a good type system in the first place)
    * Its possible to inject *any* function with that signature

C# does not have built in support for partial application.}

* Use delegates if you need to manipulate *<b>functions</b>*
* Use extension and static methods to only manipulate *<b>objects</b>*

### Discriminated Unions

*<b>The only constant in software is change</b>*

* Easy to add a new function on a discriminated union
* Hard to add new new type to a discriminated union

In object oriented programming we would use *Polymorphism* to handle type changes.
* By creating a virtual method on the base class
* And overriding it in the derrived classes.
  * Subclasses inherit *<b>behavior</b>*
  * State on the base class is *<b>encapsulated</b>*
* Overrides may depend on object's state

* Adding a class to a hierarchy is cheap
* Adding a new abstract function to the base class is a breaking change

In functional programming a function in an object
* All variants must have the same signature
* Virtual methods not applicable in functional design
* Type and Pattern matching (Type test and set operator) are used to handle type variation
* Functional style types are defined as a composition of other types
  * Public components
  * Accessed by *<b>functions</b>*

*<b>Warning!</b>*
There is no modifier in C# to specify that there will be no <b>other</b> inheritors.

Switch Expressions (C# 8)
* Each branch is an expression
* Each branch is *<b>evaluated</b>* rather than executed.
* Entire switch expression becomes an <b>expression</b>
* Use switch expression in expression-bodies methods
* Assign switch expression to a variable

<b>General advice:</b>
Separate technical code from domain-specific code
* Give *ugly* code a name that tells what it does
Use the most strict type possible on the model

Expanding a discriminated union is a *<b>breaking change</b>*
* Adding a subtype to a functional design can be much worse than adding a subclass to a object oriented design
* We need to reduce the possibility for a new subtype to emerge in the future
* Pay close attention that all the types in the discriminated must be used the same business contexts

*<b>Make illegal states unrepresentable</b>*

### Type Instances at Runtime
* A single instance -> this is the common use case of any type
* Multiple instances -> Usually in collections or sequences
* No instance -> indicated as a missing object

### Modeling Missing Objects
* A function that states that it will always return a value makes a promise it cannot hold. It is lying to you.
* There is nothing exceptional about not finding an item in the database -> it should not throw an exception
* A function signature should be *<b>honest</b>*

Possible Strategies:
* Make it nullable -> you will have to do a lot of nullchecks
* Return a sequence -> that will either contain or not contain a value
* Implement a optional object -> unlike null, an optional object is not assignable to a regular reference to an object.

Prefix methods with "Try" to indicate that failing is also possible.

By using Optional Objects we make <b>intention</b> explicit.
* The primitive functions defined on Option<T> correspond to LINQ
  * Select
  * Where
  * SingleOrDefault

Using optional objects
* You will never reach out for null in domain-related code
  * That also stands in object-oriented code

### Nondestructive Mutation
We use a copy constructor to create an new copy of an existing instance that we want to mutate.
* A copy constructor generated on a record is private.

<b>When to not use Records?</b>
* They come with generated equality members. Classes that contain collections often do not just have one method to compare for equality
* Records model values not Entities
* Do not use record types if (its an Entity)
  * An object's identity will remain unchanged
  * An object's attributes will change over time

Apparently the compiler does not check that the required properties are already set by the constructor
* That is why you need to use the [SetsRequiredMembers] attribute on a constructor that does set all required attributes.
  * This will disable the verification enforced by the required keyword.
  
### Designing Immutable Objects that contain Collections
* An immutable object can hold a mutable collection
  * When done right, that can even help improve performance
* Immutable collections are less performant than mutable ones
  * Adding an item costs O(log*n*) time, as opposed to O(1)



