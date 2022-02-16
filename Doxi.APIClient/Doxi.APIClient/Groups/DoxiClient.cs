using Consist.Doxi.Domain.Models;
using Consist.Doxi.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Doxi.APIClient
{
    public partial class DoxiClient 
    {
        public Task<List<GetGroupsResponseWithUsersKeys>> GetGroups(ParticipantKey<ParticipantKeyType> userKey)
        {
            throw new System.NotImplementedException();
        }

    }
}
