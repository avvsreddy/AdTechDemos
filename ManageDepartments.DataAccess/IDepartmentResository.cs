namespace ManageDepartments.DataAccess
{
    public interface IDepartmentResository
    {
        void Insert(Department department);
        List<Department> GetDepartments();
        Department GetDepartmentById(int id);
        List<Department> GetDepartmentsByLocation(string location);

        void DeleteDepartment(int id);
        void UpdateDepartment(Department department);
    }
}
