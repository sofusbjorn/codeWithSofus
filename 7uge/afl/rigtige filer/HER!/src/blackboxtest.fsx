module rotate 
/// Create:
printfn "\nBlack-box testing af create"
printfn "%5b: m=0u" (List.isEmpty (rotate.create (0u)))
printfn "%5b: 2x2" (rotate.create (2u) = ['a' .. 'd'])
printfn "%5b: 3x3" (rotate.create (3u) = ['a' .. 'i'])
printfn "%5b: 4x4" (rotate.create (4u) = ['a' .. 'p'])
printfn "%5b: 5x5" (rotate.create (5u) = ['a' .. 'y'])
printfn "%5b: m=15u" (List.isEmpty (rotate.create (15u)))

///board2Str:
printfn "Black-box testing af board2Str"
printfn "%5b: b=[]" (rotate.board2Str [] = "Illegal input")
printfn "%5b: b=['a'..'d']" (rotate.board2Str (rotate.create (2u)) = String.collect (sprintf " %c") "ab\ncd")
printfn "%5b: b=['a'..'y']" (rotate.board2Str (rotate.create (5u)) = String.collect (sprintf " %c") "abcde\nfghij\nklmno\npqrst\nuvwxy")
printfn "%5b: b=(create 15u)" (rotate.board2Str (rotate.create (15u)) = "Illegal input")

/// validRotation:
printfn "Black-box testing af validRotation"
printfn "%5b: b=(create 3u) p=2" (not(rotate.validRotation (rotate.create (3u)) (2)))
printfn "%5b: b=(create 3u) p=0" (rotate.validRotation (rotate.create (3u)) (0))
printfn "%5b: b=(create 3u) p=7 " (not(rotate.validRotation (rotate.create (3u)) (7)))
printfn "%5b: b=(create 5u) p=13" (rotate.validRotation (rotate.create (5u)) (13))

/// rotate:
printfn "Black-box testing af rotate"
printfn "%5b: b=(create 2u) p=0" ((rotate.rotate (rotate.create 2u) 0) = ['c';'a';'d';'b'])
printfn "%5b: b=(create 2u) p=1" ((rotate.rotate (rotate.create 2u) 1) = ['a';'b';'c';'d'])
printfn "%5b: b=(create 5u) p=16" ((rotate.rotate (rotate.create 5u) 16) = ['a'..'p'] @ ['v';'q'] @ ['s'..'u'] @ ['w';'r'] @ ['x';'y'] )
printfn "%5b: b=(create 5u) p=24" ((rotate.rotate (rotate.create 5u) 24)= ['a' .. 'y'])

/// scramble: 
printfn "Black-box testing af scramble"
printfn "%5b: b=['a'..'d'] m=10u" (rotate.scramble ['a'..'d'] 10u <> (rotate.create (2u)))
printfn "%5b: b=['a'..'d'] m=0u" (rotate.scramble ['a'..'d'] 0u = (rotate.create (2u)))
printfn "%5b: b=['a'..'y'] m=7u" (rotate.scramble ['a'..'y'] 7u <> ['a'..'y'])
printfn "%5b: b=['a'..'y'] m=1u" (rotate.scramble ['a'..'y'] 1u <> ['a'..'y'])

/// solved:
printfn "Black-box testing af solved"
printfn "%5b: b=(create 2u)" (rotate.solved (rotate.create 2u) = true)
printfn "%5b: b=(scramble(create 5u) 10u)" (rotate.solved (rotate.scramble (rotate.create 5u) 10u) = false)
printfn "%5b: b=(scramble(create 2u) 1u)" (rotate.solved (rotate.scramble (rotate.create 2u) 1u) = false)
printfn "%5b: b=(create 5u)" (rotate.solved (rotate.create 5u) = true)
