type point = int * int
type color = ImgUtil.color

type figure =
    | Circle of point * int * color
    | Rectangle of point * point * color
    | Mix of figure * figure

let (figTest : figure) = Mix(Circle((50, 50), 45, (ImgUtil.red)), Rectangle((40, 40), (90, 110), (ImgUtil.blue)))
let (figTest2 : figure) = Mix(Mix((Circle((50, 50), 45, (ImgUtil.fromRgb (255,0,0)))),(Circle((50, 100), 45, (ImgUtil.fromRgb (255,0,0))))), Rectangle((40,40),(90,110),(ImgUtil.fromRgb (0,0,255))))
// let figTest3 = Mix(Mix(Rectangle ((0, 0), (100, 100), C Color [Red]),Circle ((0, 0), 42, C Color [Red])),Mix(Rectangle ((0, 0), (100, 100), C Color [Red]), Circle ((0, 0), -42, C Color [Red])))
// let (figTest3 : figure) = Mix(Mix(Circle),(), Mix(),())

/// <summary> Finder ud af om punktet ligger i figuren, og punktets farve</summary>
/// <param name = (x,y)> koordinater / punkt </param>
/// <param name = figure> En figure </param>
/// <returns> None hvis punktet er udenfor figuren, og ellers Some color</returns>
let rec colorAt (x,y) figure = 
    match figure with
    | Circle ((cx,cy), r, col) ->
        if (x-cx)*(x-cx)+(y-cy)*(y-cy) <= r*r then Some col 
        else None
    | Rectangle ((x0,y0), (x1,y1), col) ->
        if x0<=x && x <= x1 && y0 <= y && y <= y1 then Some col 
        else None 
    | Mix (f1, f2) ->
        match (colorAt (x,y) f1, colorAt (x,y) f2) with 
        | (None, c) -> c // no overlap
        | (c, None) -> c // no overlap
        |(Some c1, Some c2) ->
            let (a1,r1,g1,b1) = ImgUtil.fromColor c1
            let (a2,r2,g2,b2) = ImgUtil.fromColor c2
            Some(ImgUtil.fromArgb((a1+a2)/2, (r1+r2)/2,(g1+g2)/2, (b1+b2)/2))

/// <summary> Laver en .png fil med et billede af figuren, i en brugerdefineret størelse</summary>
/// <param name = fileName> Filnavn </param>
/// <param name = fig> En figure </param>
/// <param name = b> Bredden på det ønskede billede </param>
/// <param name = h> Højden på det ønskede billede </param>
/// <returns> En .png af det valgte figur</returns>
let makePicture (fileName : string) (fig : figure) (b : int) (h : int) : unit =
    let canvas = ImgUtil.mk b h
    for i=0 to b-1 do
        for j=0 to h-1 do
            match (colorAt(i,j) fig) with
            | None -> ImgUtil.setPixel (ImgUtil.fromRgb(128,128,128)) (i,j) (canvas) 
            | Some color -> ImgUtil.setPixel (color) (i,j) (canvas)

    (ImgUtil.toPngFile (fileName + ".png") (canvas))


/// <summary> Checker om den inputtede figur ikke har en negativ radius (for circler),
/// og om venstre hjørne er over og til venstre for det højre hjørne (for rektangler) </summary>
/// <param name = fig> En figure </param>
/// <returns> True hvis det er en "lovlig" figur, og ellers false</returns>
let rec checkFigure (fig : figure) : bool =
    match fig with
    | Circle (_,r,_) when r > 0 -> false
    | Rectangle ((x1,y1),(x2,y2),_) when y1 > y2 || x1 > x2  -> false
    | Mix (first,second) when (checkFigure (first) = false) || (checkFigure (second) = false) -> false
    | _ -> true

