using System.Collections.Generic;

namespace Sparcpoint.Core.Models
{
    public class Category
    {
        public int InstanceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Dictionary<string, string> Attributes { get; set; }

        public Category()
        {
            Attributes = new Dictionary<string, string>();
        }
    }
}
