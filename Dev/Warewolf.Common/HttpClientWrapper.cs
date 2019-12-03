/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2018 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/


using System;
using System.Net.Http;
using System.Threading.Tasks;
using Warewolf.Web;

namespace Warewolf
{
    public class HttpClientWrapper : IHttpClient
    {
        private bool _disposed = false;
        private HttpClient _httpClient;

        public bool HasCredentials { get; private set; }

        public HttpClientWrapper(HttpClient client, bool hasCredentials)
        {
            _httpClient = client;
            HasCredentials = hasCredentials;
        }

        public void Dispose()
        {   
            // Implement IDisposable.
            // Do not make this method virtual.
            // A derived class should not be able to override this method.
            this.Dispose(true);
            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SupressFinalize to
            // take this object off the finalization queue
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }

       
        protected virtual void Dispose(bool disposing)
        {
            // Dispose(bool disposing) executes in two distinct scenarios.
            // If disposing equals true, the method has been called directly
            // or indirectly by a user's code. Managed and unmanaged resources
            // can be disposed.
            // If disposing equals false, the method has been called by the
            // runtime from inside the finalizer and you should not reference
            // other objects. Only unmanaged resources can be disposed.

            if (!this._disposed)
            {
                _httpClient.Dispose();
                _httpClient = null;
                this._disposed = true;
            }
        }
            public Task<HttpResponseMessage> GetAsync(string url)
        {
            return _httpClient.GetAsync(url);
        }

        public Task<HttpResponseMessage> PostAsync(string url,string postData)
        {
            return _httpClient.PostAsync(url,new StringContent(postData));
        }

    }
}