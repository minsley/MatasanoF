namespace MatasanoF

module Utilities =

    let rec chunkStr (s:string) (i:int) : array<string> = 
        match s.Length < i with
        | true -> [||]
        | false -> Array.append [|s.[0..i-1]|] (chunkStr s.[i..] i)

    let rec chunkArray (a:array<'T>) i = 
        match a.Length < i with
        | true -> [||]
        | false -> Array.append [|a.[0..i-1]|] (chunkArray a.[i..] i)

