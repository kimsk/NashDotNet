namespace BingoEngine

module BingoCard =
    open Util
    open Bingo

    type NumberStatus = NotCalled | Called | InPattern
    type BingoSquare = { Number:int; Status:NumberStatus }
    
    let GetNewCard () =
        let tmp = [|
                    (Shuffle B).[..4] |> Array.map (fun n -> {Number = n; Status = NumberStatus.NotCalled} )
                    (Shuffle I).[..4] |> Array.map (fun n -> {Number = n; Status = NumberStatus.NotCalled} )
                    (Shuffle N).[..4] |> Array.map (fun n -> {Number = n; Status = NumberStatus.NotCalled} )
                    (Shuffle G).[..4] |> Array.map (fun n -> {Number = n; Status = NumberStatus.NotCalled} )
                    (Shuffle O).[..4] |> Array.map (fun n -> {Number = n; Status = NumberStatus.NotCalled} )
                |]

        [|

            [|for i in 0..4 -> tmp.[i].[0]|]
            [|for i in 0..4 -> tmp.[i].[1]|]
            [|for i in 0..4 -> tmp.[i].[2]|]
            [|for i in 0..4 -> tmp.[i].[3]|]
            [|for i in 0..4 -> tmp.[i].[4]|]
        |]

