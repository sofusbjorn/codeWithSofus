	//fsi delen

module rotate 
/// <summary> Selvdefinerede typer, der er relevant for opgaven </summary>
type Board = char list
type Position = int

/// <summary> Den tager en integer som argument, og laver et board af størrelsen n x n </summary>
/// <param name = n> Det er vores unsigned integer, som er størrelsen af boardet </param>
/// <returns> Den returnerede et board i størrelsen n x n i den løste tilstand </returns>

// Create function
val create (n: uint) -> Board

/// <summary> Den tager et board som et argument, som bliver lavet om til en string
/// <param name = b> Det er et input af typen Board </param>
/// <returns> Den returnerer det formateret boardet i form af en string </returns>

//Board to string function
val board2Str (b: Board) -> string

/// <summary> Den tjekker om rotationen er gyldig eller ikke.</summar>
/// <param name = b> Det er et input af typen Board </param>
/// <param name = p> Det er et input af typen Position </param>
/// <returns> Den returnerer true eller false, alt efter om rotationen er en gyldig rotations position eller ikke. </returns>

//Valid Rotation
val validRotation (b: Board) (p: Position) -> bool

/// <summary> Den tager et board og en rotations position, og kommer med et board efter rotationen er sket</summar>
/// <param name = b> Det er et input af typen Board </param>
/// <param name = p> Det er et input af typen Position  </param>
/// <returns> Den returnerer enten et board, hvor der er sket en 2 x 2 rotation. 
/// Hvis det er en invalid position, returneres boardet, som var argumentet</returns>

//Rotate
val rotate (b: Board) (p: Position) -> Board

/// <summary> Den "scrambler"/roterer tallene tilfældigt fra et originalt board</summar>
/// <param name = b > Det er et input af typen Board </param>
/// <param name = m > Det er en unsigned integer, som er m tilfældige "lovlige" rotationer, ved brug af funktionen rotate </param>
/// <returns> Den returnerer et andet board, hvor det originale board er blevet roteret af m forskellige rotationer</returns>

//Scramble 
val scramble (b: Board) (m: uint) -> Board

/// <summary> Den tjekker om boardet er i den løste konfiguration</summar>
/// <param name = b> Det er et input af typen Board </param>
/// <returns> Den returnerer true, hvis boardet er i den løste konfiguration og false, hvis ikke.</returns>

//Solved/Løst
val solved (b: board) -> bool

	//Black-Box - test
Create:
printfn "Can reate: %5b" (List.isEmpty (create (0u)))
printfn "%5b" (create (2u) = ['a' .. 'd'])
printfn "%5b" (create (3u) = ['a' .. 'i'])
printfn "%5b" (create (4u) = ['a' .. 'p'])
printfn "%5b" (create (5u) = ['a' .. 'y'])
printfn "%5b" (List.isEmpty (create (15u)))

board2Str:
printfn "board2Str: %5b" (board2Str (create (0u)) = "")
printfn "%5b" (board2Str (create (2u)) = "abcd")
printfn "%5b" (board2Str (create (5u)) = "abcdefghijklmnopqrstuvwxy")
printfn "%5b" (board2Str (create (15u)) = "")

validRotation:
printfn "validRotation: %5b" (not(validRotation (create (3u)) (2)))
printfn "%5b" (validRotation (create (3u)) (0))
printfn "%5b" (not(validRotation (create (3u)) (7)))
printfn "%5b" (validRotation (create (5u)) (13))

rotate:
printfn "%5b" (rotate (create (2u) (0) = ['c';'a';'d';'b']))
printfn "%5b" (rotate (create (2u) (1) = ['a';'b';'c';'d']))
printfn "%5b" (rotate (create (5u) (16) = ['a'..'p'] @ ['v';'q'] @ ['s'..'u'] @ ['w';'r'] @ ['x';'y'] ))
printfn "%5b" (rotate (create (5u) (24) = ['a' .. 'y']))

scramble: 
printfn "%5b" (scramble (create (2u) (10u) <> create (2u)))

solved:
printfn "%5b" (solved (b) = create (sqrt(b.length)) = true)
printfn "%5b" (solved (b) <> create (sqrt(b.length)) = false)

/// Implementationsfilen af rotate bibloteket (.fs)
module rotate
type Position = int
type Board = char list
let boardSizeFun (b : Board) : int =  b |> List.length |> double |> sqrt |> int
let rnd = System.Random ()

rnd.Next boardSizeFun (b) = random tal under boardSizeFun (b)

/// Create 
let create (n: uint) : Board = 
  let lst = ['a' .. 'y']
  match n with
  |n when n > 5u  -> []
  |_ -> lst.[0 ..(int(n*n)-1)]

//board2Str
let board2Str (b : Board) : string =
  List.toArray b |> System.String
  
//validRotation
let validRotation (b : Board) (p : Position) : bool =
   match p with
   | p when (1 + p = boardSizeFun (b)) -> false
   | p2 when (1 + p = 2 * (boardSizeFun (b))) -> false
   | p3 when (1 + p = 3 * (boardSizeFun (b))) -> false
   | p4 when (1 + p = 4 * (boardSizeFun (b))) -> false
   | p5 when (1 + p > b.Length - (boardSizeFun (b))) -> false
   | _ -> true
  
//Rotate
let rotate (b: Board) (p: Position) : Board = 
   match p with
   | p when (not(validRotation (b) (p))) -> b
   | _ -> b.[0..(p-1)] @ (b.[p + boardSizeFun (b)] :: (b.[p] :: (b.[(p+2) .. (p+boardSizeFun(b)-1)] @ (b.[p+boardSizeFun(b)+1] :: (b.[p+1] :: (b.[(p+boardSizeFun(b)+2)..]))))))           
   

//Scramble
let rec scramble (b: Board) (m: uint) : Board =
  
  let rec rotationsAllowed (b : Board) (p : Position) : Position =
    if validRotation (b) (p) then p
    else rotationsAllowed (b) (rnd.Next (boardSizeFun (b)))
  
  match m with
  | 0u -> b
  | _ -> scramble (rotate (b) (rotationsAllowed (b) (rnd.Next (b.Length)))) (m-1u)

//Solved
let solved (b: Board) : bool =
   match b with 
   | b when b = create((boardSizeFun (b))) -> true 
   | _ -> false
  
  
  


///Game.fsx
let rec actualGame (b : Board) : string =
        printfn "%A" b
        printfn "please choose the square you want to rotate:"
        let (input3 : int) = System.Console.ReadLine
        match b with
        | solved when solved ((rotate (b) (input3)) = true -> "You did it, well done!"
        | _ -> (actualGame (rotate (b) (input3)))

let game () : string =
    printfn "Please choose a board size: 2,3,4,5:"
    let (input : int) = System.Console.ReadLine
    printfn "Please choose how many times you want the board scrambled:"
    let (input2 : int) = System.Console.ReadLine
    let (b : Board) = (scramble ((create (uint(input)))(uint(input2))))
    (actualGame b)
    

  
  
  


