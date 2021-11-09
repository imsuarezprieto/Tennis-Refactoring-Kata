namespace Tennis
{
    using System;


    internal class Score
    {
        public Int32 Points { get; private set; }

        public void AddPoint () =>
                this.Points += 1;

        public override String ToString () =>
                this.Points switch {
                        0 => "Love",
                        1 => "Fifteen",
                        2 => "Thirty",
                        3 => "Forty",
                        _ => "",
                };
    }


    internal sealed record Player(
            String Name )
    {
        public Score Score { get; init; } = new();
    }


    internal class TennisGame1 : ITennisGame
    {
        private readonly Player player1;
        private readonly Player player2;

        public TennisGame1 ( String player1Name, String player2Name )
        {
            this.player1 = new Player( player1Name );
            this.player2 = new Player( player2Name );
        }

        public void WonPoint ( String playerName )
        {
            if (playerName == "player1") {
                this.player1.Score.AddPoint();
            }
            else {
                this.player2.Score.AddPoint();
            }
        }

        public String GetScore ()
            =>
                    this.Distance( score1: this.player1.Score.Points, score2: this.player2.Score.Points ) switch {
                            0                            => this.player1.Score.Points > 2 ? "Deuce" : $"{this.player1.Score}-All",
                            1 when this.AreInAdvantage() => $"Advantage {this.GetPlayerNameInAdvantage()}",
                            _ when this.AreInAdvantage() => $"Win for {this.GetPlayerNameInAdvantage()}",
                            _                            => $"{this.player1.Score}-{this.player2.Score}",
                    };

        private String GetPlayerNameInAdvantage () =>
                this.player1.Score.Points > this.player2.Score.Points
                        ? this.player1.Name
                        : this.player2.Name;

        private Boolean AreInAdvantage () =>
                this.player1.Score.Points >= 4 || this.player2.Score.Points >= 4;

        private Int32 Distance (
                Int32 score1,
                Int32 score2 )
            =>
                    Math.Abs( score1 - score2  );
    }
}
