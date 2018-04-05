module Types

open Fable.Core
open Fable.Import

type FableReactComponentProp<'Props> =
  'Props -> React.ReactElement list -> React.ReactElement

type JsReactComponentProp =
  React.ComponentClass<obj>

type [<Pojo>] Fish =
  {
    image : string
    name : string
    desc : string
    status : string
    price : float
  }

type Fishes =
  Map<string, Fish>

type Orders =
  Map<string, int>


type AuthenticationProvider =
  | Github
  | Twitter
  | Facebook
