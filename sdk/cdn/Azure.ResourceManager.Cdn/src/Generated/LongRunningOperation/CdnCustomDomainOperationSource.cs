// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.Cdn
{
    internal class CdnCustomDomainOperationSource : IOperationSource<CdnCustomDomainResource>
    {
        private readonly ArmClient _client;
        private readonly Dictionary<string, string> _idMappings = new Dictionary<string, string>()
        {
            { "subscriptionId", "Microsoft.Resources/subscriptions" },
            { "resourceGroupName", "Microsoft.Resources/resourceGroups" },
            { "profileName", "Microsoft.Cdn/operationresults/profileresults" },
            { "endpointName", "Microsoft.Cdn/operationresults/profileresults/endpointresults" },
            { "customDomainName", "Microsoft.Cdn/operationresults/profileresults/endpointresults/customdomainresults" },
        };

        internal CdnCustomDomainOperationSource(ArmClient client)
        {
            _client = client;
        }

        CdnCustomDomainResource IOperationSource<CdnCustomDomainResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = ScrubId(CdnCustomDomainData.DeserializeCdnCustomDomainData(document.RootElement));
            return new CdnCustomDomainResource(_client, data);
        }

        async ValueTask<CdnCustomDomainResource> IOperationSource<CdnCustomDomainResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = ScrubId(CdnCustomDomainData.DeserializeCdnCustomDomainData(document.RootElement));
            return new CdnCustomDomainResource(_client, data);
        }

        private CdnCustomDomainData ScrubId(CdnCustomDomainData data)
        {
            if (data.Id.ResourceType == CdnCustomDomainResource.ResourceType)
                return data;

            var newId = CdnCustomDomainResource.CreateResourceIdentifier(
                GetName("subscriptionId", data.Id),
                GetName("resourceGroupName", data.Id),
                GetName("profileName", data.Id),
                GetName("endpointName", data.Id),
                GetName("customDomainName", data.Id));

            return new CdnCustomDomainData(
                newId,
                newId.Name,
                newId.ResourceType,
                data.SystemData,
                data.HostName,
                data.ResourceState,
                data.CustomHttpsProvisioningState,
                data.CustomHttpsAvailabilityState,
                data.CustomDomainHttpsContent,
                data.ValidationData,
                data.ProvisioningState,
                null);
        }

        private string GetName(string param, ResourceIdentifier id)
        {
            while (id.ResourceType != _idMappings[param])
                id = id.Parent;
            return id.Name;
        }
    }
}
