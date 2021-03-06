// ---------------------------------------------------------------------------
// <copyright file="CalendarEvent.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------

//-----------------------------------------------------------------------
// <summary>Implements the CalendarEvent class.</summary>
//-----------------------------------------------------------------------

namespace Microsoft.Exchange.WebServices.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Represents an event in a calendar.
    /// </summary>
    public sealed class CalendarEvent : ComplexProperty
    {
        private DateTime startTime;
        private DateTime endTime;
        private LegacyFreeBusyStatus freeBusyStatus;
        private CalendarEventDetails details;

        /// <summary>
        /// Initializes a new instance of the <see cref="CalendarEvent"/> class.
        /// </summary>
        internal CalendarEvent()
            : base()
        {
        }

        /// <summary>
        /// Gets the start date and time of the event.
        /// </summary>
        public DateTime StartTime
        {
            get { return this.startTime; }
        }

        /// <summary>
        /// Gets the end date and time of the event.
        /// </summary>
        public DateTime EndTime
        {
            get { return this.endTime; }
        }

        /// <summary>
        /// Gets the free/busy status associated with the event.
        /// </summary>
        public LegacyFreeBusyStatus FreeBusyStatus
        {
            get { return this.freeBusyStatus; }
        }

        /// <summary>
        /// Gets the details of the calendar event. Details is null if the user
        /// requsting them does no have the appropriate rights.
        /// </summary>
        public CalendarEventDetails Details
        {
            get { return this.details; }
        }

        /// <summary>
        /// Attempts to read the element at the reader's current position.
        /// </summary>
        /// <param name="reader">The reader used to read the element.</param>
        /// <returns>True if the element was read, false otherwise.</returns>
        internal override bool TryReadElementFromXml(EwsServiceXmlReader reader)
        {
            switch (reader.LocalName)
            {
                case XmlElementNames.StartTime:
                    this.startTime = reader.ReadElementValueAsUnbiasedDateTimeScopedToServiceTimeZone();
                    return true;
                case XmlElementNames.EndTime:
                    this.endTime = reader.ReadElementValueAsUnbiasedDateTimeScopedToServiceTimeZone();
                    return true;
                case XmlElementNames.BusyType:
                    this.freeBusyStatus = reader.ReadElementValue<LegacyFreeBusyStatus>();
                    return true;
                case XmlElementNames.CalendarEventDetails:
                    this.details = new CalendarEventDetails();
                    this.details.LoadFromXml(reader, reader.LocalName);
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Loads from json.
        /// </summary>
        /// <param name="jsonProperty">The json property.</param>
        /// <param name="service"></param>
        internal override void LoadFromJson(JsonObject jsonProperty, ExchangeService service)
        {
            foreach (string key in jsonProperty.Keys)
            {
                switch (key)
                {
                    case XmlElementNames.StartTime:
                        this.startTime = EwsUtilities.ParseAsUnbiasedDatetimescopedToServicetimeZone(
                            jsonProperty.ReadAsString(key),
                            service);
                        break;
                    case XmlElementNames.EndTime:
                        this.endTime = EwsUtilities.ParseAsUnbiasedDatetimescopedToServicetimeZone(
                            jsonProperty.ReadAsString(key),
                            service);
                        break;
                    case XmlElementNames.BusyType:
                        this.freeBusyStatus = jsonProperty.ReadEnumValue<LegacyFreeBusyStatus>(key);
                        break;
                    case XmlElementNames.CalendarEventDetails:
                        this.details = new CalendarEventDetails();
                        this.details.LoadFromJson(jsonProperty.ReadAsJsonObject(key), service);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
