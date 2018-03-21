module Router

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React

open Helpers
open StorePicker

Browser.console.log(getFunName())

let inline kvList props =
  keyValueList CaseRules.LowerFirst props

let inline browserRouter (children: React.ReactElement list): React.ReactElement =
  ofImport "BrowserRouter" "react-router-dom" (() :> obj) children

let inline switch children =
  ofImport "Switch" "react-router-dom" (() :> obj) children

type RouteProps<'Props> =
  | Path of string
  | Component of ('Props -> React.ReactElement list -> React.ReactElement)
  | Compi of React.Component<obj,obj>
  | Exact of bool

let inline storePicker props children = ofType<StorePicker,_,_> props children

let inline route (props : RouteProps<_> list) : React.ReactElement =
  ofImport "Route"  "react-router-dom" (props |> kvList) []

let StorePickerJs =
  importDefault<React.ComponentClass<obj>> "../components/StorePicker"

let App =
  importDefault<React.ComponentClass<obj>> "../components/App"

let NotFound =
  importDefault<React.ComponentClass<obj>> "../components/NotFound"

let Router () =
  browserRouter
    [
      switch
        [
          route [ Exact true ; Path "/" ; Component storePicker ]
          // route [ Path "/store/:storeId" ; Component App ]
          // route [ Component StorePickerJs ]
        ]
    ]