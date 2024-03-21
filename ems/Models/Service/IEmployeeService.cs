namespace ems.Models.Service
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllAsyc();
        List<Employee> Get();

        Employee Get(string id);
        Employee Create(Employee employee);
        void Update(string id, Employee employee);

        void Remove(string id);
    }
}
