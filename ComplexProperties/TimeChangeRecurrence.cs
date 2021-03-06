// ---------------------------------------------------------------------------
// <copyright file="TimeChangeRecurrence.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------

//-----------------------------------------------------------------------
// <summary>Defines the TimeChangeRecurrence class.</summary>
//-----------------------------------------------------------------------

namespace Microsoft.Exchange.WebServices.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Text;

    /// <summary>
    /// Represents a recurrence pattern for a time change in a time zone.
    /// </summary>
    internal sealed class TimeChangeRecurrence : ComplexProperty
    {
        private DayOfTheWeek? dayOfTheWeek;
        private DayOfTheWeekIndex? dayOfTheWeekIndex;
        private Month? month;

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeChangeRecurrence"/> class.
        /// </summary>
        public TimeChangeRecurrence()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeChangeRecurrence"/> class.
        /// </summary>
        /// <param name="dayOfTheWeekIndex">The index of the day in the month at which the time change occurs.</param>
        /// <param name="dayOfTheWeek">The day of the week the time change occurs.</param>
        /// <param name="month">The month the time change occurs.</param>
        public TimeChangeRecurrence(
            DayOfTheWeekIndex dayOfTheWeekIndex,
            DayOfTheWeek dayOfTheWeek,
            Month month)
            : this()
        {
            this.dayOfTheWeekIndex = dayOfTheWeekIndex;
            this.dayOfTheWeek = dayOfTheWeek;
            this.month = month;
        }

        /// <summary>
        /// Gets or sets the index of the day in the month at which the time change occurs.
        /// </summary>
        public DayOfTheWeekIndex? DayOfTheWeekIndex
        {
            get { return this.dayOfTheWeekIndex; }
            set { this.SetFieldValue<DayOfTheWeekIndex?>(ref this.dayOfTheWeekIndex, value); }
        }

        /// <summary>
        /// Gets or sets the day of the week the time change occurs.
        /// </summary>
        public DayOfTheWeek? DayOfTheWeek
        {
            get { return this.dayOfTheWeek; }
            set { this.SetFieldValue<DayOfTheWeek?>(ref this.dayOfTheWeek, value); }
        }

        /// <summary>
        /// Gets or sets the month the time change occurs.
        /// </summary>
        public Month? Month
        {
            get { return this.month; }
            set { this.SetFieldValue<Month?>(ref this.month, value); }
        }

        /// <summary>
        /// Writes elements to XML.
        /// </summary>
        /// <param name="writer">The writer.</param>
        internal override void WriteElementsToXml(EwsServiceXmlWriter writer)
        {
            if (this.DayOfTheWeek.HasValue)
            {
                writer.WriteElementValue(
                    XmlNamespace.Types,
                    XmlElementNames.DaysOfWeek,
                    this.DayOfTheWeek.Value);
            }

            if (this.dayOfTheWeekIndex.HasValue)
            {
                writer.WriteElementValue(
                    XmlNamespace.Types,
                    XmlElementNames.DayOfWeekIndex,
                    this.DayOfTheWeekIndex.Value);
            }

            if (this.Month.HasValue)
            {
                writer.WriteElementValue(
                    XmlNamespace.Types,
                    XmlElementNames.Month,
                    this.Month.Value);
            }
        }

        /// <summary>
        /// Tries to read element from XML.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>True if element was read.</returns>
        internal override bool TryReadElementFromXml(EwsServiceXmlReader reader)
        {
            switch (reader.LocalName)
            {
                case XmlElementNames.DaysOfWeek:
                    this.dayOfTheWeek = reader.ReadElementValue<DayOfTheWeek>();
                    return true;
                case XmlElementNames.DayOfWeekIndex:
                    this.dayOfTheWeekIndex = reader.ReadElementValue<DayOfTheWeekIndex>();
                    return true;
                case XmlElementNames.Month:
                    this.month = reader.ReadElementValue<Month>();
                    return true;
                default:
                    return false;
            }
        }
    }
}