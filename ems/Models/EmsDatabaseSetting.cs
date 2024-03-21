namespace ems.Models
{
    public class EmsDatabaseSetting : IEmsDatabaseSetting
    {
        public string UserCollectionName { get; set; } = string.Empty;
        public string EmployeeCollectionName { get; set; } = string.Empty;

        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
       
    }
}
