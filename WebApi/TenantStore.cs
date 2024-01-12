using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi
{
    public interface ITenantStore
    {
        Tenant GetTenant(string tenandId);
    }

    public class TenantStore : ITenantStore
    {
        public Tenant GetTenant(string tenandId)
        {
            return tenandId switch
            {
                "tenant1" => new("tenant1"),
                "tenant2" => new("tenant2"),
                _ => null
            };
        }
    }
}
