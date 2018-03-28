module Helpers

open Fable.Core.JsInterop
open Fable.Core
open Fable.Import
open Fable.Helpers.React
open Types
open Firebase

let getFunName : unit -> string =
  import "getFunName" "../helpers.js"

let formatPrice : float -> string =
  import "formatPrice" "../helpers"

type Rebase =
  {
    syncState : string -> obj -> obj
    removeBinding : obj -> unit
    post : string -> obj -> unit
    fetch : string -> obj -> unit
  }

let rebase : Rebase =
  importDefault "../base.js"

let inline kvList props =
  keyValueList CaseRules.LowerFirst props

let firebaseObj =
  createObj
    [
      "apiKey" ==> "AIzaSyBFiYmjUURidV7w6674QfIiHfWMixH88aE"
      "authDomain" ==> "catch-of-the-day-rommsen.firebaseapp.com"
      "databaseURL" ==> "https://catch-of-the-day-rommsen.firebaseio.com"
    ]

let firebaseApp : Firebase.App.App =
  import "firebaseApp" "../base.js"

Browser.console.log(firebaseApp.auth

// let authProvider = Firebase.auth.GithubAuthProvider.Create
// // let bong = authProvider.Create




// let bla = firebaseApp.auth()
// bla.signInWithPopup (authProvider)
//  [`${provider}AuthProvider`]();
//     firebaseApp
//       .auth()
//       .signInWithPopup(authProvider)
//       .then(this.authHandler);





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
