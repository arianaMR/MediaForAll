using System.Collections.Generic;
using System.Data;
using MediaForAll.Web.Domain;
using MediaForAll.Web.Models;

namespace MediaForAll.Web.Services
{
    public interface ICredentialService
    {
        Credential GetPasswordById(string userName);

        Credential MapCredential(IDataReader reader, out int JobKey);

        List<string> GetAllUserNames();

        string MapUserNames(IDataReader reader);

        void UpdatePassword(PasswordUpdateRequest model);

    }
}