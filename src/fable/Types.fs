module Types

open Fable.Core

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
