let printLstAlt (lst : 'a list) : unit =
    for elm in lst do
        printf "%A " elm
    printfn " "

printLstAlt [1;2;3]
printLstAlt ["HI"; "YOUR MOTHER"; "IM GONNA"; "DO HER"]
