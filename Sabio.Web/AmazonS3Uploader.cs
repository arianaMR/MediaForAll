using System;
using Amazon.S3;
using Amazon.S3.Model;

namespace FileUpload
{
    public class AmazonS3Uploader
    {
        private string bucketName = "sabio-training/C25";
        private string keyName = "fileEx.docx";
        private string filePath = @"C:\SF.Code\C25\Sabio.Web\Uploads\Saves Searches Sprint Outline.docx";

        public void UploadFile()
        {
            var client = new AmazonS3Client(Amazon.RegionEndpoint.USEast1);

            try
            {
                PutObjectRequest putRequest = new PutObjectRequest
                {
                    BucketName = bucketName,
                    Key = keyName,
                    FilePath = filePath,
                    ContentType = "text/plain"
                };

                PutObjectResponse response = client.PutObject(putRequest);
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                if (amazonS3Exception.ErrorCode != null &&
                    (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId")
                    ||
                    amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
                {
                    throw new Exception("Check the provided AWS Credentials.");
                }
                else
                {
                    throw new Exception("Error occurred: " + amazonS3Exception.Message);
                }
            }
        }
    }
}