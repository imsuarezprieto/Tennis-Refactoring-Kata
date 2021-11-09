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
            var score = "";

            if (this.player1.Score.Points == this.player2.Score.Points) {
                score = this.player1.Score.Points switch {
                        >2 => "Deuce",
                        _  => $"{this.player1.Score}-All",
                };
            }
            else if (this.player1.Score.Points >= 4 || this.player2.Score.Points >= 4) {
                Int32 minusResult = this.player1.Score.Points - this.player2.Score.Points;

                if (minusResult == 1) {
                    score = "Advantage player1";
                }
                else if (minusResult == -1) {
                    score = "Advantage player2";
                }
                else if (minusResult >= 2) {
                    score = "Win for player1";
                }
                else {
                    score = "Win for player2";
                }
            }
            else {
                score = $"{this.player1.Score}-{this.player2.Score}";
            }

            return score;
        }
    }
}
