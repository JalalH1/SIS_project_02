using Microsoft.AspNetCore.Mvc;
using Project_Info_Jalal_Harb.Models;
using System.Diagnostics;

namespace Project_Info_Jalal_Harb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserRepository _userRepository;

        public HomeController(ILogger<HomeController> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
        public IActionResult SignIn()
        {
            return View();
        }
        
        public IActionResult SignUp()
        {
            return View();
        }
        
        public IActionResult Profile()
        {
            return View(_userRepository.getAllUsers());
        }

        [HttpPost]
        public IActionResult UserSearch(string search)
        {
            var filteredUsers = _userRepository.getAllUsers().Where(user =>
                user.FirstName.ToLower().Contains(search.ToLower()) ||
                user.LastName.ToLower().Contains(search.ToLower())
            ).ToList();

            return View("Profile", filteredUsers);
        }
        
        [HttpPost]
        public IActionResult UserDelete(int Id)
        {
            _userRepository.UserDelete(Id);

            return View("Profile", _userRepository.getAllUsers());
        }

        [HttpPost]
        public IActionResult AddUser(User user)
        {
            _userRepository.createUser(user);

            return View("SignIn");
        }

        [HttpPost]
        public IActionResult CheckCredentials(string email, string password)
        {
            if (_userRepository.userSignIn(email, password))
            {
                return View("Profile", _userRepository.getAllUsers());
            } else
            {
                ViewBag.error = "Wrong email or password";
                return View("SignIn");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
