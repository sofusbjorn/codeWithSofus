/// Når koden køres, kommer teksten frem i terminalen. 
printfn "Sum calculator and simpleSum 3.0"
printfn "Please insert number: "


/// Brugeren bliver bedt om et input, n.
let input = int (System.Console.ReadLine())
printfn " "

/// <summary> Funktion som finder summen af alle tal op til n, ved brug af sumformlen = (n*(n+1))/2 </summary>
/// <remarks>For alle n ≥ 1 bliver der returneret 0. </remarks> 
/// <param name="n">Positivt heltal, bruger inputtet fra konsollen</param>
/// <returns>Summen af alle tal op til brugerinputtet, n</return>

let sumSimple (n : int) : int =
    if n >= 0 then
        (n*(n+1))/2
    else
        0
    
(* 3g0b: sumformlen kan skrives ud som s1 =  1 + 2 + 3 +4 + ... n
Hvis man så lægger det udtryk sammen med den omvendte rækkefølge s2 = n + (n - 1) + (n-2)+...1, altså:
(s1 + s2) = (n + 1) + (n + 1) + (n + 1) + ... (n + 1) = n(n+1)
Men da vi tog udgangspunkt i 2 gange udtrykket divideres med 2. Dermed er sumformlen udtrykt ved:
(n(n+1))/2. *)


/// <summary> Funktion som finder summen af alle tal op brugerinputtet, n, ved brug af whileloop </summary>
/// <remarks>For alle n ≥ 1 bliver der returneret 0. </remarks> 
/// <param name="n">Positivt heltal, bruger inputtet fra konsollen</param>
/// <returns>Summen af alle tal op til brugerinputtet, n</return>

let sum (n : int) : int =

    let mutable i = 1
    let mutable sumFunc = 0
    
    while i <= n do
        sumFunc <- sumFunc + i
        i <- i + 1
    sumFunc


let calSimple : int = sumSimple input
let calSum : int = sum input


printfn "The sum from %A to 1 is %i" input calSum
printfn "And the sumSimple from %A to 1 is %i" input calSimple


printfn " "
printfn "%s %4s %7s" "n" "sum n" "sumSimple n"

/// <summary> Laver en tabel ved hjælp af et for-loop og placeholder parameterization</summary>
/// <returns>En tabel med tre kolonner og ti rækker med værdierne n = 1 ... 10, for sum n og sumSimple n </returns>

for j = 1 to 10 do
    if j < 10 then
        printfn "%A %4i %4i" j (sum j) (sumSimple j)
    else
        printfn "%A %3i %4i" j (sum j) (sumSimple j)

(* Opgave 3g0e) Typen integer (int) er defineret for -2.147.483.648 til 2.147.483.647, og log_2 af tallet, er 31, hvilket vil sige at typen er defineret fra -2^(31) til 2^(31).
I funktionen sum lægges talene sammen, vha. while-loppet og den maksimale værdi for n kan dermed udregnes vha sumformlen, hvor følgende ligning løses, med henblik på n:
 ((n*(n+1))/2)=2^(31), hvilket giver 65536,5.
 Den største værdi for n for Sum er altså 65536.

I SimpleSum hvor sumformlen benyttes som funktionen, er den maksimale værdi for n kvadroden af 2^(31) da udtrykket indeholder n*n og funktionen her ville skulle håndtere en værdi der er ude for definationenfor int.Den største værdi for n for SimpleSum er altså 46340.


For at forbedre funktionerne kan typen int64 eller typen uint64 benyttes.
int64 er defineret for -9.223.372.036.854.775.808 til 9.223.372.036.854.775.807,
hvor uint64 er defineret for 0 til 18.446.744.073.709.551.615.
Det vurderes at den type der giver bedst mening for vores funktion er uint64, da vi ikke er interesserede i n < 1.
Man kan altså optimere funktionen ved at benytte typen uint64 istedet for int.*)

