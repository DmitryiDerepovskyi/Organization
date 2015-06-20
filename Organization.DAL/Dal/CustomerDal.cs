using System;
using System.Collections.Generic;
using System.Data;
using Organization.Contract.DAL;
using Organization.Core;
namespace Organization.DAL
{
    public class CustomerDal : AdoNetDataAccessLayer<Customer>, IDataAccessLayer<Customer>
    {
        public void Create(Customer entity)
        {
            try
            {
                _connection.Open();
                using (var command = _connection.CreateCommand())
                {
                    command.CommandText = @"INSERT INTO Customer (ContactName, Address, Phone)
VALUES (@ContactName, @Address, @Phone)";
                    command.AddParameter("ContactName", entity.ContactName);
                    command.AddParameter("Address", entity.Address);
                    command.AddParameter("Phone", entity.Phone);
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

        public void Delete(Customer entity)
        {
            try
            {
                _connection.Open();
                using (var command = _connection.CreateCommand())
                {
                    command.CommandText = @"DELETE FROM Customer WHERE Id = @Id";
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

        public void Update(Customer entity)
        {
            try
            {
                _connection.Open();
                using (var command = _connection.CreateCommand())
                {
                    command.CommandText =
                        @"UPDATE Customer SET ContactName = @ContactName, Address = @Address, Phone = @Phone
                                        WHERE Id = @Id";
                    command.AddParameter("Id", entity.Id);
                    command.AddParameter("ContactName", entity.ContactName);
                    command.AddParameter("Address", entity.Address);
                    command.AddParameter("Phone", entity.Phone);
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

        public IEnumerable<Customer> GetAll()
        {
            try
            {
                _connection.Open();
                using (var command = _connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Customer";
                    using (var reader = command.ExecuteReader())
                    {
                        var items = new List<Customer>();
                        while (reader.Read())
                        {
                            var item = new Customer();
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
        public Customer GetByPrimaryKey(params object[] key)
        {
            if(key == null) throw new ArgumentNullException(); 
            if(key.Length != 1) throw new ArgumentException("Key is wrong!");
            if (!(key[0] is int)) throw new ArgumentException("Key is not a number!");
            try
            {
                _connection.Open();
                using (var command = _connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Customer WHERE Id = @Id";
                    command.AddParameter("Id", key[0]);
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        var item = new Customer();
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


        protected override void Map(IDataRecord record, Customer entity)
        {
            entity.Id = (int)record["Id"];
            entity.ContactName = (string)record["ContactName"];
            entity.Address = (string)record["Address"];
            entity.Phone = (string)record["Phone"];
        }
    }
}
