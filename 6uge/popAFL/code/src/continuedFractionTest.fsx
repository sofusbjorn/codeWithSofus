open continuedFraction

let (=~) a b = 
    a < b + 0.00001 && a > b - 0.00001

///BLACKBOX-TEST TID
printfn " "
printfn "Black-Box testing af de to rekursive funktioner"
printfn "cfrac2float:"
printfn " %5b: []" (cfrac2float [] = 0.0)
printfn " %5b: Indeholder et nul: [ _ 0]" (cfrac2float [1;0] = infinity)
printfn " %5b: Et element: [100]" (cfrac2float [100] = 100.0)
printfn " %5b: [1;2;3;4]" (cfrac2float [1;2;3;4] =~ 1.43333)
printfn " "
printfn "float2cfrac:"
printfn " %5b: 0.0" (float2cfrac 0.0 = [0])
printfn " %5b: 3.235" (float2cfrac 3.245 = [3;4;12;4])
printfn " %5b: 7.246378" (float2cfrac 7.246378 = [7;4;17;176;1;2;6;2])
printfn " %5b: 3.2459" (float2cfrac 3.2459 = [3;4;14;1;163])
printfn " "
printfn "White-Box testing af de to rekursive funktioner"
printfn "cfrac2float:"
printfn " %5b: Branch 1a" (cfrac2float [1;2;3;4] =~ 1.43333)
printfn " %5b: Branch 1b" (cfrac2float [] = 0.0)
printfn " %5b: Branch 1c" (cfrac2float [100] = 100.0)
printfn " %5b: Branch 1d" ((cfrac2float [-1;-2;-3;4] = -1.43333) = false)
printfn " "
printfn "float2cfrac:"
printfn " %5b: Branch 1a" (float2cfrac 3.245 = [3;4;12;4])
printfn " %5b: Branch 1b" (float2cfrac 100.0 = [100])
printfn " %5b: Branch 1c" (float2cfrac 7.246378 = [7;4;17;176;1;2;6;2])
printfn " %5b: Branch 1d" (float2cfrac 3.2459 = [3;4;14;1;163])