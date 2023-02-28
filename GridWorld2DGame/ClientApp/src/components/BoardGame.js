import React, { Component } from 'react';
import axios from 'axios';

export class BoardGame extends Component {
    constructor(props) {
        super(props);

        this.state = {
            playerState: {
                playerId: 1,
                health: 200,
                moves: 450,
                row: 0,
                column: 0
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
                    playerId: response.data.PlayerId,
                    health: response.data.Health,
                    moves: response.data.Moves,
                    row: response.data.Row,
                    column: response.data.Column
                }
            });
        });
        axios.get('/boardgame/boardconfig').then((response) => {
            const boardConfig = response.data;
            const boardSize = 10;
            const board = [];

            // Create a random distribution of cell types
            const cellTypes = Object.keys(boardConfig);
            for (let i = 0; i < boardSize; i++) {
                const row = [];
                for (let j = 0; j < boardSize; j++) {
                    const randomIndex = Math.floor(Math.random() * cellTypes.length);
                    const randomCellType = cellTypes[randomIndex];
                    row.push(boardConfig[randomCellType]);
                }
                board.push(row);
            }

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

    handleMovePlayer = (tileType) => {
        const { playerState } = this.state;

        axios.post('/boardgame/move-player', tileType).then((response) => {
            this.setState({
                playerState: {
                    ...playerState,
                    health: playerState.health + response.data.Health,
                    moves: playerState.moves + response.data.Moves,
                }
            });
        });
    };

    renderGameBoard() {
        const { board, boardConfig } = this.state;
        const boardSize = board.length;

        // Generate a 2D grid of cells representing the game board
        const rows = [];
        for (let i = 0; i < boardSize; i++) {
            const row = [];
            for (let j = 0; j < boardSize; j++) {
                const cellTypeKeys = Object.keys(boardConfig);
                const randomIndex = Math.floor(Math.random() * cellTypeKeys.length);
                const randomCellType = cellTypeKeys[randomIndex];
                const cellType = boardConfig[randomCellType];
                const cellClass = `cell cell-${randomCellType.toLowerCase()}`;
                row.push(<div className={cellClass} key={`${i}-${j}`}></div>);
            }
            rows.push(<div className="row" key={i}>{row}</div>);
        }

        return <div className="game-board">{rows}</div>;
    }


    renderGameInfo() {
        const { playerState } = this.state;
        const isLow = (value) => value < 50;

        const movesClassName = `game-info-moves ${isLow(playerState.moves) ? 'game-info-moves-low' : ''}`;
        const healthClassName = `game-info-health ${isLow(playerState.health) ? 'game-info-health-low' : ''}`;

        return (
            <div className="game-info">
                <p className={movesClassName}>Moves remaining: {playerState.moves}</p>
                <p className={healthClassName}>Health remaining: {playerState.health}</p>
            </div>
        );
    }

    render() {
        const { playerState, isSaving, saveError, isLoading, loadError, boardConfig } = this.state;

        return (
            <div>
                {this.renderGameBoard()}
                {this.renderGameInfo()}
                <button className="button gameButton" onClick={this.handleSaveGame} disabled={isSaving}>
                    {isSaving ? 'Saving...' : 'Save Game'}
                </button>
                <button className="button gameButton" onClick={this.handleLoadGame} disabled={isLoading}>
                    {isLoading ? 'Loading...' : 'Resume Game'}
                </button>
                {saveError && <p>Error saving game: {saveError}</p>}
                {loadError && <p>Error loading game: {loadError}</p>}
            </div>
        );
    }

}