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


    internal class Player
    {
        private String name;

        public Player ( String name )
        {
            this.name = name;
            this.Score = new Score();
        }

        public Score Score { get; }
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
        {
            if (this.player1.Score.Points == this.player2.Score.Points)
                return this.player1.Score.Points switch {
                        >2 => "Deuce",
                        _  => $"{this.player1.Score}-All",
                };
            if (this.player1.Score.Points >= 4 || this.player2.Score.Points >= 4)
                return (this.player1.Score.Points - this.player2.Score.Points) switch {
                        1    => "Advantage player1",
                        -1   => "Advantage player2",
                        >= 2 => "Win for player1",
                        _    => "Win for player2",
                };
            return $"{this.player1.Score}-{this.player2.Score}";
        }
    }
}
