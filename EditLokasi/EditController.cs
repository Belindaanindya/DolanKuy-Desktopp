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
        //private EditPage editPage;

        public EditController(IMyView _myView) : base(_myView)
        {
            //this.editPage = editPage;
        }

        //revisi backend
        public async void getCategory()
        {
            var client = new ApiClient("http://127.0.0.1:8000/");
            var request = new ApiRequestBuilder();

            var req = request
                .buildHttpRequest()
                .setEndpoint("api/category")
                .setRequestMethod(HttpMethod.Get);
            client.setOnSuccessRequest(setItem);
            var response = await client.sendRequest(request.getApiRequestBundle());
        }

        //Update
        public async void putCategory(String _categoryName, int _categoryId)
        {
            var client = new ApiClient("http://127.0.0.1:8000/");
            var request = new ApiRequestBuilder();

            var req = request
                .buildHttpRequest()
                .addParameters("name", _categoryName)
                .setEndpoint("api/category/update/" + _categoryId)
                .setRequestMethod(HttpMethod.Put);
            client.setOnSuccessRequest(setItem);
            var response = await client.sendRequest(request.getApiRequestBundle());
        }

        private void setItem(HttpResponseBundle _response)
        {
            if (_response.getHttpResponseMessage().Content != null)
            {

                if (_response.getParsedObject<RootCategory>().category != null)
                {

                    getView().callMethod("setCategory", _response.getParsedObject<RootCategory>().category);

                }
                else
                {
                    getView().callMethod("setCategory", new List<ModelCategory>());
                }
            }
        }
    }
}
