﻿using System.Linq;
using EVEMon.Common.Attributes;
using EVEMon.Common.Data;
using EVEMon.Common.Enumerations;

namespace EVEMon.Common.Models
{
    /// <summary>
    /// Represents a certificate class from a character's point of view.
    /// </summary>
    [EnforceUIThreadAffinity]
    public sealed class CertificateClass
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="character"></param>
        /// <param name="src"></param>
        /// <param name="category"></param>
        internal CertificateClass(Character character, StaticCertificateClass src, CertificateGroup category)
        {
            Category = category;
            StaticData = src;
            Certificate = new Certificate(character, src.Certificate, this);
        }        

        /// <summary>
        /// Gets the static data associated with this object.
        /// </summary>
        public StaticCertificateClass StaticData { get; private set; }

        /// <summary>
        /// Gets the category for this certificate class.
        /// </summary>
        public CertificateGroup Category { get; private set; }

        /// <summary>
        /// Gets the certificate of this certificate class
        /// </summary>
        public Certificate Certificate { get; private set; }

        /// <summary>
        /// Gets this skill's id.
        /// </summary>
        public int ID
        {
            get { return StaticData.ID; }
        }

        /// <summary>
        /// Gets this skill's name.
        /// </summary>
        public string Name
        {
            get { return StaticData.Name; }
        }

        /// <summary>
        /// Gets the lowest untrained certificate level.
        /// Null if all certificates have been trained.
        /// </summary>
        public CertificateLevel LowestUntrainedLevel
        {
            get
            {
                return Certificate.AllLevel.FirstOrDefault(level => level.Status != CertificateStatus.Trained);                
            }
        }

        /// <summary>
        /// Gets the highest trained certificate level.
        /// May be null if no level has been trained.
        /// </summary>
        public CertificateLevel HighestTrainedLevel
        {
            get
            {
                CertificateLevel lastCertLevel = null;
                foreach (var certLevel in Certificate.AllLevel)
                {
                    if (certLevel.Status != CertificateStatus.Trained)
                        return lastCertLevel;
                    lastCertLevel = certLevel;
                }
                return lastCertLevel;
            }
        }

        /// <summary>
        /// Gets true if the provided character has completed this class.
        /// </summary>
        public bool IsCompleted
        {
            get { return Certificate.AllLevel.All(certLevel => certLevel.Status == CertificateStatus.Trained); }
        }

        /// <summary>
        /// Gets true if the provided character can train to the next grade,
        /// false if the class has already been completed or if the next grade is untrainable.
        /// </summary>
        /// <returns></returns>
        public bool IsFurtherTrainable
        {
            get
            {
                if (Certificate.AllLevel.All(cert => cert.IsTrained))
                    return false;

                foreach (CertificateLevel certLevel in Certificate.AllLevel)
                {
                    switch (certLevel.Status)
                    {
                        case CertificateStatus.PartiallyTrained:
                            return true;
                        case CertificateStatus.Untrained:
                            return false;
                    }
                }

                return false;
            }
        }

        /// <summary>
        /// Gets the name of the class.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return StaticData.Name;
        }
    }
}