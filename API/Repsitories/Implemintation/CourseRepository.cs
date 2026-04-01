using API.Models.Domain;
using API.Models.DTOs;
using API.Repsitories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace API.Repsitories.Implemintation
{
    public class CourseRepository : ICourseRepository
    {
        private readonly DatabaseContext _db;
        public CourseRepository(DatabaseContext db) 
        {
          _db = db;
        }

        public async Task<bool> AddUpdate(CourseDto courseDto)
        {
            Course course = new Course
            {
                Id = courseDto.Id,
                Name = courseDto.Name,
                Description = courseDto.Description,
                DepartmentId = courseDto.DepartmentId,
                CreationDate = courseDto.CreationDate,
                UpdateDate = courseDto.UpdateDate,
            };
            try
            {
                if(course.Id == 0)
                {
                    course.CreationDate = DateTime.Now;
                    await _db.Courses.AddAsync(course);
                }
                else
                {
                    course.UpdateDate = DateTime.Now;
                    _db.Courses.Update(course);
                }
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> Delete(int Id)
        {
            try
            {
                var record = await _db.Courses.FirstOrDefaultAsync(co => co.Id == Id);
                if (record == null)
                    return false;
                _db.Courses.Remove(record);
                await _db.SaveChangesAsync();
                return true;
                
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<CourseDto>> GetAll()
        {
            try
            {
                List<CourseDto>  result = await _db.Courses.Select(course => new CourseDto
                {
                    Id = course.Id,
                    Name = course.Name,
                    Description = course.Description,
                    DepartmentId = course.DepartmentId,
                    CreationDate = course.CreationDate,
                    UpdateDate = course.UpdateDate,
                    Department = new DepartmentDto 
                    {
                      Id = course.Department.Id,
                      Name = course.Department.Name,
                      Description = course.Department.Description,
                      IconClass = course.Department.IconClass
                    }
                }).ToListAsync();
                return result;
            }
            catch (Exception)
            {

                return null;
            }
            
        }

        public async Task<CourseDto> GetById(int Id)
        {
            var result =  await _db.Courses.Where(course => course.Id == Id).Select(course => new CourseDto
            {
                Id = course.Id,
                Name = course.Name,
                Description = course.Description,
                DepartmentId = course.DepartmentId,
                CreationDate = course.CreationDate,
                UpdateDate = course.UpdateDate,
                Department = new DepartmentDto
                {
                    Id = course.Department.Id,
                    Name = course.Department.Name,
                    Description = course.Department.Description,
                    IconClass = course.Department.IconClass
                }
            }).FirstOrDefaultAsync()?? new CourseDto();

            return result;
        }

        public async Task<List<CourseDto>> GetCoursesByDepartmentId(int DepartmentId)
        {
            List<CourseDto> result =  await _db.Courses
                .Where(course => course.DepartmentId == DepartmentId)
                .Select(course => new CourseDto
                {
                 Id = course.Id,
                 Name = course.Name,
                 Description = course.Description,
                 DepartmentId = course.DepartmentId,
                 CreationDate = course.CreationDate,
                 UpdateDate = course.UpdateDate
                })
                .ToListAsync();

            return result;
        }
    }
}
