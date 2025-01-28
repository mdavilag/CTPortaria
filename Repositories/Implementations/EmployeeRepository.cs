using CTPortaria.DTOs;
using CTPortaria.Entities;
using CTPortaria.Repositories.Interfaces;

namespace CTPortaria.Repositories.Implementations
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public Task<EmployeeModel> GetByNameAsync(string name)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                
            }
        }

        public Task<List<EmployeeModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeModel> CreateAsync(EmployeeCreateDto employeeToCreate)
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeModel> UpdateAsync()
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeModel> DeleteAsync()
        {
            throw new NotImplementedException();
        }
    }
}
