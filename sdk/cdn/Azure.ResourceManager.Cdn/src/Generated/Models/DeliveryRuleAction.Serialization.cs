// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Cdn.Models
{
    [PersistableModelProxy(typeof(UnknownDeliveryRuleAction))]
    public partial class DeliveryRuleAction : IUtf8JsonSerializable, IJsonModel<DeliveryRuleAction>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<DeliveryRuleAction>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<DeliveryRuleAction>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DeliveryRuleAction>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DeliveryRuleAction)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name.ToString());
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

        DeliveryRuleAction IJsonModel<DeliveryRuleAction>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DeliveryRuleAction>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DeliveryRuleAction)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDeliveryRuleAction(document.RootElement, options);
        }

        internal static DeliveryRuleAction DeserializeDeliveryRuleAction(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("name", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "CacheExpiration": return DeliveryRuleCacheExpirationAction.DeserializeDeliveryRuleCacheExpirationAction(element);
                    case "CacheKeyQueryString": return DeliveryRuleCacheKeyQueryStringAction.DeserializeDeliveryRuleCacheKeyQueryStringAction(element);
                    case "ModifyRequestHeader": return DeliveryRuleRequestHeaderAction.DeserializeDeliveryRuleRequestHeaderAction(element);
                    case "ModifyResponseHeader": return DeliveryRuleResponseHeaderAction.DeserializeDeliveryRuleResponseHeaderAction(element);
                    case "OriginGroupOverride": return OriginGroupOverrideAction.DeserializeOriginGroupOverrideAction(element);
                    case "RouteConfigurationOverride": return DeliveryRuleRouteConfigurationOverrideAction.DeserializeDeliveryRuleRouteConfigurationOverrideAction(element);
                    case "UrlRedirect": return UriRedirectAction.DeserializeUriRedirectAction(element);
                    case "UrlRewrite": return UriRewriteAction.DeserializeUriRewriteAction(element);
                    case "UrlSigning": return UriSigningAction.DeserializeUriSigningAction(element);
                }
            }
            return UnknownDeliveryRuleAction.DeserializeUnknownDeliveryRuleAction(element);
        }

        BinaryData IPersistableModel<DeliveryRuleAction>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DeliveryRuleAction>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(DeliveryRuleAction)} does not support '{options.Format}' format.");
            }
        }

        DeliveryRuleAction IPersistableModel<DeliveryRuleAction>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DeliveryRuleAction>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeDeliveryRuleAction(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(DeliveryRuleAction)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<DeliveryRuleAction>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
