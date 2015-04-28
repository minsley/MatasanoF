namespace MatasanoF

module Convert =

    open Utilities

    module Base64 =

        let ToBytes s = System.Convert.FromBase64String(s)
        let FromBytes bs = System.Convert.ToBase64String(bs)

    module Byte =
        
        let ToHex (b:byte) = System.String.Format("{0:x2}", b)
        let FromHex s = System.Byte.Parse(s, System.Globalization.NumberStyles.AllowHexSpecifier)

    module Bytes =
        
        let ToInts (bs:byte[]) = Array.map (int) bs
        let FromInts is = Array.map (byte) is

        let ToHex (bs:byte[]) = Array.map Byte.ToHex bs |> String.concat System.String.Empty 
        let FromHex s = Utilities.chunkStr s 2 |> Array.map Byte.FromHex