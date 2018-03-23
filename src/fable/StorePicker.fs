module StorePicker

open Fable.Core
open Fable.Import
open Fable.Helpers.React
open Fable.Import.React
open Fable.Helpers.React.Props
open Fable.Core.JsInterop

open Helpers

type [<Pojo>] History =
  {
    push : string -> unit
  }

type [<Pojo>] StorePickerProps =
  {
    history : History
  }

type StorePicker(initialProps) as this =   // as this is important to refer to this in the whole type
  inherit React.Component<StorePickerProps, obj> (initialProps)

  let goToStore = this.GoToStore // react perform blog

  let mutable myInput : Browser.Element option = None // create a mutable field for the ref

  let myInputSet ref =
    myInput <- Some ref

  member __.GoToStore (event : FormEvent ) =
    // stop the form from submitting
    event.preventDefault()

    // get the text from that input and change the page to /store/whatever-they-entered
    myInput |> Option.iter (fun input -> this.props.history.push("/store/"+ !!input?value) )

    ()

  override this.render() =
    form
      [
        ClassName "store-selector"
        OnSubmit goToStore
      ]
      [
        h2 [] [ ofString "Please enter a store" ]
        input
          [
            Ref myInputSet // set the ref
            Required true
            Placeholder "Store Name"
            DefaultValue <| getFunName()
          ]
        button [] [ ofString "Visit Store →" ]
      ]
