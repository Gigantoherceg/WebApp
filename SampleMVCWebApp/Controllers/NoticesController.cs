using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Models.ViewModels;

namespace Sample_MVCWebApp.Controllers
{
    public class NoticesController : Controller
    {
        private readonly NoticesService _noticeServices;

        public NoticesController(NoticesService noticeServices)
        {
            _noticeServices = noticeServices;
        }

        // GET: Notices
        public async Task<IActionResult> Index()
        {
            return View(await _noticeServices.IndexAsync());
        }

        // GET: Notices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var notice = await _noticeServices.DetailsAsync(id);
            return View(notice);
        }

        // GET: Notices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Notices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NoticeViewModel notice)
        {
            if (ModelState.IsValid)
            {
                await _noticeServices.CreateAsync(notice);
                return RedirectToAction(nameof(Index));
            }
            return View(notice);
        }

        // GET: Notices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var notice = await _noticeServices.DetailsAsync(id);
            return View(notice);
        }

        // POST: Notices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, NoticeViewModel notice)
        {
            if (id != notice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _noticeServices.UpdateAsync(notice);
                return RedirectToAction(nameof(Index));
            }
            return View(notice);
        }

        // GET: Notices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var notice = await _noticeServices.DetailsAsync(id);

            return View(notice);
        }

        // POST: Notices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _noticeServices.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> NoticeExists(int id)
        {
            if (await _noticeServices.DetailsAsync(id) is null)
            {
                return false;
            }
            return true;
        }
    }
}
