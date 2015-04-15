namespace MatasanoF

module Convert =

    let parseHex s = System.Byte.Parse(s, System.Globalization.NumberStyles.AllowHexSpecifier)
    let printHex (byte:byte) = System.String.Format("{0:x2}", byte)

    let parseBase64 s = System.Convert.FromBase64String(s)
    let printBase64 bytes = System.Convert.ToBase64String(bytes)

    let rec chunkStr (s:string) (i:int) : array<string> = 
        match s.Length < i with
        | true -> [||]
        | false -> Array.append [|s.[0..i]|] (chunkStr s.[i..] i)

    let rec chunkArray (a:array<'T>) i = 
        match a.Length < i with
        | true -> [||]
        | false -> Array.append [|a.[0..i]|] (chunkArray a.[i..] i)

    let hexStringToBytes s = 
        chunkStr s 2 
        |> Array.map parseHex

    let bytesToHexString (h:byte[]) = 
        Array.map printHex h 
        |> String.concat System.String.Empty
