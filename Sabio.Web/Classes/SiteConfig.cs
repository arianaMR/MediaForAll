using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace MediaForAll.Web.Classes
{
    public static class SiteConfig
    {

        public static string SendGrid
        {
            get { return GetFromConfig("SendGrid"); }
        }

        public static string SenderEmail
        {
            get { return GetFromConfig("SenderEmail"); }
        }

        public static string SubjectEmail
        {
            get { return GetFromConfig("SubjectEmail"); }
        }

        public static string RecipientEmail
        {
            get { return GetFromConfig("RecipientEmail"); }
        }

        public static string Environment
        {
            get { return GetFromConfig("Environment"); }
        }

        public static string SiteDomain
        {
            get { return GetFromConfig("SiteDomain"); }
        }

        public static string BaseUrl
        {
            get { return GetFromConfig("BaseUrl"); }
        }

        public static string SiteAdminEmailAddress
        {
            get { return GetFromConfig("SiteAdminEmailAddress"); }
        }

        public static string BrandName
        {
            get { return GetFromConfig("BrandName"); }
        }

        public static string BrandLogo
        {
            get { return GetFromConfig("BrandLogo"); }
        }

        public static string BrandTagline
        {
            get { return GetFromConfig("BrandTagline"); }
        }

        public static string BrandThumbnail
        {
            get { return GetFromConfig("BrandThumbnail"); }
        }
        public static string BrandLogoFooter
        {
            get { return GetFromConfig("BrandLogoFooter"); }
        }
        public static string BrandBackgroundImage
        {
            get { return GetFromConfig("BrandBackgroundImage"); }
        }

        public static string BrandHighRes
        {
            get { return GetFromConfig("BrandHighRes"); }
        }

        public static string BrandLogoEmail
        {
            get { return GetFromConfig("BrandLogoEmail"); }
        }

        public static string BrandDescription
        {
            get { return GetFromConfig("BrandDescription"); }
        }

        public static string AWSRegion
        {
            get { return GetFromConfig("AWSRegion"); }
        }

        public static string AWSBaseUrl
        {
            get { return GetFromConfig("AWSBaseUrl"); }
        }

        public static string AWSBucket
        {
            get { return GetFromConfig("AWSBucket"); }
        }

        public static string AWSFolder
        {
            get { return GetFromConfig("AWSFolder"); }
        }

        public static string AwsPrefix
        {
            get
            {
                return "https://" + AWSBucket + "." + AWSBaseUrl + "/" + AWSFolder + "/";
            }
        }

        public static string GetAWSUrl(string fileKey)
        {
            return AwsPrefix + fileKey;
        }

        public static string TwilioPhoneNumber
        {
            get { return GetFromConfig("TwilioPhoneNumber"); }
        }

        public static string TwilioAccountSid
        {
            get { return GetFromConfig("TwilioAccountSid"); }
        }

        public static string TwilioAuthToken
        {
            get { return GetFromConfig("TwilioAuthToken"); }
        }

        public static string CrmlsUserName
        {
            get { return GetFromConfig("CrmlsUserName"); }
        }

        public static string CrmlsPassword
        {
            get { return GetFromConfig("CrmlsPassword"); }
        }

        public static string CrmlsDomain
        {
            get { return GetFromConfig("CrmlsDomain"); }
        }



        #region Helper Methods

        private static string GetFromConfig(string key)
        {
            return WebConfigurationManager.AppSettings[key];
        }

        #endregion

    }
}