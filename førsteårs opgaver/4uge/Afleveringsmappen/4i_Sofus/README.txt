# Kort beskrivelse af hvordan koden oversættes og køres.
----------

Koden køres ved først at compile .fs og .fsi filen: 

```console
$ fsharpc -a vec2dSmall.fsi vec2dSmall.fs
```

Dernæst ved at køre black-box testen, *4i1.fsx*, sammen med library filen *vec2dSmall.dll*: 

```console
$ fsharpc -r vec2dSmall.dll 4i1.fsx && mono 4i1.exe
```

Desuden kan *4i2.fsx* også køres med samme procedure: 

```console
$ fsharpc -r vecdSmall.dll 4i2.fsx && mono 4i2.exe
```


## En beskrivelse af resultaterne for Black-box test og kommentere evt. fejlede test.
----------

Det kan aflæses af nedenstående billede at alle mine tests returnerede true :)
![Figur 1](https://github.com/sofusbjorn/codeWithSofus/raw/main/markdownImgs/firstEverPic.4i1.png "Figur 1")

## Besvarelse på opg. 4i2, inkl. håndkøringstabel.
----------
Fil 1 er **4i3.fsx** og fil 2 er **vec2dsmall.fs**

| Step 	| File.Line 	| Env 	|                       Bindings and Evaluations                       	|
|:----:	|:---------:	|:---:	|:--------------------------------------------------------------------:	|
|   0  	|     -     	|  E0 	|                                  ()                                  	|
|   1  	|    1.1    	|  E0 	|                            v = (1.3, -2.5)                           	|
|   2  	|    1.2    	|  E0 	|                 output = "Vector (1.3, -2.5): (?, ?)"                	|
|   3  	|    1.2    	|  E0 	|                      vec2d.len = ((x,y), body())                     	|
|   4  	|    1.2    	|  E1 	|                      ((x,y)=(1.3, -2.5), body())                     	|
|   5  	|    2.5    	|  E2 	|                            xRes = (1.3**2)                           	|
|   6  	|    2.6    	|  E2 	|                          yRes = ((-2.5)**2)                          	|
|   7  	|    2.7    	|  E2 	|                      return = Sqrt (1.69 + 6.25)                     	|
|   8  	|    1.2    	|  E1 	|                      vec2d.len v = 2.8178005607                      	|
|   9  	|    1.2    	|  E0 	|                      vec2d.ang = ((x,y), body())                     	|
|  10  	|    1.2    	|  E1 	|                      ((x,y)=(1.3, -2.5), body())                     	|
|  11  	|    2.12   	|  E2 	|                      return = atan2 (-2.5, 1.3)                      	|
|  12  	|    1.2    	|  E1 	|                     vec2d.ang v = -1.091277034802                    	|
|  13  	|    1.2    	|  E0 	|    output = "Vector (1.3, -2.5): (2.8178005607, -1.091277034802)"    	|
|  14  	|    1.2    	|  E0 	|   printfn "Vector %A: (%f, %f)" v (vec2d.len v) (vec2d.ang v) = ()   	|
|  15  	|    1.2    	|  E0 	|                              return = ()                             	|
|  16  	|    1.3    	|  E0 	|                            w = (-0.1, 0.5)                           	|
|  17  	|    1.4    	|  E0 	|                 output = "Vector (-0.1, 0.5): (?, ?)"                	|
|  18  	|    1.4    	|  E0 	|                      vec2d.len = ((x,y), body())                     	|
|  19  	|    1.4    	|  E1 	|                      ((x,y)=(-0.1, 0.5), body())                     	|
|  20  	|    2.5    	|  E2 	|                          xRes = ((-0.1)**2)                          	|
|  21  	|    2.6    	|  E2 	|                            yRes = (0.5**2)                           	|
|  22  	|    2.7    	|  E2 	|                      return = Sqrt (0.01 + 0.25)                     	|
|  23  	|    1.4    	|  E1 	|                   vec2d.len w = 0.5099019513592785                   	|
|  24  	|    1.4    	|  E0 	|                      vec2d.ang = ((x,y), body())                     	|
|  25  	|    1.4    	|  E1 	|                      ((x,y)=(-0.1, 0.5), body())                     	|
|  26  	|    2.12   	|  E2 	|                      return = atan2 (0.5, -0.1)                      	|
|  27  	|    1.4    	|  E1 	|                     vec2d.ang w = 1.768191886645                     	|
|  28  	|    1.4    	|  E0 	|  output = "Vector (1.3, -2.5): (0.5099019513592785, 1.768191886645)" 	|
|  29  	|    1.4    	|  E0 	|   printfn "Vector %A: (%f, %f)" w (vec2d.len w) (vec2d.ang w) = ()   	|
|  30  	|    1.4    	|  E0 	|                              return = ()                             	|
|  31  	|    1.5    	|  E0 	|                           s = vec2d.add v w                          	|
|  32  	|    1.5    	|  E0 	|                 vec2d.add = ((x1,y1),(x2,y2), body())                	|
|  33  	|    1.5    	|  E1 	|           ((x1,y1),(x2,y2)=(1.3,-2.5),(-0.1, 0.5), body())           	|
|  34  	|    2.17   	|  E2 	|                           x3 = 1.3 + (-0.1)                          	|
|  35  	|    2.18   	|  E2 	|                           y3 = (-2.5) + 0.5                          	|
|  36  	|    2.19   	|  E2 	|                   returns = (x3, y3) = (1.2, -2.0)                   	|
|  37  	|    1.5    	|  E1 	|                      vec2d.add v w=  (1.2, -2.0)                     	|
|  38  	|    1.6    	|  E0 	|                output = "Vector (1.2,  -2.0): (?, ?)"                	|
|  39  	|    1.6    	|  E0 	|                      vec2d.len = ((x,y), body())                     	|
|  40  	|    1.6    	|  E1 	|                      ((x,y)=(1.2, -2.0), body())                     	|
|  41  	|    2.5    	|  E2 	|                            xRes = (1.2**2)                           	|
|  42  	|    2.6    	|  E2 	|                           yRes = ((-2)**2)                           	|
|  43  	|    2.7    	|  E2 	|                       return = Sqrt (1.44 + 4)                       	|
|  44  	|    1.6    	|  E1 	|                   vec2d.len s = 2.3323807579381204                   	|
|  45  	|    1.6    	|  E0 	|                      vec2d.ang = ((x,y), body())                     	|
|  46  	|    1.6    	|  E1 	|                      ((x,y)=(1.2, -2.0), body())                     	|
|  47  	|    2.12   	|  E2 	|                      return = atan2 (-2.0, 1,2)                      	|
|  48  	|    1.6    	|  E1 	|                     vec2d.ang w = -1.030376826524                    	|
|  49  	|    1.6    	|  E0 	| output = "Vector (1.3, -2.5): (2.3323807579381204, -1.030376826524)" 	|
|  50  	|    1.6    	|  E0 	|   printfn "Vector %A: (%f, %f)" s (vec2d.len s) (vec2d.ang s) = ()   	|
|  51  	|    1.6    	|  E0 	|                              return = ()                             	|
      	          	    	                                                                      	
