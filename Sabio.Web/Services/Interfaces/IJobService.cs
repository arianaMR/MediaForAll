using System.Collections.Generic;
using System.Data;
using MediaForAll.Web.Domain;
using MediaForAll.Web.Models;

namespace MediaForAll.Web.Services
{
    public interface IJobService
    {
        int Insert(JobAddRequest model);

        List<Job> GetAllJobs();

        Job MapJob(IDataReader reader, out int JobKey);

        void Delete(int id);
    }
}