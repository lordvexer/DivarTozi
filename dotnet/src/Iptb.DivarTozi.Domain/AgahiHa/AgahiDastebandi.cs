using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Iptb.DivarTozi.AgahiHa
{
    public class AgahiDastebandi : Entity
    {

        public Guid AgahiId { get; protected set; }

        public Guid DastebandiId { get; protected set; }

        private AgahiDastebandi()
        {
        }

        public AgahiDastebandi(Guid AgahiId, Guid DastebandiId)
        {
            AgahiId = AgahiId;
            DastebandiId = DastebandiId;
        }

        public override object[] GetKeys()
        {
            return new object[] {AgahiId, DastebandiId};
        }
    }
}