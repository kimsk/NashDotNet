namespace BingoEngine

module BallCaller =
    open Util
    open Bingo

    // valid ball call status
    type BallCallStatus = NotCalled | Called | InPattern
    type BallCall = { Number:int; BallCallStatus:BallCallStatus }

    let GetBallCallStatus ballNum =
        if ballNum % 5 <> 0 then failwith "ball number should be multiply of 5"
        else
            let balls = 
                let num = (ballNum/5)-1        
                [| 
                    for x in (Shuffle B).[..num] -> x
                    for x in (Shuffle I).[..num] -> x
                    for x in (Shuffle N).[..num] -> x
                    for x in (Shuffle G).[..num] -> x
                    for x in (Shuffle O).[..num] -> x
                |] |> Array.sort
            let ballCall = Array.create 75 BallCallStatus.NotCalled
            for ball in balls do
                ballCall.[ball-1] <- BallCallStatus.Called
        
            ballCall

    let BallCallStatusToBallCalls ballCallStatus =
        ballCallStatus |> Array.mapi (fun i bc -> { Number = i+1; BallCallStatus = bc})
        
    let CallBalls ballNum =
        GetBallCallStatus ballNum |> BallCallStatusToBallCalls
