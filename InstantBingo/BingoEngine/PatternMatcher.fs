namespace BingoEngine

module PatternMatcher =
    open BingoCard
    open BallCaller
    open BingoPatterns

    let MarkBingoSquareWithBallCalls (square:BingoSquare) (ballCalls:BallCall[]) = 
        if ballCalls.[square.Number - 1].BallCallStatus = BallCallStatus.Called then
            { Number = square.Number; Status = NumberStatus.Called }
        else
            { Number = square.Number; Status = NumberStatus.NotCalled }

    let MarkCardWithBallCalls (card:BingoSquare [][]) (ballCalls:BallCall[]) =       
        [|
            [|for i in 0..4 -> MarkBingoSquareWithBallCalls card.[0].[i] ballCalls|]
            [|for i in 0..4 -> MarkBingoSquareWithBallCalls card.[1].[i] ballCalls|]
            [|
                for i in 0..1 -> MarkBingoSquareWithBallCalls card.[2].[i] ballCalls               
                yield { Number = card.[2].[2].Number; Status = NumberStatus.NotCalled }
                for i in 3..4 -> MarkBingoSquareWithBallCalls card.[2].[i] ballCalls
            |]
            [|for i in 0..4 -> MarkBingoSquareWithBallCalls card.[3].[i] ballCalls|]
            [|for i in 0..4 -> MarkBingoSquareWithBallCalls card.[4].[i] ballCalls|]
       |]

    let IsCardMatchWithPattern (card:BingoSquare[][]) pattern =
        not (pattern |> Array.exists (fun p -> p <> (2,2) && card.[fst p].[snd p].Status = NumberStatus.NotCalled))

    let GetMatchingPatterns (card:BingoSquare [][]) (patterns:BingoPattern[]) = 
        patterns |> Array.filter (fun p -> IsCardMatchWithPattern card p.Positions)

    let MatchBingoSquareWithPattern pos (square:BingoSquare) pattern =
        if (square.Status <> NumberStatus.NotCalled || pos = (2,2)) && pattern |> Array.exists ((=)pos) then
            { Number = square.Number; Status = NumberStatus.InPattern }
        else
            if square.Status = NumberStatus.NotCalled then
                { Number = square.Number; Status = NumberStatus.NotCalled }
            else
                { Number = square.Number; Status = NumberStatus.Called }

    let MarkCardWithPattern (card:BingoSquare [][]) pattern =
        [|
            [|for i in 0..4 -> MatchBingoSquareWithPattern (0,i) card.[0].[i] pattern|]
            [|for i in 0..4 -> MatchBingoSquareWithPattern (1,i) card.[1].[i] pattern|]
            [|for i in 0..4 -> MatchBingoSquareWithPattern (2,i) card.[2].[i] pattern|]
            [|for i in 0..4 -> MatchBingoSquareWithPattern (3,i) card.[3].[i] pattern|]
            [|for i in 0..4 -> MatchBingoSquareWithPattern (4,i) card.[4].[i] pattern|]
       |]

    let MarkBallCallsWithCardInPattern (card:BingoSquare [][]) (ballCalls:BallCall[]) =
        let inPatternNumbers = 
            [|
                for row in 0..4 do
                    for col in 0..4 do
                        if card.[row].[col].Status = NumberStatus.InPattern && not (row = 2 && col = 2) then
                            yield card.[row].[col].Number
            |]         
        
        Array.init 75 (fun i -> 
            if Array.exists ((=)(i+1)) inPatternNumbers then 
                { Number = ballCalls.[i].Number; BallCallStatus = BallCallStatus.InPattern }
            else 
                if ballCalls.[i].BallCallStatus = BallCallStatus.NotCalled then 
                    { Number = ballCalls.[i].Number; BallCallStatus = BallCallStatus.NotCalled }
                else 
                    { Number = ballCalls.[i].Number; BallCallStatus =  BallCallStatus.Called }
        )