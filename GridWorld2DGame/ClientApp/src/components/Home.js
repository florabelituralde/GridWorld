import React, { Component } from 'react';

export class Home extends Component {
    static displayName = Home.name;

    render() {
        return (
            <div>
                <h1>Hello!</h1>
                <p>This GridWorld application is built with:</p>
                <ul>
                    <li><a href='https://get.asp.net/'>ASP.NET Core</a> and <a href='https://msdn.microsoft.com/en-us/library/67ef8sbd.aspx'>C#</a> for cross-platform server-side code</li>
                    <li><a href='https://facebook.github.io/react/'>React</a> for client-side code</li>
                    <li><a href='http://getbootstrap.com/'>Bootstrap</a> for layout and styling</li>
                </ul>
                <p>To help you get started:</p>
                <ul>
                    <li>Click <em>BoardGame</em> to launch the boardgame.</li>
                    <li>Each player starts with Health: 200 and Moves: 450</li>
                    <li>Roll the dice to start the game and avoid the obstacles.</li>
                    <li>Each obstacle will affect your moves and health as follows: </li>
                    <ul>
                        <li>Blank = Health: 0, Moves: -1</li>
                        <li>Speeder = Health: -5, Moves: 0</li>
                        <li>Lava = Health: -50, Moves: -10</li>
                        <li>Mud = Health: -10, Moves: -5</li>
                    </ul>
                </ul>
            </div>
        );
    }
}
