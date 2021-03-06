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
using System.Reflection;
using Newtonsoft.Json;

namespace PagarMe.Converters
{
    internal class PagarMeModelConverter<T> : JsonConverter where T : PagarMeModel
    {
        private readonly ConstructorInfo _ctor;

        public PagarMeModelConverter()
        {
            _ctor = typeof(T).GetConstructor(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null,
                new[] {typeof(PagarMeProvider)}, null);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(T);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            PagarMeModel model =
                (PagarMeModel)_ctor.Invoke(new object[] {((ProviderWrapper)serializer.Context.Context).Provider});
            serializer.Populate(reader, model);
            return model;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}