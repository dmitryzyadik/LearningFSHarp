module sicp1_8

let square x = x * x
let cube x = x * x * x

let improve guess x =
    printfn "%A %A %A" x guess (((x / (square guess)) + (2.0 * guess)) / 3.0)
    ((x / (square guess)) + (2.0 * guess)) / 3.0 

//let improve guess x =
  //  cube guess ( x / guess)

let abs x = 
    match x with
    | x when x > 0.0 -> x
    | x when x < 0.0 -> -x
    | _ -> x   

let goodenough guess  x = ((improve guess x) = guess) //= abs(cube(guess)-x) < 0.000001

let rec sqrtiter guess  x =
    if goodenough  guess  x then guess
        else sqrtiter (improve guess x)  x

let fcube x =
    sqrtiter 1.0 x

(fcube 8.0)

(fcube (100.0 + 37.0))

(fcube ((sqrt 2.0) + (sqrt 3.0)))

(cube (fcube 1000000.0))

