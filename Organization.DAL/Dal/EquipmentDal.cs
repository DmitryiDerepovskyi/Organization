using System;
using System.Collections.Generic;
using System.Data;
using Organization.Contract.DAL;
using Organization.Core;

namespace Organization.DAL
{
    public class EquipmentDal : AdoNetDataAccessLayer<Equipment>, IDataAccessLayer<Equipment>
    {
        public void Create(Equipment entity)
        {
            try
            {
                _connection.Open();
                using (var command = _connection.CreateCommand())
                {
                    command.CommandText = @"INSERT INTO Equipment (Name, PurchaseDate,DepartmentId)
VALUES (@Name, @PurchaseDate,@DepartmentId)";
                    command.AddParameter("Name", entity.Name);
                    command.AddParameter("PurchaseDate", entity.PurchaseDate);
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

        public void Delete(Equipment entity)
        {
            try
            {
                _connection.Open();
                using (var command = _connection.CreateCommand())
                {
                    command.CommandText = @"DELETE FROM Equipment WHERE Id = @Id";
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

        public void Update(Equipment entity)
        {
            try
            {
                _connection.Open();
                using (var command = _connection.CreateCommand())
                {
                    command.CommandText =
                        @"UPDATE Equipment SET Name = @Name, PurchaseDate = @PurchaseDate, DepartmentId = @DepartmentId 
                                        WHERE Id = @Id";
                    command.AddParameter("Id", entity.Id);
                    command.AddParameter("Name", entity.Name);
                    command.AddParameter("PurchaseDate", entity.PurchaseDate);
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

        public IEnumerable<Equipment> GetAll()
        {
            try
            {
                _connection.Open();
                using (var command = _connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Equipment";
                    using (var reader = command.ExecuteReader())
                    {
                        var items = new List<Equipment>();
                        while (reader.Read())
                        {
                            var item = new Equipment();
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
        public Equipment GetByPrimaryKey(params object[] key)
        {
            if(key == null) throw new ArgumentNullException(); 
            if(key.Length != 1) throw new ArgumentException("Key is wrong!");
            if (!(key[0] is int)) throw new ArgumentException("Key is not a number!");
            try
            {
                _connection.Open();
                using (var command = _connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Equipment WHERE Id = @Id";
                    command.AddParameter("Id", key[0]);
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        var item = new Equipment();
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


        protected override void Map(IDataRecord record, Equipment entity)
        {
            entity.Id = (int)record["Id"];
            entity.Name = (string)record["Name"];
            entity.PurchaseDate = (DateTime)record["PurchaseDate"];
            entity.DepartmentId = record["DepartmentId"] == DBNull.Value ? (int?) null : (int) record["DepartmentId"];
        }
    }
}
