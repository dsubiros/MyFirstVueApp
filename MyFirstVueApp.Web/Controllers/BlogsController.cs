using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFirstVueApp.Database.DTOs;
using MyFirstVueApp.Database.Models;

namespace MyFirstVueApp.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("MyPolicy")]
    public class Blogs : ControllerBase
    {

        // private readonly BloggingContext _context;
        private readonly IMapper _mapper;
        public Blogs(IMapper mapper)
        {
            _mapper = mapper;
        }
        
        // GET
        public async Task<IActionResult> Index()
        {
            try
            {
                await using var ctx = new BloggingContext();

                // using (var ctx = new BloggingContext())
                // {
                //     var item = await ctx.Blogs.FirstOrDefaultAsync();
                //     return Ok(_mapper.Map<IEnumerable<BlogDto>>(item).ToList());
                // }
                
                // var items = await ctx.Blogs
                //     // .Include(x => x.Posts)
                //     .ToListAsync();
                // var item = await ctx.Blogs.FirstOrDefaultAsync();
                // return Ok(_mapper.Map<IEnumerable<BlogDto>>(item).ToList());
                
                var items = await ctx.Blogs
                    .Include(x => x.Posts)
                    .ToListAsync();
                return Ok(_mapper.Map<IEnumerable<Blog>>(items));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}