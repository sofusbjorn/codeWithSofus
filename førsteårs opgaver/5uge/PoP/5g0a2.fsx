let isTable (llst : 'a list list) : bool =
    for x in llst do
        if (llst.Item x).IsEmpty = false && (llst.Item x+1).IsEmpty = false
		 && (llst.Item x).Length = (llst.Item x+1).Length then
            true
        elif (llst.Item x).IsEmpty = true || (llst.Item x+1).IsEmpty = true then
            false
        else
            false

let llst = [[1;2];[1;2]]
printfn "%A" (isTable llst)
printfn "%A" (isTable [[1;2;3;4;5];[1;2;3;4;5]])
printfn "%A" (isTable [[1];[1;2]])
printfn "%A" (isTable [[];[]])
