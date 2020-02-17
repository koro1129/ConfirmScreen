using ConfirmScreen.Models;
using ConfirmScreen.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ConfirmScreen.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ConfirmScreenContext _context;

        public MoviesController(ConfirmScreenContext context)
        {
            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            var vm = new MoviewIndexViewModel()
            {
                Movies = await _context.Movie.ToListAsync(),
                GenreList = Common.GENRE_LIST,
            };
            return View(vm);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            var vm = new MoviewCreateViewModel()
            {
                Movie = new Movie(),
                GenreList = Common.GENRE_LIST,
            };

            return View(vm);
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ConfirmScreen.Filter.ConfirmAttribute]
        public async Task<IActionResult> Create(MoviewCreateViewModel createVM)
        {
            if (ModelState.IsValid)
            {
                _context.Add(createVM.Movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(createVM);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            var vm = new MoviewEditViewModel()
            {
                Movie = movie,
                GenreList = Common.GENRE_LIST,
            };
            return View(vm);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ConfirmScreen.Filter.ConfirmAttribute]
        public async Task<IActionResult> Edit(MoviewEditViewModel editVm, int id)
        {
            if (id != editVm.Movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(editVm.Movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(editVm.Movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(editVm);
        }


        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.Id == id);
        }
    }
}
