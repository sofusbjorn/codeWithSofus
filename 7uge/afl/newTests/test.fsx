type Position = int
type Board = char list
let rnd = System.Random ()
let boardSizeFun (b : Board) : int =  b |> List.length |> double |> sqrt |> int

let create (n: uint) : Board = 
  let lst = ['a' .. 'y']
  match n with
  |n when n > 5u  -> []
  |_ -> lst.[0 ..(int(n*n)-1)]

let board2Str (b : Board) : string =
  List.toArray b |> System.String
 
let validRotation (b : Board) (p : Position) : bool =
   match p with
   | p when (1 + p = boardSizeFun (b)) -> false
   | p2 when (1 + p = 2 * (boardSizeFun (b))) -> false
   | p3 when (1 + p = 3 * (boardSizeFun (b))) -> false
   | p4 when (1 + p = 4 * (boardSizeFun (b))) -> false
   | p5 when (1 + p > b.Length - (boardSizeFun (b))) -> false
   | _ -> true

let rotate (b: Board) (p: Position) : Board = 
   match p with
   | p when (not(validRotation (b) (p))) -> b
   | _ -> b.[0..(p-1)] @ (b.[p + boardSizeFun (b)] :: (b.[p] :: (b.[(p+2) .. (p+boardSizeFun(b)-1)] @ (b.[p+boardSizeFun(b)+1] :: (b.[p+1] :: (b.[(p+boardSizeFun(b)+2)..]))))))           

let rec scramble (b: Board) (m: uint) : Board =
  
  let rec rotationsAllowed (b : Board) (p : Position) : Position =
    if validRotation (b) (p) then p
    else rotationsAllowed (b) (rnd.Next (boardSizeFun (b)))
  
  match m with
  | 0u -> b
  | _ -> scramble (rotate (b) (rotationsAllowed (b) (rnd.Next (b.Length)))) (m-1u)

let solved (b: Board) : bool =
   match b with 
   | b when b = create((uint(boardSizeFun (b)))) -> true 
   | _ -> false

let rec rotationsAllowed2 (b : Board) (p : Position) : Position =
    if validRotation (b) (p) then p
    else rotationsAllowed2 (b) (rnd.Next (boardSizeFun (b)))

let board2StrButRight (b : Board) : string =
    match b with
    | x2 when (boardSizeFun (b) = 2) -> ((board2Str (b.[0 .. 1]))) + "\n" + (board2Str (b.[2 .. 3]))
    | x3 when (boardSizeFun (b) = 3) -> (board2Str (b.[0..2])) + "\n" + (board2Str (b.[3..5])) + "\n" + (board2Str (b.[6..9]))
    | x4 when (boardSizeFun (b) = 4) -> (board2Str (b.[0..3])) + "\n" + (board2Str (b.[4..7])) + "\n" + (board2Str (b.[8..11])) + "\n" + (board2Str (b.[12..15]))
    | x5 when (boardSizeFun (b) = 5) -> (board2Str (b.[0..4])) + "\n" + (board2Str (b.[5..9])) + "\n" + (board2Str (b.[10..14])) + "\n" + (board2Str (b.[15..19])) + "\n" + (board2Str (b.[20..24]))


printfn "%5s" (board2StrButRight(scramble (create 5u) (100u)))