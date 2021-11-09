namespace Tennis
{
    using System;


    internal class Score
    {
        public Int32 Points { set; get; } = 0;
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
                this.player1.Score.Points += 1;
            }
            else {
                this.player2.Score.Points += 1;
            }
        }

        public String GetScore ()
        {
            var score     = "";
            var tempScore = 0;

            if (this.player1.Score.Points == this.player2.Score.Points) {
                switch (this.player1.Score.Points) {
                    case 0:
                        score = "Love-All";
                        break;
                    case 1:
                        score = "Fifteen-All";
                        break;
                    case 2:
                        score = "Thirty-All";
                        break;
                    default:
                        score = "Deuce";
                        break;
                }
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
                for (var i = 1; i < 3; i++) {
                    if (i == 1) {
                        tempScore = this.player1.Score.Points;
                    }
                    else {
                        score += "-";
                        tempScore = this.player2.Score.Points;
                    }

                    switch (tempScore) {
                        case 0:
                            score += "Love";
                            break;
                        case 1:
                            score += "Fifteen";
                            break;
                        case 2:
                            score += "Thirty";
                            break;
                        case 3:
                            score += "Forty";
                            break;
                    }
                }
            }

            return score;
        }
    }
}
