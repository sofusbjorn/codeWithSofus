let f x = 3 * x + 4

let mutable i = 0
while i <= 5 do
  let a = f i
  printfn "%A" a
  i <- i + 1
printf "\n"