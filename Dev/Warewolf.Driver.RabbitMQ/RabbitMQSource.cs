﻿/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2019 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using RabbitMQ.Client;
using Warewolf.Streams;
using Warewolf.Triggers;

namespace Warewolf.Driver.RabbitMQ
{
    public class RabbitMQSource : IQueueConnectionFactory
    {
        private readonly ConnectionFactory _factory;

        public RabbitMQSource()
        {
            //TODO: Use a resource file configs here for Hostname, ect
            _factory = new ConnectionFactory() { HostName = "rsaklfsvrdev.dev2.local", UserName = "test", Password = "test" };
        }

        public IQueueConnection NewConnection(IStreamConfig config)
        {
            return new RabbitConnection(_factory.CreateConnection());
        }
    }
}
