using Dapper;
using Microsoft.AspNet.Identity;
using SPDVI_Marta_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SPDVI_Marta_WebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/Player")]
    public class PlayerController : ApiController
    {
        // return 200, 404
        [HttpPost]
        [Route("InsertNewPlayer")]
        public IHttpActionResult InsertNewPlayer(PlayerModel player)
        {
            // Connect to our bbdd
            using (IDbConnection cnn = new ApplicationDbContext().Database.Connection)
            {
                // Insert player
                string sql = "INSERT INTO dbo.Player (Id, FirstName, LastName, Email, DateOfBirth, NickName, City, BlobUri) VALUES (" +
                    $"'{player.Id}','{player.FirstName}','{player.LastName}','{player.Email}','{player.DateOfBirth}','{player.NickName}'," +
                    $"'{player.City}','{player.BlobUri}')";

                try
                {
                    cnn.Execute(sql);
                    // Use using or cnn.Dispose();
                }
                catch (Exception ex)
                {
                    return BadRequest("Error inserting player in database: " + ex.Message);
                }

                return Ok();
            }
        }

        [HttpGet]
        [Route("GetPlayerDateJoined")]
        public string GetPlayerDateJoined()
        {
            string authenticatedAspNetUserId = RequestContext.Principal.Identity.GetUserId();
            using (IDbConnection con = new ApplicationDbContext().Database.Connection)
            {
                string sql = $"select DateJoined from dbo.Player where Id like '{ authenticatedAspNetUserId }'";
                //string datejoined = con.Query<string>(sql).FirstOrDefault();
                //return datejoined;
                DateTime dateJoined = con.Query<DateTime>(sql).FirstOrDefault();
                return dateJoined.ToShortDateString();
            }

        }
    }
}
