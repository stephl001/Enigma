namespace Enigma

module Letter =
    open System
    open Domain

    [<Literal>] 
    let LettersCount = 26

    let (|IndexLetter|) = function
        | A -> 0 | B -> 1 | C -> 2 | D -> 3 | E -> 4 | F -> 5 | G -> 6 | H -> 7 | I -> 8
        | J -> 9 | K -> 10 | L -> 11 | M -> 12 | N -> 13 | O -> 14 | P -> 15 | Q -> 16 | R -> 17
        | S -> 18 | T -> 19 | U -> 20 | V -> 21 | W -> 22 | X -> 23 | Y -> 24 | Z -> 25
    
    let fromIndex = function
        | 0 -> A | 1 -> B | 2 -> C | 3 -> D | 4 -> E | 5 -> F | 6 -> G | 7 -> H | 8 -> I
        | 9 -> J | 10 -> K | 11 -> L | 12 -> M | 13 -> N | 14 -> O | 15 -> P | 16 -> Q | 17 -> R
        | 18 -> S | 19 -> T | 20 -> U | 21 -> V | 22 -> W | 23 -> X | 24 -> Y | 25 -> Z
        | _ -> failwith "Index out of range"

    let private charToLetter (c:char) = int c - int 'A' |> fromIndex
    let private (%+) m n = (((m % n) + n) % n)
    let private modAlphabet x = x %+ LettersCount
    let private fromModIndex = modAlphabet >> fromIndex
    
    let offsetLetter offset (IndexLetter letterIndex) = (letterIndex + offset) |> fromModIndex
    let reverseOffsetLetter = (~-) >> offsetLetter
    let strLetters : (string -> Letter list) = 
        List.ofSeq >> List.filter Char.IsLetter >> List.map charToLetter
