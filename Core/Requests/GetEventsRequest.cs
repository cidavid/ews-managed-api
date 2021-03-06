// ---------------------------------------------------------------------------
// <copyright file="GetEventsRequest.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------

//-----------------------------------------------------------------------
// <summary>Defines the GetEventsRequest class.</summary>
//-----------------------------------------------------------------------

namespace Microsoft.Exchange.WebServices.Data
{
    /// <summary>
    /// GetEvents request
    /// </summary>
    internal class GetEventsRequest : MultiResponseServiceRequest<GetEventsResponse>, IJsonSerializable
    {
        private string subscriptionId;
        private string watermark;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetEventsRequest"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        internal GetEventsRequest(ExchangeService service)
            : base(service, ServiceErrorHandling.ThrowOnError)
        {
        }

        /// <summary>
        /// Creates the service response.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="responseIndex">Index of the response.</param>
        /// <returns>Service response.</returns>
        internal override GetEventsResponse CreateServiceResponse(ExchangeService service, int responseIndex)
        {
            return new GetEventsResponse();
        }

        /// <summary>
        /// Gets the expected response message count.
        /// </summary>
        /// <returns>Response count.</returns>
        internal override int GetExpectedResponseMessageCount()
        {
            return 1;
        }

        /// <summary>
        /// Gets the name of the XML element.
        /// </summary>
        /// <returns>XML element name.</returns>
        internal override string GetXmlElementName()
        {
            return XmlElementNames.GetEvents;
        }

        /// <summary>
        /// Gets the name of the response XML element.
        /// </summary>
        /// <returns>XML element name.</returns>
        internal override string GetResponseXmlElementName()
        {
            return XmlElementNames.GetEventsResponse;
        }

        /// <summary>
        /// Gets the name of the response message XML element.
        /// </summary>
        /// <returns>XML element name.</returns>
        internal override string GetResponseMessageXmlElementName()
        {
            return XmlElementNames.GetEventsResponseMessage;
        }

        /// <summary>
        /// Validates the request.
        /// </summary>
        internal override void Validate()
        {
            base.Validate();
            EwsUtilities.ValidateNonBlankStringParam(this.SubscriptionId, "SubscriptionId");
            EwsUtilities.ValidateNonBlankStringParam(this.Watermark, "Watermark");
        }

        /// <summary>
        /// Writes the elements to XML writer.
        /// </summary>
        /// <param name="writer">The writer.</param>
        internal override void WriteElementsToXml(EwsServiceXmlWriter writer)
        {
            writer.WriteElementValue(
                XmlNamespace.Messages,
                XmlElementNames.SubscriptionId,
                this.SubscriptionId);

            writer.WriteElementValue(
                XmlNamespace.Messages,
                XmlElementNames.Watermark,
                this.Watermark);
        }

        /// <summary>
        /// Creates a JSON representation of this object.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <returns>
        /// A Json value (either a JsonObject, an array of Json values, or a Json primitive)
        /// </returns>
        object IJsonSerializable.ToJson(ExchangeService service)
        {
            JsonObject jsonRequest = new JsonObject();

            jsonRequest.Add(XmlElementNames.SubscriptionId, this.SubscriptionId);
            jsonRequest.Add(XmlElementNames.Watermark, this.Watermark);

            return jsonRequest;
        }

        /// <summary>
        /// Gets the request version.
        /// </summary>
        /// <returns>Earliest Exchange version in which this request is supported.</returns>
        internal override ExchangeVersion GetMinimumRequiredServerVersion()
        {
            return ExchangeVersion.Exchange2007_SP1;
        }

        /// <summary>
        /// Gets or sets the subscription id.
        /// </summary>
        /// <value>The subscription id.</value>
        public string SubscriptionId
        {
            get { return this.subscriptionId; }
            set { this.subscriptionId = value; }
        }

        /// <summary>
        /// Gets or sets the watermark.
        /// </summary>
        /// <value>The watermark.</value>
        public string Watermark
        {
            get { return this.watermark; }
            set { this.watermark = value; }
        }
    }
}
