namespace Enigma.Tests

module Letter =

    open FsUnit.Xunit
    open FsCheck.Xunit
    open Enigma.Domain
    open Enigma.Letter

    [<Property>]
    let ``Offset then reverse offset should yield then same letter`` (letter:Letter) (offset:int) =
        offsetLetter offset letter
        |> reverseOffsetLetter offset
        |> should equal letter
