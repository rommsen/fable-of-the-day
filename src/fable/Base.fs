module Base

open Fable.Core.JsInterop
open Fable.Import
open Firebase

[<RequireQualifiedAccess>]
module Firebase =
  let private firebaseObj =
    createObj
      [
        "apiKey" ==> "AIzaSyBFiYmjUURidV7w6674QfIiHfWMixH88aE"
        "authDomain" ==> "catch-of-the-day-rommsen.firebaseapp.com"
        "databaseURL" ==> "https://catch-of-the-day-rommsen.firebaseio.com"
      ]

  let app =
    Firebase.firebase.initializeApp (unbox firebaseObj,"roman")

[<RequireQualifiedAccess>]
module Rebase =
  type private Rebase =
    {
      post : string -> obj -> JS.Promise<unit>
      fetch : string -> obj -> JS.Promise<string>
    }

  type private RebaseInit = { createClass : Firebase.Database.Database -> Rebase }

  let private rebaseInit : RebaseInit =
    importDefault "re-base"

  let private rebase = rebaseInit.createClass <| Firebase.app.database()

  let fetch store =
    rebase.fetch store (createObj [])

  let post key value =
    rebase.post key value
