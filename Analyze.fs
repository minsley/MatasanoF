namespace MatasanoF

module Analyze =

    module Language =

        type NGram = { ngram: string; weight: float }
        type Distribution = NGram list

        let diff a b = 
            match a - b > 0.0f with
            | true -> a - b
            | false -> b - a

        let disparity a b =
            List.map2 diff a b
            |> List.sum
        
        module English =

            let Characters = [
                { ngram="e"; weight=0.12702 };
                { ngram="t"; weight=0.09056 };
                { ngram="a"; weight=0.08167 };
                { ngram="o"; weight=0.07507 };
                { ngram="i"; weight=0.06966 };
                { ngram="n"; weight=0.06749 };
                { ngram="s"; weight=0.06327 };
                { ngram="h"; weight=0.06094 };
                { ngram="r"; weight=0.05987 };
                { ngram="d"; weight=0.04253 };
                { ngram="l"; weight=0.04025 };
                { ngram="c"; weight=0.02782 };
                { ngram="u"; weight=0.02758 };
                { ngram="m"; weight=0.02406 };
                { ngram="w"; weight=0.02360 };
                { ngram="f"; weight=0.02228 };
                { ngram="g"; weight=0.02015 };
                { ngram="y"; weight=0.01974 };
                { ngram="p"; weight=0.01929 };
                { ngram="b"; weight=0.01492 };
                { ngram="v"; weight=0.00978 };
                { ngram="k"; weight=0.00772 };
                { ngram="j"; weight=0.00153 };
                { ngram="x"; weight=0.00150 };
                { ngram="q"; weight=0.00095 };
                { ngram="z"; weight=0.00074 }]

            let Digrams = [
                { ngram=""; weight=0.1 };
                { ngram=""; weight=0.1 };
                { ngram=""; weight=0.1 }]

            let FirstChars = [
                { ngram=" t"; weight=0.16671 };
                { ngram=" a"; weight=0.11602 };
                { ngram=" s"; weight=0.07755 };
                { ngram=" h"; weight=0.07232 };
                { ngram=" w"; weight=0.06753 };
                { ngram=" i"; weight=0.06286 };
                { ngram=" o"; weight=0.06264 };
                { ngram=" b"; weight=0.04702 };
                { ngram=" m"; weight=0.04374 };
                { ngram=" f"; weight=0.03779 };
                { ngram=" c"; weight=0.03511 };
                { ngram=" l"; weight=0.02705 };
                { ngram=" d"; weight=0.02670 };
                { ngram=" p"; weight=0.02545 };
                { ngram=" n"; weight=0.02365 };
                { ngram=" e"; weight=0.02007 };
                { ngram=" g"; weight=0.01950 };
                { ngram=" r"; weight=0.01653 };
                { ngram=" y"; weight=0.01620 };
                { ngram=" u"; weight=0.01487 };
                { ngram=" v"; weight=0.00649 };
                { ngram=" j"; weight=0.00597 };
                { ngram=" k"; weight=0.00590 };
                { ngram=" q"; weight=0.00173 };
                { ngram=" z"; weight=0.00034 };
                { ngram=" x"; weight=0.00017 }]