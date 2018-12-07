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
    public class CredentialService : BaseService, ICredentialService
    {

        public Credential GetPasswordById(string userName)
        {
            Credential credential = new Credential();
            int TransactionId = 0;
            DataProvider.ExecuteCmd(GetConnection, "dbo.Credential_Get"
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@UserName", userName);
                }, map: delegate (IDataReader reader, short set)
                {
                    credential = MapCredential(reader, out TransactionId);
                }
                );
            return credential;
        }

        public Credential MapCredential(IDataReader reader, out int CredentialKey)
        {
            Credential d = new Credential();
            int index = 0;
            d.CredentialKey = reader.GetSafeInt32(index++);
            d.ApplicantKey = reader.GetSafeInt32(index++);
            d.UserName = reader.GetSafeString(index++);
            d.Password = reader.GetSafeString(index++);
            d.IsAdmin = reader.GetSafeBool(index++);

            CredentialKey = d.CredentialKey;

            return d;
        }



        public List<string> GetAllUserNames()
        {
            List<string> userNames = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.Credential_Get_AllUserNames"
                , inputParamMapper: null
                , map: delegate (IDataReader reader, short set)
                {
                    string userName = MapUserNames(reader);

                    if (userNames == null)
                    {
                        userNames = new List<string>();
                    }

                    userNames.Add(userName);
                }
                );
            return userNames;
        }


        public string MapUserNames(IDataReader reader)
        {
            string UserName;
            int index = 0;
            UserName = reader.GetSafeString(index++);

            return UserName;
        }


        public void UpdatePassword(PasswordUpdateRequest model)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Credential_Update_Password", inputParamMapper: delegate (SqlParameterCollection paramCollection)
            {
                paramCollection.AddWithValue("@UserName", model.UserName);
                paramCollection.AddWithValue("@Password", model.Password);
            }, returnParameters: null
            );

        }


    }
}