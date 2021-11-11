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
        private readonly Player3 player1;
        private readonly Player3 player2;

        public TennisGame3 ( String player1Name, String player2Name )
        {
            this.player1 = new Player3( player1Name );
            this.player2 = new Player3( player2Name );
        }

        public String GetScore ()
        {
            String s;
            if (!this.AreOnePlayerInAdvantage()) {
                String[] p = { "Love", "Fifteen", "Thirty", "Forty" };
                s = p[this.player1.points];
                return this.player1.points == this.player2.points ? s + "-All" : s + "-" + p[this.player2.points];
            }
            if (this.player1.points == this.player2.points) {
                return "Deuce";
            }
            return this.Difference() * this.Difference() == 1
                    ? "Advantage " + this.AdvantagePlayerName()
                    : "Win for " + this.AdvantagePlayerName();
        }

        public void WonPoint ( String playerName )
        {
            if (playerName == "player1") {
                this.player1.AddPoint();
            }
            else {
                this.player2.AddPoint();
            }
        }

        private Boolean AreOnePlayerInAdvantage ()
            =>
                    this.player1.points >= 4
                    || this.player2.points >= 4
                    || this.player1.points + this.player2.points >= 6;

        private String AdvantagePlayerName ()
            =>
                    this.player1.points > this.player2.points
                            ? this.player1.name
                            : this.player2.name;

        private Int32 Difference ()
            =>
                    this.player1.points - this.player2.points;
    }
}
