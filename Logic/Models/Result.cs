namespace Logic.Models;

public class Result
{
    private int _id;
    private int _userId;
    private int _matchId;
    private int _matchResult;

    public int Id { get => _id; }
    public int UserId => _userId;
    public int MatchId => _matchId;
    public int MatchResult => _matchResult;

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