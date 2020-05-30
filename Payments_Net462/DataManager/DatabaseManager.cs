using System;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using System.Web;
using Payments_Net462.Models;

namespace Payments_Net462.DataManager
{
    internal class DatabaseManager
    {
        private readonly PaymentsContext db = new PaymentsContext();

        internal string CreateBackUp()
        {
            DateTime today = DateTime.Now;

            try
            {
                string dataFile = HttpContext.Current.Server.MapPath($"~/App_Data/{today:yyMMdd.HHmm.ss}.txt");

                IOrderedQueryable<Payment> allData = db.Payments.OrderByDescending(i => i.ID);

                StreamWriter streamWriter = new StreamWriter(dataFile, true);

                streamWriter.WriteLine($"Records : {allData.Count()}");

                foreach (Payment item in allData)
                {
                    streamWriter.WriteLine($"{item.ID},{item.Amount},{item.CatogoryId},{item.PayDate},{item.Description}");
                }

                streamWriter.FlushAsync();

                return $"{today:MM.dd} ({today.DayOfWeek.ToString().Substring(0, 3)}) {today:HH:mm} BackUp created successfully.";
            }
            catch (Exception ex)
            {
                return $"{today:MM.dd} ({today.DayOfWeek.ToString().Substring(0, 3)}) {today:HH:mm} BackUp Error : {ex.Message}";
            }
        }

        // TODO:
        // make it async !!!

        private async Task WriteFileAsync(string dir, string file, string content)
        {
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(dir, file)))
            {
                await outputFile.WriteAsync(content);
            }
        }
    }
}