// Дополнительные сведения о F# см. на http://fsharp.org
// Дополнительную справку см. в проекте "Учебник по F#".
//#if INTERACTIVE
//#r "FSharp.Data.SqlClient.dll"
//#endif
//open FSharp.Data
//
//
//[<Literal>]
//let connectionString = @"Data Source=SQLBACK-WIN12;Initial Catalog=cLines; User=sa;"
//
//let cmd = new SqlCommandProvider<"SELECT TOP 1 [id],[DeviceName],[Description],[Owner] ,[TypeDevice] ,[idImage]  FROM [cLines].[dbo].[Device]" , connectionString >(connectionString)
//
//let incomos (acc:string) 
//    item = acc + item
//
//let addAcc acc i = acc + i
//
//let  location = (77.51, 160.40, 23)
//let longAlt location =
//    let long,_,alt = location
//    (alt, long )
//let birthday = (15,5,1984)
//
//let redBirthday birthday =
//    let day,month,year = birthday
//    (year,month,day)
//
//printfn "%A" (redBirthday birthday)
//
//let area h w =
//    (h * w) /2 
//
open System.Drawing
open System.IO
open System

let pathAndFileName =
    Path.Combine(__SOURCE_DIRECTORY__, "naive.png" )

type Plotter = {
    position: int*int
    color: Color
    direction: float
    bitmap : Bitmap
    }

let naiveLine (x1,y1) plotter =
    let updatedPlotter = {plotter with position = (x1,y1) }
    let (x0,y0) = plotter.position
    let xLen = float (x1 - x0)
    let yLen = float (y1 - y0)

    let x0,y0,x1,y1 = if x0 > x1 then x1,y1,x0,y0 else x0,y0,x1,y1
    
    if xLen <> 0.0 then
        for x in x0..x1 do
            let proportion = float (x - x0) / xLen
            let y = (int (Math.Round(proportion * yLen))) + y0
            printfn "%i" y
            plotter.bitmap.SetPixel(x,y, plotter.color)

    let x0,y0,x1,y1 = if y0 > y1 then x1,y1,x0,y0 else x0,y0,x1,y1

    if yLen <> 0.0 then
        for y in y0..y1 do
            let proportion = float (y - y0) / yLen
            let x = (int (Math.Round(proportion * xLen))) + x0
            printfn "%i" x
            plotter.bitmap.SetPixel(x,y, plotter.color)
    
    updatedPlotter 

let turn amt plotter = 
    let newDir = plotter.direction + amt
    let angled = {plotter with direction = newDir}
    printfn "%A" angled
    angled
    

let move dist plotter = 
    let currPos = plotter.position
    let angle   = plotter.direction
    let startX  = fst currPos
    let startY  = snd currPos
    let rads    = (angle - 90.0) * Math.PI / 180.0
    let endX    = (float startX) + (float dist) * cos rads
    let endY    = (float startY) + (float dist) * sin rads
    let plotted = naiveLine (int endX ,int endY) plotter
    printfn "%A"  plotted
    plotted
     
type command = Turn | Move

let action (c:command) (value:float) plotter =    
    match c with
    | Turn -> turn (float value) plotter
    | Move -> move (int value) plotter
     


let fill color (bitmap:Bitmap) =
    for x in 0..bitmap.Width - 1 do
        for y in 0..bitmap.Height - 1 do
            bitmap.SetPixel(x,y,color)

            

let bitmap2 = new Bitmap(400,400)

fill Color.Red bitmap2

let initPLotter = {
    position = (200, 200)
    color = Color.Goldenrod
    direction = 90.0
    bitmap = bitmap2
    }



let problem1 =
    Seq.fold (fun acc i -> if i%3=0 || i%5=0 then acc + i else acc + 0) 0 [0..999]
printfn "%A" problem1  

//let dr =  
//    let com = [(Move,15.0); (Turn, 90.0); (Move,60.0);(Turn,90.0); (Move,15.0); (Turn,-90.0); (Move,20.0); (Turn,-90.0); (Move,15.0)]
//    let plot = initPLotter
//
//    let rec drawn command plotter =
//            let p = plotter
//            match command with
//                | h::t -> action (fst h) (snd( h)) p |> drawn t
//                | _ -> p
//                
//    let r = plot |> drawn com 
//    r.bitmap.Save(pathAndFileName) 
            
//let rectangle x y =
//    initPLotter 
//    |> move x
//    |> turn 90.0
//    |> move y
//    |> turn 90.0
//    |> move x
//    |> turn 90.0
//    |> move y

let poligon (sides:int) length plotter =
    let angle = Math.Round(360.0 / float sides)
    List.fold (fun s i -> 
                turn angle (move length s)) 
                    plotter [1.0..(float sides)]

