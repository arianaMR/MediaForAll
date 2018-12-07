using MediaForAll.Data;
using MediaForAll.Web.Domain;
using MediaForAll.Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MediaForAll.Web.Services
{
    public class ExperienceService : BaseService, IExperienceService
    {

        public int Insert(ApplicationAddRequest model, int ApplicantKey)
        {
            for (int i = 0; i < model.Experience.Length; i++)
            {
                int ExperienceKey = 0;
                DataProvider.ExecuteNonQuery(GetConnection, "dbo.Experience_Insert", inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@ExperienceKey", ExperienceKey);
                    paramCollection.AddWithValue("@ApplicantKey", ApplicantKey);
                    paramCollection.AddWithValue("@CategoryKey", model.Experience[i].CategoryKey);
                    paramCollection.AddWithValue("@ExperienceLevel", model.Experience[i].ExperienceLevel);
                });
            }

            return ApplicantKey;
        }




        public List<Experience> GetExperienceById(int id)
        {
            List<Experience> experienceList = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.Experience_Get"
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@ApplicantKey", id);
                }
                , map: delegate (IDataReader reader, short set)
                {
                    int TransactionId = 0;
                    Experience experience = MapExperience(reader, out TransactionId);

                    if (experienceList == null)
                    {
                        experienceList = new List<Experience>();
                    }
                    experienceList.Add(experience);
                }
                );
            return experienceList;

        }


   

        public Experience MapExperience(IDataReader reader, out int ExperienceKey)
        {
            Experience d = new Experience();
            int index = 0;
            d.ExperienceKey = reader.GetSafeInt32(index++);
            d.ExperienceLevel = reader.GetSafeInt32(index++);
            d.CategoryKey = reader.GetSafeInt32(index++);
            d.CategoryName = reader.GetSafeString(index++);

            ExperienceKey = d.ExperienceKey;

            return d;
        }


    }
}