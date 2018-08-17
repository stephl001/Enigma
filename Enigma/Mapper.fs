namespace Enigma

module Mapper =
    open Domain
    open Letter

    let fromArray (mapping:Letter array) (IndexLetter letterIndex) =
        mapping.[letterIndex]

    let reverseMapper (mapper:Mapper) : Mapper =
        Letter.mapAlphabet (fun l -> (l,mapper l))
        |> Array.sortBy snd 
        |> Array.map fst
        |> fromArray

    let offsetMapper (IndexLetter offset) (mapper:Mapper) : Mapper = 
        offsetLetter offset >> mapper >> reverseOffsetLetter offset

    let fromString : (string->Mapper) = 
        Seq.map Letter.charToLetter >> Array.ofSeq >> fromArray