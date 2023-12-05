# MealDB_API
A .NET library for easy integration with the meal db API. This library provides services to interact with meals, recipies, ingrediants and more from TheMealDB.

# Introduction
The Meals DB API Wrapper is a convenient C# library that simplifies access to TheMealsDB API. 
The MealsDB API provides comprehensive data related to meals, ingreidnets, and categories of food. By leveraging this wrapper, developers can easily integrate food related data into their C# applications. The official documentation for the MealsDB API can be found [here](https://www.themealdb.com/api.php).

# Getting Started

## Installation

To begin using TheMealsDB API Wrapper, you can install the NuGet package using one of the following methods:

Package Manager Console:
Install-Package TheMealDB 

.NET CLI:
dotnet add package TheMealDB 

Visual Studio:
Right-click on your project in the Solution Explorer. Select "Manage NuGet Packages." Search for "TheMealDB" and click "Install."

# Basic Usage

The MealsDB API Wrapper provides the main service: 

### Search Service 

Each service has its corresponding interface:

### ISearchService

You can use these services with or without dependency injection, based on your preferred approach. 
Here's an example of how you can hook up the services into your dependency injection using the Microsoft.Extensions.DependencyInjection library:

```cs
using Microsoft.Extensions.DependencyInjection;
using TheMealDB;
using TheMealDB.Services;
using TheMealDB.Interfaces;

// Create a service collection
var services = new ServiceCollection();

// Add the MealDBClient to the service collection which in turn adds other services
services.AddSingleton<MealDBClient>();

// Or you can add the services and their corresponding interfaces to the service collection manually
services.AddScoped<IRequestHandler, RequestHandler>();
services.AddScoped<ISearchService, SearchService>();
```

# Using The Search Service

With an instance of the ISearchService you now have access to the following Methods

Search For Meals With Bread In The Name
```cs
var breadMeals = _searchService.SearchMealByName("Bread");
```

Search For Meals With B As The First Letter
```cs
var mealsBeginingWithB = _searchService.SearchMealByFirstLetter("B");
```

Search A Random Meal
```cs
var randomMeal = _searchService.SearchMealByFirstLetter("B");
```