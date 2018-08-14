namespace Enigma

module EnigmaMachine =
    open System
    open Domain

    let private wheelMappers machine = 
        [machine.FastSocket;machine.MiddleSocket;machine.SlowSocket]
        |> List.map Socket.getMapper
        |> List.reduce (>>)

    let mapLetter machine =
        let forwardMapper = machine.Plugboard >> wheelMappers machine
        let reverseMapper = forwardMapper |> Mapper.reverseMapper
        
        forwardMapper >> machine.Reflector >> reverseMapper

    let advanceRotors (machine:EnigmaMachine) =
        let (ms,fs) = (machine.MiddleSocket,machine.FastSocket)
        match (ms.IsInNotchPosition,fs.IsInNotchPosition) with
        | (true,_) -> { machine with 
                            MiddleSocket=ms|>Socket.advance
                            FastSocket=fs|>Socket.advance }
        | _ -> { machine with FastSocket=fs|>Socket.advance }

    let encodeMessage machine msg =
        let rec encodeMessage' acc machine' = function
        | [] -> acc
        | l::rest -> encodeMessage' ((mapLetter machine' l)::acc) (advanceRotors machine') rest

        msg |> encodeMessage' [] (advanceRotors machine) |> List.rev

    let private encodableString : (string->string) = 
        Seq.filter Char.IsLetter >> Seq.map Char.ToUpperInvariant >> String.Concat
    let private strLetters = Seq.map Letter.charToLetter >> List.ofSeq
    let encodeString machine = 
        encodableString >> strLetters >> encodeMessage machine >> String.Concat

    let defaultMachine = 
       { 
           FastSocket = Socket.setupDefault Rotor.rotorIII
           MiddleSocket = Socket.setupDefault Rotor.rotorII
           SlowSocket = Socket.setupDefault Rotor.rotorI
           Plugboard = id
           Reflector = Reflector.reflectorB
       }