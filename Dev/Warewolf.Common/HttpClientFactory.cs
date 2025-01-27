﻿/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2018 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/


using System;
using System.Net;
using System.Net.Http;
using Warewolf.Web;

namespace Warewolf.Common
{
    public interface IHttpClientFactory
    {
        IHttpClient New(Uri uri, string userName, string password);
        IHttpClient New(string url, string userName, string password);
    }

    public class HttpClientFactory : IHttpClientFactory
    {
        public IHttpClient New(Uri uri, string userName, string password)
        {
            var baseAddress = uri.GetLeftPart(UriPartial.Authority);
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.UseDefaultCredentials = true;
            var hasCredentials = false;
            if (!string.IsNullOrEmpty(userName))
            {
                httpClientHandler.UseDefaultCredentials = false;
                httpClientHandler.PreAuthenticate = true;
                var credential = new NetworkCredential();
                if (userName.Contains("\\"))
                {
                    var userNameParts = userName.Split('\\');
                    credential.Domain = userNameParts[0];
                    credential.UserName = userNameParts[1];
                }
                else
                {
                    credential.UserName = userName;
                }
                credential.Password = password;
                hasCredentials = true;
            }
            var client = new HttpClient(httpClientHandler)
            {
                BaseAddress = new Uri(baseAddress)
            };

            return new HttpClientWrapper(client, hasCredentials);
        }

        public IHttpClient New(string url, string userName, string password)
        {
            return New(new Uri(url), userName, password);
        }
    }
}
