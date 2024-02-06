namespace TryBets.Matches.DTO;
public class MatchDTOResponse
{
    public int matchId { get; set; }
    public DateTime matchDate { get; set; }
    public int matchTeamAId { get; set; }
    public int matchTeamBId { get; set; }
    public string? teamAName { get; set; } 
    public string? teamBName { get; set; } 
    public string? matchTeamAOdds { get; set; }
    public string? matchTeamBOdds { get; set; }
    public bool matchFinished { get; set; }
    public int? matchWinnerId { get; set; }
}