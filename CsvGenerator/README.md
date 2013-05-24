# Survey CSV exercise

## Background

We are surveying developers at a number of sites to find their favourite programming language. Each response from a site is stored in a type that contains the site name, and a map/dictionary of programming languages and the number of votes they received. In C# this could look something like this:

```csharp
class SurveyResponse {
    public string Site;
    public Dictionary<ProgrammingLanguage, int> Results;
}
```

Our `ProgrammingLanguage` type has a number of possible values. In C#:

```csharp
enum ProgrammingLanguage {
  CSharp,
  FSharp,
  Haskell,
  Ruby,
  JavaScript
}
```

We have a collection of these survey responses, so we end up with a structure like this:

    site1 [ csharp: 3, fsharp: 1, haskell: 0 ]
    site2 [ csharp: 3, ruby: 5 ]
    site3 [ ruby: 7, javascript: 4 ]

Not every response will have entries for every `ProgrammingLanguage`.

## Goal

Write a program that transforms a collection of these survey responses to CSV. The survey responses above should be written as:

    site,csharp,fsharp,haskell,ruby,javascript
    site1,3,1,0,0,0
    site2,3,0,0,5,0
    site3,0,0,0,7,4

In C#, the entry to our program would look something like this:

```csharp
public string SurveyToCsv(IEnumerable<SurveyResponse> responses) {
    // TODO: implement
}
```

## Conditions

Examples have been provided in C#, but you can use any programming language and paradigm you like, with the one disclaimer that this should be code you are happy to ship. 

The important aspect of the problem is that our `SurveyResponse` has some kind of map/dictionary between language and the number of votes for that language, but that not every response will have entries for every `ProgrammingLanguage`. Our final CSV will include all the programming languages as columns, with missing entries recorded as `0` for each response.
