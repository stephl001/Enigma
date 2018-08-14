namespace Enigma

module Mapper =
    open Domain
    open Letter
    open Mapping

    let fromArray = create >> mapLetter

    let reverseMapper (mapper:Mapper) : Mapper =
        id
        |> map (fun l -> (l,mapper l)) 
        |> Array.sortBy snd 
        |> Array.map fst
        |> fromArray

    let offsetMapper (IndexLetter offset) (mapper:Mapper) : Mapper = 
        offsetLetter offset >> mapper >> reverseOffsetLetter offset

    let fromString = Mapping.fromString >> mapLetter