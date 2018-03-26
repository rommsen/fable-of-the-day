module Inventory

open Fable.Core
open Fable.Import
open Fable.Import.React
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open EditFishForm
open AddFishForm


type [<Pojo>] InventoryProps =
  {
    Fishes : Fishes
    Orders : Orders
    AddFish : Fish -> unit
    UpdateFish : string -> Fish -> unit
    DeleteFish : string -> unit
    LoadSampleFishes : unit -> unit
  }

type Inventory(initialProps) as this =
  inherit React.Component<InventoryProps,obj>(initialProps)

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

  override __.render () =
    div [ ClassName "inventory" ]
      [
        yield h2 [] [ str "Inventory" ]

        yield! this.props.Fishes |> Map.map makeEditFishForm |> Map.toList |> List.map snd

        yield addFishForm { AddFish = this.props.AddFish }

        yield button [ OnClick loadSampleFishes ] [ str "Load Sample Fishes" ]
      ]

let inventory props =
  ofType<Inventory,InventoryProps,obj> props []
