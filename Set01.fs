namespace MatasanoF

open Convert
open Math

module Set01 =

        (*

        1.1 Hex to base64

        *)

        let Challenge01 = 

            let input = "49276d206b696c6c696e6720796f757220627261696e206c696b65206120706f69736f6e6f7573206d757368726f6f6d"
            let expected = "SSdtIGtpbGxpbmcgeW91ciBicmFpbiBsaWtlIGEgcG9pc29ub3VzIG11c2hyb29t"

            let result =
                input
                |> Bytes.FromHex
                |> Base64.FromBytes

            printfn "%s" result

        (*

        1.2 Fixed XOR

        *)

        let Challenge02 = 

            let input = "1c0111001f010100061a024b53535009181c"
            let seed = "686974207468652062756c6c277320657965"
            let expected = "746865206b696420646f6e277420706c6179"

            let result = 
                input
                |> Bytes.FromHex |> Bytes.ToInts
                |> Array.map2 xor (seed |> Bytes.FromHex |> Bytes.ToInts)
                |> Bytes.FromInts |> Bytes.ToHex

            printfn "%s" result