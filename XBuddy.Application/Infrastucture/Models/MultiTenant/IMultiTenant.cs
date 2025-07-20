namespace XBuddy.Application.Infrastucture.Models.MultiTenant
{
    public interface IMultiTenant
    {
        public string TenantId { get; set; }
    }
}
