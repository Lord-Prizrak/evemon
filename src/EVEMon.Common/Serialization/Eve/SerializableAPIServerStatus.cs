﻿using System;
using System.Xml.Serialization;
using EVEMon.Common.Constants;

namespace EVEMon.Common.Serialization.Eve
{
    /// <summary>
    /// Represents a serializable version of a server status. Used for querying CCP.
    /// </summary>
    public sealed class SerializableAPIServerStatus
    {
        [XmlElement("serverOpen")]
        public string CCPOpen
        {
            get { return Open.ToString(); }
            set
            {
                if (!String.IsNullOrEmpty(value))
                    Open = Convert.ToBoolean(value, CultureConstants.InvariantCulture);
            }
        }

        [XmlElement("onlinePlayers")]
        public int Players { get; set; }

        [XmlIgnore]
        public bool Open { get; set; }
    }
}