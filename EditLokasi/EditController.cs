using DolanKuyDesktopPalingbaru.Kategori;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Velacro.Api;
using Velacro.Basic;

namespace DolanKuyDesktopPalingbaru.EditLokasi
{
    public class EditController : MyController
    {
        private String token;

        public EditController(IMyView _myView) : base(_myView)
        {
            //this.editPage = editPage;
        }

        public async void editLocation(
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
            MyList<string> fileKey = new MyList<string>() { "image" };
            MyList<MyFile> file = new MyList<MyFile>() { newImage };
            this.token = _token;



            var client = new ApiClient("http://api.dolankuy.me/api/");

            var req = new ApiRequestBuilder()
                .buildHttpRequest()
                .addParameters("name", _name)
                .addParameters("address", _address)
                .addParameters("description", _description)
                .addParameters("contact", _contact)
                .addParameters("latitude", _latitude)
                .addParameters("longitude", _longitude)
                .setRequestMethod(HttpMethod.Post)
                .setEndpoint("locations/update/" + _id);
            client.setAuthorizationToken(_token);
            if (newImage == null)
            {
                client.setOnSuccessRequest(setViewStatus);
            }
            var response = await client.sendRequest(req.getApiRequestBundle());


            if (newImage != null)
            {
                MultiPartContent multiPartContent1 = new MultiPartContent(file, fileKey);
                var req2 = new ApiRequestBuilder()
               .buildMultipartRequest(multiPartContent1)
               .setRequestMethod(HttpMethod.Post)
               .setEndpoint("locations/update/" + _id);
                client.setAuthorizationToken(_token);
                client.setOnSuccessRequest(setViewStatus);
                var response2 = await client.sendRequest(req2.getApiRequestBundle());
            }



        }

        private void setViewStatus(HttpResponseBundle _response)
        {



            if (_response.getHttpResponseMessage().Content != null)
            {
                string status = _response.getHttpResponseMessage().ReasonPhrase;
                getView().callMethod("setEditStatus", this.token);
            }

        }
    }
}
