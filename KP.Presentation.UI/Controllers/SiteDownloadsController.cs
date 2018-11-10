using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using KP.Application.Contracts;
using KP.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KP.Presentation.UI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SiteDownloadsController : ControllerBase
  {
    private ILoggerManager _logger;

    public SiteDownloadsController(ILoggerManager logger)
    {
      _logger = logger;
    }

    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<string>> Get()
    {
      _logger.LogInfo("Here is info message from our values controller.");
      _logger.LogDebug("Here is debug message from our values controller.");
      _logger.LogWarn("Here is warn message from our values controller.");
      _logger.LogError("Here is error message from our values controller.");

      string sql = "SELECT TOP 10 * FROM SiteDownloads"; // Just loading top 10 while testing

      using (var connection = new SqlConnection(@"Server=KPDC001\KPSQLDBS;Database=KPBlog;User Id=WebApiAccess;Password = Itsapassword01; ")) //Change to use env vars in prod and secrets during dev
      {
        var orderDetail = connection.Query<SiteDownloads>(sql);

        return Ok(orderDetail);
      }
    }

    [HttpGet]
    public ActionResult<IEnumerable<string>> GetById(string id)
    {
      string sql = "SELECT * FROM SiteDownloads Where Id = @Id"; // Just loading top 10 while testing

      using (var connection = new SqlConnection(@"Server=KPDC001\KPSQLDBS;Database=KPBlog;User Id=WebApiAccess;Password = Itsapassword01; ")) //Change to use env vars in prod and secrets during dev
      {
        var orderDetail = connection.Query<SiteDownloads>(sql);

        return Ok(orderDetail);
      }
    }

    [HttpPut]
    public ActionResult<IEnumerable<string>> Update([FromBody] SiteDownloads siteDownload)
    {
      string sql = "SELECT TOP 10 * FROM SiteDownloads"; // Just loading top 10 while testing

      using (var connection = new SqlConnection(@"Server=KPDC001\KPSQLDBS;Database=KPBlog;User Id=WebApiAccess;Password = Itsapassword01; ")) //Change to use env vars in prod and secrets during dev
      {
        var orderDetail = connection.Query<SiteDownloads>(sql);

        return Ok(orderDetail);
      }
    }

    [HttpPost]
    public ActionResult<IEnumerable<string>> Add([FromBody] SiteDownloads siteDownload)
    {
      string sql = "SELECT TOP 10 * FROM SiteDownloads"; // Just loading top 10 while testing

      using (var connection = new SqlConnection(@"Server=KPDC001\KPSQLDBS;Database=KPBlog;User Id=WebApiAccess;Password = Itsapassword01; ")) //Change to use env vars in prod and secrets during dev
      {
        var orderDetail = connection.Query<SiteDownloads>(sql);

        return Ok(orderDetail);
      }
    }

    [HttpDelete]
    public ActionResult<IEnumerable<string>> Delete(string Id)
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
