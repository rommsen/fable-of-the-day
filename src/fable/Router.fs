module Router

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React

open Helpers
open App
open StorePicker

let inline browserRouter (children: React.ReactElement list): React.ReactElement =
  ofImport "BrowserRouter" "react-router-dom" (() :> obj) children

let inline switch children =
  ofImport "Switch" "react-router-dom" (() :> obj) children


type RouteProps<'Props> =
  | Path of string
  | Component of U2<FableReactComponentProp<'Props>,JsReactComponentProp>
  | Exact of bool

let inline storePicker props children =
  ofType<StorePicker,StorePickerProps,_> props children

let inline app props children =
  ofType<App,_,_> props children

let inline route (props : RouteProps<_> list) : React.ReactElement =
  ofImport "Route" "react-router-dom" (props |> kvList) []

let NotFound =
  importDefault<JsReactComponentProp> "../components/NotFound"

let Router () =
  browserRouter
    [
      switch
        [
          route [ Exact true ; Path "/" ; Component <| U2.Case1 storePicker ]
          route [ Path "/store/:storeId" ; Component <| U2.Case1 app ]
          route [ Component <| U2.Case2 NotFound ]
        ]
    ]
