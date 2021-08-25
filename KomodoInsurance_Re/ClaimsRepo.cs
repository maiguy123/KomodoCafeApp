using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KomodoInsurance_Re
{
    public class ClaimsRepo
    {
        protected readonly Queue<Claims> _claimsDirectory = new Queue<Claims>();
        
        // Create 
        public void AddClaimsToQueue(Claims content)
        {
            _claimsDirectory.Enqueue(content);

        }

        //Read
        public Queue<Claims> GetClaimsByQueue()
        {
            return _claimsDirectory;
        }

        // Update 
        public bool UpdateExistingClaims(string claims, Claims newcontent)
        {
            Claims oldcontent = GetClaims(claims);

            //update the content
            if (oldcontent != null)
            {
                oldcontent.ID = newcontent.ID;
                oldcontent.Type = newcontent.Type;
                oldcontent.Description = newcontent.Description;
                oldcontent.Amount = newcontent.Amount;
                oldcontent.DateOfIncident = newcontent.DateOfIncident;
                oldcontent.DateOfClaim = newcontent.DateOfClaim;
                return true;
            }
            else
            {
                return false;
            }
        }
        // Delete
        public bool DequeueFromList(string name) 
        {
            int claimLength = _claimsDirectory.Count();
            _claimsDirectory.Dequeue();
            bool isRemoved = claimLength - 1 == _claimsDirectory.Count();
            return isRemoved;
        }
        // Helper Method
        public Claims GetClaims(string claims)
        {
            foreach (Claims content in _claimsDirectory)
            {
                if (content.ID == claims)
                {
                    return content;
                }
            }
            return null;
        }
    }
}

