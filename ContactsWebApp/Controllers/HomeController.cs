using ContactsWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ContactsWebApp.Data;

namespace ContactsWebApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

        private readonly ContactsAppDbContext _contactsAppDbContext;

        public HomeController(ILogger<HomeController> logger, ContactsAppDbContext contactsAppDbContext)
        {
            _logger = logger;
            _contactsAppDbContext = contactsAppDbContext;
        }

		public IActionResult Index(string? id)
        {
            var mainVM = new MainViewModel();
            Contact? selectedContact = null;
            if (!string.IsNullOrWhiteSpace(id))
            {
                selectedContact = _contactsAppDbContext.Contacts.Find(new Guid(id));
            }

            mainVM.Contacts = _contactsAppDbContext.Contacts.ToList();
            mainVM.SelectContact = selectedContact;
            mainVM.BirthdayContacts = _contactsAppDbContext.Contacts.Where(
                contact => contact.Birthday.Day == DateTime.Now.Day
                           && contact.Birthday.Month == DateTime.Now.Month)
                .ToList();
            return View(mainVM);
		}

        public IActionResult GetContact(string? id)
        {
            Contact? selectedContact = null;
            if (!string.IsNullOrWhiteSpace(id))
            {
                selectedContact = _contactsAppDbContext.Contacts.Find(new Guid(id));
            }

            return Json(selectedContact);
        }

        public IActionResult Privacy()
		{
			return View();
		}

        public IActionResult AddContact()
        {
            ViewBag.Title = "Add Contact";
            return View("AddEdit", new Contact());
        }

        public IActionResult EditContact(string id)
        {
            var contact = new Contact();
            if (!string.IsNullOrWhiteSpace(id))
            {
                contact = _contactsAppDbContext.Contacts.Find(new Guid(id));
            }

            ViewBag.Title = "Edit Contact";
            return View("AddEdit", contact);
        }

        [HttpGet]
        public IActionResult RemoveContact(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                Contact customer = new Contact()
                {
                    Id = new Guid(id)
                };
                _contactsAppDbContext.Contacts.Attach(customer);
                _contactsAppDbContext.Contacts.Remove(customer);
                _contactsAppDbContext.SaveChanges();
            }

            var result = new { Success = "True" };
            return Json(result);
        }

        [HttpPost]
        public IActionResult SaveChange(Contact contact)
        {
            if (_contactsAppDbContext.Contacts.Contains(contact))
            {
                _contactsAppDbContext.Contacts.Update(contact);
            }
            else
            {
                _contactsAppDbContext.Contacts.Add(contact);
            }

            _contactsAppDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult CancelChange()
        {
            return RedirectToAction(nameof(Index));
        }

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}