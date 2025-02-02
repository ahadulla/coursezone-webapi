﻿using CourseZone.DataAccsess.Utils;
using CourseZone.Domain.Entites.Courses;
using CourseZone.Service.Dtos.Categories;
using CourseZone.Service.Dtos.Courses;

namespace CourseZone.Service.Interfaces.Courses;

public interface ICourseTypeService
{
    public Task<bool> CreateAsync(CourseTypeCreateDto dto);

    public Task<bool> DeleteAsync(long TypeId);

    public Task<long> CountAsync();

    public Task<IList<CourseType>> GetAllAsync(PaginationParams @params);

    public Task<CourseType> GetByIdAsync(long TypeId);

    public Task<bool> UpdateAsync(long TypeId, CourseTypeUpdateDto dto);
}
