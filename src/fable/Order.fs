module Order

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Helpers
open Types

let cssTransition (props: obj) children =
  ofImport "CSSTransition" "react-transition-group" props children

let transitionGroup (props : obj) children  =
  ofImport "TransitionGroup" "react-transition-group" props children

type [<Pojo>] OrderProps =
  {
    Fishes : Fishes
    Orders : Orders
    RemoveFromOrder : (string -> unit)
  }

type Order(initialProps) as this =
  inherit React.Component<OrderProps,obj>(initialProps)

  let renderOrder key =
    let fishOpt = this.props.Fishes |> Map.tryFind key

    let count =
      this.props.Orders
      |> Map.tryFind key
      |> Option.defaultValue 0

    let isAvailable =
      fishOpt
      |> Option.exists (fun fish -> fish.status = "available")

    let name,price =
      fishOpt
      |> Option.map (fun fish -> fish.name, fish.price)
      |> Option.defaultValue ("fish",0.)

    let transitionOptions =
      createObj
        [
          "classNames" ==> "order"
          "key" ==> key
          "timeout" ==> createObj [ "enter" ==> 500 ; "exit" ==> 500]
        ]

    if not isAvailable then
      cssTransition transitionOptions
        [
          li [ Key key]
            [
              str "Sorry "; str name ; str " is no longer available"
            ]
        ]
    else
      cssTransition transitionOptions
        [
          li [ Key key]
            [
              span []
                [
                  transitionGroup (createObj [ "component" ==> "span";  "className" ==> "count" ])
                    [
                      cssTransition
                        (createObj
                          [
                              "classNames" ==> "count"
                              "key" ==> count
                              "timeout" ==> createObj [ "enter" ==> 500 ; "exit" ==> 500]
                          ]
                        )
                        [
                          span [] [ ofInt count ]
                        ]
                    ]

                  str "lbs "
                  str name
                  str  <| formatPrice price
                  button
                    [
                      OnClick (fun _ -> this.props.RemoveFromOrder key)
                    ]
                    [
                      str "&times;"
                    ]
                ]
            ]
        ]

  override __.render () =
    let orderIds =
      this.props.Orders
      |> Map.toList
      |> List.map fst

    let calcTotal prevTotal key =
      let fishOpt = this.props.Fishes |> Map.tryFind key

      let count =
        this.props.Orders
        |> Map.tryFind key
        |> Option.defaultValue 0

      let price =
        fishOpt
        |> Option.map (fun fish -> fish.price)
        |> Option.defaultValue 0.

      let isAvailable =
        fishOpt
        |> Option.exists (fun fish -> fish.status = "available")

      if isAvailable then
        prevTotal + (price * float count)
      else
        prevTotal

    let total =
      orderIds
      |> List.fold calcTotal 0.

    div [ ClassName "order-wrap" ]
      [
        h2 [] [ str "Order" ]

        transitionGroup (createObj [ "component" ==> "ul";  "className" ==> "order" ])
          (orderIds |> List.map renderOrder)

        div [ ClassName "total"]
          [
            strong [] [ str <| formatPrice total ]
          ]
      ]
