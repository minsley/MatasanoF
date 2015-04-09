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

(******************************

04 Concepts

Algebraic typing lets you combine existing types into new ones.
a. Product types require all included types (like a tuple?)
b. Union/sum types give you a choice of underlying types (like an enum kinda?)

Control flow is done with pattern matching.
c. Replaces "if/else"
d. Replaces "switch"
e. Replaces loops with recursion

Used together, sum types and matching effectively provide polymorphism.
f. Replacement passing subclasses to methods with superclass params

******************************)

type IntAndBool = {intPart:int; boolPart:bool} //a

let x = {intPart=1; boolPart=true}  // x:IntAndBool

type IntOrBool = //b
    | IntChoice of int
    | BoolChoice of bool

let y = IntChoice 42 // y:IntOrBool
let z = BoolChoice true //  z:IntOrBool

let booleanExpression = true
match booleanExpression with //c
| true -> () // true branch
| false -> () // false branch

let aDigit = 0
match aDigit with //d
| 1 -> ()
| 2 -> ()
| _ -> () // no-match case

let rec doSomethingWithAList list = //e
    match list with
    | [] -> printf "empty case"
    | first::rest -> 
        printf "do something with %s" first;  
        doSomethingWithAList rest

type Shape =
| Circle of int
| Rectangle of int * int
| Polygon of (int * int) list
| Point of (int * int)

let draw shape =
    match shape with
    | Circle radius ->
        printfn "The circle has a radius of %d" radius
    | Rectangle (height, width) ->
        printfn "The rectangle is %d high by %d wide" height width
    | Polygon points ->
        printfn "The polygon is made of these points %A" points
    | _ ->
        printfn "I don't recognize this shape"

let circ = Circle 10
let rect = Rectangle (4,5)
let poly = Polygon [1,1;2,2;3,3]
let point = Point (2,3)

[circ; rect; poly; point] |> List.iter draw //f