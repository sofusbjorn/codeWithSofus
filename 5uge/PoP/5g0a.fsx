let isTable (llst : 'a list list) : bool =
    if (llst.Item 0).IsEmpty = false && (llst.Item 1).IsEmpty = false  && (llst.Item 0).Length = (llst.Item 1).Length then
        true
    elif (llst.Item 0).IsEmpty = true || (llst.Item 1).IsEmpty = true then
        false
    else
        false

let llst = [[1;2];[1;2]]
printfn "%A" (isTable llst)
printfn "%A" (isTable [[1;2;3;4;5];[1;2;3;4;5]])
printfn "%A" (isTable [[1];[1;2]])
printfn "%A" (isTable [[];[]])
