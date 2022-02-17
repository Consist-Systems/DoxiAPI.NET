﻿using Newtonsoft.Json;
using System;

namespace Doxi.Services.General.Core.Utils
{
    public class EmptyToNullConverter : JsonConverter
    {
        private JsonSerializer _stringSerializer = new JsonSerializer();

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        public override object ReadJson(JsonReader reader, Type objectType,
                                        object existingValue, JsonSerializer serializer)
        {
            string value = _stringSerializer.Deserialize<string>(reader);

            if (string.IsNullOrEmpty(value))
            {
                value = null;
            }

            return value;
        }

        public override void WriteJson(JsonWriter writer, object value,
                                       JsonSerializer serializer)
        {
            _stringSerializer.Serialize(writer, value);
        }
    }
}
