namespace Enigma.Tests

module Letter =

    open Xunit
    open FsUnit.Xunit
    open FsCheck.Xunit
    open Enigma.Domain
    open Enigma.Letter

    [<Property>]
    let ``Offset then reverse offset should yield then same letter`` (letter:Letter) (offset:int) =
        offsetLetter offset letter
        |> reverseOffsetLetter offset
        |> should equal letter

    [<Fact>]
    let ``Converting alphabet string to Letter list should yield proper result``() =
        strLetters "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        |> should equal [A;B;C;D;E;F;G;H;I;J;K;L;M;N;O;P;Q;R;S;T;U;V;W;X;Y;Z]
