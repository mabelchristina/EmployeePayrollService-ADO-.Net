using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace EmployeePayRoll
{
    class EmployeeRepo
    {
        public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=payroll_service;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection connection = new SqlConnection(connectionString);
        public bool DataBaseConnection()
        {
            try
            {
                connection.Open();
                using (connection)
                {
                    Console.WriteLine($"Connection is created Successful");
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return true;
        }
        public DataSet GetAllEmployee()
        {
            try
            {
                DataSet dataSet = new DataSet();
                using (this.connection)
                {
                    this.connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("spGetAllemployee_payroll", this.connection);
                    adapter.Fill(dataSet, "employee_payroll");
                    foreach (DataRow dataRow in dataSet.Tables["employee_payroll"].Rows)
                    {
                        Console.WriteLine("\t" + dataRow["id"] + "  " + dataRow["name"] + " " + dataRow["salary"] +
                            " " + dataRow["start_date"] + " " + dataRow["Gender"] + " " + dataRow["phone"] + " " +
                            dataRow["address"] + dataRow["department"] + " " + dataRow["basicPay"] + " " + dataRow["deduction"] + " " +
                            dataRow["taxablePay"] + " " + dataRow["incomeTax"] + " ");
                    }
                    this.connection.Close();
                }
                return dataSet;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
        public void AddEmployee(EmployeeModel obj)
        {
            try
            {
                using (connection)
                {
                    //Creating a stored Procedure for adding employees into database
                    SqlCommand com = new SqlCommand("spAddEmployeePayroll", connection);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@name", obj.name);
                    com.Parameters.AddWithValue("@salary", obj.salary);
                    com.Parameters.AddWithValue("@start_date", obj.start_date);
                    connection.Open();
                    var result = com.ExecuteNonQuery();
                    Console.WriteLine("Record Successfully Inserted On Table");
                    connection.Close();
                    GetAllEmployee();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public void UpdateEmployee(double basicPay, string name)
        {
            try
            {
                using (connection)
                {
                    SqlCommand com = new SqlCommand("spUpdateEmployeePayroll", connection);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@name", name);
                    com.Parameters.AddWithValue("@basicPay", basicPay);
                    connection.Open();
                    var result = com.ExecuteNonQuery();
                    Console.WriteLine("Record Successfully Updated On Table");
                    connection.Close();
                    GetAllEmployee();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public DataSet RetrieveAllEmployeeForParticularRange()
        {
            try
            {
                DataSet dataSet = new DataSet();
                using (this.connection)
                {
                    this.connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("spRetrieveAllEmployeeForParticularRange", this.connection);
                    adapter.Fill(dataSet, "employee_payroll");
                    foreach (DataRow dataRow in dataSet.Tables["employee_payroll"].Rows)
                    {
                        Console.WriteLine("\t" + dataRow["id"] + "  " + dataRow["name"] + " " + dataRow["salary"] +
                                " " + dataRow["start_date"] + " " + dataRow["Gender"] + " " + dataRow["phone"] + " " +
                                dataRow["address"] + dataRow["department"] + " " + dataRow["basicPay"] + " " + dataRow["deduction"] + " " +
                                dataRow["taxablePay"] + " " + dataRow["incomeTax"] + " ");
                    }
                    this.connection.Close();
                }
                return dataSet;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
        public DataSet RetrieveAllEmployeeDeatilsUsingJoins()
        {
            try
            {
                DataSet dataSets = new DataSet();
                using (this.connection)
                {
                    this.connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("spGetAllemployeeAndPayroll", this.connection);
                    adapter.Fill(dataSets, "Employee");
                    foreach (DataRow dataRow in dataSets.Tables["Employee"].Rows)
                    {
                        Console.WriteLine("\t" + dataRow["emp_id"] + "  " + dataRow["name"] + " "  +
                                " " + dataRow["startdate"] + " " + dataRow["gender"] + " " + dataRow["phone"] + " " +
                                dataRow["address"] + dataRow["emp_id"] + " " + dataRow["net_pay"] + " " + dataRow["deduction"] + " " +
                                dataRow["taxable_pay"] + " " + dataRow["income_tax"] + " ");
                    }
                    this.connection.Close();
                }
                return dataSets;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
    }
}
