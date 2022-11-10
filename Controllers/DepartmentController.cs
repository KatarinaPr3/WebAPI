using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApplication4.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DepartmentDbContext _context;
        public DepartmentController(DepartmentDbContext context) => _context = context;

        [HttpGet]
        public async Task<IEnumerable<Department>> Get()
           => await _context.Departments.ToListAsync();
        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            return department == null ? NotFound() : Ok(department);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Department department)
        {
            await _context.Departments.AddAsync(department);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = department.DepartmentId }, department);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Department department)
        {
            if (id != department.DepartmentId) return BadRequest();
            _context.Entry(department).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var departmentDelete = await _context.Departments.FindAsync(id);
            if (departmentDelete == null) return NotFound();

            _context.Departments.Remove(departmentDelete);
            await _context.SaveChangesAsync();
            return NoContent();
          
        }

    }
}
