using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class TaxiCompany
    {
        public int Id { get; private set; }
        public int OwnerId { get; private set; }
        public string CompanyName { get; private set; }
        public string CompanyLocation { get; private set; }
        public string Description { get; private set; }
        public int HasBeenValidated { get; private set; }

        public TaxiCompany(int Id, int OwnerId, string CompanyName, string CompanyLocation, string Description, int HasBeenValidated)
        {
            this.Id = Id;
            this.OwnerId = OwnerId;
            this.CompanyName = CompanyName;
            this.CompanyLocation = CompanyLocation;
            this.Description = Description;
            this.HasBeenValidated = HasBeenValidated;
        }
    }
