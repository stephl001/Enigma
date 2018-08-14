namespace Enigma

module Rotor =
    open Domain
    
    let create ringOffset notch mapping =
        {Notch=notch; Mapper=Mapper.fromString mapping; InnerRingOffset=ringOffset}
    let createDefault = create A

    let rotorI = createDefault Q "EKMFLGDQVZNTOWYHXUSPAIBRCJ"
    let rotorII = createDefault E "AJDKSIRUXBLHWTMCQGZNPYFVOE"
    let rotorIII = createDefault V "BDFHJLCPRTXVZNYEIWGAKMUSQO"
    let rotorIV = createDefault J "ESOVPZJAYQUIRHXLNFTGKDCMWB"
    let rotorV = createDefault Z "VZBRGITYUPSDNHLXAWMJQOFECK"

