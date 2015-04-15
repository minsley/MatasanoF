namespace MatasanoF

module Set01 =

    open Convert

    (*

    1.1 Hex to base64

    *)

    let Challenge01 = 

        let input = "49276d206b696c6c696e6720796f757220627261696e206c696b65206120706f69736f6e6f7573206d757368726f6f6d"
        let expected = "SSdtIGtpbGxpbmcgeW91ciBicmFpbiBsaWtlIGEgcG9pc29ub3VzIG11c2hyb29t"

        let result = 
            input
            |> hexStringToBytes 
            |> printBase64

        printfn "%s" result