namespace Enigma

module Domain =
    
    type Letter = A|B|C|D|E|F|G|H|I|J|K|L|M|N|O|P|Q|R|S|T|U|V|W|X|Y|Z
    type Mapper = Letter -> Letter

    type Rotor = internal {
        Notch: Letter
        Mapper: Mapper
        InnerRingOffset: Letter
    }

    type Socket = internal {
        Rotor: Rotor
        RotorPosition: Letter
        IsInNotchPosition: bool
    }

    type EnigmaMachine = {
        Plugboard: Mapper
        SlowSocket: Socket
        MiddleSocket: Socket
        FastSocket: Socket
        Reflector: Mapper
    }
