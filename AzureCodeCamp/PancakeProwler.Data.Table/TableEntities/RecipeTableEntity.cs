using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage.Table;

namespace PancakeProwler.Data.Table.TableEntities
{
    class RecipeTableEntity : TableEntity
    {
        public RecipeTableEntity()
        {
            PartitionKey = "recipe";
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
                RowKey = _id.ToString();
            }
        }
        public string Name { get; set; }
        public string Contributor { get; set; }

        public IEnumerable<string> Ingredients { get; set; }

        public IEnumerable<string> Steps { get; set; }

        public string ImageLocation { get; set; }
    }
}
