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
    public class InterestService : BaseService, IInterestService
    {

        public int Insert(ApplicationAddRequest model, int ApplicantKey)
        {
            for (int i = 0; i < model.Interest.Length; i++)
            {
                int InterestKey = 0;
                DataProvider.ExecuteNonQuery(GetConnection, "dbo.Interest_Insert", inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@InterestKey", InterestKey);
                    paramCollection.AddWithValue("@ApplicantKey", ApplicantKey);
                    paramCollection.AddWithValue("@CategoryKey", model.Interest[i].CategoryKey);
                    paramCollection.AddWithValue("@InterestLevel", model.Interest[i].InterestLevel);
                });
            }

            return ApplicantKey;
        }


        public List<Interest> GetInterestById(int id)
        {
            List<Interest> InterestList = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.Interest_Get"
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@ApplicantKey", id);
                }
                , map: delegate (IDataReader reader, short set)
                {
                    int TransactionId = 0;
                    Interest Interest = MapInterest(reader, out TransactionId);

                    if (InterestList == null)
                    {
                        InterestList = new List<Interest>();
                    }
                    InterestList.Add(Interest);
                }
                );
            return InterestList;

        }




        public Interest MapInterest(IDataReader reader, out int InterestKey)
        {
            Interest d = new Interest();
            int index = 0;
            d.InterestKey = reader.GetSafeInt32(index++);
            d.InterestLevel = reader.GetSafeInt32(index++);
            d.CategoryKey = reader.GetSafeInt32(index++);
            d.CategoryName = reader.GetSafeString(index++);

            InterestKey = d.InterestKey;

            return d;
        }




    }
}