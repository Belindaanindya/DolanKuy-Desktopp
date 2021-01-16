using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Velacro.Api;
using Velacro.Basic;

namespace DolanKuyDesktopPalingbaru.Dashboard
{
    public class DashboardController : MyController
    {
        private String token;
        public DashboardController(IMyView _myView) : base(_myView) { }

        public async void logout(string _token)
        {
            var client = new ApiClient("http://api.dolankuy.me/");
            var request = new ApiRequestBuilder();
            this.token = _token;
            var req = request
                .buildHttpRequest()
                .setEndpoint("api/logout")
                .setRequestMethod(HttpMethod.Post);
            client.setAuthorizationToken(_token);
            client.setOnSuccessRequest(setViewStatus);
            var response = await client.sendRequest(request.getApiRequestBundle());

        }

        private void setViewStatus(HttpResponseBundle _response)
        {
            if (_response.getHttpResponseMessage().Content != null)
            {
                string status = _response.getHttpResponseMessage().ReasonPhrase;
                getView().callMethod("setLogoutStatus");
            }
        }

    }
}
