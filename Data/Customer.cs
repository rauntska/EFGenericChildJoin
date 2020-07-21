using System.Collections.Generic;
using EFGenericChildJoin.Data.Base;

namespace EFGenericChildJoin.Data
{
    public class Customer:BaseEntity,IBaseAttachmentEntity
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public ICollection<ResourceAttachment> ResourceAttachment { get; set; }
    }
}