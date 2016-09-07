using System.Linq;
using System.Threading.Tasks;
using ContactManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactsManager.Controllers
{
	public class ContactsController : Controller
	{
		private ContactsDbContext _dbContext;
		public ContactsController (ContactsDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public IActionResult Index()
		{
			return View(_dbContext.Contacts);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(Contact contact)
		{
			if(ModelState.IsValid)
			{
				_dbContext.Contacts.Add(contact);
				await _dbContext.SaveChangesAsync();

				return RedirectToAction("Index");
			}

			return View(contact);
		}
		[HttpGet]
		public IActionResult Edit(int id)
		{
			var contact = _dbContext.Contacts.FirstOrDefault(c => c.ContactId == id);

			if(contact == null)
				return NotFound();

			return View(contact);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(Contact contact)
		{
			if(ModelState.IsValid){
				_dbContext.Contacts.Update(contact);
				await _dbContext.SaveChangesAsync();

				return RedirectToAction("Index");
			}

			return View(contact);
		}

		[HttpGet]
		public IActionResult Delete(int id)
		{
			var contact = _dbContext.Contacts.FirstOrDefault(c => c.ContactId == id);

			if(contact == null)
				return NotFound();

			return View(contact);
		}
		[HttpPost]
		public async Task<IActionResult> Destroy(int id)
		{
			var contact = _dbContext.Contacts.FirstOrDefault(c => c.ContactId == id);

			if(contact == null)
				return NotFound();
			
			_dbContext.Contacts.Remove(contact);
			await _dbContext.SaveChangesAsync();

			return RedirectToAction("Index");
		}
		
	}
}