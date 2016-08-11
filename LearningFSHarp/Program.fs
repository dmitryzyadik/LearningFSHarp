// Дополнительные сведения о F# см. на http://fsharp.org
// Дополнительную справку см. в проекте "Учебник по F#".
#if INTERACTIVE
#r "FSharp.Data.SqlClient.dll"
#endif
open FSharp.Data

[<Literal>]
let connectionString = @"Data Source=SQLBACK-WIN12;Initial Catalog=cLines; User=sa; Password=bug;"

let cmd = new SqlCommandProvider<"SELECT TOP 1 [id],[DeviceName],[Description],[Owner] ,[TypeDevice] ,[idImage]  FROM [cLines].[dbo].[Device]" , connectionString >(connectionString)

let incomos (acc:string) 
    item = acc + item

let addAcc acc i = acc + i

[<EntryPoint>]
let main argv = 
    printfn "%A" argv       

    //cmd.Execute() |> printfn "%A"
    //List.reduce incomos ["d"; "s"; "a"] |> printfn "%A"
    List.fold addAcc 


    0 // возвращение целочисленного кода выхода
   

