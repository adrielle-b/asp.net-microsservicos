using TryBets.Matches.DTO;

namespace TryBets.Matches.Repository;

public class TeamRepository : ITeamRepository
{
    protected readonly ITryBetsContext _context;
    public TeamRepository(ITryBetsContext context)
    {
        _context = context;
    }

    public IEnumerable<TeamDTOResponse> Get()
    {
        var teams = _context.Teams
            .Select(t => new TeamDTOResponse
            {
                teamId = t.TeamId,
                teamName = t.TeamName
            }).ToList();

        return teams;
    }
}