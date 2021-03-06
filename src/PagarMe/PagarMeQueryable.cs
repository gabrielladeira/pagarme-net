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

using System.Linq;
using System.Linq.Expressions;
using JetBrains.Annotations;
using Remotion.Linq;
using Remotion.Linq.Parsing.Structure;

namespace PagarMe
{
    /// <summary>
    ///     Manages access underlying object in Pagar.me API
    /// </summary>
    /// <typeparam name="T">Object type</typeparam>
    public class PagarMeQueryable<T> : QueryableBase<T> where T : PagarMeModel
    {
        /// <summary>
        ///     Infrastructure.
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="expression"></param>
        [UsedImplicitly]
        public PagarMeQueryable(IQueryProvider provider, Expression expression)
            : base(provider, expression)
        {
        }

        internal PagarMeQueryable(PagarMeProvider pagarme)
            : base(
                new DefaultQueryProvider(typeof(PagarMeQueryable<>), QueryParser.CreateDefault(),
                    new PagarMeQueryExecutor(pagarme)))
        {
        }
    }
}