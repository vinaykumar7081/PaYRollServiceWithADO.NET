﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeServiceWithADO.NET
{
    public class EmployeeRepo
    {
        private SqlConnection con;
        //To Handle connection related activities    
        private void connection()
        {
            string connectingString = "Data Source=(localdb)\\MSSQLLocaldb;Initial Catalog=Payroll_Service";
            con = new SqlConnection(connectingString);
        }
        public string AddEmployee(EmpModel obj)
        {
            try
            {
                connection();
                SqlCommand com = new SqlCommand("spAddNewEmployeeDetails", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", obj.Id);
                com.Parameters.AddWithValue("@Name", obj.Name);
                com.Parameters.AddWithValue("@Salary", obj.Salary);
                com.Parameters.AddWithValue("@StartDate", obj.StartDate);
                com.Parameters.AddWithValue("@Gender", obj.Gender);
                com.Parameters.AddWithValue("@ContyactNumber", obj.ContactNumber);
                com.Parameters.AddWithValue("@Address", obj.Address);
                com.Parameters.AddWithValue("@Pay", obj.Pay);
                com.Parameters.AddWithValue("@Deduction", obj.Deduction);
                com.Parameters.AddWithValue("@TaxablePay", obj.TaxablePay);
                com.Parameters.AddWithValue("@IncomeTax", obj.IncomeTax);
                com.Parameters.AddWithValue("@NetPay", obj.NetPay);
                con.Open();
                int i = com.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                {
                    return "New Data Added";
                }
                else
                {
                    return "New Data Not Added";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                this.con.Close();
            }
        }
        /// <summary>
        /// Get All Employee data from the Table to the Console
        /// </summary>
        /// <returns></returns>
        public List<EmpModel> GetAllEmployees()
        {
            connection();
            List<EmpModel> EmpList = new List<EmpModel>();

            SqlCommand com = new SqlCommand("spGetAllEmployeePayroll", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind EmpModel generic list using dataRow     
            foreach (DataRow dr in dt.Rows)
            {
                EmpList.Add(

                new EmpModel
                {
                    Id=Convert.ToInt32(dr["Id"]),
                    Name = Convert.ToString(dr["Name"]),
                    Salary = Convert.ToDecimal(dr["Salary"]),
                    StartDate = Convert.ToDateTime(dr["StartDate"]),
                    Gender = Convert.ToString(dr["Gender"]),
                    ContactNumber = Convert.ToString(dr["ContactNumber"]),
                    Address = Convert.ToString(dr["Address"]),
                    Pay = Convert.ToDecimal(dr["Pay"]),
                    Deduction = Convert.ToDecimal(dr["Deduction"]),
                    TaxablePay = Convert.ToDecimal(dr["TaxablePay"]),
                    IncomeTax = Convert.ToDecimal(dr["IncomeTax"]),
                    NetPay = Convert.ToDecimal(dr["NetPay"])
                }
                    );
            }
            return EmpList;
        }

    }
}
