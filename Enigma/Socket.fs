namespace Enigma

module Socket =
    open Domain
    open Letter
    open Mapper

    let setup startPos rotor = {
        Rotor = rotor
        RotorPosition = startPos
        IsInNotchPosition = (rotor.Notch = startPos)
    } 

    let setupDefault = setup A

    let advance socket = 
        let newPos = socket.RotorPosition |> offsetLetter 1
        { socket with 
            RotorPosition=newPos
            IsInNotchPosition = (socket.Rotor.Notch = newPos)
        }

    let getMapper socket = 
        socket.Rotor.Mapper 
        |> offsetMapper socket.Rotor.InnerRingOffset
        |> offsetMapper socket.RotorPosition
    

