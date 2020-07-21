using System;
using System.Linq;
using EFGenericChildJoin.Data;
using EFGenericChildJoin.Data.Base;
using Microsoft.Extensions.DependencyInjection;

namespace EFGenericChildJoin.Extensions
{
    public static class EFCoreExtension
    {
        public static IQueryable<TEntity> IncludeResourceAttachment<TEntity>
            (this IQueryable<TEntity> queryable,IServiceProvider serviceProvider) where TEntity : class,IBaseAttachmentEntity
        {
            var className = queryable.ElementType.Name;
            var dataContext = serviceProvider.GetRequiredService<DataContext>();
            var attachments = dataContext.Set<ResourceAttachment>().Where(x => x.ResourceType == className);
     
            var joined = (from q in queryable
                join a in attachments on q.Id equals a.ParentId into qa
                from a in qa.DefaultIfEmpty()
                select  new {Parent=q,Attachments = qa});

            return joined.Select(x => x.Parent);
        }
       
    }
}