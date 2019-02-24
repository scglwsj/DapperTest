using DapperTest.Common.Models.Teams;

namespace DapperTest.Common.Interface.Repository
{
    public interface ITeamRepository
    {
        TeamDo FindById(int id);
        TeamDo FindByOwnerId(int id);
    }
}