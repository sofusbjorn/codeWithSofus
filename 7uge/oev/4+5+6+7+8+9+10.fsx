type suit = Hearts | Diamonds | Clubs | Spades
type rank = Two | Three | Four | Five | Six | Seven | Eigth | Nine | Ten | Jack | Queen | King | Ace
type card = rank * suit
let succSuit (s : suit) : suit option =
    match s with
    | Hearts -> Some Diamonds
    | Diamonds -> Some Clubs
    | Clubs -> Some Spades
    | Spades -> None
let succRank (r : rank) : rank option =
    match r with
    | Two -> Some Three
    | Three -> Some Four 
    | Four -> Some Five
    | Five -> Some Six
    | Six -> Some Seven
    | Seven -> Some Eigth
    | Eigth -> Some Nine
    | Nine -> Some Ten
    | Ten -> Some Jack
    | Jack -> Some Queen
    | Queen -> Some King
    | King -> Some Ace
    | Ace -> None
printfn "%A" (succRank King)
printfn "%A" (succRank Ace)

// old but doesnt really do what it is meant to// or does it?
let succCard (c : card) : card option =
    match c with
    | (Ace,Spades) -> None
    | _ -> match (succRank (fst c), succSuit (snd c)) with
                     | (Some rank, Some suit) -> Some (rank, suit)
                     | (None, Some suit) -> Some (Two, suit)
                     | (Some rank, None) -> Some (rank, Hearts)
                     | (None, None) -> None
      


printfn "succcard %A" (succCard (Two, Hearts))
printfn "succard %A" (succCard (Three, Hearts))
printfn "succard %A" (succCard (Ace, Hearts))
printfn "succard %A" (succCard (Ace, Spades))
printfn "succard %A" (succCard (Two, Spades))

let rec helpingRec (c : card) (lst : card list) : card list =
    match c with
    | _ -> match succCard (c) with
            | None -> lst
            | Some (rank , suit) -> helpingRec (rank , suit ) (lst @ [(rank , suit)])   

let initDeck (unit) : card list =
    helpingRec (Two, Hearts) [(Two , Hearts)] 

printfn "%65A" (initDeck ())

let sameRank (c : card) (cc : card) : bool =
    (fst c) = (fst cc)

let sameSuit (c : card) (cc : card) : bool =
    (snd c) = (snd cc)

printfn "%A" (sameRank (Two, Hearts) (Two, Spades))
printfn "%A" (sameRank (Three, Spades) (Two, Spades))
printfn "%A" (sameRank (Two, Hearts) (Ace, Spades))


printfn "%A" (sameSuit (Two, Hearts) (Two, Spades))
printfn "%A" (sameSuit (Three, Spades) (Two, Spades))
printfn "%A" (sameSuit (Two, Clubs) (Ace, Clubs))

let highCard (c : card) (cc : card) : card =
    if sameRank (c) (cc) then c
    elif (fst c) >= (fst cc) then c
    else cc

printfn "%A" (highCard (Five, Spades) (Two, Spades))
printfn "%A" (highCard (Five, Hearts) (Two, Diamonds))
printfn "%A" (highCard (Five, Spades) (Two, Diamonds))
printfn "%A" (highCard (Six, Spades) (Six, Diamonds))
printfn "%A" (highCard (Six, Hearts) (Ace, Diamonds))