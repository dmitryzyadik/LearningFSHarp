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

open FsharpTv



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
   

