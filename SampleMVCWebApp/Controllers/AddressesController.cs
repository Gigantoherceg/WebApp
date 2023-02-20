using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Models;
using Services.Models.ViewModels;

namespace Sample_MVCWebApp.Controllers
{
    public class AddressesController : Controller
    {
        private readonly AddressService _addressServices;

        public AddressesController(AddressService addressServices)
        {
            _addressServices= addressServices;
        }

        // GET: Addresses
        public async Task<IActionResult> Index()
        {
            return View(await  _addressServices.IndexAsync());
        }

        // GET: Addresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var address = await _addressServices.DetailsAsync(id);
            return View(address);
        }

        // GET: Addresses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Addresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddressViewModel address)
        {
            if (ModelState.IsValid)
            {
                await _addressServices.CreateAsync(address);
                return RedirectToAction(nameof(Index));
            }
            return View(address);
        }

        // GET: Addresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var address = await _addressServices.DetailsAsync(id);
            return View(address);
        }

        // POST: Addresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AddressViewModel addressViewModel)
        {
            if (id != addressViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _addressServices.UpdateAsync(addressViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(addressViewModel);
        }

        // GET: Addresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var address = await _addressServices.DetailsAsync(id);

            return View(address);
        }

        // POST: Addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _addressServices.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> AddressExists(int id)
        {
            if (await _addressServices.DetailsAsync(id) is null)
            {
                return false;
            }
            return true;
        }
    }
}
