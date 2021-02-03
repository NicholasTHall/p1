# project-p1
The goal of the project is to build a Pizza Ordering System

# Architecture (REQUIRED)
* [solution] PizzaWorld.sln <br/>
  * [project -MVC] PizzaWorld.Client.csproj <br/>
  * [project - ClassLib] PizzaWorld.Domain.csproj <br/>
    * think about abstraction, design patterns <br/>
    * implement Models <br/>
  * [project - ClassLib ] PizzaWorld.Storing.csproj <br/>
    * implement at least 1 repository <br/>
  * [project - xunit] PizzaWorld.Testing.csproj <br/>
    * implement unit testing <br/>
# requirements
The project should support objects of Customer, Store, Order, Pizza.

# store
[required] there should exist at least 2 stores for a user to choose from. <br/>
[required] each store should be able to view/list any and all of their completed/placed orders. <br/>
[required] each store should be able to view/list any and all of their sales (amount of revenue weekly or monthly). <br/>
# order
[required] each order must be able to view/list/edit its collection of pizzas. <br/>
[required] each order must be able to compute its pricing. <br/>
[required] each order must be limited to a total pricing of no more than $250. <br/>
[required] each order must be limited to a collection of pizzas of no more than 50. <br/>
# pizza
[required] each pizza must be able to have a crust. <br/>
[required] each pizza must be able to have a size. <br/>
[required] each pizza must be able to have toppings. <br/>
[required] each pizza must be able to compute its pricing. <br/>
[required] each pizza must have no less than 2 default toppings. <br/>
[required] each pizza must limit its toppings to no more 5. <br/>
# customer
[required] must be able to view/list its order history. <br/>
[required] must be able to only order from 1 location in a 24-hour period with no reset. <br/>
[required] must be able to only order once every 2-hour period. <br/>
# technologies
.NET Core - ASP.NET Core MVC <br/>
.NET Core - C# <br/>
.NET Core - EF + SQL <br/>
.NET Core - xUnit <br/>
# timelines
due on Jan-19 at 11p Central. <br/>
present on Jan-20 starting at 9.30a Central. <br/>
implement as many requirements as you can. <br/>
# customer story
as a customer, i should be able to do this: <br/>

* access the application <br/>
* see a list of locations <br/>
* select a location <br/>
* place an order <br/>
* with either custom or preset pizza. <br/>
* if custom: <br/>
  * select crust, size and toppings <br/>
* if preset: <br/>
  * select pizza and its size <br/>
* see a tally of my order <br/>
* add or remove more pizzas <br/>
* and checkout when complete with latest order <br/>
* see my order history <br/>
* make a new order <br/>
# store story
as a store, i should be able do this:

* access the application <br/>
* select options for order history, sales <br/>
* if order history <br/>
  * select options for all store orders and orders associated to a user (filtering) <br/>
* if sales <br/>
  * see pizza type, count, revenue by week or by month <br/>
the goal is to try to complete as many reqs as you can in the time alloted. :)
