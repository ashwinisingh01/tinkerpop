#region License
/*
 * Licensed to the Apache Software Foundation (ASF) under one
 * or more contributor license agreements.  See the NOTICE file
 * distributed with this work for additional information
 * regarding copyright ownership.  The ASF licenses this file
 * to you under the Apache License, Version 2.0 (the
 * "License"); you may not use this file except in compliance
 * with the License.  You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing,
 * software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 * KIND, either express or implied.  See the License for the
 * specific language governing permissions and limitations
 * under the License.
 */
#endregion

using System.Collections;
using System.Collections.Generic;

namespace Gremlin.Net.Driver
{
    ///<inheritdoc />
    internal sealed class ResultSet<T> : IResultSet<T>
    {
        /// <summary>
        /// Initializes a new instance of the ResultSet class for the specified data and status attributes.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="attributes"></param>
        public ResultSet(IReadOnlyCollection<T> data, Dictionary<string, object> attributes)
        {
            this.Data = data;
            this.StatusAttributes = attributes;
        }

        /// <summary>Returns an enumerator that iterates through the collection.</summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return this.Data.GetEnumerator();
        }

        /// <summary>Returns an enumerator that iterates through a collection.</summary>
        /// <returns>An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>Gets the number of elements in the collection.</summary>
        /// <returns>The number of elements in the collection. </returns>
        public int Count => this.Data.Count;

        /// <summary>
        ///  Gets the data from the response
        /// </summary>
        public IReadOnlyCollection<T> Data {get; private set;}
      
        /// <summary>
        /// Gets the status attributes from the gremlin response
        /// </summary>
        public Dictionary<string, object> StatusAttributes {get; private set;}
    }
}