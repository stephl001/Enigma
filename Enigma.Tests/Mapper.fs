namespace Enigma.Tests

module Mapper =

    open FsUnit.Xunit
    open FsCheck.Xunit
    open Enigma.Domain
    open FsCheck
    open Enigma

    let mapperGen : Gen<Mapper> = 
        gen { 
            let! shuffledLetters = Letter.Alphabet |> Gen.shuffle
            return (shuffledLetters |> Mapper.fromArray)
        }

    type Mappers =
        static member Mapper() = mapperGen |> Arb.fromGen

    type RandomMapperPropertyAttribute() =
        inherit PropertyAttribute(
            Arbitrary = [| typeof<Mappers> |],
            QuietOnSuccess = true)

    [<RandomMapperProperty>]
    let ``Ensure generated random mapper do not map the same letter twice`` (mapper:Mapper) =
        Letter.mapAlphabet mapper 
        |> Array.sort
        |> should equal Letter.Alphabet

    [<RandomMapperProperty>]
    let ``Given a random mapper, reversing it twice should yield the same original mapper`` (mapper:Mapper) =
        let twiceReverseMapper = Mapper.reverseMapper >> Mapper.reverseMapper
        let mapper2 = mapper |> twiceReverseMapper
        Letter.mapAlphabet (fun l -> (mapper l, mapper2 l))
        |> Array.filter (fun (l1,l2) -> l1=l2)
        |> Array.map fst
        |> Array.sort
        |> should equal Letter.Alphabet

    [<RandomMapperProperty>]
    let ``Given a random mapper, offsetting it then unoffsetting it should yield then same original mapper`` (mapper:Mapper) (offset:Letter) =
        let (Letter.IndexLetter iOffset) = offset
        let reverseOffsetLetter = Letter.reverseOffsetLetter iOffset A
        let newMapper = 
            mapper |> Mapper.offsetMapper offset |> Mapper.offsetMapper reverseOffsetLetter
        Letter.mapAlphabet newMapper 
        |> Array.sort
        |> should equal Letter.Alphabet
            
