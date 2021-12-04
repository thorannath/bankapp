using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using bankApp.Models;
using System.Data;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace bankApp.Controllers
{

    public class BankController : Controller
    {

        string myConnectionString = "server=127.0.0.1;uid=root;" +
            "pwd=Thor@6237;database=bankcs673";


        [Route("GetCust")]
        [HttpPost]
        public string GetCust()
        {

            string trans = string.Empty;
            DataTable data = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(myConnectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM customers";
                MySqlDataAdapter sqlda = new MySqlDataAdapter(sql, conn);
                sqlda.Fill(data);
                trans = JsonConvert.SerializeObject(data);

            }
            return trans;
        }



        [Route("GetTrans")]
        [HttpPost]
        public string GetTrans(string AccountID)
        {

            string trans = string.Empty;
            DataTable data = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(myConnectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("getTransactions", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("actno", AccountID));

                MySqlDataAdapter sqlda = new MySqlDataAdapter(cmd);
                sqlda.Fill(data);
                trans = JsonConvert.SerializeObject(data);

            }
            return trans;
        }



        [Route("GetBalance")]
        [HttpPost]
        public string GetBalance(string AcntID)
        {

            string trans = string.Empty;
            DataTable data = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(myConnectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("getBalance", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("actno", AcntID));

                MySqlDataAdapter sqlda = new MySqlDataAdapter(cmd);
                sqlda.Fill(data);
                trans = JsonConvert.SerializeObject(data);

            }
            return trans;
        }



        [Route("DepositAmount")]
        [HttpPost]
        public string DepositAmount(string Account, int Amount)
        {
            var td = "";


            using (MySqlConnection conn = new MySqlConnection(myConnectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("depositAmount", conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure
                cmd.Parameters.Add(new MySqlParameter("AcntID", Account));
                cmd.Parameters.Add(new MySqlParameter("bal", Amount));

                cmd.ExecuteNonQuery();
                conn.Close();
                td = JsonConvert.SerializeObject("1");

            }
            return td;
        }

        [Route("WithdrawAmount")]
        [HttpPost]
        public string WithdrawAmount(string Account, int Amount)
        {
            var td = "";


            using (MySqlConnection conn = new MySqlConnection(myConnectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("withdrawAmount", conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure
                cmd.Parameters.Add(new MySqlParameter("AcntID", Account));
                cmd.Parameters.Add(new MySqlParameter("bal", Amount));

                cmd.ExecuteNonQuery();
                conn.Close();
                td = JsonConvert.SerializeObject("1");

            }
            return td;
        }

        [Route("PrintTrans")]
        [HttpPost]
        public string PrintTrans(string Accountid)
        {
            var td = "";


            using (MySqlConnection conn = new MySqlConnection(myConnectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("updatePrint", conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure

                cmd.Parameters.Add(new MySqlParameter("actno", Accountid));

                cmd.ExecuteNonQuery();
                conn.Close();
                td = JsonConvert.SerializeObject("1");

            }
            return td;
        }














        [Route("InsertCustomer")]
        [HttpPost]
        public string InsertCustomer(int ssn, string first, string last, string city, string flat, string phone, string bankssn, string Accountid, int amnt)
        {
            var td = "";


            using (MySqlConnection conn = new MySqlConnection(myConnectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("insertCustomer", conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure
                cmd.Parameters.Add(new MySqlParameter("SSN", ssn));
                cmd.Parameters.Add(new MySqlParameter("FirstName", first));
                cmd.Parameters.Add(new MySqlParameter("LastName", last));
                cmd.Parameters.Add(new MySqlParameter("City", city));
                cmd.Parameters.Add(new MySqlParameter("FlatNo", flat));
                cmd.Parameters.Add(new MySqlParameter("phone", phone));
                cmd.Parameters.Add(new MySqlParameter("BankerSSN", bankssn));
                cmd.Parameters.Add(new MySqlParameter("AccountID", Accountid));
                cmd.Parameters.Add(new MySqlParameter("amountDeposited", amnt));
                cmd.ExecuteNonQuery();
                conn.Close();
                td = JsonConvert.SerializeObject("1");

            }
            return td;
        }

        [Route("deleteCustomer")]
        [HttpPost]
        public string deleteCustomer(int ssn)
        {
            var td = "";


            using (MySqlConnection conn = new MySqlConnection(myConnectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("deleteCustomer", conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure
                cmd.Parameters.Add(new MySqlParameter("S", ssn));

                cmd.ExecuteNonQuery();
                conn.Close();
                td = JsonConvert.SerializeObject("1");

            }
            return td;
        }

        [Route("UpdateCustomer")]
        [HttpPost]
        public string UpdateCustomer(int ssn, string first, string last, string city, string flat, string phone, string bankssn, string Accountid)
        {
            var td = "";


            using (MySqlConnection conn = new MySqlConnection(myConnectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("updateCustomer", conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure
                cmd.Parameters.Add(new MySqlParameter("uSSN", ssn));
                cmd.Parameters.Add(new MySqlParameter("uFirstName", first));
                cmd.Parameters.Add(new MySqlParameter("uLastName", last));
                cmd.Parameters.Add(new MySqlParameter("uCity", city));
                cmd.Parameters.Add(new MySqlParameter("uFlatNo", flat));
                cmd.Parameters.Add(new MySqlParameter("uphone", phone));
                cmd.Parameters.Add(new MySqlParameter("uBankerSSN", bankssn));
                cmd.Parameters.Add(new MySqlParameter("uAccountID", Accountid));
                cmd.ExecuteNonQuery();
                conn.Close();
                td = JsonConvert.SerializeObject("1");

            }
            return td;
        }





    }
}