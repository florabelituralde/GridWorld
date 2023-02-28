# GridWorld2DGame

PROBLEM:
In a 100 by 100 2-D grid world, you are given a starting point A on one side of the grid, and an
ending point B on the other side of the grid. Your objective is to get from point A to point B.
Each grid space can be in a state of [“Blank”, “Speeder”, “Lava”, “Mud”]. You start out with 200
points of health and 450 moves. Below is a mapping of how much your health and moves are
affected by landing on a grid space.
[
“Blank”: {“Health”: 0, “Moves”: -1},
“Speeder”: {“Health”: -5, “Moves”: 0},
“Lava”: {“Health”: -50, “Moves”: -10},
“Mud”: {“Health”: -10, “Moves”: -5},
]

Assignment 2
Build a back end API in any modern framework / language (such as Node, Python, Ruby, Java,
Go, Rust, etc.) that allows a player to save the game and come back to it later. As well as
returns any relevant data to the front end such as where the player is on the board, what the
board is configured like, how much health or moves are left, etc.


-----

Based on above problem and chosen assignment, this repo consist of:

- Backend API built in .NET6 consists of `BoardGameController.cs` and `SaveGameController.cs`
- A Data repository called `SavedGameData.cs` which saves the player data to a dictionary and retriever player data from it.
- Board game data config in `BoardGameData.cs` which gets the info for each grid status.
- This also renders remaining health and moves data to the front end
