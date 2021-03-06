// ---------------------------------------------------------------------------
// <copyright file="FailedSearchMailbox.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------

//-----------------------------------------------------------------------
// <summary>Defines the FailedSearchMailbox class.</summary>
//-----------------------------------------------------------------------

namespace Microsoft.Exchange.WebServices.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Represents failed mailbox to be searched
    /// </summary>
    public sealed class FailedSearchMailbox
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mailbox">Mailbox identifier</param>
        /// <param name="errorCode">Error code</param>
        /// <param name="errorMessage">Error message</param>
        public FailedSearchMailbox(string mailbox, int errorCode, string errorMessage) :
            this(mailbox, errorCode, errorMessage, false)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mailbox">Mailbox identifier</param>
        /// <param name="errorCode">Error code</param>
        /// <param name="errorMessage">Error message</param>
        /// <param name="isArchive">True if it is mailbox archive</param>
        public FailedSearchMailbox(string mailbox, int errorCode, string errorMessage, bool isArchive)
        {
            Mailbox = mailbox;
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
            IsArchive = isArchive;
        }

        /// <summary>
        /// Mailbox identifier
        /// </summary>
        public string Mailbox { get; set; }

        /// <summary>
        /// Error code
        /// </summary>
        public int ErrorCode { get; set; }

        /// <summary>
        /// Error message
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Whether it is archive mailbox or not
        /// </summary>
        public bool IsArchive { get; set; }

        /// <summary>
        /// Load failed mailboxes xml
        /// </summary>
        /// <param name="rootXmlNamespace">Root xml namespace</param>
        /// <param name="reader">The reader</param>
        /// <returns>Array of failed mailboxes</returns>
        internal static FailedSearchMailbox[] LoadFailedMailboxesXml(XmlNamespace rootXmlNamespace, EwsServiceXmlReader reader)
        {
            List<FailedSearchMailbox> failedMailboxes = new List<FailedSearchMailbox>();

            reader.EnsureCurrentNodeIsStartElement(rootXmlNamespace, XmlElementNames.FailedMailboxes);
            do
            {
                reader.Read();
                if (reader.IsStartElement(XmlNamespace.Types, XmlElementNames.FailedMailbox))
                {
                    string mailbox = reader.ReadElementValue(XmlNamespace.Types, XmlElementNames.Mailbox);
                    int errorCode = 0;
                    int.TryParse(reader.ReadElementValue(XmlNamespace.Types, XmlElementNames.ErrorCode), out errorCode);
                    string errorMessage = reader.ReadElementValue(XmlNamespace.Types, XmlElementNames.ErrorMessage);
                    bool isArchive = false;
                    bool.TryParse(reader.ReadElementValue(XmlNamespace.Types, XmlElementNames.IsArchive), out isArchive);

                    failedMailboxes.Add(new FailedSearchMailbox(mailbox, errorCode, errorMessage, isArchive));
                }
            }
            while (!reader.IsEndElement(rootXmlNamespace, XmlElementNames.FailedMailboxes));

            return failedMailboxes.Count == 0 ? null : failedMailboxes.ToArray();
        }
    }
}
