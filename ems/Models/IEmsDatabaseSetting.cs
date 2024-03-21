namespace ems.Models
{
    public interface IEmsDatabaseSetting
    {

        string UserCollectionName { get; set; }
        string EmployeeCollectionName { get; set; }

        string ConnectionString { get; set; }
        string DatabaseName { get; set; }



    }
}
