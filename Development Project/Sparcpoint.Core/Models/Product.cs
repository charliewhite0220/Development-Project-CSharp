using System.Collections.Generic;

namespace Sparcpoint.Core.Models
{
    public class Product
    {
        public int InstanceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProductImageUris { get; set; }
        public string ValidSkus { get; set; }
        public Dictionary<string, string> Metadata { get; set; }

        public Product()
        {
            Metadata = new Dictionary<string, string>();
        }
    }
}