let triangle = initPLotter |> poligon 3 30

//triangle.bitmap.Save(pathAndFileName)


    
//let fuzzy =
//    seq {
//        for x in 1..100 do
//            yield if x % 3 = 0 && x % 5 = 0 
//                then "FizzBuzz"
//                elif x % 3 = 0 then "Fizz"
//                elif x % 5 = 0 then "Buzz"
//                else x.ToString() }  
    
//let commandStripe =
//    [   move 15
//        turn 15.0
//        poligon 3 10
//    ]
//
//let cmdsGen = seq {while true do yield! commandStripe}
//
//let imageCommands = cmdsGen |> Seq.take 75
//
//let image =
//    imageCommands 
//    |> Seq.fold (fun plot cmds -> plot |> cmds) initPLotter
//
//image.bitmap.Save(pathAndFileName)


//    let r  = com |> Seq.reduce (fun acc elem -> action (fst elem) (snd elem) acc)
    
  
//    initPLotter 
//    |> (action (command.Move) 15.0)
//    |> turn 90.0
//    |> move 60
//    |> turn 90.0
//    |> move 15
//    |> turn -90.0
//    |> move 20
//    |> turn -90.0 
//    |> move 15    


//let drawn = naiveLine (44, 44) initPLotter

//drawn.bitmap.Save(pathAndFileName)


//naiveLine (0,0) (38,0) Color.Navy bitmap2
//naiveLine (38,0) (38,26) Color.Navy bitmap2
//naiveLine (0,0) (0,26) Color.Navy bitmap2
//naiveLine (1,1) (19,19) Color.Navy bitmap2
//naiveLine (20,18) (37,1) Color.Navy bitmap2
//naiveLine (0,26) (38,26) Color.Navy bitmap2

//let bitmap = new Bitmap(16, 16)
//
//let path = __SOURCE_DIRECTORY__ + "/"  //System.Environment.CurrentDirectory + "/"
//
//fill Color.Red bitmap
//
//let smileXY = [|(5,5); (5,10); (8,8);(12,5); (13,6); (13,7); (13,8); (13,9); (12,10)|]
//
//let squard a = 
//    (Array.append (Array.append (Array.append [| for i in 0 .. a -> (0,i)|]  [| for i in 0 .. a -> (i,0)|]) [| for i in 0 .. a -> (a,i)|]) [| for i in 0 .. a -> (i,a)|])
//    
//    
//
//
//let draw bm coorsination =
//    let bitmap:Bitmap = bm
//    let xy = coorsination //[|(5,5); (5,10); (8,8);(12,5); (13,6); (13,7); (13,8); (13,9); (12,10)|]
//    xy 
//    |> Seq.iter (fun a -> 
//                        bitmap.SetPixel(fst(a) , snd(a) , Color.DarkOrange)  ) 
//    |> ignore
//    
//    bitmap 
// 
//   
//    
//let savebm bm =
//    let bitmap:Bitmap = bm
//    bitmap.Save(path + "plot.png", Imaging.ImageFormat.Png)
//
//let f = savebm (draw (draw bitmap (squard 15)) smileXY)
//f
//
//let person = ("Dima", "Zyadik", "Nizh", 32)
//
//type Date = {
//    day : int
//    month: int
//    year:int
//}
//
//type Person = 
//    { 
//    firstName: string
//    lastName: string
//    city: string
//    age: int    
//    birth: Date
//    }
//
//let me = { 
//    firstName="Dima" 
//    lastName="Gray"
//    city = "Nizh"
//    age = 32
//    birth = {day=15;month=5; year=1984}
//    }
//let { firstName = myFirstName } = me
//let { lastName = myLastName } = me
//let { city = myCity } = me
//let { age = myAge } = me
//    
//let myFullName = me.firstName + "" + me.lastName
//
//let temp = { me with age=30 } 
//
//let updateBirth person newbirth =
//    let update = { person with birth = newbirth}
//    printfn "%A" update
//    update
//
//let p = printfn "%A" (updateBirth me {day=15;month=5;year=1994})


[<EntryPoint>]
let main argv = 
    //printfn "%A" argv       

//    (move 15
//        (turn 90.0 
//            (move 60
//                (turn 90.0 
//                    (move 15
//                        (turn -180.0 ( initPLotter))))))).bitmap.Save(pathAndFileName)
    
    //p
    //cmd.Execute() |> printfn "%A"
    //List.reduce incomos ["d"; "s"; "a"] |> printfn "%A"
    //dr.bitmap.Save(pathAndFileName)
    //let rect = rectangle 60 30

    //rect.bitmap.Save(pathAndFileName)

    triangle.bitmap.Save(pathAndFileName)
   // image.bitmap.Save(pathAndFileName)
    
    0 // возвращение целочисленного кода выхода
   

