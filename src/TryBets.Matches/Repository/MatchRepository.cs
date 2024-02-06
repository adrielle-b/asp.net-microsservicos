using Microsoft.EntityFrameworkCore;
using TryBets.Matches.DTO;

namespace TryBets.Matches.Repository;

public class MatchRepository : IMatchRepository
{
    protected readonly ITryBetsContext _context;
    public MatchRepository(ITryBetsContext context)
    {
        _context = context;
    }

    public IEnumerable<MatchDTOResponse> Get(bool matchFinished)
    {
        var matches = _context.Matches
            .Where(m => m.MatchFinished == matchFinished)
            .OrderBy(m => m.MatchId)
            .Select(m => new MatchDTOResponse
            {
                matchId = m.MatchId,
                matchDate = m.MatchDate,
                matchTeamAId = m.MatchTeamAId,
                matchTeamBId = m.MatchTeamBId,
                teamAName = m.MatchTeamA!.TeamName,
                teamBName = m.MatchTeamB!.TeamName,
                matchTeamAOdds = Math.Round((m.MatchTeamAValue + m.MatchTeamBValue)  / m.MatchTeamAValue, 2).ToString("###.##"),
                matchTeamBOdds = Math.Round((m.MatchTeamAValue + m.MatchTeamBValue)  / m.MatchTeamBValue, 2).ToString("###.##"),
                matchFinished = m.MatchFinished,
                matchWinnerId = m.MatchWinnerId
            }).ToList();

        return matches;
    }
}