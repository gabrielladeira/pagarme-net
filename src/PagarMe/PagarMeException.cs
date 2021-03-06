﻿#region License

// The MIT License (MIT)
// 
// Copyright (c) 2013 Pagar.me
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

#endregion

using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace PagarMe
{
    /// <summary>
    ///     Pagar.me remote API exception
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class PagarMeException : Exception
    {
        [JsonConstructor]
        internal PagarMeException(PagarMeQueryResponse response)
        {
            JsonConvert.PopulateObject(response.Data, this);
        }

        /// <summary>
        ///     API URL that caused this error
        /// </summary>
        [JsonProperty(PropertyName = "url"), UsedImplicitly]
        public string Url { get; private set; }

        /// <summary>
        ///     HTTP method that caused this error
        /// </summary>
        [JsonProperty(PropertyName = "method"), UsedImplicitly]
        public string Method { get; private set; }

        /// <summary>
        ///     Description of the errors
        /// </summary>
        [JsonProperty(PropertyName = "errors"), UsedImplicitly]
        public List<PagarMeError> Errors { get; private set; }
    }
}