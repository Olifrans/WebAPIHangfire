using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIHangfire.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HangfireController : ControllerBase
    {


        //// GET: HangfireController
        //[HttpGet]
        //public IActionResult Get()
        //{
        //    return Ok("Teste API Hangfire WebApi");
        //}




        //POST: HangfireController
       [HttpPost]
       [Route("[action]")]
        public IActionResult BemVimdos()
        {
            var jobId = BackgroundJob.Enqueue(() => SendBemVimdosEmail("Bem vimdos entre com seu email"));    
            return Ok($"Job ID:{jobId}. Bem vimdos entre com seu email!");
        }


        //POST: HangfireController
        [HttpPost]
        [Route("[action]")]
        public IActionResult Discount()
        {
            int timeInSeconds = 30;
            var jobId = BackgroundJob.Schedule(() => SendBemVimdosEmail("Bem vimdos entre com seu email"), TimeSpan.FromSeconds(timeInSeconds));
            return Ok($"Job ID:{jobId}. Discount email em {timeInSeconds} segundos!");
        }


        //POST: HangfireController
        [HttpPost]
        [Route("[action]")]
        public IActionResult DatabaseUpdate()
        {
            RecurringJob.AddOrUpdate(() => Console.WriteLine("Database update"), Cron.Minutely);

            return Ok("Database check job initiated!");
        }


        public void SendBemVimdosEmail(string text)
        {
            Console.WriteLine(text);
        }

    }
}
