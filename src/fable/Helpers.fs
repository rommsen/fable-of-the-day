module Helpers

open Fable.Core.JsInterop

let getFunName : unit -> string =
    import "getFunName" "../helpers.js"
