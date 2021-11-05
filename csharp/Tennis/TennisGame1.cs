namespace Tennis
{
    using System;


    internal class Player1
    {

        private Int32 m_score1  ;
        private String player1Name;


        public Player1 (String player1Name)
        {
            this.player1Name = player1Name;
        }


        public Int32 MScore1 {
            set { this.m_score1 = value; }
            get { return this.m_score1; }
        }

    }


    internal class Player2
    {

        private Int32 _mScore1  ;
        private String player2Name;


        public Player2 (String player2Name)
        {
            this.player2Name = player2Name;
        }


        public Int32 MScore1 {
            set { this._mScore1 = value; }
            get { return this._mScore1; }
        }

    }


    internal class TennisGame1 : ITennisGame
    {

        private readonly Player1 player1;
        private readonly Player2 player2;


        public TennisGame1 (String player1Name, String player2Name)
        {
            this.player1 = new Player1( player1Name );
            this.player2 = new Player2( player2Name );
        }


        public void WonPoint (String playerName)
        {
            if (playerName == "player1") {
                this.player1.MScore1 += 1;
            }
            else {
                this.player2.MScore1 += 1;
            }
        }


        public String GetScore ()
        {
            var score     = "";
            var tempScore = 0;

            if (this.player1.MScore1 == this.player2.MScore1) {
                switch (this.player1.MScore1) {
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
            else if (this.player1.MScore1 >= 4 || this.player2.MScore1 >= 4) {
                Int32 minusResult = this.player1.MScore1 - this.player2.MScore1;

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
                        tempScore = this.player1.MScore1;
                    }
                    else {
                        score += "-";
                        tempScore = this.player2.MScore1;
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
