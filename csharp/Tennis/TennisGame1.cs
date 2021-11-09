// ReSharper disable ArrangeConstructorOrDestructorBody

// ReSharper disable ArgumentsStyleOther

namespace Tennis
{
    using System;
    using System.Collections.Specialized;


    internal sealed class Score
    {
        public Int32 Points { get; private set; }

        public void AddPoint ()
            =>
                    this.Points += 1;

        public override String ToString ()
            =>
                    this.Points switch {
                            0 => "Love",
                            1 => "Fifteen",
                            2 => "Thirty",
                            3 => "Forty",
                            _ => "",
                    };
    }


    internal sealed record Player(
            String Name,
            Score  Score );


    internal sealed class Players
    {
        private readonly IOrderedDictionary players = new OrderedDictionary();

        public Player this [ String playerName ]
            =>
                    this.players[playerName] as Player;

        public Player this [ Int32 playerNumber ]
            =>
                    this.players[playerNumber] as Player;

        public Players Add ( String playerName )
        {
            this.players.Add(
                    key: playerName,
                    value: new Player( Name: playerName, Score: new Score() ) );
            return this;
        }
    }


    internal sealed class TennisGame1 : ITennisGame
    {
        private readonly Players players = new();

        public TennisGame1 ( String player1Name, String player2Name )
            =>
                    this.players
                            .Add( player1Name )
                            .Add( player2Name );

        public void WonPoint ( String playerName )
            =>
                    this.players[playerName]
                            .Score.AddPoint();

        public String GetScore ()
            =>
                    this.Distance( this.players[0], this.players[1] ) switch {
                            0                            => this.players[0].Score.Points > 2 ? "Deuce" : $"{this.players[0].Score}-All",
                            1 when this.AreInAdvantage() => $"Advantage {this.GetPlayerInAdvantage().Name}",
                            _ when this.AreInAdvantage() => $"Win for {this.GetPlayerInAdvantage().Name}",
                            _                            => $"{this.players[0].Score}-{this.players[1].Score}",
                    };

        private Player GetPlayerInAdvantage () =>
                this.players[0].Score.Points > this.players[1].Score.Points
                        ? this.players[0]
                        : this.players[1];

        private Boolean AreInAdvantage ()
            =>
                    this.players[0].Score.Points >= 4
                    || this.players[1].Score.Points >= 4;

        private Int32 Distance (
                Player player1,
                Player player2 )
            =>
                    Math.Abs( player1.Score.Points - player2.Score.Points  );
    }
}
