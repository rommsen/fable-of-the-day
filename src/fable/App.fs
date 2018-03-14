module FableApp

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React
open Fable.Import.Browser
open Fable.Import.React
open Fable.Helpers.React.Props

// [<Pojo>]
// type HelloProps = {
//     name : string
// }

// type HelloWorld(props) =
//   inherit React.Component<HelloProps, obj> (props)

//   member this.render() =
//     div []
//       [
//         str "Hello World"
//         ]

// let render() =
//   ReactDom.render(
//       com<HelloWorld,_,_> { name = "roman" } [],
//       Browser.document.getElementById("hello")
//   )

// render()




(*
Element with Helpers
*)
let liste =
  // Each HTML element has an helper with the same name
  ul
    // The first parameter is the properties of the elements.
    // For html elements they are specified as a list and for custom
    // elements it's more typical to find a record creation
    [ClassName "my-ul"; Id "unique-ul"]

    // The second parameter is the list of children
    [
      // str is the helper for exposing a string to React as an element
      li [] [ str "Hello 🌍" ]

      // Helpers exists also for other primitive types
      li [] [ str "The answer is: "; ofInt 42 ]
      li [] [ str "π="; ofFloat 3.14 ]

      // ofOption can be used to return either null or something
      li [] [ str "🤐"; ofOption (Some (str "🔫")) ]
      // And it can also be used to unconditionally return null, rendering nothing
      li [] [ str "😃"; ofOption None ]

      // ofList allows to expose a list to react, as with any list of elements
      // in React each need an unique and stable key
      [1;2;3]
        |> List.map(fun i ->
            let si = i.ToString()
            li [Key si] [str "🎯 "; str si])
        |> ofList

      // fragment is the <Fragment/> element introduced in React 16 to return
      // multiple elements
      [1;2;3]
        |> List.map(fun i ->
            let si = i.ToString()
            li [] [str "🎲 "; str si])
        |> fragment []
    ]


type [<Pojo>] WelcomeProps = { name: string }

(*
Functional Component
*)
let Welcome { name = name } =
    h1 [] [ str "Hello, "; str name ]

let inline welcome name = ofFunction Welcome { name = name } []


(*
Class Component
*)
type Welcome2 =
    inherit Component<WelcomeProps, obj>
    new(props) = { inherit Component<_, _>(props) }
    override this.render() =
        h1 [] [ str "Hello "; str this.props.name ]

let inline welcome2 name = ofType<Welcome2,_,_> { name = name } []


(*
Component with State
*)

// A pure, stateless component that will simply display the counter
type [<Pojo>] CounterDisplayProps = { counter: int }

type CounterDisplay(initialProps) =
  inherit PureStatelessComponent<CounterDisplayProps>(initialProps)
  override this.render() =
    div [] [ str "Counter = "; ofInt this.props.counter ]

let inline counterDisplay p = ofType<CounterDisplay,_,_> p []

// Another pure component displaying the buttons
type [<Pojo>] AddRemoveProps = { add: MouseEvent -> unit; remove: MouseEvent -> unit }

type AddRemove(initialProps) =
  inherit PureStatelessComponent<AddRemoveProps>(initialProps)
  override this.render() =
    div [] [
        button [OnClick this.props.add] [str "👍"]
        button [OnClick this.props.remove] [str "👎"]
    ]

let inline addRemove props = ofType<AddRemove,_,_> props []

// The counter itself using state to keep the count
type [<Pojo>] CounterState = { counter: int }

type Counter(initialProps) as this =
  inherit Component<obj, CounterState>(initialProps)
  do
      this.setInitState({ counter = 0})

  // This is the equivalent of doing `this.add = this.add.bind(this)`
  // in javascript (Except for the fact that we can't reuse the name)
  let add = this.Add
  let remove = this.Remove

  member this.Add(_:MouseEvent) =
    this.setState({ counter = this.state.counter + 1 })

  member this.Remove(_:MouseEvent) =
    this.setState({ counter = this.state.counter - 1 })

  override this.render() =
    div [] [
      counterDisplay { CounterDisplayProps.counter = this.state.counter }
      addRemove { add = add; remove = remove }
    ]

let inline counter props = ofType<Counter,_,_> props []


type [<RequireQualifiedAccess>] HelloProp =
  | Name of string

let inline hello (props: IProp list) (children: React.ReactElement list) : React.ReactElement =
  ofImport "default" "../components/HelloJS" (keyValueList CaseRules.LowerFirst props) children



let init() =
  let element =
    fragment []
      [
        hello [ Name "JS 🌍" ] []
        welcome "🌍"
        welcome2 "2🌍"
        liste
        counter createEmpty
      ]
  ReactDom.render(element, document.getElementById("root"))


init()