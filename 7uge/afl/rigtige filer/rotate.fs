module rotate
type Position = int
type Board = char list
let rnd = System.Random ()
let boardSizeFun (b : Board) : int =  b |> List.length |> double |> sqrt |> int

let create (n: uint) : Board = 
  let lst = ['a' .. 'y']
  match n with
  |n when n > 5u  -> []
  |_ -> lst.[0 ..(int(n*n)-1)]

let rec board2Str (b : Board) : string = 
  let str (b : Board) : string = List.toArray b |> System.String
  match b with
  | x when (boardSizeFun (b) = 2) -> (str (b.[0 .. 1])) + "\n" + (str (b.[2 .. 3])) |> String.collect (sprintf " %c")
  | x2 when (boardSizeFun (b) = 3) -> (str (b.[0..2])) + "\n" + (str (b.[3..5])) + "\n" + (str (b.[6..9])) |> String.collect (sprintf " %c")
  | x3 when (boardSizeFun (b) = 4) -> (str (b.[0..3])) + "\n" + (str (b.[4..7])) + "\n" + (str (b.[8..11])) + "\n" + (str(b.[12..15])) |> String.collect (sprintf " %c")
  | x4 when (boardSizeFun (b) = 5) -> (str (b.[0..4])) + "\n" + (str (b.[5..9])) + "\n" + (str (b.[10..14])) + "\n" + (str (b.[15..19])) + "\n" + (str (b.[20..24])) |> String.collect (sprintf " %c")
  |_ -> "Illegal input"

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
    else rotationsAllowed (b) (rnd.Next (b.Length))
  
  match m with
  | 0u -> b
  | _ -> scramble (rotate (b) (rotationsAllowed (b) (rnd.Next (b.Length)))) (m-1u)
 
let solved (b: Board) : bool =
   match b with 
   | b when b = create((uint(boardSizeFun (b)))) -> true 
   | _ -> false