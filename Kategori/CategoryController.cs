using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Velacro.Api;
using Velacro.Basic;

namespace DolanKuyDesktopPalingbaru.Kategori
{
    public class CategoryController : MyController
    {
        private String token;
        public CategoryController(IMyView _myView) : base(_myView)
        {

        }

        public async void editCategory(string _name, string _token, String id)
        {
            var client = new ApiClient("http://api.dolankuy.me/");
            var request = new ApiRequestBuilder();
            this.token = _token;
            //string token = "";
            var req = request
                .buildHttpRequest()
                .addParameters("name", _name)
                .setEndpoint("api/category/update/" + id)
                .setRequestMethod(HttpMethod.Put);
            client.setAuthorizationToken(_token);
            client.setOnSuccessRequest(setViewCategoryStatus);
            var response = await client.sendRequest(request.getApiRequestBundle());

        }

        public async void getCategory()
        {
            var client = new ApiClient("http://api.dolankuy.me/");
            var request = new ApiRequestBuilder();

            var req = request
                .buildHttpRequest()
                .setEndpoint("api/category")
                .setRequestMethod(HttpMethod.Get);
            client.setOnSuccessRequest(setItem);
            var response = await client.sendRequest(request.getApiRequestBundle());
        }

        private void setItem(HttpResponseBundle _response)
        {
            if (_response.getHttpResponseMessage().Content != null)
            {
                getView().callMethod("setCategory", _response.getParsedObject<RootCategory>().category);
            }
        }

        public async void deleteCategory(String id, String token)
        {
            var client = new ApiClient("http://api.dolankuy.me/");
            var request = new ApiRequestBuilder();

            var req = request
                .buildHttpRequest()
                .setEndpoint("api/category/delete/" + id)
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

        public async void postCategory(string _name, string _token)
        {
            var client = new ApiClient("http://api.dolankuy.me/");
            var request = new ApiRequestBuilder();
            this.token = _token;
            //string token = "";
            var req = request
                .buildHttpRequest()
                .addParameters("name", _name)
                .setEndpoint("api/category/create")
                .setRequestMethod(HttpMethod.Post);
            client.setAuthorizationToken(_token);
            client.setOnSuccessRequest(setViewCategoryStatus);
            var response = await client.sendRequest(request.getApiRequestBundle());

        }

        private void setViewCategoryStatus(HttpResponseBundle _response)
        {
            if (_response.getHttpResponseMessage().Content != null)
            {
                string status = _response.getHttpResponseMessage().ReasonPhrase;
                getView().callMethod("setCategoryStatus", this.token);
            }
        }
    }
}
