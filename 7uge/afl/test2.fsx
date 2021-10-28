type Position = int
type Board = char list
let rnd = System.Random ()
let boardSizeFun (b : Board) : int =  b |> List.length |> double |> sqrt |> int

let create (n : uint ) : Board =
    let lst = ['a' .. 'y']
    lst.[0..((int (n) * int (n))-1)]

let create2 (n: uint) : Board = 
  let lst = ['a' .. 'y']
  match n with
  |n when n > 5u -> []
  |_ -> lst.[0 ..(int(n*n)-1)]

let validRotation2 (b : Board) (p : Position) : bool =
   match p with
   | p when (1 + p = boardSizeFun (b)) -> false
   | p2 when (1 + p = 2 * (boardSizeFun (b))) -> false
   | p3 when (1 + p = 3 * (boardSizeFun (b))) -> false
   | p4 when (1 + p = 4 * (boardSizeFun (b))) -> false
   | p5 when (1 + p > b.Length - (boardSizeFun (b))) -> false
   | _ -> true

let board2CoolStr (b : Board) : string =
    let (boardSize : int) = int(sqrt(double b.Length))
    match b.Length with
    | 4 -> sprintf("a b") + sprintf ("\n") + sprintf("c d")
    | 9 -> sprintf("a b c") + sprintf ("\n") + sprintf("d e f") + sprintf ("\n") + sprintf("g h i")
    | 16 -> sprintf("a b c d") + sprintf ("\n") + sprintf("e f g h") + sprintf ("\n") + sprintf("i j k l")+ sprintf ("\n") + sprintf("m n o p")
    | 25 -> sprintf("a b c d e") + sprintf ("\n") + sprintf("f g h i j") + sprintf ("\n") + sprintf("k l m n o") + sprintf ("\n") + sprintf("p q r s t") + sprintf ("\n") + sprintf("u v w x y")  

let board2Str (b : Board) : string = 
    List.toArray b |> System.String

let validRotation (b : Board) (p : Position) : bool =
    match p with
    | x1 when double p = double 1 + (sqrt (double (b.Length))) -> false
    | x2 when double p = double 1 + (double 2 * sqrt (double (b.Length))) -> false
    | x3 when double p = double 1 + (double 3 * sqrt (double (b.Length))) -> false
    | x4 when double p = double 1 + (double 4 * sqrt (double (b.Length))) -> false
    | x5 when double p > double 1 + ((double b.Length) - (double (sqrt (double b.Length)))) -> false
    | _ -> true

let rotate2 (b: Board) (p: Position) : Board = 
   match p with
   |p when (not(validRotation (b) (p))) -> b
  
   |_ -> b.[0..(p-1)] @ (b.[p + boardSizeFun (b)] :: (b.[p] :: (b.[(p+2) .. (p+boardSizeFun(b)-1)] @ (b.[p+boardSizeFun(b)+1] :: (b.[p+1] :: (b.[(p+boardSizeFun(b)+2)..]))))))          


let rotate (b : Board) (p : Position) : Board =
    let (boardSize : int) = int(sqrt(double b.Length))
    if validRotation (b) (p) then
        b.[0..(p-1)] @ (b.[p + boardSize] :: (b.[p] :: (b.[(p+2) .. (p+boardSize-1)] @ (b.[p+boardSize+1] :: (b.[p+1] :: (b.[(p+boardSize+2)..])))))) 
    else b

let rec allowedRotation (b : Board) (p : Position) : Position =
        let (boardSize : int) = int(sqrt(double b.Length))
        if (validRotation (b) (p)) then p
        else (allowedRotation (b) (rnd.Next (boardSize)))

//printf "%A " (allowedRotation (create 5u) (rnd.Next 25))
//printf "%A " (allowedRotation (create 5u) (rnd.Next 25))  
//printf "%A " (allowedRotation (create 5u) (rnd.Next 25))  
//printf "%A " (allowedRotation (create 5u) (rnd.Next 25))  
//printf "%A " (allowedRotation (create 5u) (rnd.Next 25))  
//printf "%A " (allowedRotation (create 5u) (rnd.Next 25))  
//printf "%A " (allowedRotation (create 5u) (rnd.Next 25))  
//printf "%A " (allowedRotation (create 5u) (rnd.Next 25))  
//printf "%A " (allowedRotation (create 5u) (rnd.Next 25))  
//printf "%A " (allowedRotation (create 5u) (rnd.Next 25))  
//printf "%A " (allowedRotation (create 5u) (rnd.Next 25))  
//printfn "%A" (allowedRotation (create 5u) (rnd.Next 25))  


//let scramble (b : Board) (m : uint) : Board =
  //  let (boardSize : int) = int(sqrt(double b.Length))
    //let rec scrambler (b : Board) (p : Position) (m : uint) : Board =
      //  match m with
        //| 0u -> b
        //| _ -> (scrambler (rotate (b) (allowedRotation (b) (p))) (allowedRotation (b) (p)) (m-1u)) 
    //scrambler (b) (allowedRotation (b) (rnd.Next (boardSize))) (m)


let rec scramble (b: Board) (m: uint) : Board =
  match m with
  | 0u -> b
  | _ -> scramble (rotate (b) (rnd.Next (boardSizeFun (b))) (m-1u)

let solved (b : Board) : bool =
    let (boardSize : int) = int(sqrt(double b.Length))
    match b with
    | itsTrue when b = (create (uint(boardSize))) -> true
    | _ -> false

// let rec actualGame (b : Board) : string =
//         printfn "%A" b
//         printfn "please choose the square you want to rotate:"
//         let (input3 : int) = System.Console.ReadLine
//         match b with
//         | solved when solved (b) = true -> "You did it well done"
//         | _ -> (actualGame (rotate (b) (input3)))

// let game () : string =
//     printfn "Please choose a board size: 2,3,4,5:"
//     let (input : int) = System.Console.ReadLine
//     printfn "Please choose how many times you want the board scrambled:"
//     let (input2 : int) = System.Console.ReadLine
//     let (b : Board) = (scramble2 ((create (uint(input)))(uint(input2))))
//     (actualGame b)
    
    

printfn "%A" (create2 (15u))
//printfn "%b" (validRotation (create 4u) (13))
//printfn "%b" (validRotation (create 4u) (12))
//printfn "%b" (validRotation (create 4u) (6))
//printfn "%b" (validRotation (create 5u) (25))
//printfn "%b" (validRotation (create 5u) (21))
//printfn "4x4 med a: %20A" (rotate (create 4u) (0))
//printfn "4x4 med d: %20A" (rotate (create 4u) (3))
//printfn "4x4 med j: %20A" (rotate (create 4u) (9))
//printfn "%20A" (create (4u))
//printfn "%20A" (rotate (create 4u) (10))
//printfn "%25A" (scramble2 (create 5u) (20u))

//printfn "%A" (solved (create (4u)))
//printfn "%s \n" (board2CoolStr(scramble2 (create 4u) (20u)))
//printfn "%s" (board2CoolStr(create 5u))

printfn "%5b" (not(validRotation2 (create2 (3u)) (2)))
printfn "%5b" (validRotation2 (create2 (3u)) (0))
printfn "%5b" (not(validRotation2 (create2 (3u)) (7)))
printfn "%5b" (validRotation2 (create2 (5u)) (13))