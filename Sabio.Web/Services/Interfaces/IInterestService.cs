using System.Collections.Generic;
using System.Data;
using MediaForAll.Web.Domain;
using MediaForAll.Web.Models;

namespace MediaForAll.Web.Services
{
    public interface IInterestService
    {
        int Insert(ApplicationAddRequest model, int ApplicantKey);

        List<Interest> GetInterestById(int id);

        Interest MapInterest(IDataReader reader, out int InterestKey);

        //List<Applicant> GetAllApplicants();

        //Applicant MapApplicant(IDataReader reader, out int ApplicantKey);

        //void Delete(int id);

        //List<Document> GetByTransactionId(int id);
        //Document GetDocumentById(int id);

        //Document MapDocument(IDataReader reader, out int transactionId);
        //void Update(DocumentUpdateRequest model);
    }
}