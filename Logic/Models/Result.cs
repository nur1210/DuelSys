namespace Logic.Models;

public class Result
{
    private int _id;
    private int _userId;
    private int _matchId;
    private int _matchResult;

    public int Id { get => _id; }
    public int UserId { get => _userId; set => _userId = value; }
    public int MatchId { get => _matchId; set => _matchId = value; }
    public int MatchResult { get => _matchResult; set => _matchResult = value; }

    public Result(int userId, int matchId, int matchResult)
    {
        _userId = userId;
        _matchId = matchId;
        _matchResult = matchResult;
    }

    public Result(int id, int userId, int matchId, int matchResult)
    {
        _id = id;
        _userId = userId;
        _matchId = matchId;
        _matchResult = matchResult;
    }
}