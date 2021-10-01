using System.Threading.Tasks;
using AspNetCoreSignalR.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace AspNetCoreSignalR.Controllers
{
    public class AnnouncementController : Controller
    {
        const string receiveMsgMethodName = "ReceiveMessage";

        private IHubContext<MessageHub> _hubContext;

        public AnnouncementController(IHubContext<MessageHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpGet("/announcement")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("/announcement")]
        public async Task<IActionResult> Post([FromForm] string message)
        {
            await _hubContext.Clients.All.SendAsync(receiveMsgMethodName, message);
            return RedirectToAction("Index");
        }
    }
}
