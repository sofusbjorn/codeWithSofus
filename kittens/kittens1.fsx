let hw (unit) : unit = 
    let input = System.Console.ReadLine()
    let toList = [input]
    printfn "%s" (input + " " + input + " " + input)


hw ()