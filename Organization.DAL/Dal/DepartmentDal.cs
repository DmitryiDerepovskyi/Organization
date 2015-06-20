using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Organization.Contract.DAL;
using Organization.Core;
namespace Organization.DAL
{
    public class DepartmentDal : AdoNetDataAccessLayer<Department>, IDataAccessLayer<Department>
    {
        public void Create(Department entity)
        {
            try
            {
                _connection.Open();
                using (var command = _connection.CreateCommand())
                {
                    command.CommandText = @"INSERT INTO Department (Name) VALUES(@Name)";
                    command.AddParameter("Name", entity.Name);
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

        public void Delete(Department entity)
        {
            try
            {
                _connection.Open();
                using (var command = _connection.CreateCommand())
                {
                    command.CommandText = @"DELETE FROM Department WHERE Id = @Id";
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

        public void Update(Department entity)
        {
            try
            {
                _connection.Open();
                using (var command = _connection.CreateCommand())
                {
                    command.CommandText = @"UPDATE Department SET Name = @Name WHERE Id = @Id";
                    command.AddParameter("Id", entity.Id);
                    command.AddParameter("Name", entity.Name);
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

        public IEnumerable<Department> GetAll()
        {
            try
            {
                _connection.Open();
                using (var command = _connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Department";
                    using (var reader = command.ExecuteReader())
                    {
                        var items = new List<Department>();
                        while (reader.Read())
                        {
                            var item = new Department();
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
        public Department GetByPrimaryKey(params object[] key)
        {
            if (key == null) throw new ArgumentNullException();
            if (key.Length != 1) throw new ArgumentException("Key is wrong!");
            if (!(key[0] is int)) throw new ArgumentException("Key is not a number!");
            try
            {
                _connection.Open();
                using (var command = _connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Department WHERE Id = @Id";
                    command.AddParameter("Id", key[0]);
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        var item = new Department();
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


        protected override void Map(IDataRecord record, Department entity)
        {
            entity.Id = (int)record["Id"];
            entity.Name = (string)record["Name"];
        }
    }
}
