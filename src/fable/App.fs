module FableApp

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React
open Fable.Import.Browser
open Fable.Helpers.React.Props

open Router


type [<RequireQualifiedAccess>] HelloProp =
  | Name of string

let inline hello (props: IProp list) (children: React.ReactElement list) : React.ReactElement =
  ofImport "default" "../components/HelloJS" (keyValueList CaseRules.LowerFirst props) children

printfn "halloooo"
let init() =
  let element =
    fragment []
      [
        str "hier"
        hello [ Name "JS 🌍" ] []
        Router()
      ]
  ReactDom.render(element, document.getElementById("root"))


init()