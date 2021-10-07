using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccesslayer;
using DataAccesslayer.Models;

namespace Service_Layer.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class JobsController : Controller
    {
        InterviewTestRepository repository;
        public JobsController()
        {
            repository = new InterviewTestRepository();
        }
        [HttpGet]
        public JsonResult GetAllJobs()
        {
            List<Job> jobs = new List<Job>();
            try
            {
                jobs = repository.GetAllJobs();
            }
            catch(Exception ex)
            {
                jobs = null;
            }
            return Json(jobs);
        }
        [HttpGet("{id:int}")]
        public JsonResult GetJobsById(int id)
        {
            Job jobs = new Job();
            try
            {
                jobs = repository.GetJobsById(id);
            }
            catch (Exception ex)
            {
                jobs = null;
            }
            return Json(jobs);
        }

        [HttpPost]
        public JsonResult AddJob(Job job)
        {
            int status = -1;
            string message;
            try
            {
                status = repository.AddJob(job);
                if(status > 0)
                {
                    message = "200 http://localhost/api/v1/jobs/" + status;
                }
                else
                {
                    message = "Error";
                }
            }
            catch(Exception ex)
            {
                message = "Fatal Error";
            }
            return Json(message);
        }

        [HttpPut("{id:int}")]
        public JsonResult Updatejob(int id,Job job)
        {
            int status = 0;
            string message;
            try
            {
                job.Id = id;
                status = repository.UpdateJob(job);
                if (status == 1)
                {
                    message = "200 Ok";
                }
                else
                {
                    message = "error";
                }
            }
            catch(Exception e)
            {
                message = e.Message;

            }
            return Json(message);
        }
        
    }
}
