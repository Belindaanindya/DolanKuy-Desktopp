using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Velacro.Api;
using Velacro.Basic;

namespace DolanKuyDesktopPalingbaru.ListWisata
{
    class ListWisataController : MyController
    {
        public ListWisataController(IMyView _myView) : base(_myView)
        {

        }

        public async void getLocation()
        {
            var client = new ApiClient("http://api.dolankuy.me/");
            var request = new ApiRequestBuilder();

            var req = request
                .buildHttpRequest()
                .setEndpoint("api/locations")
                .setRequestMethod(HttpMethod.Get);
            client.setOnSuccessRequest(setItem);
            var response = await client.sendRequest(request.getApiRequestBundle());
        }

        public async void deleteWisata(String id, String token)
        {
            var client = new ApiClient("http://api.dolankuy.me/");
            var request = new ApiRequestBuilder();

            var req = request
                .buildHttpRequest()
                .setEndpoint("api/locations/delete/" + id)
                .setRequestMethod(HttpMethod.Delete);
            client.setAuthorizationToken(token);
            client.setOnSuccessRequest(onDelete);
            var response = await client.sendRequest(request.getApiRequestBundle());
            
        }

        private void onDelete(HttpResponseBundle _response)
        {
            if (_response.getHttpResponseMessage().Content != null)
            {
                getView().callMethod("setDelete", _response.getHttpResponseMessage().ToString());
            }
        }

        private void setItem(HttpResponseBundle _response)
        {
            if (_response.getHttpResponseMessage().Content != null)
            {
                getView().callMethod("setLocation", _response.getParsedObject<RootLocation>().locations);
            }
        }
    }
}
