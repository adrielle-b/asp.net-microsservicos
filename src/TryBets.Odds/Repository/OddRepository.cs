using TryBets.Odds.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Globalization;

namespace TryBets.Odds.Repository;

public class OddRepository : IOddRepository
{
    protected readonly ITryBetsContext _context;
    public OddRepository(ITryBetsContext context)
    {
        _context = context;
    }

    public Match Patch(int MatchId, int TeamId, string BetValue)
    {
        string BetValueConverted = BetValue.Replace(',', '.');
        decimal betValueDecimal = decimal.Parse(BetValueConverted, CultureInfo.InvariantCulture);

        Match findedMatch = _context.Matches.FirstOrDefault(m => m.MatchId == MatchId)!;
        if (findedMatch == null) throw new Exception("Match not founded");
        if (findedMatch.MatchTeamAId != TeamId && findedMatch.MatchTeamBId != TeamId ) throw new Exception("Team is not in this match");

        if (findedMatch.MatchTeamAId == TeamId) findedMatch.MatchTeamAValue += betValueDecimal;
        else findedMatch.MatchTeamBValue += betValueDecimal;
        _context.Matches.Update(findedMatch);
        _context.SaveChanges();

        return findedMatch;
    }
}