using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_Repo
{
     public class Claim
    {
        public string ID { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string DateOfIncident{ get; set; }
        public string  DateOfClaim { get; set; }

        public Claim() { }
        public Claim (string claimID, string claimType, string claimDescription, 
            int claimAmount, string dateOfIncident, string dateOfclaim)
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
