module sicp_1_x

//1.1

5 + 3 + 4
9 - 1 
6 / 2 
(2 * 4) + ( 4 - 6)

let a = 3.0
let b = a + 1.0

a + b + (a * b)

a.Equals(b)

if b > a && b < ( a *b) then b else a

match a, b with
| (4.0 , _) -> 6.0
| (_ , 4.0) -> a + 6.0 + 7.0
| (_ , _) -> 25.0

//TODO Найти короткую запись условия
//2.0 + (b>a)?b:a

match a , b with
| a, b when a < b -> a
| a, b when a > b -> b
| a, b when a = b -> -1.0

//1.2

(5.0 + 4.0 + (2.0- (3.0 - (6.0 + 4.0/5.0)))) / (3.0*(6.0 - 2.0) * (2.0-7.0)) 

 // 1.3

let f a b c =
    match a, b, c with  
    | a, b , c when a <= b && b <= c -> (b * b) + (c * c)
    | a, b , c when a >= b && b >= c -> (a * a) + (b * c)
    | a, b , c when b <= a && b <= c -> (a * a) + (c * c)
f 3.0 2.0 2.0

// 1.4

// 1.5

// 1.1.7

let average x y = 
    (x + y) / 2.0

let improve guess x =
    average guess ( x / guess)

let abs x = 
    match x with
    | x when x > 0.0 -> x
    | x when x < 0.0 -> -x
    | _ -> x

let square x = x * x    

let goodenough guess x = (abs((square guess) - x) < 0.001)    


let rec sqrtiter guess x =
    if goodenough  guess x then guess
        else sqrtiter (improve guess x) x

let sqrt x =
    sqrtiter 1.0 x

(sqrt 9.0)

(sqrt (100.0 + 37.0))

(sqrt ((sqrt 2.0) + (sqrt 3.0)))

(square (sqrt 1000.0))

//1.6    
let newif predicate thenclause elseclause =
    match predicate with
    | true -> thenclause
    | false -> elseclause

//1.7
