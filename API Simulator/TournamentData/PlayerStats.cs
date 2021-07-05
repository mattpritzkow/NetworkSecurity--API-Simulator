using API_Simulator.Extensions;
using System;
using System.Threading;

namespace API_Simulator.TournamentData
{
    public class PlayerStats
    {
        public int Kills { get; set; }
        public int MedalXP
        {
            get
            {
                return 100;
            }
        }
        public int ObjectiveTeamWiped { get; set; }
        public int ObjectiveLastStandKill { get; set; }
        public int MatchXp { get; set; }
        public int ScoreXp { get; set; }
        public int WallBangs { get; set; }
        public int Score { get; set; }
        public int TotalXp
        {
            get
            {
                return this.ScoreXp + this.MatchXp;
            }
        }
        public int Headshots { get; set; }
        public int Assists { get; set; }
        public int ChallengeXp { get; set; }
        public int Rank { get; set; }
        public double ScorePerMinute
        {
            get
            {
                if (TimePlayed == 0) 
                {
                    return Score;
                }
                return Score / TimePlayed;
            }
        }
        public double DistanceTravelled { get; set; }
        public int TeamSurvivalTime { get; set; }
        public int Deaths { get; set; }
        public double KdRatio
        {
            get
            {
                if (Deaths == 0)
                {
                    return Kills;
                }
                return Kills / Deaths;
            }
        }
        public int BonusXp
        {
            get
            {
                return 0;
            }
        }
        public int GulagDeaths { get; set; }
        public int TimePlayed { get; set; }
        public int Executions { get; set; }
        public int GulagKills { get; set; }
        public int NearMisses
        {
            get
            {
                return 0;
            }
        }
        public double PercentTimeMoving { get; set; }
        public int MiscXp
        {
            get
            {
                return 0;
            }
        }
        public int LongestStreak { get; set; }
        public int TeamPlacement { get; set; }
        public int DamageDone { get; set; }
        public int DamageTaken { get; set; }

        public PlayerStats(Random random)
        {
            Kills = random.Next(15);
            if (Kills > 3)
            {
                ObjectiveTeamWiped = random.NextGaussian(1);
                ObjectiveLastStandKill = random.NextGaussian(2);
                WallBangs = random.NextGaussian(1);
                Executions = random.NextGaussian(1);
            }
            MatchXp = (Kills * 3000) + random.NextGaussian(500);
            ScoreXp = (Kills * 1000) + random.NextGaussian(1000);
            Score = (Kills * 1000) + random.NextGaussian(250);
            Headshots = random.Next(Kills);
            Assists = random.NextGaussian(4);
            //TODO: Change this?
            ChallengeXp = 0;
            //TODO: Base on kills somehow
            Rank = random.Next(150);
            DistanceTravelled = (1 + Kills) * Score * 10;
            TeamSurvivalTime = random.Next(1, 2000000);
            Deaths = random.NextGaussian(2);
            GulagDeaths = random.NextGaussian(2);
            TimePlayed = Score / 5;
            if (Kills > 0 && Deaths > 0)
            {
                GulagKills = random.NextGaussian(Kills / 2);
            }
            PercentTimeMoving = random.NextDouble() * 100;
            if (PercentTimeMoving < 50)
            {
                PercentTimeMoving += 50;
            }
            LongestStreak = random.Next(Kills);
            //TODO: Improve this, dear god.
            TeamPlacement = random.Next(30);
            DamageDone = random.Next(50, 2000) * Kills;
            //Big shoulderman gets 0 here.
            DamageTaken = random.Next(DamageDone / 4, DamageDone);

        }
    }
}
