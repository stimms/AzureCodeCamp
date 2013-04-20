namespace PancakeProwler.CookbookBuilder

open System

type CookbookBuilder() =

    member this.Start() =
        Console.WriteLine "hello"

    member this.Stop() = 
        Console.WriteLine "bye"