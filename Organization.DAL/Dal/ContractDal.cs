using System.Data.SqlClient;
using Organization.Contract.DAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace Organization.DAL
{
    public class ContractDal : AdoNetDataAccessLayer<Core.Contract>, IDataAccessLayer<Core.Contract>
    {
        public void Create(Core.Contract entity)
        {
            try
            {
                _connection.Open();
                using (var command = _connection.CreateCommand())
                {
                    command.CommandText =
                        @"INSERT INTO Contract (ContractDate, DueDate, Price,Comment,CustomerId,DepartmentId)
VALUES (@ContractDate, @DueDate, @Price,@Comment,@CustomerId,@DepartmentId)";
                    command.AddParameter("ContractDate", entity.ContractDate);
                    command.AddParameter("DueDate", entity.DueDate);
                    command.AddParameter("Price", entity.Price);
                    command.AddParameter("Comment", entity.Comment);
                    command.AddParameter("CustomerId", entity.CustomerId);
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

        public void Delete(Core.Contract entity)
        {
            try
            {
                _connection.Open();
                using (var command = _connection.CreateCommand())
                {
                    command.CommandText = @"DELETE FROM Contract WHERE Id = @Id";
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

        public void Update(Core.Contract entity)
        {
            try
            {
                _connection.Open();
                using (var command = _connection.CreateCommand())
                {
                    command.CommandText =
                        @"UPDATE Contract SET ContractDate = @ContractDate, DueDate = @DueDate, Price = @Price,
                                        Comment = @Comment, CustomerId = @CustomerId, DepartmentId = @DepartmentId 
                                        WHERE Id = @Id";
                    command.AddParameter("Id", entity.Id);
                    command.AddParameter("ContractDate", entity.ContractDate);
                    command.AddParameter("DueDate", entity.DueDate);
                    command.AddParameter("Price", entity.Price);
                    command.AddParameter("Comment", entity.Comment);
                    command.AddParameter("CustomerId", entity.CustomerId);
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

        public IEnumerable<Core.Contract> GetAll()
        {
            try
            {
                _connection.Open();
                using (var command = _connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Contract";
                    using (var reader = command.ExecuteReader())
                    {
                        var items = new List<Core.Contract>();
                        while (reader.Read())
                        {
                            var item = new Core.Contract();
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
        public Core.Contract GetByPrimaryKey(params object[] key)
        {
            if(key == null) throw new ArgumentNullException(); 
            if(key.Length != 1) throw new ArgumentException("Key is wrong!");
            if (!(key[0] is int)) throw new ArgumentException("Key is not a number!");
            try
            {
                _connection.Open();
                using (var command = _connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Contract WHERE Id = @Id";
                    command.AddParameter("Id", key[0]);
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        var item = new Core.Contract();
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


        protected override void Map(IDataRecord record, Core.Contract entity)
        {
            entity.Id = (int)record["Id"];
            entity.ContractDate = (DateTime)record["ContractDate"];
            entity.DueDate = (DateTime)record["DueDate"];
            entity.Price = (decimal)record["Price"];
            entity.CustomerId = (int)record["CustomerId"];
            entity.DepartmentId = (int)record["DepartmentId"];
            entity.Comment = record["Comment"] == DBNull.Value ? String.Empty : Convert.ToString(record["DepartmentId"]);

        }
    }
}
