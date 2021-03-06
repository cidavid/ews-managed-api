// ---------------------------------------------------------------------------
// <copyright file="MailboxQuery.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------

//-----------------------------------------------------------------------
// <summary>Defines the MailboxQuery class.</summary>
//-----------------------------------------------------------------------

namespace Microsoft.Exchange.WebServices.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Represents mailbox query object.
    /// </summary>
    public sealed class MailboxQuery
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="query">Search query</param>
        /// <param name="searchScopes">Set of mailbox and scope pair</param>
        public MailboxQuery(string query, MailboxSearchScope[] searchScopes)
        {
            Query = query;
            MailboxSearchScopes = searchScopes;
        }

        /// <summary>
        /// Search query
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// Set of mailbox and scope pair
        /// </summary>
        public MailboxSearchScope[] MailboxSearchScopes { get; set; }
    }

    /// <summary>
    /// Represents mailbox search scope object.
    /// </summary>
    public sealed class MailboxSearchScope
    {
        private MailboxSearchLocation searchScope = MailboxSearchLocation.All;
        private MailboxSearchScopeType scopeType = MailboxSearchScopeType.LegacyExchangeDN;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mailbox">Mailbox</param>
        /// <param name="searchScope">Search scope</param>
        public MailboxSearchScope(string mailbox, MailboxSearchLocation searchScope)
        {
            this.Mailbox = mailbox;
            this.searchScope = searchScope;
            this.ExtendedAttributes = new ExtendedAttributes();
        }

        /// <summary>
        /// Mailbox
        /// </summary>
        public string Mailbox { get; set; }

        /// <summary>
        /// Search scope
        /// </summary>
        public MailboxSearchLocation SearchScope
        {
            get { return this.searchScope; }
            set { this.searchScope = value; }
        }

        /// <summary>
        /// Search scope type
        /// </summary>
        internal MailboxSearchScopeType SearchScopeType
        {
            get { return this.scopeType; }
            set { this.scopeType = value; }
        }

        /// <summary>
        /// Gets the extended data.
        /// </summary>
        /// <value>The extended data.</value>
        public ExtendedAttributes ExtendedAttributes
        {
            get;
            private set;
        }
    }

    /// <summary>
    /// Represents mailbox object for preview item.
    /// </summary>
    public sealed class PreviewItemMailbox
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public PreviewItemMailbox()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mailboxId">Mailbox id</param>
        /// <param name="primarySmtpAddress">Primary smtp address</param>
        public PreviewItemMailbox(string mailboxId, string primarySmtpAddress)
        {
            MailboxId = mailboxId;
            PrimarySmtpAddress = primarySmtpAddress;
        }

        /// <summary>
        /// Mailbox id
        /// </summary>
        public string MailboxId { get; set; }

        /// <summary>
        /// Primary smtp address
        /// </summary>
        public string PrimarySmtpAddress { get; set; }
    }
}
