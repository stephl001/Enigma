namespace Enigma

module Domain =
    type Letter = A|B|C|D|E|F|G|H|I|J|K|L|M|N|O|P|Q|R|S|T|U|V|W|X|Y|Z
    type Mapping = private Mapping of Letter array
    type Mapper = Letter -> Letter

    type Rotor = private {
        Notch: Letter
        Mapper: Mapper
        InnerRingOffset: Letter
    }

    type Socket = private {
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
