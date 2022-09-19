using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Iptb.DivarTozi.DastebandiHa
{
    public class Dastebandi : AuditedAggregateRoot<Guid>
    {
        public string Name { get; private set; }
        public Guid? ParentId { get; set; }

        protected Dastebandi()
        {
        }

        public Dastebandi(
            Guid id,
            string name,
            Guid? parentId
        ) : base(id)
        {
            Name = name;
            ParentId = parentId;
        }
    }
}
