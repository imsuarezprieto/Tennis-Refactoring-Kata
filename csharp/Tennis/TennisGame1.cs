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

        public String GetScore () =>
                this.GetDifference() switch {
                        Difference.Equal     => this.player1.Score.Points > 2 ? "Deuce" : $"{this.player1.Score}-All",
                        Difference.Advantage => $"Advantage {this.GetPlayerNameInAdvantage()}",
                        Difference.Win       => $"Win for {this.GetPlayerNameInAdvantage()}",
                        _                    => $"{this.player1.Score}-{this.player2.Score}",
                };

        public String GetPlayerNameInAdvantage () =>
                this.player1.Score.Points > this.player2.Score.Points
                        ? this.player1.Name
                        : this.player2.Name;

        private Difference GetDifference ()
        {
            if (this.player1.Score.Points == this.player2.Score.Points) {
                return Difference.Equal;
            }
            if (this.player1.Score.Points >= 4 || this.player2.Score.Points >= 4) {
                return Math.Abs( this.player1.Score.Points - this.player2.Score.Points  ) == 1 ? Difference.Advantage : Difference.Win;
            }
            return Difference.None;
        }


        private enum Difference
        {
            Equal,
            Advantage,
            Win,
            None,
        }
    }
}
