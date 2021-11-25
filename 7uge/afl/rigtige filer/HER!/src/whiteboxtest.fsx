///White box test
///Create white-box test
module rotate

printfn "White-box testing af create"
printfn " %5b: Branch 1a" (rotate.create 6u = [])
printfn " %5b: Branch 2a" (rotate.create 4u = ['a' .. 'p'])
printfn " %5b: Branch 1b" (rotate.create 50u = [])
printfn " %5b: Branch 2a" (rotate.create 5u = ['a' .. 'y'])

printfn "White-box testing af board2Str" //fucker
printfn " %5b: Branch 1a" ((rotate.board2Str ['a'..'d']) = String.collect (sprintf " %c") "ab\ncd")
printfn " %5b: Branch 2a" ((rotate.board2Str ['a' .. 'i']) = String.collect (sprintf " %c") "abc\ndef\nghi")
printfn " %5b: Branch 3a" ((rotate.board2Str ['a' .. 'p'])= String.collect (sprintf " %c") "abcd\nefgh\nijkl\nmnop")
printfn " %5b: Branch 4a" ((rotate.board2Str ['a' .. 'y'] )= String.collect (sprintf " %c") "abcde\nfghij\nklmno\npqrst\nuvwxy")
printfn " %5b: Branch 5a" (rotate.board2Str (rotate.create (15u)) = "Illegal input") // I princippet nås denne branch ikke, men vi tager casen med for, at have en gennemført pattern matching.


printfn "White-box testing af validRotation"
printfn " %5b: Branch 1a" (rotate.validRotation ['a'..'d'] 1 = false)
printfn " %5b: Branch 2a" (rotate.validRotation ['a'..'i'] 5 = false)
printfn " %5b: Branch 3a" (rotate.validRotation ['a'..'p'] 11 = false)
printfn " %5b: Branch 4a" (rotate.validRotation ['a'..'y'] 19 = false)
printfn " %5b: Branch 5a" (rotate.validRotation ['a'..'i'] 7 = false)
printfn " %5b: Branch 6a" (rotate.validRotation ['a'..'i'] 1 = true) 

printfn "White-box testing af rotate"
printfn " %5b: Branch 1a" (rotate.rotate ['a'..'d'] 1 = ['a'..'d'])
printfn " %5b: Branch 1b" (rotate.rotate ['a'..'y'] 19 = ['a'..'y'])
printfn " %5b: Branch 2a" (rotate.rotate ['a'..'d'] 0 = ['c';'a';'d';'b'])
printfn " %5b: Branch 2b" (rotate.rotate ['a'..'p'] 5 = ['a';'b';'c';'d';'e';'j';'f';'h';'i';'k';'g';'l';'m';'n';'o';'p'])

printfn "White-box testing af scramble"
printfn " %5b: Branch 1a" (rotate.scramble ['a'..'d'] 0u = ['a'..'d'])
printfn " %5b: Branch 1b" (rotate.scramble ['a'..'y'] 0u = ['a'..'y'])
printfn " %5b: Branch 2a" (rotate.scramble ['a'..'y'] 5u <> ['a'..'y'])
printfn " %5b: Branch 2b" (rotate.scramble ['a'..'d'] 7u <> ['a'..'d'])

printfn "White-box testing af solved"
printfn " %5b: Branch 1a" (rotate.solved ['a'..'d'] = true)
printfn " %5b: Branch 1b" (rotate.solved ['a'..'y'] = true)
printfn " %5b: Branch 2a" (rotate.solved ['c';'a';'d';'b'] = false)
printfn " %5b: Branch 2b" (rotate.solved ['a';'e';'b';'d';'f';'c';'g';'h';'i'] = false)


