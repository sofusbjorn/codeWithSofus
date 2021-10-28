open rotate

let game (unit) : unit =
  printfn "Please choose your desired boardsize (2, 3, 4, 5)" 
    let rec theGame (b : Board): uint =
      printfn "%A" b
      printfn "choose your desired position to rotate"
      match b with
      |x when (solved (b)) -> ()
      |_ -> (theGame (rotate (b) (System.Console.ReadLine)))
  (theGame (scramble (create (uint (System.Console.ReadLine))) (100u)))
    