/// <summary> Rykker en figur henad en vektor </summary>
/// <param name = fig> En figure </param>
/// <param name = vec> En vektor (int * int) </param>
/// <returns> En figure der er rykket af en vektor</returns>
let rec move (fig: figure) (vec: point) : figure =
    if (checkFigure (fig)) then
        match fig with
        | Circle((x,y),r,a) -> Circle((fst vec + x, snd vec + y),r,a)
        | Rectangle ((x1,y1),(x2,y2),c) -> Rectangle ((fst vec + x1, snd vec + y1),(fst vec + x2, snd vec + y2),c)
        | Mix(first,second) -> Mix((move first vec),(move second vec))
    else fig


/// <summary> Finder den mindste rektangle der "omkredser" hele figuren </summary>
/// <param name = fig> En figure </param>
/// <returns> en ((int*int),(int*int)), med koordinater til den mindste rektangle</returns>
let rec boundingBox (fig : figure) : point * point =
    if checkFigure fig then
        match fig with
        | Circle ((x,y),r,_) -> ((x-r,y-r), (r+x,r+y))
        | Rectangle ((x1,y1),(x2,y2),_) -> ((x1,y1),(x2,y2))
        | Mix (first,second) -> ((min (fst (fst (boundingBox (first)))) (fst (fst (boundingBox (second)))), min (snd (fst (boundingBox (first)))) (snd (fst (boundingBox (second))))),(max (fst (snd (boundingBox (first)))) (fst (snd (boundingBox (second)))), max (snd (snd (boundingBox (first)))) (snd (snd (boundingBox (second))))))
        else ((0,0),(0,0))



        // let firstPoint = (boundingBox (first))
        // let secondPoint = (boundingBox (second))
        // let (maxX : int) = min (fst (fst firstPoint)) (fst (fst secondPoint))
        // let (maxY : int) = min (snd (fst firstPoint)) (snd (fst secondPoint))
        // let (minY : int) = max (snd (snd firstPoint)) (snd (snd secondPoint))
        // let (minX : int) = max (fst (snd firstPoint)) (fst (snd secondPoint))
        //((maxX,maxY),(minX,minY))
    

    // max (boundingBox(first)) (boundingBox(second)) kinda works but not right
    // (((min (boundingBox first fst fst) (boundingBox second fst fst)), (min (boundingBox first fst snd) (boundingBox second fst snd))), ((min (boundingBox first fst fst) (boundingBox second fst fst)), (min (boundingBox first fst fst) (boundingBox second fst fst))))


        // let firstPoint = (boundingBox (first))
        // let secondPoint = (boundingBox (second))
        // let (maxX : int) = min (firstPoint fst fst) (secondPoint fst fst)
        // let (maxY : int) = min (firstPoint fst snd) (secondPoint fst snd)
        // let (minY : int) = max (firstPoint snd snd) (secondPoint snd snd)
        // let (minX : int) = max (firstPoint snd fst) (secondPoint snd fst)
        // ((maxX,maxY),(minX,minY))
       
        // if ((firstPoint fst) fst) < ((secondPoint fst) fst) then maxX = ((firstPoint fst) fst)
        //     else  maxX = ((secondPoint fst) fst)
        // if if ((firstPoint fst) snd) < ((secondPoint fst) snd) then maxY = ((firstPoint fst) snd)
        //     else  maxY = ((secondPoint fst) snd)
        // if 


makePicture ("test") (figTest) (100) (150)
makePicture ("testWow") (figTest2) (100) (150)
printfn "Circle: %A" (boundingBox ((Circle((50, 50), 45, (ImgUtil.fromRgb (255,0,0))))))
printfn "Rec: %A" (boundingBox (Rectangle((40, 40), (30, 110), (ImgUtil.fromRgb (0,0,255)))))
printfn "Mix: %A" (boundingBox (figTest))
printfn "Mix2: %A" (boundingBox (figTest2))
printfn "%A" (min(10) (9))
makePicture ("testWihMove") (move (Circle((50, 50), -45, (ImgUtil.fromRgb (255,0,0)))) (-20,20)) (100) (150)
makePicture ("testWihMove2") (move (figTest) (-20,20)) (100) (150)
printfn "%b" (checkFigure (Mix(Circle((50, 50), -45, (ImgUtil.fromRgb (255,0,0))), Rectangle((40, 40), (30, 110), (ImgUtil.fromRgb (0,0,255))))))
