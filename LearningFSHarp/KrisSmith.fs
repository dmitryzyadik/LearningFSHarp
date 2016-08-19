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
 
 //Сопосталвение с групповыми симвоолами
let rec funListLenght =
    function
    | [] -> 0
    | [_] -> 1
    | [_; _] -> 2
    | [_; _; _] -> 3
    | h::t -> 1 + funListLenght t

//Размеченные объединения

type Suit = 
    | Heart
    | Diamond
    | Spade
    | Club

let suits = [Heart ; Diamond ; Spade ; Club]

type PlayingCard =
    | Ace of Suit
    | King of Suit
    | Queen of Suit
    | Jack  of Suit
    | ValueCard of int * Suit

    member this.Value =
        match this with
        | Ace(_) -> 11
        | Jack(_) | King(_) | Queen(_) -> 10
        | ValueCard(x, _) when x <= 10 && x >= 2
            -> x
        | ValueCard(_) -> failwith "Ошибка значения!"

let highCard = Ace(Spade)
let highCardValue = highCard.Value

let deckOfCards =
    [
        for suit in suits do
            yield Ace(suit)
            yield King(suit)
            yield Queen(suit)
            yield Jack(suit)
            for value in 2..10 do
                yield ValueCard(value, suit)
    ]
//Рекурсивное  связывание c помощъю слова and

type Statement =
    | Print of string
    | Sequence of Statement * Statement
    | IfStmt of Expression * Statement * Statement

and Expression =
    | Integer of int
    | LessThan of Expression * Expression
    | GreaterThan of Expression * Expression

let program =
    IfStmt(
        GreaterThan(
            Integer(3),
            Integer(1)),
        Print("3 больше чем 1"),
        Sequence(
            Print("3 не"),
            Print("больше чем 1")
          )
     )

//Двоичное дерево

type BinaryTree =
    | Node of int * BinaryTree * BinaryTree
    | Empty

let rec printInOrder tree =
    match tree with
    | Node (data, left, right)
        -> printInOrder left
           printfn "Node %d" data
           printInOrder right
    | Empty
        -> ()

let binTree =
    Node(2,
        Node(1, Empty, Empty),
        Node(4,
            Node(3, Empty, Empty),
            Node(5, Empty, Empty)
            )
        )

// printInOrder binTree

type Employee =
    | Manager of string * Employee list
    | Worker of string

let rec printOrganization worker =
    match worker with
    | Worker(name) -> printfn "Employee %s" name
    | Manager(managerName, [Worker(employeeName)])
        -> printfn "Manager %ss with Worker %s" managerName employeeName
    | Manager(managerName, [Worker(employeeName1); Worker(employeeName2)])
        -> printfn "Manager %ss with workers %s and %s" managerName employeeName1 employeeName2
    | Manager(managerName, workers)
        -> printfn "Manager %s with workers..." managerName
           workers |> List.iter printOrganization  