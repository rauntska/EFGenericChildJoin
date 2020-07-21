using System.Collections.Generic;

namespace EFGenericChildJoin.Data.Base
{
    public interface IBaseAttachmentEntity:IBaseEntity
    {
        ICollection<ResourceAttachment> ResourceAttachment { get; set; }
    }
}