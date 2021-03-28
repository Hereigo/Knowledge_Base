using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
//using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MyXpens.Models;
// using ZipFile = Ionic.Zip.ZipFile; // Deprecated !!!

namespace MyXpens.DataManager
{
    internal class DatabaseManager
    {
        private static DbContextOptions<PaymentsContext> _options;
        public DatabaseManager(DbContextOptions<PaymentsContext> options)
        {
            _options = options;
        }
        private readonly PaymentsContext db = new PaymentsContext(_options);

        internal string CreateBackUp()
        {
            DateTime today = DateTime.Now;

            try
            {
                // // https://www.mikesdotnetting.com/article/302/server-mappath-equivalent-in-asp-net-core
                // string dataFile = ""; //HttpContext.Current.Server.MapPath($"~/App_Data/{today:yyMMdd.HHmm.ss}.txt");
                //
                // IOrderedQueryable<Payment> allData = db.Payments.OrderByDescending(i => i.ID);
                //
                // StreamWriter streamWriter = new StreamWriter(dataFile, true);
                //
                // streamWriter.WriteLine($"Records : {allData.Count()}");
                //
                // foreach (Payment item in allData)
                // {
                //     streamWriter.WriteLine($"{item.ID},{item.Amount},{item.CatogoryId},{item.PayDate:M/d/yy},{item.Description}");
                // }
                //
                // streamWriter.Close();
                //
                // // TODO:
                // // Ionic.Zip.ZipFile; // Deprecated !!!
                // ZipFile zip = new ZipFile();
                // zip.AddFile(dataFile, ""); // 2nd param can create dir inside archive
                // zip.Save(dataFile + ".zip");
                //
                // File.Delete(dataFile);
                //
                // return $"{today:MM.dd} ({today.DayOfWeek.ToString().Substring(0, 3)}) {today:HH:mm} BackUp created successfully.";
                
                return $"{today:MM.dd} ({today.DayOfWeek.ToString().Substring(0, 3)}) {today:HH:mm} BackUp Error - Not implemented yet.";
            }
            catch (Exception ex)
            {
                return $"{today:MM.dd} ({today.DayOfWeek.ToString().Substring(0, 3)}) {today:HH:mm} BackUp Error : {ex.Message}";
            }
        }

        // TODO:

        // MAKE IT ASYNC !!!

        private async Task WriteFileAsync(string dir, string file, string content)
        {
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(dir, file)))
            {
                await outputFile.WriteAsync(content);
            }
        }
    }
}