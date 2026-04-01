using API.Models.Domain;
using API.Models.DTOs;
using API.Repsitories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace API.Repsitories.Implemintation
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DatabaseContext _db;
        public DepartmentRepository(DatabaseContext db) 
        {
            _db= db;
        }
        public async Task <bool> AddUpdateDepartment(Department department)
        {
            try
            {
                if(department.Id == 0)
                {
                   await _db.Departments.AddAsync(department);
                }
                else
                {
                    _db.Departments.Update(department);
                }
               await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task <bool> DeleteDepartment(int Id)
        {
            try
            {
                var record = await _db.Departments.FirstOrDefaultAsync(dep => dep.Id == Id);
                if (record == null)
                    return false;
                _db.Departments.Remove(record);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task <List<DepartmentDto>> GetAllDepartment()
        {
            List<DepartmentDto> result = await _db.Departments.Select(dep => new DepartmentDto
            {
                Id = dep.Id,
                Name = dep.Name,
                Description = dep.Description,
                IconClass = dep.IconClass,
            }).ToListAsync();
            //return await _db.Departments.ToListAsync();
            return result;
        }

        public async Task<List<DepartmentLookupDto>> GetAllDepartmentLookup()
        {
            List<DepartmentLookupDto> result = await _db.Departments.Select(dep => new DepartmentLookupDto
            {
                Id = dep.Id,
                Name = dep.Name
           
            }).ToListAsync();
            return result;
        }

        public async Task <DepartmentDto> GetDepartmentById(int Id)
        {
            var result = await _db.Departments.FirstOrDefaultAsync(dep => dep.Id == Id);
            if (result == null)
                return null;
            return new DepartmentDto {
             Id = result.Id,
             Name = result.Name,
             Description = result.Description,
             IconClass = result.IconClass,
            };
        }
    }
}
