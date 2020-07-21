using EFGenericChildJoin.Data.Base;

namespace EFGenericChildJoin.Data
{
    public  class ResourceAttachment:BaseEntity
    {
        //PK- Id of the parent table
        public long ParentId { get; set; }
        // type or enum of a parent table. Should point to which table it points to
        public string ResourceType { get; set; }
        
        public string AttachmentType { get; set; }

        public string Value { get; set; }
    }
}