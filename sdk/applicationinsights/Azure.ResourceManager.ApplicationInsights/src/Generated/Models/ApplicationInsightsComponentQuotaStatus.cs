// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.ResourceManager.ApplicationInsights.Models
{
    /// <summary> An Application Insights component daily data volume cap status. </summary>
    public partial class ApplicationInsightsComponentQuotaStatus
    {
        /// <summary> Initializes a new instance of ApplicationInsightsComponentQuotaStatus. </summary>
        internal ApplicationInsightsComponentQuotaStatus()
        {
        }

        /// <summary> Initializes a new instance of ApplicationInsightsComponentQuotaStatus. </summary>
        /// <param name="appId"> The Application ID for the Application Insights component. </param>
        /// <param name="shouldBeThrottled"> The daily data volume cap is met, and data ingestion will be stopped. </param>
        /// <param name="expirationTime"> Date and time when the daily data volume cap will be reset, and data ingestion will resume. </param>
        internal ApplicationInsightsComponentQuotaStatus(string appId, bool? shouldBeThrottled, string expirationTime)
        {
            AppId = appId;
            ShouldBeThrottled = shouldBeThrottled;
            ExpirationTime = expirationTime;
        }

        /// <summary> The Application ID for the Application Insights component. </summary>
        public string AppId { get; }
        /// <summary> The daily data volume cap is met, and data ingestion will be stopped. </summary>
        public bool? ShouldBeThrottled { get; }
        /// <summary> Date and time when the daily data volume cap will be reset, and data ingestion will resume. </summary>
        public string ExpirationTime { get; }
    }
}
