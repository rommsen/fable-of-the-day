module Helpers

open Fable.Core.JsInterop
open Fable.Core

let getFunName : unit -> string =
    import "getFunName" "../helpers.js"

let inline kvList props =
  keyValueList CaseRules.LowerFirst props
