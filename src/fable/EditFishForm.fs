module EditFishForm

open Fable.Core
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Core.JsInterop
open Types


type [<Pojo>] EditFishFormProps =
  {
    Fish : Fish
    Index : string
    UpdateFish : string -> Fish -> unit
    RemoveFish : string -> unit
  }

type EditFishForm(initialProps) as this =
  inherit React.Component<EditFishFormProps,obj>(initialProps)

  let handleChange = this.HandleChange

  let removeFish = this.RemoveFish

  member __.RemoveFish _ =
    this.props.RemoveFish this.props.Index

  member __.HandleChange (event : React.FormEvent) =
    // ugly ugly
    match !!event?currentTarget?name with
    | "name" ->
         { this.props.Fish with name = !!event?currentTarget?value } |> Some

    | "price" ->
         { this.props.Fish with price = !!event?currentTarget?value } |> Some

    | "status" ->
         { this.props.Fish with status = !!event?currentTarget?value } |> Some

    | "desc" ->
         { this.props.Fish with desc = !!event?currentTarget?value } |> Some

    | "image" ->
         { this.props.Fish with image = !!event?currentTarget?value } |> Some

    | _ -> None

    |> Option.iter (fun fish -> this.props.UpdateFish this.props.Index fish)

  override __.render () =
    div [ ClassName "fish-edit" ]
      [
        input
          [
            Type "text"
            Name "name"
            OnChange handleChange
            Value this.props.Fish.name
          ]

        input
          [
            Type "text"
            Name "price"
            OnChange handleChange
            Value <| string this.props.Fish.price
          ]

        select
          [
            Type "text"
            Name "status"
            OnChange handleChange
            Value this.props.Fish.status
          ]
          [
            option [ Value "available" ] [ str "Fresh!" ]
            option [ Value "unavailable" ] [ str "Sold Out!" ]
          ]

        textarea
          [
            Name "desc"
            OnChange handleChange
            Value this.props.Fish.desc
          ]
          []

        input
          [
            Type "text"
            Name "image"
            OnChange handleChange
            Value this.props.Fish.image
          ]

        button
          [
            OnClick removeFish
          ]
          [ str "Remove Fish" ]
      ]
