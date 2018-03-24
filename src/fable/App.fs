module App

open Fable.Core
open Fable.Import
open Fable.Helpers.React
open Fable.Import.React
open Fable.Helpers.React.Props
open Fable.Core.JsInterop
open Helpers

// 1. create type for component
// 2. create Constructor Function for React Element (ofType)
// 3. for js imports create react Components (when no children needed we can give an empty list)
// define the types


type HeaderProps =
  | Tagline of string

let inline header props =
  ofDefaultImport "../components/Header" props []

type [<Pojo>] Fish =
  {
    image : string
    name : string
    desc : string
    status : string
    price : float
  }

type FishProps =
  | Key of string
  | Index of string
  | Details of Fish
  | AddToOrder of (string -> unit)

let inline fish props =
  ofDefaultImport "../components/Fish" props []

type [<Pojo>] AppState =
  {
    fishes : Fish list
  }

let sampleFishes =
  [
    {
      name = "Pacific Halibut"
      image = "/images/hali.jpg"
      desc = "Everyones favorite white fish. We will cut it to the size you need and ship it."
      price = 1724.
      status = "available"
    }

    {
      name = "Lobster"
      image = "/images/lobster.jpg"
      desc = "These tender mouth-watering beauties are a fantastic hit at any dinner party."
      price = 3200.
      status = "available"
    }
  ]


type App(props) as this=
  inherit React.Component<obj,AppState>(props)
  do
    this.setInitState { fishes = [] }

  let addToOrder = this.AddToOrder
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

  member __.AddToOrder index =
    ()

  member __.LoadSampleFishes event =
    this.setState { this.state with fishes = sampleFishes}

  override this.render () =
    div [ ClassName "catch-of-the-day" ]
      [
        div [ ClassName "menu" ]
          [
            header [ Tagline "Fresh Seafood Market" ]

            ul [ ClassName "fishes"]
              (this.state.fishes |> List.mapi makeFish)
          ]

        button [ OnClick loadSampleFishes ]
          [ ofString "Load Sample Fishes" ]
      ]
