namespace Logic.Models;

public class Result
{
    private int _id;
    private int _userId;
    private string _matchResult;

    public int Id { get=>_id; set=>_id = value; }
    public int UserId { get=>_userId; set=>_userId = value; }
    public string MatchResult { get=> _matchResult; set=> _matchResult = value; }
}