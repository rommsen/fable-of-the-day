module Helpers

open Fable.Core.JsInterop
open Fable.Core
open Fable.Import
open Fable.Helpers.React

let getFunName : unit -> string =
    import "getFunName" "../helpers.js"

let inline kvList props =
  keyValueList CaseRules.LowerFirst props


type FableReactComponentProp<'Props> =
  'Props -> React.ReactElement list -> React.ReactElement

type JsReactComponentProp =
  React.ComponentClass<obj>

let inline ofDefaultImport component props =
  ofImport "default" component (props |> kvList)
