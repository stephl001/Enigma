namespace Enigma

module Mapping =
    open Domain
    open Letter

    let create letters =
        let lettersCount = letters |> Array.distinct |> Array.length
        if lettersCount <> 26
        then failwith "A mapping must be composed of 26 distinct letters"
        else Mapping letters

    let fromString : (string -> Mapping) = Seq.map charToLetter >> Array.ofSeq >> create
    let id = fromString "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
    let map f (Mapping m) = Array.map f m

    let mapLetter (Mapping mapping) (IndexLetter letterIndex) =
        mapping.[letterIndex]