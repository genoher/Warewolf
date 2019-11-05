﻿/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2019 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System;
using System.Collections.Generic;
using Warewolf.Interfaces;

namespace Warewolf.Driver.Redis
{
    public abstract class RedisCacheBase
    {
        readonly Lazy<IRedisConnection> _connection;

        protected RedisCacheBase(Func<IRedisConnection> createConnection)
        {
            if (createConnection is null) throw new ArgumentNullException(nameof(createConnection));
            _connection = new Lazy<IRedisConnection>(() => createConnection?.Invoke());
        }
       
        private IRedisCache Cache => _connection.Value.Cache;

        public void Set(string key, IDictionary<string, string> dictionary, TimeSpan timeSpan)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));
            Cache.Set(key, dictionary, timeSpan);
        }

        public IDictionary<string,string> Get(string key)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));
            return Cache.Get(key);
        }
    }

    public class RedisCacheImpl : RedisCacheBase
    {
        public RedisCacheImpl(string hostName) : this(() => new RedisConnection(hostName)) { }
        public RedisCacheImpl(Func<IRedisConnection> createConnection) : base(createConnection)
        {
        }
    }
}
