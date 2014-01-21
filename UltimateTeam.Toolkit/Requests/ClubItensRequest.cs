using System.Net.Http;
using System.Threading.Tasks;
using UltimateTeam.Toolkit.Constants;
using UltimateTeam.Toolkit.Extensions;
using UltimateTeam.Toolkit.Models;
using UltimateTeam.Toolkit.Parameters;

namespace UltimateTeam.Toolkit.Requests
{
    internal class ClubItensRequest : FutRequestBase, IFutRequest<ClubItensResponse>
    {
        private readonly ClubItemSearchParameters _clubItemSearchParameters;

        public ClubItensRequest(ClubItemSearchParameters clubItemSearchParameters)
        {
            clubItemSearchParameters.ThrowIfNullArgument();
            _clubItemSearchParameters = clubItemSearchParameters;
        }

        public async Task<ClubItensResponse> PerformRequestAsync()
        {
            //var uriString = string.Format(Resources.FutHome + Resources.TransferMarket + "?start={0}&num={1}",
            //    (_searchParameters.Page - 1) * _searchParameters.PageSize, _searchParameters.PageSize + 1);
            //_searchParameters.BuildUriString(ref uriString);

            //var ClubItens = "club?start=0&count=20&type={0}&level=10";

            var uriString = string.Format(Resources.FutHome + Resources.ClubItens + "?start={0}&count={1}",
                (_clubItemSearchParameters.Page - 1) * _clubItemSearchParameters.PageSize, _clubItemSearchParameters.PageSize); 
            _clubItemSearchParameters.BuildUriString(ref uriString);

            AddMethodOverrideHeader(HttpMethod.Get);
            AddCommonHeaders();
            var clubItensResponseMessage = await HttpClient
                .GetAsync(uriString)
                .ConfigureAwait(false);

            return await Deserialize<ClubItensResponse>(clubItensResponseMessage);
        }
    }
}