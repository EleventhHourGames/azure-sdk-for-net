// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.CostManagement.Models;

namespace Azure.ResourceManager.CostManagement
{
    internal partial class BenefitRecommendationsRestOperations
    {
        private readonly TelemetryDetails _userAgent;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> Initializes a new instance of BenefitRecommendationsRestOperations. </summary>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="applicationId"> The application id to use for user agent. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pipeline"/> or <paramref name="apiVersion"/> is null. </exception>
        public BenefitRecommendationsRestOperations(HttpPipeline pipeline, string applicationId, Uri endpoint = null, string apiVersion = default)
        {
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? new Uri("https://management.azure.com");
            _apiVersion = apiVersion ?? "2023-03-01";
            _userAgent = new TelemetryDetails(GetType().Assembly, applicationId);
        }

        internal HttpMessage CreateListRequest(string billingScope, string filter, string orderby, string expand)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/", false);
            uri.AppendPath(billingScope, false);
            uri.AppendPath("/providers/Microsoft.CostManagement/benefitRecommendations", false);
            if (filter != null)
            {
                uri.AppendQuery("$filter", filter, true);
            }
            if (orderby != null)
            {
                uri.AppendQuery("$orderby", orderby, true);
            }
            if (expand != null)
            {
                uri.AppendQuery("$expand", expand, true);
            }
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> List of recommendations for purchasing savings plan. </summary>
        /// <param name="billingScope"> The scope associated with benefit recommendation operations. This includes &apos;/subscriptions/{subscriptionId}/&apos; for subscription scope, &apos;/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}&apos; for resource group scope, /providers/Microsoft.Billing/billingAccounts/{billingAccountId}&apos; for enterprise agreement scope, and &apos;/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}&apos; for billing profile scope. </param>
        /// <param name="filter"> Can be used to filter benefitRecommendations by: properties/scope with allowed values [&apos;Single&apos;, &apos;Shared&apos;] and default value &apos;Shared&apos;; and properties/lookBackPeriod with allowed values [&apos;Last7Days&apos;, &apos;Last30Days&apos;, &apos;Last60Days&apos;] and default value &apos;Last60Days&apos;; properties/term with allowed values [&apos;P1Y&apos;, &apos;P3Y&apos;] and default value &apos;P3Y&apos;; properties/subscriptionId; properties/resourceGroup. </param>
        /// <param name="orderby"> May be used to order the recommendations by: properties/armSkuName. For the savings plan, the results are in order by default. There is no need to use this clause. </param>
        /// <param name="expand"> May be used to expand the properties by: properties/usage, properties/allRecommendationDetails. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="billingScope"/> is null. </exception>
        public async Task<Response<BenefitRecommendationsListResult>> ListAsync(string billingScope, string filter = null, string orderby = null, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(billingScope, nameof(billingScope));

            using var message = CreateListRequest(billingScope, filter, orderby, expand);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        BenefitRecommendationsListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = BenefitRecommendationsListResult.DeserializeBenefitRecommendationsListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> List of recommendations for purchasing savings plan. </summary>
        /// <param name="billingScope"> The scope associated with benefit recommendation operations. This includes &apos;/subscriptions/{subscriptionId}/&apos; for subscription scope, &apos;/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}&apos; for resource group scope, /providers/Microsoft.Billing/billingAccounts/{billingAccountId}&apos; for enterprise agreement scope, and &apos;/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}&apos; for billing profile scope. </param>
        /// <param name="filter"> Can be used to filter benefitRecommendations by: properties/scope with allowed values [&apos;Single&apos;, &apos;Shared&apos;] and default value &apos;Shared&apos;; and properties/lookBackPeriod with allowed values [&apos;Last7Days&apos;, &apos;Last30Days&apos;, &apos;Last60Days&apos;] and default value &apos;Last60Days&apos;; properties/term with allowed values [&apos;P1Y&apos;, &apos;P3Y&apos;] and default value &apos;P3Y&apos;; properties/subscriptionId; properties/resourceGroup. </param>
        /// <param name="orderby"> May be used to order the recommendations by: properties/armSkuName. For the savings plan, the results are in order by default. There is no need to use this clause. </param>
        /// <param name="expand"> May be used to expand the properties by: properties/usage, properties/allRecommendationDetails. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="billingScope"/> is null. </exception>
        public Response<BenefitRecommendationsListResult> List(string billingScope, string filter = null, string orderby = null, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(billingScope, nameof(billingScope));

            using var message = CreateListRequest(billingScope, filter, orderby, expand);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        BenefitRecommendationsListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = BenefitRecommendationsListResult.DeserializeBenefitRecommendationsListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateListNextPageRequest(string nextLink, string billingScope, string filter, string orderby, string expand)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRawNextLink(nextLink, false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> List of recommendations for purchasing savings plan. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="billingScope"> The scope associated with benefit recommendation operations. This includes &apos;/subscriptions/{subscriptionId}/&apos; for subscription scope, &apos;/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}&apos; for resource group scope, /providers/Microsoft.Billing/billingAccounts/{billingAccountId}&apos; for enterprise agreement scope, and &apos;/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}&apos; for billing profile scope. </param>
        /// <param name="filter"> Can be used to filter benefitRecommendations by: properties/scope with allowed values [&apos;Single&apos;, &apos;Shared&apos;] and default value &apos;Shared&apos;; and properties/lookBackPeriod with allowed values [&apos;Last7Days&apos;, &apos;Last30Days&apos;, &apos;Last60Days&apos;] and default value &apos;Last60Days&apos;; properties/term with allowed values [&apos;P1Y&apos;, &apos;P3Y&apos;] and default value &apos;P3Y&apos;; properties/subscriptionId; properties/resourceGroup. </param>
        /// <param name="orderby"> May be used to order the recommendations by: properties/armSkuName. For the savings plan, the results are in order by default. There is no need to use this clause. </param>
        /// <param name="expand"> May be used to expand the properties by: properties/usage, properties/allRecommendationDetails. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> or <paramref name="billingScope"/> is null. </exception>
        public async Task<Response<BenefitRecommendationsListResult>> ListNextPageAsync(string nextLink, string billingScope, string filter = null, string orderby = null, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNull(billingScope, nameof(billingScope));

            using var message = CreateListNextPageRequest(nextLink, billingScope, filter, orderby, expand);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        BenefitRecommendationsListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = BenefitRecommendationsListResult.DeserializeBenefitRecommendationsListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> List of recommendations for purchasing savings plan. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="billingScope"> The scope associated with benefit recommendation operations. This includes &apos;/subscriptions/{subscriptionId}/&apos; for subscription scope, &apos;/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}&apos; for resource group scope, /providers/Microsoft.Billing/billingAccounts/{billingAccountId}&apos; for enterprise agreement scope, and &apos;/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}&apos; for billing profile scope. </param>
        /// <param name="filter"> Can be used to filter benefitRecommendations by: properties/scope with allowed values [&apos;Single&apos;, &apos;Shared&apos;] and default value &apos;Shared&apos;; and properties/lookBackPeriod with allowed values [&apos;Last7Days&apos;, &apos;Last30Days&apos;, &apos;Last60Days&apos;] and default value &apos;Last60Days&apos;; properties/term with allowed values [&apos;P1Y&apos;, &apos;P3Y&apos;] and default value &apos;P3Y&apos;; properties/subscriptionId; properties/resourceGroup. </param>
        /// <param name="orderby"> May be used to order the recommendations by: properties/armSkuName. For the savings plan, the results are in order by default. There is no need to use this clause. </param>
        /// <param name="expand"> May be used to expand the properties by: properties/usage, properties/allRecommendationDetails. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> or <paramref name="billingScope"/> is null. </exception>
        public Response<BenefitRecommendationsListResult> ListNextPage(string nextLink, string billingScope, string filter = null, string orderby = null, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNull(billingScope, nameof(billingScope));

            using var message = CreateListNextPageRequest(nextLink, billingScope, filter, orderby, expand);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        BenefitRecommendationsListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = BenefitRecommendationsListResult.DeserializeBenefitRecommendationsListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
