using CTPortaria.Data;
using CTPortaria.DTOs;
using CTPortaria.Entities;
using CTPortaria.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CTPortaria.Repositories.Implementations
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;

        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<EmployeeModel> GetByNameAsync(string name)
        {
            try
            {
                return await _context.Employees.FirstOrDefaultAsync(x => x.Name == name);
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<EmployeeModel>> GetAllAsync()
        {
            try
            {
                return await _context.Employees.ToListAsync();
            }
            catch
            {
                return null;
            }
        }

        public async Task<EmployeeModel> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch
            {
                return null;
            }
        }

        public async Task<EmployeeModel> CreateAsync(EmployeeModel employeeToCreate)
        {
            try
            {
                await _context.Employees.AddAsync(employeeToCreate);
                await _context.SaveChangesAsync();
                return employeeToCreate;
            }
            catch
            {
                return null;
            }
        }

        public async Task<EmployeeModel> UpdateAsync(EmployeeModel employeeToUpdate)
        {
            try
            {
                var exists = await _context.Employees.AnyAsync(x => x.Id == employeeToUpdate.Id);

                if (exists == false)
                {
                    return null;
                }

                var employee = await _context.Employees.FirstAsync(x => x.Id == employeeToUpdate.Id);

                // Update proprieties
                employee.Name = employeeToUpdate.Name;
                employee.Cpf = employeeToUpdate.Cpf;
                employee.IsActive = employeeToUpdate.IsActive;
                employee.JobRole = employeeToUpdate.JobRole;

                // Update
                _context.Employees.Update(employee);
                // Savechanges
                await _context.SaveChangesAsync();

                return employee;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            try
            {
                var exists = await _context.Employees.AnyAsync(x=>x.Id == id);
                if (exists == false)
                {
                    return false;
                }

                var userToDelete = await _context.Employees.FirstAsync(x=>x.Id == id);
                _context.Employees.Remove(userToDelete);

                await _context.SaveChangesAsync();

                return true;

            }
            catch
            {
                return false;
            }
        }
    }
}
