open rotate

let rec theGame (b : Board): unit =
      System.Console.Clear ()
      printfn "\n%s" (board2Str (b)) 
      printfn "\nIf you give up, simply type: quit"
      printfn "Choose your desired position to rotate:"
      let userInput = System.Console.ReadLine()
      match userInput with
      | "quit" ->
            printfn "\nThanks for playing, better luck next time"
            () 
      |_ -> match System.Int32.TryParse userInput with
            | false,int -> 
                  printfn "Illegal input"
                  (theGame (b))
            | _ -> match userInput with
                        | x when (int(userInput)) < 1 -> 
                              printfn "Illegal input"
                              (theGame (b))
                        | _ -> match b with
                                    |x when (solved (rotate (b) (int(userInput) - 1))) ->
                                          printfn "\n%s" (rotate b ((int userInput) - 1) |> board2Str) //board2Str(rotate (b) (int(userInput)))
                                          printfn "Solved!"
                                          ()
                                    |_ -> rotate b ((int userInput) - 1) |> theGame

let rec game (unit) : unit =
  printfn "\nPlease choose your desired boardsize (2, 3, 4, 5):" 
  let userInput2 = System.Console.ReadLine()
  match System.Int32.TryParse userInput2 with
      | false,int -> 
            printfn "Illegal input"
            (game ())
      | _ -> match userInput2 with
                  | x when (int(userInput2)) > 5 -> 
                        printfn "Illegal input"
                        (game ())
                  | x2 when (int(userInput2)) < 2 -> 
                        printfn "Illegal input"
                        (game ())
                  | _ -> (theGame (scramble (create (uint(userInput2))) (10u)))

game ()
    