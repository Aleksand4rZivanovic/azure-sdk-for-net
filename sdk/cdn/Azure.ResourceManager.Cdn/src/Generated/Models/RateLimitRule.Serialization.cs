// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class RateLimitRule : IUtf8JsonSerializable, IJsonModel<RateLimitRule>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<RateLimitRule>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<RateLimitRule>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RateLimitRule>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(RateLimitRule)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("rateLimitThreshold"u8);
            writer.WriteNumberValue(RateLimitThreshold);
            writer.WritePropertyName("rateLimitDurationInMinutes"u8);
            writer.WriteNumberValue(RateLimitDurationInMinutes);
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            if (Optional.IsDefined(EnabledState))
            {
                writer.WritePropertyName("enabledState"u8);
                writer.WriteStringValue(EnabledState.Value.ToString());
            }
            writer.WritePropertyName("priority"u8);
            writer.WriteNumberValue(Priority);
            writer.WritePropertyName("matchConditions"u8);
            writer.WriteStartArray();
            foreach (var item in MatchConditions)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("action"u8);
            writer.WriteStringValue(Action.ToString());
            if (options.Format != "W" && _serializedAdditionalRawData != null)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
            writer.WriteEndObject();
        }

        RateLimitRule IJsonModel<RateLimitRule>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RateLimitRule>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(RateLimitRule)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeRateLimitRule(document.RootElement, options);
        }

        internal static RateLimitRule DeserializeRateLimitRule(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int rateLimitThreshold = default;
            int rateLimitDurationInMinutes = default;
            string name = default;
            Optional<CustomRuleEnabledState> enabledState = default;
            int priority = default;
            IList<CustomRuleMatchCondition> matchConditions = default;
            OverrideActionType action = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("rateLimitThreshold"u8))
                {
                    rateLimitThreshold = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("rateLimitDurationInMinutes"u8))
                {
                    rateLimitDurationInMinutes = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("enabledState"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    enabledState = new CustomRuleEnabledState(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("priority"u8))
                {
                    priority = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("matchConditions"u8))
                {
                    List<CustomRuleMatchCondition> array = new List<CustomRuleMatchCondition>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(CustomRuleMatchCondition.DeserializeCustomRuleMatchCondition(item));
                    }
                    matchConditions = array;
                    continue;
                }
                if (property.NameEquals("action"u8))
                {
                    action = new OverrideActionType(property.Value.GetString());
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new RateLimitRule(name, Optional.ToNullable(enabledState), priority, matchConditions, action, serializedAdditionalRawData, rateLimitThreshold, rateLimitDurationInMinutes);
        }

        BinaryData IPersistableModel<RateLimitRule>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RateLimitRule>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(RateLimitRule)} does not support '{options.Format}' format.");
            }
        }

        RateLimitRule IPersistableModel<RateLimitRule>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RateLimitRule>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeRateLimitRule(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(RateLimitRule)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<RateLimitRule>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
