(*

1.1 Hex to base64

*)

open System

let input = "49276d206b696c6c696e6720796f757220627261696e206c696b65206120706f69736f6e6f7573206d757368726f6f6d"
let expected = "SSdtIGtpbGxpbmcgeW91ciBicmFpbiBsaWtlIGEgcG9pc29ub3VzIG11c2hyb29t"

let rec hexToByte (s:string) = 
    let first = s.[0..1]
    let rest = s.[2..]
    List.concat [[Byte.Parse(first)]; hexToByte rest]

let rec byteToHex b = b |> List.map (fun x -> printf x) |> String.concat
    

printfn byteToHex hexToByte input

[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    0 // return an integer exit code