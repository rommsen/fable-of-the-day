module App

open Fable.Core
open Fable.Import
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Import.React
open Fable.Helpers.React.Props
open Fable.PowerPack
open Helpers
open SampleFishes
open Order
open Fish
open Types
open Inventory
open System
open Base

// 1. create type for component
// 2. create Constructor Function for React Element (ofType)
// 3. for js imports create react Components (when no children needed we can give an empty list)
// define the types


type HeaderProps =
  | Tagline of string

let inline header props =
  ofDefaultImport "../components/Header" props []

let inline fish props =
  ofType<Fish.Fish,FishProps,_> props []

type [<Pojo>] AppState =
  {
    Fishes : Fishes
    Orders : Orders
  }

type [<Pojo>] Params =
  { storeId : string }

type [<Pojo>] Match =
  { ``params`` : Params }

type [<Pojo>] AppProps =
  { ``match`` : Match }

let order props =
  ofType<Order,OrderProps,_> props []


type App(props) as this=
  inherit React.Component<AppProps,AppState>(props)
  do
    this.setInitState { Fishes = Map.empty ; Orders = Map.empty }

  let addToOrder = this.AddToOrder
  let removeFromOrder = this.RemoveFromOrder

  let addFish = this.AddFish

  let updateFish = this.UpdateFish

  let deleteFish = this.DeleteFish

  let loadSampleFishes = this.LoadSampleFishes

  let makeFish key element =
    let props =
      {
        Key = string key
        Index = string key
        Details = element
        AddToOrder = addToOrder
      }

    fish props

  member __.AddToOrder key =
    let order =
      this.state.Orders
      |> Map.tryFind key
      |> Option.defaultValue 0
      |> (+) 1

    this.setState { this.state with Orders = this.state.Orders |> Map.add key order }

  member __.RemoveFromOrder key =
    this.setState { this.state with Orders = this.state.Orders |> Map.remove key }

  member __.LoadSampleFishes _ =
    this.setState { this.state with Fishes = sampleFishes |> Map.ofList }

  member __.DeleteFish key =
    this.setState { this.state with Fishes = this.state.Fishes |> Map.remove key }

  member __.UpdateFish key fish =
    this.setState { this.state with Fishes = this.state.Fishes |> Map.add key fish }

  member __.AddFish fish =
    let key = System.Guid.NewGuid() |> string

    this.setState { this.state with Fishes = this.state.Fishes |> Map.add key fish }

  member __.StoreId =
    this.props.``match``.``params``.storeId

  override __.componentDidMount () =
    promise {
      let! data = Rebase.fetch <| this.StoreId + "/fishes"
      if data |> String.IsNullOrEmpty |> not then
        let fishes = ofJson<Fishes> data
        this.setState { this.state with Fishes = fishes}
    } |> Promise.start

    // load the orders from the localStorage and set the state when found
    this.StoreId
    |> BrowserLocalStorage.load<Orders>
    |> Option.iter (fun orders -> this.setState { this.state with Orders = orders })

  override __.componentDidUpdate (_,prevState) =
    // otherwise we will delete the fishes every time
    if(prevState.Fishes <> this.state.Fishes) then
      // save the fishes to firebase
      promise {
        let fishes =
          createObj [ "data" ==> toJson this.state.Fishes ]

        do! Rebase.post (this.StoreId + "/fishes") fishes
      } |> Promise.start

    // save the orders to the local storage
    this.state.Orders |> BrowserLocalStorage.save<Orders> this.StoreId

  override this.render () =
    let inventoryProps : InventoryProps =
      {
        StoreId = this.StoreId
        Fishes = this.state.Fishes
        Orders = this.state.Orders
        AddFish = addFish
        UpdateFish = updateFish
        DeleteFish = deleteFish
        LoadSampleFishes = loadSampleFishes
      }

    div [ ClassName "catch-of-the-day" ]
      [
        div [ ClassName "menu" ]
          [
            header [ Tagline "Fresh Seafood Market" ]

            ul [ ClassName "fishes"]
              (this.state.Fishes |> Map.map makeFish |> Map.toList |> List.map snd)
          ]
        order
          {
            Fishes = this.state.Fishes
            Orders = this.state.Orders
            RemoveFromOrder = removeFromOrder
          }

        inventory inventoryProps
      ]
