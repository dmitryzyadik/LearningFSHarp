module Projecteuler

//Problem 1



//Problem 2

let problem2 =     
    
    let fibseq =
        let rec fibonacci a b =
            seq {
                if b < 4000000 then
                    let s = a + b 
                    yield s
                    yield! fibonacci b s
                else yield 0
                }
        seq {yield 1 ; yield! fibonacci 1 1}

    fibseq 
    |> Seq.filter (fun x -> if x%2=0 then true else false )
    //|> Seq.iter (fun x -> printfn "%A" x)
    |> Seq.sum
    |> printfn "%A"
//printfn "%A" proble2

//Problem 3
//Простые множители

let problem3 =
    
    let rec checkSimple (a:bigint) (b:bigint) =         
        match (a % b) with            
        | 0 -> true
        | >1 -> 
                
   // let x  = bigint 10// 600851475143)

   // printfn "%A" checkSimple x x

    
