module Helpers

open Fable.Core.JsInterop
open Fable.Core
open Fable.Helpers.React

let getFunName : unit -> string =
  import "getFunName" "../helpers"

let formatPrice : float -> string =
  import "formatPrice" "../helpers"

let inline kvList props =
  keyValueList CaseRules.LowerFirst props

let inline ofDefaultImport com props =
  ofImport "default" com (props |> kvList)
