using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Data;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Business.Implementations
{
    public class SliderRepository : ISlidersService
    {
        private readonly AppDbContext _context;

        public SliderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Slider> Get(int? id)
        {
            if(id is null)
            {
                throw new ArgumentNullException();
            }

            var data = await _context.Sliders.Where(s => !s.IsDeleted && s.Id == id).FirstOrDefaultAsync();

            if(data is null)
            {
                throw new NullReferenceException();
            }

            return data;
        }

        public async Task<List<Slider>> GetAll()
        {
            List<Slider> datas = await _context.Sliders.Where(s => !s.IsDeleted).ToListAsync();

            if(datas is null)
            {
                throw new NullReferenceException();
            }

            return datas;
        }

        public async Task Create(Slider entity)
        {
            if(entity is null)
            {
                throw new ArgumentNullException();
            }

            entity.CreatedDate = DateTime.Now;

            await _context.Sliders.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Slider entity)
        {
            if(entity is null)
            {
                throw new ArgumentNullException();
            }

            entity.UpdatedDate = DateTime.Now;
            _context.Sliders.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int? id)
        {
            var data = await Get(id);
            data.IsDeleted = true;
            await Update(data);
        }

        
    }
}
