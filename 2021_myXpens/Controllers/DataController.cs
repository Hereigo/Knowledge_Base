using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyXpens.Models;

namespace MyXpens.Controllers
{
    [Authorize]
    public class DataController : Controller
    {
        private readonly PaymentsContext _dbContext;

        public DataController(PaymentsContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult GetBkpJson()
        {
            var bkp = _dbContext.Payments
                .Include(p => p.Category)
                .OrderByDescending(p => p.PayDate).ToArray();

            var json = JsonSerializer.Serialize(bkp);

            // A: Simple JSON response:
            // return Content(json, "application/json");

            // B: ZIPPED json response:
            return File(ZipString(json), "application/octet-stream", $"{DateTime.Now:yy.MM.dd}_xPens_BKP.zip");

            // C: If needed to response a raw JSON FILE:
#pragma warning disable CS0162
            var stream = new MemoryStream();
            var sw = new StreamWriter(stream);
            sw.Write(json);
            sw.Flush();
            stream.Position = 0;

            return File(stream, "application/octet-stream");
#pragma warning restore CS0162
        }

        [HttpGet]
        public IActionResult GetBkpJson_2()
        {
            var zipStream = GetZipStream("test", "test", Encoding.UTF8);
            return File(zipStream, "application/octet-stream");
        }

        public Stream GetZipStream(string name, string contentStr, Encoding encoding)
        {
            // convert string to stream
            var byteArray = encoding.GetBytes(contentStr);

            var memoryStream = new MemoryStream(byteArray);

            var zipStream = new MemoryStream();

            using (var zip = new ZipArchive(zipStream, ZipArchiveMode.Create, true))
            {
                var entry = zip.CreateEntry(name);

                using (var entryStream = entry.Open())
                {
                    memoryStream.CopyTo(entryStream);
                }
            }
            zipStream.Position = 0;
            return zipStream;
        }

        private static byte[] ZipString(string str)
        {
            var bytes = Encoding.UTF8.GetBytes(str);

            using var msi = new MemoryStream(bytes);
            using var mso = new MemoryStream();
            using (var gs = new GZipStream(mso, CompressionMode.Compress))
            {
                byte[] bytesBuffer = new byte[4096];
                int cnt;
                while ((cnt = msi.Read(bytesBuffer, 0, bytesBuffer.Length)) != 0)
                {
                    gs.Write(bytesBuffer, 0, cnt);
                }
            }
            return mso.ToArray();
        }
    }
}
