//fsi delen
module rotate 
/// <summary> Selvdefinerede typer, der er relevant for opgaven </summary>
type Board = char list
type Position = int

/// <summary> Den tager en integer som argument, og laver et board af størrelsen n x n </summary>
/// <param name = n> Det er vores unsigned integer, som er størrelsen af boardet </param>
/// <returns> Den returnerede et board i størrelsen n x n i den løste tilstand </returns>
// Create function
val create : n:uint -> Board

/// <summary> Den tager et board som et argument, som bliver lavet om til en string
/// <param name = b> Det er et input af typen Board </param>
/// <returns> Den returnerer det formateret boardet i form af en string </returns>
//Board to string function
val board2Str : b:Board -> string

/// <summary> Den tjekker om rotationen er gyldig eller ikke.</summar>
/// <param name = b> Det er et input af typen Board </param>
/// <param name = p> Det er et input af typen Position </param>
/// <returns> Den returnerer true eller false, alt efter om rotationen er en gyldig rotations position eller ikke. </returns>
//Valid Rotation
val validRotation : b:Board -> p:Position -> bool

/// <summary> Den tager et board og en rotations position, og kommer med et board efter rotationen er sket</summar>
/// <param name = b> Det er et input af typen Board </param>
/// <param name = p> Det er et input af typen Position  </param>
/// <returns> Den returnerer enten et board, hvor der er sket en 2 x 2 rotation. 
/// Hvis det er en invalid position, returneres boardet, som var argumentet</returns>

//Rotate
val rotate : b:Board -> p:Position -> Board

/// <summary> Den "scrambler"/roterer tallene tilfældigt fra et originalt board</summar>
/// <param name = b > Det er et input af typen Board </param>
/// <param name = m > Det er en unsigned integer, som er m tilfældige "lovlige" rotationer, ved brug af funktionen rotate </param>
/// <returns> Den returnerer et andet board, hvor det originale board er blevet roteret af m forskellige rotationer</returns>
//Scramble 
val scramble : b:Board -> m:uint -> Board

/// <summary> Den tjekker om boardet er i den løste konfiguration</summar>
/// <param name = b> Det er et input af typen Board </param>
/// <returns> Den returnerer true, hvis boardet er i den løste konfiguration og false, hvis ikke.</returns>
val solved : b:Board -> bool 