module Fish

open Fable.Core
open Fable.Import.React
open Fable.Import
open Fable.Helpers
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Helpers
open Types


type [<Pojo>] FishProps =
  {
    Key : string
    Index : string
    Details : Fish
    AddToOrder : string -> unit
  }

type Fish(initialProps) as this =
  inherit React.Component<FishProps,obj>(initialProps)

  override __.render () =
    let {
        name = name
        price = price
        desc = desc
        status = status
        image = image
        } = this.props.Details

    let isAvailable =
      status = "available"

    li [ ClassName "menu-fish" ]
      [
        img [ Src image ; Alt name ]

        h3 [ ClassName "fish-name" ] [ str name ]

        span [ ClassName "price" ] [ str <| formatPrice price ]

        p [] [ str desc ]

        button
          [
            Disabled <| not isAvailable
            OnClick (fun _ -> this.props.AddToOrder this.props.Index)
          ]
          [
            if isAvailable then
              yield "Add To Order" |> str
            else
              yield "Sold Out" |> str
          ]

      ]




