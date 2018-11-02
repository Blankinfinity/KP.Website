using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using KP.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KP.Presentation.UI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SiteDownloadsController : ControllerBase
  {
    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<string>> Get()
    {
      string sql = "SELECT TOP 10 * FROM SiteDownloads"; // Just loading top 10 while testing

      using (var connection = new SqlConnection(@"Server=KPDC001\KPSQLDBS;Database=KPBlog;User Id=WebApiAccess;Password = Itsapassword01; ")) //Change to use env vars in prod and secrets during dev
      {
        var orderDetail = connection.Query<SiteDownloads>(sql);

        return Ok(orderDetail);
      }
    }

    // TODO: Add remaining CRUD operations
  }
}
