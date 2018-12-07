using System.Collections.Generic;
using System.Data;
using MediaForAll.Web.Domain;
using MediaForAll.Web.Models;

namespace MediaForAll.Web.Services
{
    public interface IExperienceService
    {
        int Insert(ApplicationAddRequest model, int ApplicantKey);

        List<Experience> GetExperienceById(int id);
        
        Experience MapExperience(IDataReader reader, out int ExperienceKey);

        //void Delete(int id);

        //List<Document> GetByTransactionId(int id);
        //Document GetDocumentById(int id);

        //Document MapDocument(IDataReader reader, out int transactionId);
        //void Update(DocumentUpdateRequest model);
    }
}