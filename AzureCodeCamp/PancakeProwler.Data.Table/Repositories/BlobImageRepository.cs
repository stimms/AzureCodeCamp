using System;
using System.Linq;
using System.Configuration;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace PancakeProwler.Data.Common.Repositories
{
    public class BlobImageRepository : IImageRepository
    {
        public Uri Save(string contentType, int contentLength, System.IO.Stream inputStream)
        {
            var container = GetContainer();
            var blockBlob = container.GetBlockBlobReference(Guid.NewGuid().ToString());
            blockBlob.Properties.ContentType = contentType;
            blockBlob.UploadFromStream(inputStream);
            return blockBlob.Uri;

        }
        private static CloudBlobContainer GetContainer()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["StorageConnectionString"].ConnectionString);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            CloudBlobContainer container = blobClient.GetContainerReference("recipeimages");//must be lowercase
            container.CreateIfNotExists();

            return container;
        }
    }
}
