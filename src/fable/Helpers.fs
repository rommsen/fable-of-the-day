module Helpers

open Fable.Core.JsInterop
open Fable.Core
open Fable.Import

let getFunName : unit -> string =
    import "getFunName" "../helpers.js"

let inline kvList props =
  keyValueList CaseRules.LowerFirst props


type FableReactComponentProp<'Props> =
  'Props -> React.ReactElement list -> React.ReactElement

type JsReactComponentProp =
  React.ComponentClass<obj>
