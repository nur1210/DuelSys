using Logic.DTOs;

namespace Logic.Models;

public class Badminton : Sport
{
    public Badminton(SportDTO sport) : base(sport)
    {
        MinPlayers = 4;
        MaxPlayers = 10;
    }

    public override TournamentLeaderboard GenerateTournamentLeaderBoard()
    {
        return new TournamentLeaderboard();
    }
}