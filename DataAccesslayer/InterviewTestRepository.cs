using DataAccesslayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace DataAccesslayer
{
    public class InterviewTestRepository
    {
        InterviewTestContext context;
        static int count = 0;
        public InterviewTestRepository()
        {
            context = new InterviewTestContext();
        }

        public List<Job> GetAllJobs()
        {
            List<Job> jobList = null;
            try
            {
                jobList = context.Jobs.OrderBy(c => c.Id).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occured" + e);
            }
            return jobList;
        }

        public Job GetJobsById(int id)
        {
            Job job = null;
            try
            {
                job = context.Jobs.Where(p => p.Id == id).FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occured" + e);
            }
            return job;
        }

        public List<Department> GetAllDepartments()
        {
            List<Department> departmentList = null;
            try
            {
                departmentList = context.Departments.OrderBy(c => c.Id).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occured" + e);
            }
            return departmentList;
        }

        public Department GetDepartments(Decimal? id)
        {
            Department department = null;
            try
            {
                department = context.Departments.Where(p => p.Id == id).OrderBy(c => c.Id).FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occured" + e);
            }
            return department;
        }

        public Location GetLocation(Decimal? id)
        {
            Location location = null;
            try
            {
                location = context.Locations.Where(p => p.Id == id).OrderBy(c => c.Id).FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occured" + e);
            }
            return location;
        }

        public List<Location> GetAllLocation()
        {
            List<Location> locationList = null;
            try
            {
                locationList = context.Locations.OrderBy(c => c.Id).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occured" + e);
            }
            return locationList;
        }

        public int AddJob(Job jobs)
        {
            int status = -1;
            try
            {
                jobs.Code = "Job-" + count;
                context.Jobs.Add(jobs);
                context.SaveChanges();
                Job j = context.Jobs.Where(f => f.Code == jobs.Code).LastOrDefault();
                status = (int)j.Id;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Some Error Occured " + ex);
                status = 0;
            }

            return status;
        }

        public bool AddLocations(params Location[] location)
        {
            bool status = false;
            try
            {
                context.Locations.AddRange(location);
                context.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Some Error Occured " + ex);
                status = false;
            }

            return status;
        } 
        public bool Addlocation(Location location)
        {
            bool status = false;
            try
            {
                context.Locations.Add(location);
                context.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Some Error Occured " + ex);
                status = false;
            }

            return status;
        } 
        public bool AddJobs(params Job[] jobs)
        {
            bool status = false;
            try
            {
                context.Jobs.AddRange(jobs);
                context.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Some Error Occured " + ex);
                status = false;
            }

            return status;
        } 
        public bool AddDepartment(Department department)
        {
            bool status = false;
            try
            {
                context.Departments.Add(department);
                context.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Some Error Occured " + ex);
                status = false;
            }

            return status;
        }
        public bool AddDepartments(params  Department[] department)
        {
            bool status = false;
            try
            {
                context.Departments.AddRange(department);
                context.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Some Error Occured " + ex);
                status = false;
            }

            return status;
        }

        public int UpdateJob(Job job)
        {
            int status = 0;
            Job updatejob = context.Jobs.Where(j => j.Id == job.Id).FirstOrDefault();
            try
            {
                if (updatejob != null)
                {
                    updatejob.Description = job.Description;
                    updatejob.ClosedDate = job.ClosedDate;
                    updatejob.LocationId = job.LocationId;
                    updatejob.DepartmentId = job.DepartmentId;
                    using(var newcontext = new InterviewTestContext())
                    {
                        newcontext.Jobs.Update(updatejob);
                        newcontext.SaveChanges();
                        status = 1;
                    }
                }
                else
                {
                    return status;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Some error occured" + ex);
                status = 0;
            }
            return status;
        }

    }
}