using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage.Table;

namespace PancakeProwler.Data.Table.TableEntities
{
    class MealTableEntity : TableEntity
    {
        public MealTableEntity()
        {
            this.PartitionKey = "meal";
        }
        private Guid _id;

        public Guid Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                RowKey = this.RowKey;
            }
        }

        public string Name { get; set; }

        public string SponsorName { get; set; }
        public string SponsorWebSite { get; set; }
        public string SponsorEMail { get; set; }
        public string SponsorTwitter { get; set; }

        public string ContactName { get; set; }

        public string ContactEMail { get; set; }
        public string ContactPhoneNumber { get; set; }

        public string Address { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public string ImageLocation { get; set; }
    }
}
