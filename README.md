# drinkshopping
This is a small project to test Web API Http Verbs when dealing with online Drink Ordering, below are explaination for all projects

1. DrinkShopping.Business is a project containing Shopping List Management
2. DrinkShopping.Contracts defines all Interfaces & shared Classes other project would use to keep them all depend on Contracts project & nothing else
3. DrinkShopping.Data contains how to retrieve data from some data files, e.g. product.json from DrinkShopping->App_Data folder
4. DrinkShopping project is the Web Api, it contains controller methods to deal with Drink's name, price Add/Update/Remove from stock; it also includes methods doing shopping cart calls. 

IocContainerConfig.cs is to solve dependencies using Simple Injector. 

Angular 2 was also tried but something wierd happened to my machine I couldn't get it to load when trying to display a list of Drinks
