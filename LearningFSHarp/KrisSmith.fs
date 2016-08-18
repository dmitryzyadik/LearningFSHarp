module KrisSmith

[<Literal>]
let Bill = "Bill Gates"

let greet name =
    match name with
        | Bill -> "Hello, Bill"
        | x -> sprintf "Hello %s " x


open System

let hightLowGame () =
    
    let  rnd = new Random()
    let securityNumber = rnd.Next() % 100

    let rec hightLowGameStep() =
        
        printfn "Угадай  загаданое число:"
        let guessStr = Console.ReadLine()
        let guess = Int32.Parse(guessStr)
        match guess with
        | _ when guess > securityNumber
            -> printfn "Секретное число менше"
               hightLowGameStep()
        | _ when guess = securityNumber
            -> printfn "Правильно!"
        | _ when guess < securityNumber
            ->  printfn "Секретное число больше"
                hightLowGameStep()

    hightLowGameStep()

