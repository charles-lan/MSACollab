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
using NotificationSignalR.Models;

namespace NotificationSignalR.Controllers
{
    public class UserNotificationsController : ApiController
    {
        private NotificationSignalRContext db = new NotificationSignalRContext();

        // GET: api/UserNotifications
        public IQueryable<UserNotification> GetUserNotifications()
        {
            return db.UserNotifications;
        }

        //// GET: api/UserNotifications/5 ORIGINAL
        //[ResponseType(typeof(UserNotification))]
        //public IHttpActionResult GetUserNotification(int id)
        //{
        //    UserNotification userNotification = db.UserNotifications.Find(id);
        //    if (userNotification == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(userNotification);
        //}


        // GET: api/UserNotifications/5
        public IHttpActionResult GetUserNotification(int id)
        {
            var userNotificationss = db.UserNotifications
                .Include(a => a.Notification)
                .Where(b => b.UserId == id);


            if (userNotificationss == null)
            {
                return NotFound();
            }

            return Ok(userNotificationss);
        }



        // PUT: api/UserNotifications/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserNotification(int id, UserNotification userNotification)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userNotification.UsrNID)
            {
                return BadRequest();
            }

            db.Entry(userNotification).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserNotificationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/UserNotifications
        [ResponseType(typeof(UserNotification))]
        public IHttpActionResult PostUserNotification(UserNotification userNotification)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserNotifications.Add(userNotification);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = userNotification.UsrNID }, userNotification);
        }

        // DELETE: api/UserNotifications/5
        [ResponseType(typeof(UserNotification))]
        public IHttpActionResult DeleteUserNotification(int id)
        {
            UserNotification userNotification = db.UserNotifications.Find(id);
            if (userNotification == null)
            {
                return NotFound();
            }

            db.UserNotifications.Remove(userNotification);
            db.SaveChanges();

            return Ok(userNotification);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserNotificationExists(int id)
        {
            return db.UserNotifications.Count(e => e.UsrNID == id) > 0;
        }
    }
}