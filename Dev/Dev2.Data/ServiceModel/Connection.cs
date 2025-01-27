#pragma warning disable
/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2019 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using Dev2.Common.Common;
using Dev2.Common.Interfaces;
using Dev2.Common.Interfaces.Core.DynamicServices;
using Dev2.Runtime.ServiceModel.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Linq;
using System.Xml.Linq;
using Warewolf.Security.Encryption;

namespace Dev2.Data.ServiceModel
{
    public class Connection : Resource, IConnection
    {
        static readonly int DefaultWebServerPort = 3142;

        public string Address { get; set; }

        [JsonIgnore]
        public string WebAddress
        {
            get
            {
                var address = new UriBuilder(Address) { Port = WebServerPort, Path = string.Empty };
                return address.ToString();
            }
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public AuthenticationType AuthenticationType { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
        public int WebServerPort { get; set; }

        public Connection()
        {
            ResourceType = enSourceType.Dev2Server.ToString();
            VersionInfo = new VersionInfo();
        }

        public Connection(XElement xml)
            : base(xml)
        {
            ResourceType = enSourceType.Dev2Server.ToString();

            var conString = xml.AttributeSafe("ConnectionString");
            var connectionString = conString.CanBeDecrypted() ? DpapiWrapper.Decrypt(conString) : conString;
            var props = connectionString.Split(';');
            foreach (var p in props.Select(prop => prop.Split('=')).Where(p => p.Length >= 1))
            {
                switch (p[0].ToLowerInvariant())
                {
                    case "appserveruri":
                        Address = p[1];
                        break;
                    case "webserverport":
                        int port;
                        WebServerPort = Int32.TryParse(p[1], out port) ? port : DefaultWebServerPort;
                        break;
                    case "authenticationtype":
                        AuthenticationType authType;
                        AuthenticationType = Enum.TryParse(p[1], true, out authType) ? authType : AuthenticationType.Windows;
                        break;
                    case "username":
                        UserName = p[1];
                        break;
                    case "password":
                        Password = p[1];
                        break;
                    default:
                        break;
                }
            }
        }

        public String FetchTestConnectionAddress()
        {
            var result = Address;

            if (result?.IndexOf("dsf", StringComparison.Ordinal) < 0)
            {
                result += result.EndsWith("/") ? "dsf" : "/dsf";

            }

            return result;
        }

        public override XElement ToXml()
        {
            var result = base.ToXml();
            var connectionString = string.Join(";",
                $"AppServerUri={Address}",
                $"WebServerPort={WebServerPort}",
                $"AuthenticationType={AuthenticationType}"
                );
            if (AuthenticationType == AuthenticationType.User)
            {
                connectionString = string.Join(";",
                    connectionString,
                    $"UserName={UserName}",
                    $"Password={Password}"
                    );
            }

            result.Add(
                new XAttribute("ConnectionString", DpapiWrapper.Encrypt(connectionString)),
                new XAttribute("Type", GetType().Name),
                new XElement("TypeOf", enSourceType.Dev2Server)
                );

            return result;
        }

        public override bool IsSource => false;
        public override bool IsService => false;
        public override bool IsFolder => false;
        public override bool IsReservedService => false;
        public override bool IsServer => true;
        public override bool IsResourceVersion => false;

        protected bool Equals(Connection other)
        {
            return base.Equals(other) &&
                 string.Equals(Address, other.Address) &&
                 AuthenticationType == other.AuthenticationType &&
                 string.Equals(UserName, other.UserName) &&
                 string.Equals(Password, other.Password) &&
                 WebServerPort == other.WebServerPort;
        }

        public override bool Equals(object obj)
        {
            if (obj is Connection connection)
            {
                return this.Equals(connection);

            }
            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = base.GetHashCode();
                hashCode = (hashCode * 397) ^ (Address != null ? Address.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int)AuthenticationType;
                hashCode = (hashCode * 397) ^ (UserName != null ? UserName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Password != null ? Password.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ WebServerPort;
                return hashCode;
            }
        }
    }
}
