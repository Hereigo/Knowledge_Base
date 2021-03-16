using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
// using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using System.Web;
using CinoMCounter.Data;
using Ionic.Zip;
using CinoMCounter.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using ZipFile = Ionic.Zip.ZipFile;

namespace CinoMCounter.Data
{
    internal class DatabaseManager
    {
        private readonly IPaymentsContext db;
        private readonly IWebHostEnvironment _host;

        public DatabaseManager(IPaymentsContext context, IWebHostEnvironment host)
        {
            db = context;
            _host = host;
        }
        
        internal string CreateBackUp()
        {
            DateTime today = DateTime.Now;

            try
            {
                // string dataFile = HttpContext.Current.Server.MapPath($"~/App_Data/{today:yyMMdd.HHmm.ss}.txt");
                
                string dataFile = Path.Combine(new [] {_host.ContentRootPath, "App_Data", $"{today:yyMMdd.HHmm.ss}.txt"});

                IOrderedQueryable<Payment> allData = db.Payments.OrderByDescending(i => i.ID);

                StreamWriter streamWriter = new StreamWriter(dataFile, true);

                streamWriter.WriteLine($"Records : {allData.Count()}");

                foreach (Payment item in allData)
                {
                    streamWriter.WriteLine($"{item.ID},{item.Amount},{item.CatogoryId},{item.PayDate:M/d/yy},{item.Description}");
                }

                streamWriter.Close();

                ZipFile zip = new ZipFile();
                zip.AddFile(dataFile, ""); // 2nd param can create dir inside archive
                zip.Save(dataFile + ".zip");

                File.Delete(dataFile);

                return $"{today:MM.dd} ({today.DayOfWeek.ToString().Substring(0, 3)}) {today:HH:mm} BackUp created successfully.";
            }
            catch (Exception ex)
            {
                return $"{today:MM.dd} ({today.DayOfWeek.ToString().Substring(0, 3)}) {today:HH:mm} BackUp Error : {ex.Message}";
            }
        }

        private async Task WriteFileAsync(string dir, string file, string content)
        {
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(dir, file)))
            {
                await outputFile.WriteAsync(content);
            }
        }
    }
}