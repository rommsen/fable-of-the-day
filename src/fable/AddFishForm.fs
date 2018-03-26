module AddFishForm

open Fable.Core
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Core.JsInterop
open Types

type [<Pojo>] AddFishFormProps =
  {
    AddFish : Fish -> unit
  }

type MaybeBuilder() =
    member __.Bind(x, f) =
      Option.bind f x

    member __.Return(x) = Some x

let maybe = MaybeBuilder()

type AddFishForm(initialProps) as this =
  inherit React.Component<AddFishFormProps,obj>(initialProps)

  let mutable nameRef : Browser.Element option = None // create a mutable field for the ref
  let mutable priceRef : Browser.Element option = None // create a mutable field for the ref
  let mutable statusRef : Browser.Element option = None // create a mutable field for the ref
  let mutable descRef : Browser.Element option = None // create a mutable field for the ref
  let mutable imageRef : Browser.Element option = None // create a mutable field for the ref

  let nameRefSet ref =
    nameRef <- Some ref
  let priceRefSet ref =
    priceRef <- Some ref
  let statusRefSet ref =
    statusRef <- Some ref
  let descRefSet ref =
    descRef <- Some ref
  let imageRefSet ref =
    imageRef <- Some ref


  let addFish = this.AddFish

  member __.AddFish _ =
    maybe {
      let! image = imageRef
      let! name = nameRef
      let! desc = descRef
      let! status = statusRef
      let! price = priceRef

      return {
        image = !!image?value
        name = !!name?value
        desc = !!desc?value
        status = !!status?value
        price = !!price?value
      }
    }
    |> Option.iter (fun fish -> fish |> this.props.AddFish)

  override __.render () =
    form
      [
        ClassName "fish-edit"
        OnSubmit addFish
      ]
      [
        input
          [
            Name "name"
            Ref nameRefSet
            Type "text"
            Placeholder "Name"
          ]

        input
          [
            Name "price"
            Ref priceRefSet
            Type "text"
            Placeholder "Price"
          ]

        select
          [
            Name "status"
            Ref statusRefSet
          ]
          [
            option [ Value "available" ] [ str "Fresh!" ]
            option [ Value "unavailable" ]  [ str "Sold Out!" ]
          ]

        textarea
          [
            Name "desc"
            Ref descRefSet
            Placeholder "Desc"
          ]
          [ ]

        input
          [
            Name "image"
            Ref imageRefSet
            Type "text"
            Placeholder "Image"
          ]

        button [ Type "submit" ] [ str "+ Add Fish" ]
      ]


let addFishForm props =
  ofType<AddFishForm,AddFishFormProps,_> props []
