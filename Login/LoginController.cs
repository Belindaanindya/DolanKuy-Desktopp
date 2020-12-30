using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Velacro.Api;
using Velacro.Basic;

namespace DolanKuyDesktopPalingbaru.Login
{
    public class LoginController : MyController
    {

        public LoginController(IMyView _myView) : base(_myView)
        {

        }

        public async void login(string _email, string _password)
        {
            var client = new ApiClient("http://127.0.0.1:8000/api/");
            var request = new ApiRequestBuilder();

            var req = request
                .buildHttpRequest()
                .addParameters("email", _email)
                .addParameters("password", _password)
                .setEndpoint("login")
                .setRequestMethod(HttpMethod.Post);
            client.setOnSuccessRequest(setViewLoginStatus);
            var response = await client.sendRequest(request.getApiRequestBundle());
            Console.WriteLine(response.getJObject()["token"]);
            client.setAuthorizationToken(response.getJObject()["token"].ToString());
        }

        private void setViewLoginStatus(HttpResponseBundle _response)
        {
            if (_response.getHttpResponseMessage().Content != null)
            {

                string status = _response.getJObject()["token"].ToString();
                getView().callMethod("setLoginStatus", status);


            }

        }
    }
}
