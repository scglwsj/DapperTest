using DapperTest.Common.Models.Teams;

namespace DapperTest.Common.Interface.ApplicationService
{
    public interface ITeamApplicationService
    {
        Team FindById(int id);
        Team FindByOwnerId(int id);
    }
}