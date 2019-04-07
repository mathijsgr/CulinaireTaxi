using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataObjects;
using Querys;

public class RestaurantController : ApiController
{
    // GET api/<controller>
    public string Get()
    {
        return null;
    }

    // GET api/<controller>/5
    public Restaurant Get(int id)
    {
        RestaurantQuerys rQuery = new RestaurantQuerys();
        var restaurants = rQuery.GetRestaurant(id);
        return restaurants;
    }

    // POST api/<controller>
    public void Post([FromBody]string value)
    {
    }

    // PUT api/<controller>/5
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE api/<controller>/5
    public void Delete(int id)
    {
    }
}
