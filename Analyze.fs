namespace MatasanoF

module Analyze =

    module Language =

        type NGram = { token: string; weight: float }
        type Distribution = NGram list

        let diff a b = 
            match a - b > 0.0f with
            | true -> a - b
            | false -> b - a

        let disparity a b =
            List.map2 diff a b
            |> List.sum

        // fun divideIntoNgrams (n:int, text:string) : list<string>
        // input: 3, "text"
        // output: ["tex";"ext"]
        // process:
        //  l = t,e,x,t
        //  l = tex,e,x,t
        //  l = text,ext,x,t
        //  return l[0..l.len-3]

        // fun ngrams to distribution dictionary
        
        module English =

            let Characters = [
                { token="e"; weight=0.12702 };
                { token="t"; weight=0.09056 };
                { token="a"; weight=0.08167 };
                { token="o"; weight=0.07507 };
                { token="i"; weight=0.06966 };
                { token="n"; weight=0.06749 };
                { token="s"; weight=0.06327 };
                { token="h"; weight=0.06094 };
                { token="r"; weight=0.05987 };
                { token="d"; weight=0.04253 };
                { token="l"; weight=0.04025 };
                { token="c"; weight=0.02782 };
                { token="u"; weight=0.02758 };
                { token="m"; weight=0.02406 };
                { token="w"; weight=0.02360 };
                { token="f"; weight=0.02228 };
                { token="g"; weight=0.02015 };
                { token="y"; weight=0.01974 };
                { token="p"; weight=0.01929 };
                { token="b"; weight=0.01492 };
                { token="v"; weight=0.00978 };
                { token="k"; weight=0.00772 };
                { token="j"; weight=0.00153 };
                { token="x"; weight=0.00150 };
                { token="q"; weight=0.00095 };
                { token="z"; weight=0.00074 }]

            // lots of pages with frequencies, but all are unitless and divergent
//            let Digrams = [
//                { token=""; weight=0.1 };
//                { token=""; weight=0.1 };
//                { token=""; weight=0.1 }]

            let FirstChars = [
                { token=" t"; weight=0.16671 };
                { token=" a"; weight=0.11602 };
                { token=" s"; weight=0.07755 };
                { token=" h"; weight=0.07232 };
                { token=" w"; weight=0.06753 };
                { token=" i"; weight=0.06286 };
                { token=" o"; weight=0.06264 };
                { token=" b"; weight=0.04702 };
                { token=" m"; weight=0.04374 };
                { token=" f"; weight=0.03779 };
                { token=" c"; weight=0.03511 };
                { token=" l"; weight=0.02705 };
                { token=" d"; weight=0.02670 };
                { token=" p"; weight=0.02545 };
                { token=" n"; weight=0.02365 };
                { token=" e"; weight=0.02007 };
                { token=" g"; weight=0.01950 };
                { token=" r"; weight=0.01653 };
                { token=" y"; weight=0.01620 };
                { token=" u"; weight=0.01487 };
                { token=" v"; weight=0.00649 };
                { token=" j"; weight=0.00597 };
                { token=" k"; weight=0.00590 };
                { token=" q"; weight=0.00173 };
                { token=" z"; weight=0.00034 };
                { token=" x"; weight=0.00017 }]