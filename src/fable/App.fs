module App

open Fable.Core
open Fable.Import
open Fable.Helpers.React
open Fable.Import.React
open Fable.Helpers.React.Props
open Helpers
open Types
open Order

// 1. create type for component
// 2. create Constructor Function for React Element (ofType)
// 3. for js imports create react Components (when no children needed we can give an empty list)
// define the types


type HeaderProps =
  | Tagline of string

let inline header props =
  ofDefaultImport "../components/Header" props []

type FishProps =
  | Key of string
  | Index of string
  | Details of Fish
  | AddToOrder of (string -> unit)

let inline fish props =
  ofDefaultImport "../components/Fish" props []

type [<Pojo>] AppState =
  {
    Fishes : Fishes
    Orders : Orders
  }

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

let order props =
  ofType<Order,OrderProps,_> props []


type App(props) as this=
  inherit React.Component<obj,AppState>(props)
  do
    this.setInitState { Fishes = Map.empty ; Orders = Map.empty }

  let addToOrder = this.AddToOrder
  let removeFromOrder = this.RemoveFromOrder

  let loadSampleFishes = this.LoadSampleFishes

  let makeFish key element =
    let props =
      [
        Key <| string key
        Index <| string key
        Details element
        AddToOrder addToOrder
      ]

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

  override this.render () =
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

        button [ OnClick loadSampleFishes ]
          [ ofString "Load Sample Fishes" ]
      ]
