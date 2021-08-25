using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoInsurance_Re
{
    public class Claims
    {
        public string ID { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }

        public bool IsValid
        {
            get
            {
                if((DateOfClaim.Date - DateOfIncident.Date).Days > 30)
                {
                    return false; 
                }
                else
                {
                    return true;
                }
            }
        }
        

        public Claims() { }
        public Claims(string claimID, string claimType, string claimDescription,
            decimal claimAmount, DateTime dateOfIncident, DateTime dateOfclaim)
        {
            ID = claimID;
            Type = claimType;
            Description = claimDescription;
            Amount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfclaim;
        }

    }
}