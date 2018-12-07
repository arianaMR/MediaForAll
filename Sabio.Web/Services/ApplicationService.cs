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
    public class ApplicationService : BaseService, IApplicationService
    {
        IInterestService _interestService = null;
        IExperienceService _experienceService = null;
        public ApplicationService(
                IInterestService interestService,
                IExperienceService experienceService
        )
        {
            _interestService = interestService;
            _experienceService = experienceService;
        }

        public int Insert(ApplicationAddRequest model)
        {
            int ApplicantKey = 0;
            int CredentialKey = 0;
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Applicant_Insert", inputParamMapper: delegate (SqlParameterCollection paramCollection)
            {
                paramCollection.AddWithValue("@FirstName", model.FirstName);
                paramCollection.AddWithValue("@LastName", model.LastName);
                paramCollection.AddWithValue("@Phone", model.Phone);
                paramCollection.AddWithValue("@Email", model.Email);
                paramCollection.AddWithValue("@CredentialKey", CredentialKey);
                paramCollection.AddWithValue("@UserName", model.UserName);
                paramCollection.AddWithValue("@Password", model.Password);
                paramCollection.AddWithValue("@IsAdmin", model.IsAdmin);
                SqlParameter p = new SqlParameter("@ApplicantKey", System.Data.SqlDbType.Int);
                p.Direction = System.Data.ParameterDirection.Output;
                paramCollection.Add(p);
            }, returnParameters: delegate (SqlParameterCollection param) 
            {
                int.TryParse(param["@ApplicantKey"].Value.ToString(), out ApplicantKey);
            }
               );

            int InsertExperience = _interestService.Insert(model, ApplicantKey);
            int InsertInterest = _interestService.Insert(model, ApplicantKey);

            return ApplicantKey;
        }


        public List<Applicant> GetAllApplicants()
        {
            List<Applicant> applicantList = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.Applicant_GetAll"
                , inputParamMapper: null
                , map: delegate (IDataReader reader, short set)
                {
                    int transactionId = 0;
                    Applicant applicant = MapApplicant(reader, out transactionId);

                    if (applicantList == null)
                    {
                        applicantList = new List<Applicant>();
                    }
                    
                    applicant.Experience = _experienceService.GetExperienceById(applicant.ApplicantKey);
                    applicant.Interest = _interestService.GetInterestById(applicant.ApplicantKey);

                    applicantList.Add(applicant);
                }
                );
            return applicantList;
        }


        public Applicant GetApplicantById(int id)
        {
            Applicant applicant = new Applicant();
            int TransactionId = 0;
            DataProvider.ExecuteCmd(GetConnection, "dbo.Applicant_Get"
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@ApplicantKey", id);
                }, map: delegate (IDataReader reader, short set)
                {
                    applicant = MapApplicant(reader, out TransactionId);
                    applicant.Experience = _experienceService.GetExperienceById(applicant.ApplicantKey);
                    applicant.Interest = _interestService.GetInterestById(applicant.ApplicantKey);
                }
                );
            return applicant;
        }


        public void Update(ApplicationUpdateRequest model)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Applicant_Update", inputParamMapper: delegate (SqlParameterCollection paramCollection)
            {
                paramCollection.AddWithValue("@ApplicantKey", model.ApplicantKey);
                paramCollection.AddWithValue("@FirstName", model.FirstName);
                paramCollection.AddWithValue("@LastName", model.LastName);
                paramCollection.AddWithValue("@Phone", model.Phone);
                paramCollection.AddWithValue("@Email", model.Phone);
            }, returnParameters: null
            );

        }

        public Applicant MapApplicant(IDataReader reader, out int ApplicantKey)
        {
            Applicant d = new Applicant();
            int index = 0;
            d.ApplicantKey = reader.GetSafeInt32(index++);
            d.FirstName = reader.GetSafeString(index++);
            d.LastName = reader.GetSafeString(index++);
            d.Phone = reader.GetSafeString(index++);
            d.Email = reader.GetSafeString(index++);
            d.JoinDate = reader.GetDateTime(index++);
            d.UserName = reader.GetSafeString(index++);
            d.Password = reader.GetSafeString(index++);
            d.IsAdmin = reader.GetBoolean(index++);

            ApplicantKey = d.ApplicantKey;
 
            return d;
        }








        //        public void Update(DocumentUpdateRequest model)
        //        {
        //            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Documents_Update", inputParamMapper: delegate (SqlParameterCollection paramCollection)
        //            {
        //                paramCollection.AddWithValue("@Id", model.Id);
        //                paramCollection.AddWithValue("@DocumentNickName", model.DocumentNickName);
        //                paramCollection.AddWithValue("@FirstName", model.FirstName);
        //                paramCollection.AddWithValue("@LastName", model.LastName);
        //                paramCollection.AddWithValue("@DocumentTypeId", model.DocumentTypeId);
        //                paramCollection.AddWithValue("@RequiredSignatures", model.RequiredSignatures);
        //                paramCollection.AddWithValue("@AcquiredSignatures", model.AcquiredSignatures);
        //                paramCollection.AddWithValue("@PendingSignatures", model.PendingSignatures);
        //                paramCollection.AddWithValue("@DateExecuted", model.DateExecuted);
        //                paramCollection.AddWithValue("@UserId", UserService.GetCurrentUserId());
        //                paramCollection.AddWithValue("@TransactionId", model.TransactionId);
        //                paramCollection.AddWithValue("@KeyName", model.KeyName);
        //            }, returnParameters: null
        //            );

        //        }

        //        public void Delete(int id)
        //        {
        //            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Documents_Delete", inputParamMapper: delegate (SqlParameterCollection paramCollection)
        //            {
        //                paramCollection.AddWithValue("@Id", id);
        //            }, returnParameters: null
        //            );
        //        }



    }
}