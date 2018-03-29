module Inventory

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Import.React
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.PowerPack
open Firebase
open Types
open Helpers
open EditFishForm
open AddFishForm
open Login
open System

type [<Pojo>] InventoryProps =
  {
    StoreId : string
    Fishes : Fishes
    Orders : Orders
    AddFish : Fish -> unit
    UpdateFish : string -> Fish -> unit
    DeleteFish : string -> unit
    LoadSampleFishes : unit -> unit
  }

type [<Pojo>] InventoryState =
  {
    Owner : string option
    Uid : string option
  }

type User =
  { uid : string }

type AuthData =
  { user : User }

type Inventory(initialProps) as this =
  inherit React.Component<InventoryProps,InventoryState>(initialProps)

  do
    this.setInitState  { Uid = None; Owner = None }

  let loadSampleFishes _ =
    this.props.LoadSampleFishes ()

  let makeEditFishForm index fish =
    let props =
      {
        Fish = fish
        Index = index
        UpdateFish = this.props.UpdateFish
        RemoveFish = this.props.DeleteFish
      }

    editFishForm props

  let renderFishes fishes =
    fishes
    |> Map.map makeEditFishForm
    |> Map.toList
    |> List.map snd
    |> fragment []

  let authenticate = this.Authenticate

  let logout = this.Logout

  member __.AuthHandler authData =
    promise {
      let! data = fetch <| this.props.StoreId + "/owner"
      let owner =
        if data |> String.IsNullOrEmpty then
          authData.user.uid
        else
          data

      if data |> String.IsNullOrEmpty then
        do! post (this.props.StoreId + "/owner") (createObj [ "data" ==> authData.user.uid ])

      this.setState
        {
          Uid = authData.user.uid |> Some
          Owner = owner |> Some
        }
    }

  member __.Authenticate provider =
    let authProvider =
      match provider with
      | Github ->
          Firebase.auth.GithubAuthProvider.Create ()

      | Twitter ->
          Firebase.auth.GithubAuthProvider.Create ()

      | Facebook ->
          Firebase.auth.GithubAuthProvider.Create ()

    promise {
      let auth = firebaseApp.auth()
      let! authData = auth.signInWithPopup authProvider

      do! (unbox authData) |> this.AuthHandler
    } |> Promise.start

  member __.Logout _ =
    promise {
      let! _ = firebaseApp.auth().signOut()
      this.setState { this.state with Uid = None }
    } |> Promise.start

  override __.componentDidMount () =
    let observer (user : Firebase.User option) =
      match user with
      | Some user  ->
          let authData =
            { user = { uid = user.uid }}

          this.AuthHandler authData |> Promise.start
          None

      | None -> None

    observer
    |> U2.Case2
    |> firebaseApp.auth().onAuthStateChanged
    |> ignore

  override __.render () =
    let logout =
      button [ OnClick logout ] [ str "Log Out!" ]

    let notOwner =
      div []
        [
          p []
            [
              str "Sorry you are not the owner!"
              logout
            ]
        ]

    let inventory () =
      div [ ClassName "inventory" ]
        [
          h2 [] [ str "Inventory" ]

          logout

          this.props.Fishes |> renderFishes

          addFishForm { AddFish = this.props.AddFish }

          button [ OnClick loadSampleFishes ] [ str "Load Sample Fishes" ]
        ]

    if this.state.Uid = None then
      login authenticate
    elif this.state.Uid <> this.state.Owner then
      notOwner
    else
      inventory()

let inventory props =
  ofType<Inventory,InventoryProps,InventoryState> props []
