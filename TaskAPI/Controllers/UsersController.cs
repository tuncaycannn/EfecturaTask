using System;
using TaskAPI.Config;
using TaskAPI.Models;
using Microsoft.AspNetCore.Mvc;


namespace TaskAPI.Controllers
{
    public class UsersController : ControllerBase
    {
        Connection _con = new Connection();
        Function _func = new Function();

        [HttpGet]
        [Route("[controller]")]
        public IActionResult Index()
        {
            try
            {
                string sql = "SELECT * FROM Tbl_Users";
                var model = _con.GetDataTable(sql);
                Response result = new Response { Result = "success", Message = "", Users = _con.DataTableToModelList<Users>(model) };
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                Response result = new Response { Result = "error", Message = ex.Message.ToString() };
                return Ok(result);
            }
        }


        [HttpGet]
        [Route("[controller]/id/{id}")]
        public IActionResult GetByID(string id)
        {
            try
            {
                if (_func.isIdentityNoValid(id))
                {
                    string sql = "SELECT * FROM Tbl_Users WHERE ID='" + id + "'";
                    var model = _con.GetDataTable(sql);
                    Response result = new Response { Result = "success", Message = "Record Found", Users = _con.DataTableToModelList<Users>(model) };
                    return Ok(result);
                }
                else
                {
                    Response result = new Response { Result = "error", Message = "No Records Found" };
                    return Ok(result);
                }
            }
            catch (System.Exception ex)
            {
                Response result = new Response { Result = "error", Message = ex.Message.ToString() };
                return Ok(result);
            }
        }


        [HttpPost]
        [Route("[controller]/add/{id},{name},{surname},{birthday},{address}")]
        public IActionResult Add(string id, string name, string surname, string birthday, string address)
        {
            try
            {
                if (_func.isIdentityNoValid(id))
                {
                    string sql = "INSERT INTO Tbl_Users (ID,Name,Surname,Birthday,Address) VALUES ('" + id + "','" + name + "','" + surname + "','" + birthday + "','" + address + "')";
                    var model = _con.Execute(sql);
                    Response result = new Response { Result = "success", Message = "Adding successfully." };
                    return Ok(result);
                }
                else
                {
                    Response result = new Response { Result = "error", Message = "Invalid Id" };
                    return Ok(result);
                }

            }
            catch (System.Exception ex)
            {
                Response result = new Response { Result = "error", Message = ex.Message.ToString() };
                return Ok(result);
            }
        }


        [HttpPost]
        [Route("[controller]/update/{id},{name},{surname},{birthday},{address}")]
        public IActionResult Update(string id, string name, string surname, string birthday, string address)
        {
            try
            {

                string sql = "UPDATE Tbl_Users SET Name='" + name + "', Surname='" + surname + "', Birthday='" + birthday + "', Address='" + address + "', " +
                "UpdatedDate='" + DateTime.Now.ToString() + "' WHERE ID='" + id + "'";
                var model = _con.Execute(sql);
                Response result = new Response { Result = "success", Message = "Successfully updated." };
                return Ok(result);


            }
            catch (System.Exception ex)
            {
                Response result = new Response { Result = "error", Message = ex.Message.ToString() };
                return Ok(result);
            }
        }


        [HttpPost]
        [Route("[controller]/delete/{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                string sql = "DELETE Tbl_Users WHERE ID='" + id + "'";
                var model = _con.Execute(sql);
                Response result = new Response { Result = "success", Message = "Successfully deleted." };
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                Response result = new Response { Result = "error", Message = ex.Message.ToString() };
                return Ok(result);
            }
        }


    }
}
