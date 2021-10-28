open ImgUtil

let rec triangle C len (x,y) =
  if len < 128 then
    setBox red (x,y) (x+len,y+len) C
  else let half = len / 2
       do triangle C half (x+half/2,y)
       do triangle C half (x,y+half)
       do triangle C half (x+half,y+half)

do runApp "Sierpinski" 600 600 draw react init
      (fun w h -> let C = mk w h
                  in triangle C 512 (30,30);
                     C)