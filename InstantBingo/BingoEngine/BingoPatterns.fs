namespace BingoEngine

module BingoPatterns =
    type BingoPattern = {Name:string; Credits:int; Positions:(int*int) []}

    let PatternsToBools patterns =
        [|
            Array.init 5 (fun col -> patterns |> Array.exists ((=)(0,col)))
            Array.init 5 (fun col -> patterns |> Array.exists ((=)(1,col)))
            Array.init 5 (fun col -> patterns |> Array.exists ((=)(2,col)))
            Array.init 5 (fun col -> patterns |> Array.exists ((=)(3,col)))
            Array.init 5 (fun col -> patterns |> Array.exists ((=)(4,col)))
        |]

    // available bing patterns
    let Patterns = [|
            { Name = "2 Stamps-1";    Credits = 1;    Positions = [|(0,0);(0,1);(1,0);(1,1);(3,0);(4,0);(4,1);(3,1)|]};
            { Name = "2 Stamps-2";    Credits = 1;    Positions = [|(0,0);(1,0);(1,1);(0,1);(0,3);(1,3);(1,4);(0,4)|]};
            { Name = "2 Stamps-3";    Credits = 1;    Positions = [|(0,0);(1,0);(1,1);(0,1);(3,3);(4,3);(4,4);(3,4)|]};
            { Name = "2 Stamps-4";    Credits = 1;    Positions = [|(3,0);(4,0);(4,1);(3,1);(0,3);(1,3);(1,4);(0,4)|]};
            { Name = "2 Stamps-5";    Credits = 1;    Positions = [|(3,0);(4,0);(4,1);(3,1);(3,3);(4,3);(4,4);(3,4)|]};
            { Name = "2 Stamps-6";    Credits = 1;    Positions = [|(0,3);(1,3);(1,4);(0,4);(3,3);(4,3);(4,4);(3,4)|]};
            { Name = "3 Stamps-1";    Credits = 5;    Positions = [|(0,0);(1,0);(1,1);(0,1);(3,0);(4,0);(4,1);(3,1);(0,3);(1,3);(1,4);(0,4)|]};
            { Name = "3 Stamps-2";    Credits = 5;    Positions = [|(0,0);(1,0);(1,1);(0,1);(0,3);(1,3);(1,4);(0,4);(3,3);(4,3);(4,4);(3,4)|]};
            { Name = "3 Stamps-3";    Credits = 5;    Positions = [|(0,0);(1,0);(1,1);(0,1);(3,0);(4,0);(4,1);(3,1);(4,3);(4,4);(3,4);(3,3)|]};
            { Name = "3 Stamps-4";    Credits = 5;    Positions = [|(3,0);(4,0);(4,1);(3,1);(3,3);(4,3);(4,4);(3,4);(1,3);(0,3);(0,4);(1,4)|]};
            { Name = "4 Stamps";        Credits = 58;   Positions = [|(0,0);(1,0);(1,1);(0,1);(0,3);(1,3);(1,4);(0,4);(3,0);(4,0);(4,1);(3,1);(3,3);(4,3);(4,4);(3,4)|]};
            { Name = "Lucky 7";         Credits = 6;    Positions = [|(0,0);(0,1);(0,2);(0,3);(0,4);(1,3);(2,2);(3,1);(4,0)|]};
            { Name = "Diamond";         Credits = 6;    Positions = [|(2,0);(1,1);(0,2);(1,3);(2,4);(3,3);(4,2);(3,1)|]};
            { Name = "Large Kite-1";    Credits = 3;    Positions = [|(0,0);(1,0);(2,0);(2,1);(2,2);(1,2);(0,2);(0,1);(1,1);(3,3);(4,4)|]};
            { Name = "Large Kite-2";    Credits = 3;    Positions = [|(0,2);(1,2);(2,2);(2,3);(2,4);(1,4);(1,3);(0,3);(0,4);(4,0);(3,1)|]};
            { Name = "Large Kite-3";    Credits = 3;    Positions = [|(2,0);(3,0);(4,0);(4,1);(4,2);(3,2);(2,2);(2,1);(3,1);(1,3);(0,4)|]};
            { Name = "Large Kite-4";    Credits = 3;    Positions = [|(2,2);(3,2);(4,2);(4,4);(4,3);(3,3);(3,4);(2,4);(2,3);(1,1);(0,0)|]};
            { Name = "Bar";             Credits = 40;   Positions = [|(0,0);(1,0);(2,0);(3,0);(4,0);(4,2);(3,2);(2,2);(1,2);(0,2);(0,4);(1,4);(2,4);(3,4);(4,4)|]};
            { Name = "Small Frame";     Credits = 7;    Positions = [|(1,1);(2,1);(3,1);(3,2);(3,3);(2,3);(1,3);(1,2)|]};
            { Name = "Large Frame";     Credits = 58;   Positions = [|(0,0);(1,0);(2,0);(3,0);(4,0);(4,1);(4,2);(4,3);(4,4);(3,4);(2,4);(1,4);(0,4);(0,3);(0,2);(0,1)|]};
            { Name = "Goal Post";       Credits = 11;   Positions = [|(0,0);(1,0);(2,0);(2,1);(2,2);(2,3);(2,4);(1,4);(0,4);(3,2);(4,2)|]};
            { Name = "X";               Credits = 6;    Positions = [|(0,0);(1,1);(2,2);(3,3);(4,4);(4,0);(3,1);(1,3);(0,4)|]};
            { Name = "Y";               Credits = 4;    Positions = [|(0,0);(1,1);(2,2);(3,2);(4,2);(1,3);(0,4)|]};
            { Name = "Z";               Credits = 17;   Positions = [|(0,0);(0,1);(0,2);(0,3);(0,4);(1,3);(2,2);(3,1);(4,0);(4,1);(4,2);(4,3);(4,4)|]};
            { Name = "7-11";            Credits = 68;   Positions = [|(0,0);(0,1);(1,1);(2,1);(3,1);(4,1);(0,3);(2,3);(1,3);(3,3);(4,3);(4,4);(3,4);(2,4);(1,4);(0,4)|]};
            { Name = "13";              Credits = 47;   Positions = [|(0,0);(1,0);(2,0);(3,0);(4,0);(4,2);(4,3);(4,4);(3,4);(2,4);(2,3);(1,4);(0,4);(0,3);(0,2)|]};
            { Name = "Full Card";       Credits = 570;  Positions = [|(0,0);(0,1);(0,2);(0,3);(0,4);(1,4);(1,3);(1,2);(1,1);(1,0);(4,0);(3,0);(2,0);(2,1);(3,1);(4,1);(4,3);(3,2);(4,2);(3,3);(2,2);(2,3);(2,4);(3,4);(4,4)|]};
            { Name = "Tiny I";          Credits = 4;    Positions = [|(1,1);(1,2);(1,3);(2,2);(3,2);(3,1);(3,3)|]};
            { Name = "Small I";         Credits = 7;    Positions = [|(0,1);(0,2);(0,3);(1,2);(2,2);(3,2);(4,2);(4,1);(4,3)|]};
            { Name = "Large I";         Credits = 18;   Positions = [|(0,0);(0,1);(0,2);(0,3);(0,4);(1,2);(2,2);(3,2);(4,0);(4,1);(4,2);(4,3);(4,4)|]};
            { Name = "Poodle";          Credits = 12;   Positions = [|(0,0);(0,1);(1,1);(2,1);(3,1);(4,1);(2,2);(2,3);(2,4);(3,3);(4,3);|]};
            { Name = "Pyramid";         Credits = 6;   Positions = [|(4,0);(4,1);(3,1);(4,2);(4,3);(4,4);(3,3);(3,2);(2,2);|]};
            { Name = "Air Plane";       Credits = 15;   Positions = [|(2,0);(2,1);(1,1);(0,1);(3,1);(4,1);(2,2);(2,3);(2,4);(1,4);(3,4);|]};
            { Name = "Chair";       Credits = 12;   Positions = [|(4,1);(3,1);(2,1);(2,2);(2,3);(1,4);(0,4);(2,4);(3,4);(4,4);|]};
            { Name = "Corners";       Credits = 2;   Positions = [|(0,0);(4,0);(4,4);(0,4);|]};
            { Name = "Dog Bone";       Credits = 17;   Positions = [|(1,0);(2,0);(3,0);(2,1);(2,2);(2,3);(2,4);(1,4);(3,4);|]};
            { Name = "Arrow Head";       Credits = 11;   Positions = [|(4,2);(2,2);(1,2);(3,2);(0,2);(1,1);(2,0);(1,3);(2,4);|]};
// Chair, Question Mark, Peace, Large L, K, Dog Bone, Cross Corner, Arrow Head, Cross, Corners, Inside Corners, Open Diamond
            
        |]



