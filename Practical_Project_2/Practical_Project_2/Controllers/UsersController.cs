using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Practical_Project_2.Models;
using Practical_Project_2.ViewModel;

namespace Practical_Project_2.Controllers
{
    public class UsersController : ApiController
    {
        private ShoppingDB db = new ShoppingDB("");

        // (GET request)
        // get users and purchased items for each user
        [Route("api/GetUsersItemsPurchases")]
        public IQueryable<UsersItemsPurchases> GetUsersItemsPurchases()
        {
            var list = db.Users.Include(x => x.UserPurchases).Include(y => y.Profile).ToList();
            var usersItemsPurchases = new List<UsersItemsPurchases>();
            foreach (var item in list)
            {
                if (item.UserPurchases.Count == 0)
                    usersItemsPurchases.Add(new UsersItemsPurchases() { FirstName = item.Profile.FirstName, LastName = item.Profile.LastName, Email = item.Email, NumOfItems = "-", TotalPrice = "-", Date = "-" });
                foreach (var userPurchasesItem in item.UserPurchases)
                {
                    usersItemsPurchases.Add(new UsersItemsPurchases() { FirstName = item.Profile.FirstName, LastName = item.Profile.LastName, Email = item.Email, NumOfItems = userPurchasesItem.NumOfItems.ToString(), TotalPrice = userPurchasesItem.TotalPrice.ToString(), Date = userPurchasesItem.Date.ToString("MM/dd/yyyy hh:mm tt") });
                }
            }
            return usersItemsPurchases.AsQueryable();

            //var records = usersItemsPurchases.ToList();
            //switch (sortColumn)
            //{
            //    case "FirstName":
            //        records = records.OrderBy(x => x.FirstName).ToList();
            //        break;
            //    case "LastName":
            //        records = records.OrderBy(x => x.LastName).ToList();
            //        break;
            //    case "Email":
            //        records = records.OrderBy(x => x.Email).ToList();
            //        break;
            //    case "NumOfItems":
            //        records = records.OrderBy(x => x.NumOfItems).ToList();
            //        break;
            //    case "TotalPrice":
            //        records = records.OrderBy(x => x.TotalPrice).ToList();
            //        break;
            //    case "Date":
            //        records = records.OrderBy(x => x.Date).ToList();
            //        break;
            //    default:
            //        break;
            //}

            //if (!string.IsNullOrEmpty(filter1))
            //{
            //    filter1 = filter1.ToLower();
            //    records = records.Where(x => x.FirstName.ToLower().Contains(filter1) || x.LastName.ToLower().Contains(filter1) || x.Email.ToLower().Contains(filter1) || x.NumOfItems.ToLower().Contains(filter1) || x.TotalPrice.ToLower().Contains(filter1) || x.Date.ToLower().Contains(filter1)).ToList();
            //}

            //if (itemsPerPage == -1)
            //    records = records.ToList(); // get all items
            //else
            //{
            //    int itemsToSkip = pageNum * itemsPerPage - itemsPerPage;
            //    records = records.Skip(itemsToSkip).Take(itemsPerPage).ToList();
            //}

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }
    }
}