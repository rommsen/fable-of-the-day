module Login

open Fable.Core
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types

type [<Pojo>] LoginProps =
  {
    Authenticate : AuthenticationProvider -> unit
  }

type Login(initialProps) as this =
  inherit React.PureStatelessComponent<LoginProps>(initialProps)

  override __.render () =
    nav [ ClassName "login" ]
      [
        h2 [] [ str "Inventory Login" ]

        p [] [ str "Sign in to manage your store's inventory." ]

        button
          [
            ClassName "github"
            OnClick (fun _ -> this.props.Authenticate Github)
          ]
          [ str "Login with Github" ]

        button
          [
            ClassName "twitter"
            OnClick (fun _ -> this.props.Authenticate Twitter)
          ]
          [ str "Login with Twitter" ]

        button
          [
            ClassName "facebook"
            OnClick (fun _ -> this.props.Authenticate Facebook)
          ]
          [ str "Login with Facebook" ]
      ]


let login authenticate =
  ofType<Login,LoginProps,obj> { Authenticate = authenticate } []

