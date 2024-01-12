using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Tenant
{
    public class Tenants
    {
        public const string OrganizacionUsuario = nameof(OrganizacionUsuario);
        public const string OrganizacionProducto = nameof(OrganizacionProducto);
        public static IReadOnlyCollection<string> All = new[] { OrganizacionUsuario, OrganizacionProducto };
        public static string Find(string? value)
        {
            return All.FirstOrDefault(t => t.Equals(value?.Trim(), StringComparison.OrdinalIgnoreCase)) ?? OrganizacionUsuario;
        }
    }

    public class TenantService : ITenantGetter, ITenantSetter
    {
        public string Tenant { get; private set; } = Tenants.OrganizacionUsuario;
        public void SetTenant(string tenant)
        {
            Tenant = tenant;
        }
    }

    public interface ITenantGetter
    {
        string Tenant { get; }
    }
    public interface ITenantSetter
    {
        void SetTenant(string tenant);
    }


    public interface ITenantProvider
    {
        String GetCurrentTenant();
    }


    public class TenantProvider : ITenantProvider
    {
        private String currentTenant;

        public String GetCurrentTenant()
        {
            return currentTenant;
        }

        public void SetCurrentTenant(String tenant)
        {
            currentTenant = tenant;
        }
    }


}
