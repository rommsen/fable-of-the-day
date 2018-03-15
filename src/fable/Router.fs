module Router

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React
open Fable.Import.Browser
open Fable.Helpers.React.Props


(*
import React from "react";
import { BrowserRouter, Route, Switch } from "react-router-dom";
import StorePicker from "./StorePicker";
import App from "./App";
import NotFound from "./NotFound";

const Router = () => (
  <BrowserRouter>
    <Switch>
      <Route exact={true} path="/" component={StorePicker} />
      <Route path="/store/:storeId" component={App} />
      <Route component={NotFound} />
    </Switch>
  </BrowserRouter>
);

export default Router;
*)


// type [<RequireQualifiedAccess>] HelloProp =
//   | Name of string

// let inline hello (props: IProp list) (children: React.ReactElement list) : React.ReactElement =
//   ofImport "default" "../components/HelloJS" (keyValueList CaseRules.LowerFirst props) children

let inline kvList props =
  keyValueList CaseRules.LowerFirst props

let inline browserRouter (children: React.ReactElement list): React.ReactElement =
  ofImport "BrowserRouter" "react-router-dom" (() :> obj) children

let inline switch children =
  ofImport "Switch" "react-router-dom" (() :> obj) children

type RouteProps =
  | Path of string
  | Component of React.ComponentClass<obj>
  | Exact of bool

let inline route (props : RouteProps list) : React.ReactElement =
  ofImport "Route"  "react-router-dom" (props |> kvList) []

let StorePicker =
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
          route [ Exact true ; Path "/" ; Component StorePicker ]
          route [ Path "/store/:storeId" ; Component App ]
          route [ Component StorePicker ]
        ]
    ]

