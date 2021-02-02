# Test Cheap, Code Simple
(a.k.a. Pragmatic Unit Testing Now!)

This the sample project for the workshop, in C# / .NET Core.

TL;DR if you can run `dotnet test` and see tests pass then chances are you are all set.

Be warned: the code in this project may change from time to time and workshop to workshop (possibly just very slightly and the gist should stay the same).

## Prerequisites
- .NET Core
- Git
- an IDE to work with, e.g. Visual Studio Code
- ... and an open mind :)

## The example - a shopping service
A contrived shopping service that works as follows,

1. accepts a `BuyRequest`
2. calculates and applies discounts
3. charges member the discounted price 

### How discounts are calculated
- if member is having a birthday, then a certain discount is given
- if promo code "AM" is presented and checkout time is AM then a discount is given
- similarly for promo code "PM"
- only some items are discountable
- the higher discount applies if an item qualifies for more than one types of discounts

## The goal of the workshop
* halve the code for this project
* happily write simple code and cheap unit tests, and benefit now! Not later
* and some more excitement 

# Enjoy coding! :)