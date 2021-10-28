open rotate

let rec theGame (b : Board): unit =
      printfn " "
      printfn "%s" (board2Str (b)) 
      printfn " "
      printfn "Choose your desired position to rotate:"
      let userInput = System.Console.ReadLine()
      match b with
      |x when (solved (rotate (b) (int(userInput)))) ->
            printfn " " 
            printfn "%s" (board2Str(rotate (b) (int(userInput))))
            printfn "Solved!"
            ()
      |_ -> (theGame (rotate (b) (int(userInput))))

let rec game (unit) : unit =
  printfn " "
  printfn "Please choose your desired boardsize (2, 3, 4, 5):" 
  let userInput2 = int(System.Console.ReadLine())
  match userInput2 with
  | x when userInput2 > 5 -> 
      printfn "Illegal input"
      (game ())
  | x2 when userInput2 < 2 -> 
      printfn "Illegal input"
      (game ())
  | _ -> (theGame (scramble (create (uint(userInput2))) (10u)))

game ()
    