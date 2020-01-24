using System.Collections.Generic;

namespace GIT_IGNORE
{
    public static class Variables
    {
        public static string paymentsNet462_BaseAuthStr = "odw1sZerI6sc6W6XaT7yR5TYiIg=";
        public static string httpApiClientBaseUrl = "";
        public static string httpApiClientReqPath = "";
        public static string apiRequestJsonPath = "";
        public static string apiRequestJsonToken = "";
        public static string oAuth2Token = "";
        public static string trioFormActionUrl = "";
        public static readonly string actionRedirectUrl = "";
        public static IEnumerable<KeyValuePair<string, string>> trioFormParans = new List<KeyValuePair<string, string>>()
        {
            new KeyValuePair<string, string>("login2$tbAgreement", "111135191000084"),
            new KeyValuePair<string, string>("login2$tbPassword", "")
        };
        public static string TrioLoginPage = "http://somee.com/DOKA/DOU/DOMP/DOWebSites/DOSiteDefault.aspx";
        public static string TrioPostPath = "https://somee.com/DOKA/DOU/DOUserNotAuthorized.aspx";// "https://somee.com/DOKA/DOC/DOLoginOrRegister.aspx";
        public static string TrioRootPath = "https://somee.com/";
        public static string TrioLoginUser = "Hereigo";
        public static object TrioLoginPassw = "";
        public static object TrioLoginBtn = "Log+In";

        // ELX :

        public static string AdoUri__TEST__ = "https://dev.azure.com/andriiplakhtii/"; // new VssBasicCredential(string.Empty, AdoPat)
        public static string AdoUri__PROD__ = "https://dev.azure.com/aonanalytics/"; // new VssAadCredential(AdoMagicWord1, AdoMagicWord2)
        public static string AdoUri__PROD__ALT__ = "https://aonanalytics.visualstudio.com/";

        public static string AdoPat = "7ox7o42s62mdweiebijjwngftd4exc7tjrckrce4rjkl5o46ptoa";
        public static string AdoProjectHotmail = "MyFirstProject"; // "MyTestADO";
        public static string AdoMagicWord1 = "aon.pdar.support@eleks.com";
        public static string AdoMagicWord2 = "Q!W@E#r4t5y6";
        public static string AdoMagicWord3 = "YW9uLnBkYXIuc3VwcG9ydEBlbGVrcy5jb206USFXQEUjcjR0NXk2";

        public static string ZDDevConsoleBearerToken = "062f798338a653d79c5d60a363dc4e623aec376353b78a62144ee510891bff34";
        // "aGVyZWlnb0BvbmxpbmUudWE6YXZvdGl5YTc3ISE="; // Base64 (4 Basic:)
        // Dev Console API TOKEN - "062f798338a653d79c5d60a363dc4e623aec376353b78a62144ee510891bff34";
        //                                   

        // https://aonbenfield.zendesk.com/api/v2/search.json?query=10536
        // https://aonbenfield.zendesk.com/api/v2/search.json?page=0&query=type:ticket updated>2019-11-19T11:00:00Z  - ("yyyy-MM-ddTHH:mm:ssZ")
        // https://aonbenfield.zendesk.com/api/v2/search.json?page=0&query=type:ticket status:open created>2019-11-19T11:00:00Z

        // https://aonbenfield.zendesk.com/api/v2/search.json?page=0&query=type:ticket status:new created>2019-11-26T03:08:00Z

        // POST : https://aonanalytics.visualstudio.com/_apis/wit/workitemsbatch?api-version=5.1

        public static string ZdApiRootPath = "https://and.zendesk.com";

        public static string AdoPatHotmail = "nxuu62mz25l6mhaqj54autjqla26p55y7oiridymqs5dgz6geiqq";
        public static string AdoNsHotmail = "https://dev.azure.com/plakhtiy-a";

        //     Console.WriteLine(item.Url); // https://dev.azure.com/andriiplakhtii/b428a4bf-22f5-468c-be84-3b71edc31669/_apis/wit/workItems/5
        //     Console.WriteLine();         // https://dev.azure.com/aonanalytics/adfb5d7c-dd41-4493-b32d-34bf89e536f5/_apis/wit/workItems/5


        // Get REZULT for ADO Query # d0ca1313-8986-4d55-9bda-6bf1744522da :
        // https://dev.azure.com/andriiplakhtii/MyTestADO/_apis/wit/wiql/d0ca1313-8986-4d55-9bda-6bf1744522da?api-version=5.1

        // "https://dev.azure.com/andriiplakhtii/_apis/projects?api-version=5.1";

    }
}