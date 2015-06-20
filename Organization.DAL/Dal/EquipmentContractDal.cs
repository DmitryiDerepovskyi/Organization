using System;
using System.Collections.Generic;
using System.Data;
using Organization.Contract.DAL;
using Organization.Core;
namespace Organization.DAL
{
    public class EquipmentContractDal : AdoNetDataAccessLayer<EquipmentContract>, IDataAccessLayer<EquipmentContract>
    {
        public void Create(EquipmentContract entity)
        {
            try
            {
                _connection.Open();
                using (var command = _connection.CreateCommand())
                {
                    command.CommandText = @"INSERT INTO Equipment_Contract (ContractId, EquipmentId)
                                        VALUES (@ContractId, @EquipmentId)";
                    command.AddParameter("ContractId", entity.ContractId);
                    command.AddParameter("EquipmentId", entity.EquipmentId);
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

        public void Delete(EquipmentContract entity)
        {
            try
            {
                _connection.Open();
                using (var command = _connection.CreateCommand())
                {
                    command.CommandText = @"DELETE FROM Equipment_Contract WHERE Id = @Id";
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

        public void Update(EquipmentContract entity)
        {
            try
            {
                _connection.Open();
                using (var command = _connection.CreateCommand())
                {
                    command.CommandText =
                        @"UPDATE Equipment_Contract SET ContractId = @ContractId, EquipmentId = @EquipmentId
                                        WHERE Id = @Id";
                    command.AddParameter("Id", entity.Id);
                    command.AddParameter("ContractId", entity.ContractId);
                    command.AddParameter("EquipmentId", entity.EquipmentId);
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

        public IEnumerable<EquipmentContract> GetAll()
        {
            try
            {
                _connection.Open();
                using (var command = _connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Equipment_Contract";
                    using (var reader = command.ExecuteReader())
                    {
                        var items = new List<EquipmentContract>();
                        while (reader.Read())
                        {
                            var item = new EquipmentContract();
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
        public EquipmentContract GetByPrimaryKey(params object[] key)
        {
            if(key == null) throw new ArgumentNullException(); 
            if(key.Length != 1) throw new ArgumentException("Key is wrong!");
            if (!(key[0] is int)) throw new ArgumentException("Key is not a number!");
            try
            {
                _connection.Open();
                using (var command = _connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Equipment_Contract WHERE Id = @Id";
                    command.AddParameter("Id", key[0]);
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        var item = new EquipmentContract();
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


        protected override void Map(IDataRecord record, EquipmentContract entity)
        {
            entity.Id = (int)record["Id"];
            entity.ContractId = (int)record["ContractId"];
            entity.EquipmentId = (int)record["EquipmentId"];
        }
    }
}
