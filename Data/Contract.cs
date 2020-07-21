using System.Collections.Generic;
using EFGenericChildJoin.Data.Base;

namespace EFGenericChildJoin.Data
{
    public class Contract:BaseEntity,IBaseAttachmentEntity
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public ICollection<ResourceAttachment> ResourceAttachment { get; set; }
    }
}