using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Velacro.Api;
using Velacro.Basic;

namespace DolanKuyDesktopPalingbaru.CreateLokasi
{
    public class CreateController : MyController
    {
        String token;

        public CreateController(IMyView _myView) : base(_myView) { }


        public async void create(
            string _name,
            string _description,
            string _address,
            string _contact,
            String _latitude,
            String _longitude,
            String _id,
            string _token,
            MyFile newImage
        )
        {
            MyList<string> fileKey = new MyList<string>() {"image"};
            MyList<MyFile> file = new MyList<MyFile>() {newImage};
            this.token = _token;

            MultiPartContent multiPartContent1 = new MultiPartContent(file, fileKey);
            var client = new ApiClient("http://127.0.0.1:8000/api/");

            var req = new ApiRequestBuilder()
                //.buildMultipartRequest(multiPartContent1)
                .buildHttpRequest()
                .addParameters("category_id", _id)
                .addParameters("name", _name)
                .addParameters("address", _address)
                .addParameters("description", _description)
                .addParameters("contact", _contact)
                .addParameters("latitude", _latitude)
                .addParameters("longitude", _longitude)
                .setRequestMethod(HttpMethod.Post)
                .setEndpoint("locations/create");
            client.setAuthorizationToken(_token);
            var response = await client.sendRequest(req.getApiRequestBundle());

            var req2 = new ApiRequestBuilder()
                .buildMultipartRequest(multiPartContent1)
                .setRequestMethod(HttpMethod.Post)
                .setEndpoint("locations/update/"+ response.getJObject()["id"].ToString());
            client.setAuthorizationToken(_token);
            client.setOnSuccessRequest(setViewRegisterStatus);
            var response2 = await client.sendRequest(req2.getApiRequestBundle());

        }

        private void setViewRegisterStatus(HttpResponseBundle _response)
        {



            if (_response.getHttpResponseMessage().Content != null)
            {
                string status = _response.getHttpResponseMessage().ReasonPhrase;
                getView().callMethod("setRegisterStatus", this.token);
            }

        }


    }
}
