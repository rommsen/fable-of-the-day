module Index

open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React
open Fable.Import.Browser

open Router

importAll "../css/style.css"

let init() =
  let element =
    fragment []
      [
        Router()
      ]
  ReactDom.render(element, document.getElementById("main"))

init()