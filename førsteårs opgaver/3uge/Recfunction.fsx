printfn "Sum calculator 3.0"
printfn "Please insert number: "

let input = int (System.Console.ReadLine())

let rec plus (x : int) (str : string) : string =
    let str = " "
    let n = x
    if n = 0 then printfn "%s" str

    else
        plus(n-1, "0" + str)
	plus(n-1, "1" + str)
	
let cal = plus input
printfn "%s" cal
