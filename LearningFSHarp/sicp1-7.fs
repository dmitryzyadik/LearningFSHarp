module sicp1_7

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

let goodenough guess  x = ((improve guess x) = guess)    


let rec sqrtiter guess  x =
    if goodenough  guess  x then guess
        else sqrtiter (improve guess x)  x

let sqrt x =
    sqrtiter 1.0 x

(sqrt 9.0)

(sqrt (100.0 + 37.0))

(sqrt ((sqrt 2.0) + (sqrt 3.0)))

(square (sqrt 1000.0))

