using DapperTest.Common.Interface.ApplicationService;
using DapperTest.Common.Interface.Repository;
using DapperTest.Common.Models.Teams;
using Unity;

namespace DapperTest.ApplicationService
{
    public class TeamApplicationService : ITeamApplicationService
    {
        private readonly ITeamRepository _teamRepository;

        [InjectionConstructor]
        public TeamApplicationService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public Team FindById(int id)
        {
            return _teamRepository.FindById(id).ConvertToTeam();
        }

        public Team FindByOwnerId(int id)
        {
            return _teamRepository.FindByOwnerId(id).ConvertToTeam();

        }
    }
}