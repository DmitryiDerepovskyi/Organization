using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Organization.Contract.DAL;
using Organization.Core;
namespace Organization.DAL
{
    public class EmployeeDal : AdoNetDataAccessLayer<Employee>, IDataAccessLayer<Employee>
    {
        public void Create(Employee entity)
        {
            try
            {
                _connection.Open();
                using (var command = _connection.CreateCommand())
                {
                    command.CommandText =
                        @"INSERT INTO Employee (Firstname, Lastname, BirthDate,Phone,Gender,Salary,DepartmentId)
VALUES (@Firstname, @Lastname, @BirthDate,@Phone,@Gender,@Salary,@DepartmentId)";
                    command.AddParameter("FirstName", entity.FirstName);
                    command.AddParameter("LastName", entity.LastName);
                    command.AddParameter("BirthDate", entity.BirthDate);
                    command.AddParameter("Phone", entity.Phone);
                    command.AddParameter("Gender", entity.Gender);
                    command.AddParameter("Salary", entity.Salary);
                    command.AddParameter("DepartmentId", entity.DepartmentId);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

        public void Delete(Employee entity)
        {
            try
            {
                _connection.Open();
                using (var command = _connection.CreateCommand())
                {
                    command.CommandText = @"DELETE FROM Employee WHERE Id = @Id";
                    command.AddParameter("Id", entity.Id);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

        public void Update(Employee entity)
        {
            try
            {
                _connection.Open();
                using (var command = _connection.CreateCommand())
                {
                    command.CommandText =
                        @"UPDATE Employee SET FirstName = @FirstName, LastName = @LastName, BirthDate = @BirthDate,
                                        Phone = @Phone, Gender = @Gender, Salary = @Salary, DepartmentId = @DepartmentId 
                                        WHERE Id = @Id";
                    command.AddParameter("Id", entity.Id);
                    command.AddParameter("FirstName", entity.FirstName);
                    command.AddParameter("LastName", entity.LastName);
                    command.AddParameter("BirthDate", entity.BirthDate);
                    command.AddParameter("Phone", entity.Phone);
                    command.AddParameter("Gender", entity.Gender);
                    command.AddParameter("Salary", entity.Salary);
                    command.AddParameter("DepartmentId", entity.DepartmentId);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

        public IEnumerable<Employee> GetAll()
        {
            try
            {
                _connection.Open();
                using (var command = _connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Employee";
                    using (var reader = command.ExecuteReader())
                    {
                        var items = new List<Employee>();
                        while (reader.Read())
                        {
                            var item = new Employee();
                            Map(reader, item);
                            items.Add(item);
                        }
                        return items;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

        public Employee GetByPrimaryKey(params object[] key)
        {
            if (key == null) throw new ArgumentNullException();
            if (key.Length != 1) throw new ArgumentException("Key is wrong!");
            if (!(key[0] is int)) throw new ArgumentException("Key is not a number!");
            try
            {
                _connection.Open();
                using (var command = _connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Employee WHERE Id = @Id";
                    command.AddParameter("Id", key[0]);
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        var item = new Employee();
                        Map(reader, item);
                        return item;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                _connection.Close();
            }
        }


        protected override void Map(IDataRecord record, Employee entity)
        {
            entity.Id = (int)record["Id"];
            entity.FirstName = (string)record["FirstName"];
            entity.LastName = (string)record["LastName"];
            entity.BirthDate = (DateTime)record["BirthDate"];
            entity.Gender = Convert.ToChar(record["Gender"]);
            entity.Salary = (decimal)record["Salary"];
            entity.Phone = (string)record["Phone"];
            entity.DepartmentId = (int)record["DepartmentId"];
        }
    }
}
