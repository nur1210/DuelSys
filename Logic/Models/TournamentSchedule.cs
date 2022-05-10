namespace Logic.Models;

public class TournamentSchedule
{
    private int _matchId;
    private int _firstPlayerId;
    private int _secondPlayerId;

    public int MatchId { get => _matchId; set => _matchId = value; }
    public int FirstPlayerId { get => _firstPlayerId; set => _firstPlayerId = value; }
    public int SecondPlayerId { get => _secondPlayerId; set => _secondPlayerId = value; }
}