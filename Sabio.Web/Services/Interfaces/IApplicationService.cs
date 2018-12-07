using System.Collections.Generic;
using System.Data;
using MediaForAll.Web.Domain;
using MediaForAll.Web.Models;

namespace MediaForAll.Web.Services
{
    public interface IApplicationService
    {
        int Insert(ApplicationAddRequest model);
        List<Applicant> GetAllApplicants();

        Applicant MapApplicant(IDataReader reader, out int ApplicantKey);
        Applicant GetApplicantById(int id);

        void Update(ApplicationUpdateRequest model);

        //void Delete(int id);

        //Document MapDocument(IDataReader reader, out int transactionId);
        //void Update(DocumentUpdateRequest model);
    }
}