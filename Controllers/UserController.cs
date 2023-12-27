using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TelegeramHappyBirthday.Jobs;
using TelegeramHappyBirthday.Models;

namespace TelegeramHappyBirthday.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        [HttpGet]
        public IEnumerable<User> Get()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.Users.ToList();
            }

        }
        [HttpGet("Start")]
        public IActionResult Start()
        {
            StartSheduler();
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult Get_Id(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Id == id);
                return Ok(user);
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] User user) 
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
                return Ok(user);
            }  
        }

        public async Task StartSheduler()
        {
            UserSheduler userSheduler = new UserSheduler();
            await Task.Run(() => userSheduler.Start());
        }

        [HttpPut]
        public IActionResult Put([FromBody] User user)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var userId = db.Users.FirstOrDefault(p => p.Id == user.Id);
                if (userId == null)
                {
                    return NotFound();
                }
                else
                {
                    userId.Name = user.Name != null ? user.Name : userId.Name;
                    userId.Surname = user.Surname != null ? user.Surname : userId.Surname;
                    userId.HappyBirthday = user.HappyBirthday != null ? user.HappyBirthday : userId.HappyBirthday;
                    userId.Post = user.Post != null ? user.Post : userId.Post;
                    db.Users.Update(userId);
                    db.SaveChanges();
                    return Ok(userId);
                }
            }
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Id == id);
                db.Users.Remove(user);
                db.SaveChanges();
                return Ok();
            }
        }
    }
}
