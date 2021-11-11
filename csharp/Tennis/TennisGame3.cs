namespace Tennis
{
    using System;


    internal record Player3(
            String name )
    {
        public Int32 points { get; private set;  }

        public void AddPoint ()
            => this.points += 1;
    }


    public class TennisGame3 : ITennisGame
    {
        private readonly String p1N;
        private readonly String p2N;
        private Int32 p1;
        private Int32 p2;

        public TennisGame3 ( String player1Name, String player2Name )
        {
            this.p1N = player1Name;
            this.p2N = player2Name;
        }

        public String GetScore ()
        {
            String s;
            if (this.p1 < 4 && this.p2 < 4 && this.p1 + this.p2 < 6) {
                String[] p = { "Love", "Fifteen", "Thirty", "Forty" };
                s = p[this.p1];
                return this.p1 == this.p2 ? s + "-All" : s + "-" + p[this.p2];
            }
            if (this.p1 == this.p2) {
                return "Deuce";
            }
            s = this.p1 > this.p2 ? this.p1N : this.p2N;
            return this.Difference() * this.Difference() == 1 ? "Advantage " + s : "Win for " + s;
        }

        public void WonPoint ( String playerName )
        {
            if (playerName == "player1") {
                this.p1 += 1;
            }
            else {
                this.p2 += 1;
            }
        }

        private Int32 Difference () => this.p1 - this.p2;
    }
}
