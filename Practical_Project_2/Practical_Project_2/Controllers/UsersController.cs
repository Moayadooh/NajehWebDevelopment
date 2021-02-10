﻿using System;
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

        public string GetRoleName(List<UserRole> roleList, User user)
        {
            var list1 = roleList.Where(x => x.UserID == user.ID).ToList();
            int roleID = list1.FirstOrDefault().RoleID;
            var list2 = roleList.Where(x => x.Role.ID == roleID).ToList();
            var roleName = list2.FirstOrDefault().Role.Name;
            return roleName;
        }

        // (GET request)
        // get users details
        [Route("api/GetUserDetails")]
        public IQueryable<UserDetails> GetUserDetails()
        {
            var list = db.Users.Include(x => x.Profile).Include(y => y.UserRoles).ToList();
            var roleList = db.UserRoles.Include(x => x.Role).ToList();

            var userDetails = new List<UserDetails>();
            foreach (var item in list)
            {
                var roleName = GetRoleName(roleList, item);
                userDetails.Add(new UserDetails() { ID = item.ID, FirstName = item.Profile.FirstName, LastName = item.Profile.LastName, Email = item.Email, Role = roleName });
            }
            return userDetails.AsQueryable();
        }
        //NumOfItems = userPurchasesItem.NumOfItems.ToString(), TotalPrice = userPurchasesItem.TotalPrice.ToString(), Date = userPurchasesItem.Date.ToString("MM/dd/yyyy hh:mm tt")
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }
    }
}