import React, { Component } from 'react';
import axios from 'axios';

export class BoardGame extends Component {
    constructor(props) {
        super(props);

        this.state = {
            playerState: {
                PlayerId: 1,
                Health: 200,
                Moves: 450,
                Row: 0,
                Column: 0
            },
            isSaving: false,
            saveError: null,
            isLoading: false,
            loadError: null,
            boardConfig: [],
            savedGames: [],
            board: []
        };
    }

    componentDidMount() {
        axios.get('/boardgame/start-game').then((response) => {
            this.setState({
                playerState: {
                    PlayerId: response.data.PlayerId,
                    Health: response.data.Health,
                    Moves: response.data.Moves,
                    Row: response.data.Row,
                    Column: response.data.Column
                }
            });
        });
        axios.get('/boardgame/boardconfig').then((response) => {
            const boardConfig = response.data;
            const boardSize = 10;
            const board = Array.from({ length: boardSize }, () =>
                Array.from({ length: boardSize }, () =>
                    boardConfig.Blank));
            // set the state with the fetched board configuration and the created board
            this.setState({ boardConfig, board });
        });
    }

    // This method is called when the player clicks the "Save Game" button
    handleSaveGame = () => {
        this.setState({ isSaving: true, saveError: null });
        axios.post('/savegame/saved-games', this.state.playerState)
            .then(() => {
                this.setState({ isSaving: false });
                // display a success message to the player
            })
            .catch((error) => {
                this.setState({ isSaving: false, saveError: error.message });
                // Optional: display an error message to the player
            });
    };

    // This method is called when the player clicks the "Resume Game" button
    handleLoadGame = () => {
        this.setState({ isLoading: true, loadError: null });
        axios.get(`/savegame/saved-games/${this.state.playerState.PlayerId}`)
            .then((response) => {
                const playerState = response.data;
                this.setState({ playerState, isLoading: false });
            })
            .catch((error) => {
                this.setState({ isLoading: false, loadError: error.message });
                // Optional: display an error message to the player
            });
    };

    renderGameBoard(boardConfig) {
        // Generate the game board UI based on this.state.playerState
        const { board } = this.state;
        const boardSize = board.length;

        // Generate a grid of cells representing the game board
        const grid = [];
        for (let i = 0; i < boardSize; i++) {
            for (let j = 0; j < boardSize; j++) {
                const cellType = board[i][j];
                const cellClass = `cell ${cellType.toLowerCase()} ${boardConfig[cellType].cssClass}`;
                grid.push(<div className={cellClass} key={`${i}-${j}`}></div>);
            }
        }

        const containerStyle = {
            gridTemplateColumns: `repeat(${boardSize}, 1fr)`,
            gridTemplateRows: `repeat(${boardSize}, 1fr)`,
        };

        return <div className="game-board" style={containerStyle}>{grid}</div>;
    };


    renderGameInfo(playerState) {
        // Generate the game info UI based on this.state.playerState
        const movesClassName = `game-info-moves ${playerState.Moves < 50 ? 'game-info-moves-low' : ''}`;
        const healthClassName = `game-info-health ${playerState.Health < 50 ? 'game-info-health-low' : ''}`;

        return (
            <div className="game-info">
                <p className={movesClassName}>Moves remaining: {playerState.Moves}</p>
                <p className={healthClassName}>Health remaining: {playerState.Health}</p>
            </div>
        );
    }

    render() {
        const { playerState, isSaving, saveError, isLoading, loadError, boardConfig } = this.state;

        return (
            <div>
                {this.renderGameBoard(boardConfig)}
                {this.renderGameInfo(playerState)}
                <button className="button gameButton" onClick={this.handleSaveGame} disabled={isSaving}>
                    {isSaving ? 'Saving...' : 'Save Game'}
                </button>
                <button className="button gameButton"  onClick={this.handleLoadGame} disabled={isLoading}>
                    {isLoading ? 'Loading...' : 'Resume Game'}
                </button>
                {saveError && <p>Error saving game: {saveError}</p>}
                {loadError && <p>Error loading game: {loadError}</p>}
            </div>
        );
    }
}