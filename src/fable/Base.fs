module Base

open Fable.Core.JsInterop
open Fable.Import
open Firebase

[<RequireQualifiedAccess>]
module Firebase =
  let private firebaseObj =
    createObj
      [
        "apiKey" ==> "AIzaSyBdzsaNt3_E_gHD2gcko4PmlHqbGxz7vrA"
        "authDomain" ==> "fable-of-the-day.firebaseapp.com"
        "databaseURL" ==> "https://fable-of-the-day.firebaseio.com"
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
