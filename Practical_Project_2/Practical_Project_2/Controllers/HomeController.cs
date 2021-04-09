using Newtonsoft.Json;
using Practical_Project_2.Models;
using Practical_Project_2.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;

namespace Practical_Project_2.Controllers
{
    public class HomeController : Controller
    {
        private ShoppingDB db = new ShoppingDB();

        [HttpGet]
        public ActionResult Register()
        {
            if (Session["role"] != null)
                Response.Redirect("~/" + Session["role"] + "/Index");
            return View();
        }

        public bool IsEmailExist(string email)
        {
            return db.Users.Count(x => x.Email == email) > 0;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserViewModel userViewModel)
        {
            try
            {
                Guid userID = Guid.NewGuid();
                User user = new User
                {
                    ID = userID,
                    Email = userViewModel.Email,
                    Password = MiscCode.PassHasher(userViewModel.Password)
                };
                Profile profile = new Profile
                {
                    UserID = userID,
                    FirstName = userViewModel.FirstName,
                    LastName = userViewModel.LastName,
                };
                UserRole userRole = new UserRole
                {
                    UserID = userID,
                    RoleID = 1
                };
                if (IsEmailExist(user.Email))
                    ModelState.AddModelError("Email", "Email is already taken, try another one!");
                if (ModelState.IsValid)
                {
                    db.Users.Add(user);
                    db.Profiles.Add(profile);
                    db.UserRoles.Add(userRole);
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e);
            }
            return View();
        }

        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            if (Session["role"] != null)
                Response.Redirect("~/" + Session["role"] + "/Index");
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        public string GetRoleName(User user)
        {
            int roleID = user.UserRoles.FirstOrDefault().RoleID;
            var listOfRoles = db.Roles.Where(x => x.ID == roleID).ToList();
            return listOfRoles.FirstOrDefault().Name;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserViewModel userViewModel, string returnUrl)
        {
            bool isCapthcaValid = ValidateCaptcha(Request["g-recaptcha-response"]);
            if (isCapthcaValid)
            {
                if (ModelState.IsValidField("Email") && ModelState.IsValidField("Password"))
                {
                    string passwordHash = MiscCode.PassHasher(userViewModel.Password);
                    var model = db.Users.SingleOrDefault(x => x.Email == userViewModel.Email && x.Password == passwordHash);
                    if (model == null)
                        ViewBag.error = "Please Verify Email and Password";
                    else
                    {
                        Session["profile"] = model;
                        Session["role"] = GetRoleName(model);
                        return RedirectToAction("Index", (string)Session["role"]);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("g-recaptcha", "You have put wrong Captcha,Please ensure the authenticity!!!");
                ModelState.Remove("Password"); //reset password field
                return View(); //should load sitekey again
            }
            return View();
        }

        public bool ValidateCaptcha(string response)
        {
            // Setting _Setting = repositorySetting.GetSetting;
            // secret that was generated in key value pair  
            string secret = ConfigurationManager.AppSettings["GoogleSecretkey"]; //WebConfigurationManager.AppSettings["recaptchaPrivateKey"];
            var client = new WebClient();
            var reply = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, response));
            var captchaResponse = JsonConvert.DeserializeObject<CaptchaResponse>(reply);
            return Convert.ToBoolean(captchaResponse.Success);
        }

        public ActionResult Logout()
        {
            Session["profile"] = null;
            Session["role"] = null;
            return RedirectToAction("Login", "Home");
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult LoginWithGoogle(List<UserIntegrationLogin> user)
        {
            if (user != null)
            {
                Session["Name"] = user[0].Name;
                Session["Email"] = user[0].Email;
                string email = (string)Session["Email"];
                var redirectUrl = "";
                var model = db.Users.SingleOrDefault(x => x.Email == email);
                if (model != null)
                {
                    Session["profile"] = model;
                    Session["role"] = GetRoleName(model);
                    Session["Name"] = null;
                    Session["Email"] = null;
                    redirectUrl = new UrlHelper(Request.RequestContext).Action("Index", (string)Session["role"]);
                    return Json(new { Url = redirectUrl });
                }
                //return RedirectToAction("CreatePassword", "Home");
                redirectUrl = new UrlHelper(Request.RequestContext).Action("CreatePassword", "Home");
                return Json(new { Url = redirectUrl });
            }
            return Json("Something went wrong");
        }

        public ActionResult CreatePassword()
        {
            if (Session["Name"] == null || Session["Email"] == null)
                return RedirectToAction("Login", "Home");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePassword(UserPasswordConfirmation userPasswordConfirmation)
        {
            try
            {
                Guid userID = Guid.NewGuid();
                string passwordHash = MiscCode.PassHasher(userPasswordConfirmation.Password);
                string name = (string)Session["Name"];
                string email = (string)Session["Email"];
                User user = new User
                {
                    ID = userID,
                    Email = email,
                    Password = passwordHash
                };
                Profile profile = new Profile
                {
                    UserID = userID,
                    FirstName = name,
                    LastName = null
                };
                UserRole userRole = new UserRole
                {
                    UserID = userID,
                    RoleID = 1
                };
                if (ModelState.IsValid)
                {
                    db.Users.Add(user);
                    db.Profiles.Add(profile);
                    db.UserRoles.Add(userRole);
                    db.SaveChanges();

                    var model = db.Users.SingleOrDefault(x => x.Email == email && x.Password == passwordHash);
                    Session["profile"] = model;
                    Session["role"] = GetRoleName(model);
                    Session["Name"] = null;
                    Session["Email"] = null;
                    return RedirectToAction("Index", Session["role"]);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e);
            }
            return View();
        }

        public ActionResult SaveLanguageToCookies(string lang)
        {
            if (lang != null)
            {
                HttpCookie ck = new HttpCookie("currentlang");
                ck.Value = lang;
                ck.Expires = DateTime.Now.AddMinutes(10);
                Response.Cookies.Add(ck);
            }
            return RedirectToAction("index", "Home");
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Products()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactViewModel contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var body = "<p> Email From : {0} - ({1})</p><p>Message:</p><p>{2}</p> ";
                    var message = new MailMessage();
                    message.To.Add(new MailAddress("moayadarss97@gmail.com")); //info@yourdomain
                    message.From = new MailAddress("moayad.soft@outlook.com");
                    message.Subject = "Test Message";
                    message.Body = string.Format(body, contact.UserEmail, contact.UserName, contact.UserMessage);
                    message.IsBodyHtml = true;

                    using (var smtp = new SmtpClient())
                    {
                        var crd = new NetworkCredential()
                        {
                            UserName = "moayad.soft@outlook.com",
                            Password = ""
                        };
                        smtp.Credentials = crd;
                        smtp.Host = "smtp-mail.outlook.com";
                        smtp.Port = 587;
                        smtp.EnableSsl = true;
                        smtp.Send(message);
                    }
                }
                return RedirectToAction("Sent");
            }
            catch (Exception)
            {
                //throw;
                return View();
            }
        }

        public ActionResult Sent()
        {
            return View();
        }

        public ActionResult FAQ()
        {
            return View();
        }
    }
}