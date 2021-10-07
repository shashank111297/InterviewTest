using DataAccesslayer;
using DataAccesslayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service_Layer.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LocationController : Controller
    {
        InterviewTestRepository repository;
        public LocationController()
        {
            repository = new InterviewTestRepository();
        }
        [HttpGet]
        public JsonResult GetAllJobs()
        {
            List<Location> jobs = new List<Location>();
            try
            {
                jobs = repository.GetAllLocation();
            }
            catch (Exception ex)
            {
                jobs = null;
            }
            return Json(jobs);
        }
    }
}
