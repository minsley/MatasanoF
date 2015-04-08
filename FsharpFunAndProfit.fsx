// Examples for learning F# from C#.
// http://fsharpforfunandprofit.com/

(******************************

01 Simple Sums 

a. Apply a function to all values of a list with "List.map fun [v;a;l;s]"
b. Pipe the output of one function into the next with "|>"

******************************)

let square x = x * x

let sumOfSquares n = 
    [1..n] 
    |> List.map (fun x -> x*x) //a
    |> List.sum //b

(****************************** 

02 Quicksort

a. Use "rec" to let the compiler know this function is recursive.
b. "Match...with...|" works like a switch statement.
c. Shorthand "param = match param with |" using "function |" 

******************************)

let rec quickNDirtySort list = //a
    match list with //b
    | [] -> []
    | first::rest ->
        let smaller = 
            rest
            |> List.filter(fun e -> e < first)
            |> quickNDirtySort
        let larger = 
            rest
            |> List.filter(fun e -> e >= first)
            |> quickNDirtySort
        List.concat [smaller;[first];larger]

let rec quicksort = function //c
    | [] -> []
    | first::rest ->
        let smaller,larger = List.partition ((>=) first) rest
        List.concat [quicksort smaller; [first]; quicksort larger]

(******************************

03 Web Scraping

a. C#s "using" is replaced by "open" for namespaces and "use" for disposables.
b. Specify param types with (var:type).
c. Bake in params at the end of the param list for easier callback reuse.

******************************)

open System //a
open System.Net
open System.IO

let fetchUrl callback url = 
    let req = WebRequest.Create(Uri(url))
    use resp = req.GetResponse() //a
    use stream = resp.GetResponseStream()
    use reader = new IO.StreamReader(stream)
    callback reader url

let myCallback (reader:IO.StreamReader) url = //b
    let html = reader.ReadToEnd()
    let html1000 = html.Substring(0,1000)
    printfn "Downloaded %s. First 1000 is %s" url html1000
    html

let google = fetchUrl myCallback "http://google.com"

let fetchUrl2 = fetchUrl myCallback //c

let google2 = fetchUrl2 "http://www.google.com"
let bbc = fetchUrl2 "http://news.bbc.co.uk"

let sites = ["http://www.bing.com";
             "http://www.google.com";
             "http://www.yahoo.com"]

sites |> List.map fetchUrl2