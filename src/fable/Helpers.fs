module Helpers

open Fable.Core.JsInterop
open Fable.Core
open Fable.Import
open Fable.Helpers.React
open Types

let getFunName : unit -> string =
  import "getFunName" "../helpers"

let formatPrice : float -> string =
  import "formatPrice" "../helpers"

let inline kvList props =
  keyValueList CaseRules.LowerFirst props


type FableReactComponentProp<'Props> =
  'Props -> React.ReactElement list -> React.ReactElement

type JsReactComponentProp =
  React.ComponentClass<obj>

let inline ofDefaultImport com props =
  ofImport "default" com (props |> kvList)


let sampleFishes : (string * Fish) list =
  [
    ("fish1", {
        name = "Pacific Halibut"
        image = "/images/hali.jpg"
        desc = "Everyones favorite white fish. We will cut it to the size you need and ship it."
        price = 1724.
        status = "available"
      })

    ("fish2", {
        name = "Lobster"
        image = "/images/lobster.jpg"
        desc = "These tender mouth-watering beauties are a fantastic hit at any dinner party."
        price = 3200.
        status = "available"
      })
  ]
