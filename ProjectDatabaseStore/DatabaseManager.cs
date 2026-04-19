using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectDatabaseStore
{
    /// <summary>
    /// не везду же мне писать что люблю тебя 
    /// Класс DatabaseManager отвечает за работу с базой данных.
    /// Он выполняет загрузку таблиц из базы данных, хранит их в локальном DataSet,
    /// создаёт новые строки, удаляет записи и сохраняет изменения обратно в базу.
    /// Также этот класс автоматически формирует SQL-команды для добавления,
    /// изменения и удаления данных.
    /// </summary>
    public class DatabaseManager
    {
        private readonly Dictionary<Type, SqlDbType> _typeMap =
            new Dictionary<Type, SqlDbType>
            {
                { typeof(int), SqlDbType.Int },
                { typeof(long), SqlDbType.BigInt },
                { typeof(string), SqlDbType.NVarChar },
                { typeof(bool), SqlDbType.Bit },
                { typeof(float), SqlDbType.Real },
                { typeof(double), SqlDbType.Float }
            };

        private readonly string _connectionString;
        private readonly SqlConnection _connection;
        private readonly SqlDataAdapter _adapter;
        private readonly DataSet _dataSet;

        public DatabaseManager(string connectionString)
        {
            _connectionString = connectionString;
            _connection = new SqlConnection(_connectionString);
            _adapter = new SqlDataAdapter();
            _dataSet = new DataSet();
        }

        public void LoadTable(string tableName)
        {
            if (_dataSet.Tables.Contains(tableName))
                return;

            string query = $"SELECT * FROM {tableName}";

            try
            {
                _connection.Open();

                SqlCommand command = new SqlCommand(query, _connection);
                _adapter.SelectCommand = command;

                DataTable table = new DataTable(tableName);
                _adapter.Fill(table);
                _dataSet.Tables.Add(table);

                _connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }
        }

        public DataTable GetTable(string tableName)
        {
            if (!_dataSet.Tables.Contains(tableName))
                LoadTable(tableName);

            return _dataSet.Tables[tableName];
        }

        public DataRow CreateNewRow(string tableName)
        {
            DataTable table = GetTable(tableName);
            return table.NewRow();
        }

        public void AddNewRow(string tableName, DataRow row)
        {
            DataTable table = GetTable(tableName);
            table.Rows.Add(row);
        }

        public void DeleteRow(DataRow row)
        {
            row.Delete();
        }

        private void CreateParameters(DataTable table, SqlCommand command)
        {
            var columns = table.Columns
                .Cast<DataColumn>()
                .Where(c => c.ColumnName != GetIdColumnName(table.TableName))
                .ToList();

            foreach (var column in columns)
            {
                SqlParameter parameter = new SqlParameter
                {
                    ParameterName = "@" + column.ColumnName,
                    SourceColumn = column.ColumnName,
                    SqlDbType = _typeMap[column.DataType]
                };

                command.Parameters.Add(parameter);
            }
        }

        private void CreateIdParameter(SqlCommand command, DataTable table, bool output)
        {
            SqlParameter parameter = new SqlParameter
            {
                ParameterName = "@" + GetIdColumnName(table.TableName),
                SourceColumn = GetIdColumnName(table.TableName),
                SqlDbType = SqlDbType.BigInt
            };

            if (output)
                parameter.Direction = ParameterDirection.Output;

            command.Parameters.Add(parameter);
        }

        private string GetIdColumnName(string tableName)
        {
            if (tableName == Constants.Tables.Department) return "DepartmentId";
            if (tableName == Constants.Tables.Supplier) return "SupplierId";
            if (tableName == Constants.Tables.Product) return "ProductId";

            throw new Exception("Неизвестная таблица");
        }

        private string GenerateUpdateSql(DataTable table)
        {
            string tableName = table.TableName;
            string idColumn = GetIdColumnName(tableName);

            var columnNames = table.Columns
                .Cast<DataColumn>()
                .Select(c => c.ColumnName)
                .Where(c => c != idColumn)
                .ToList();

            string setPart = string.Join(", ", columnNames.Select(c => $"{c} = @{c}"));

            return $"UPDATE dbo.[{tableName}] SET {setPart} WHERE {idColumn} = @{idColumn}";
        }

        private string GenerateInsertSql(DataTable table)
        {
            string tableName = table.TableName;
            string idColumn = GetIdColumnName(tableName);

            var columnNames = table.Columns
                .Cast<DataColumn>()
                .Select(c => c.ColumnName)
                .Where(c => c != idColumn)
                .ToList();

            string columnsPart = "(" + string.Join(", ", columnNames) + ")";
            string paramsPart = "(@" + string.Join(", @", columnNames) + ")";

            return $"INSERT INTO dbo.[{tableName}] {columnsPart} VALUES {paramsPart}; SELECT @{idColumn} = SCOPE_IDENTITY()";
        }

        private string GenerateDeleteSql(DataTable table)
        {
            string tableName = table.TableName;
            string idColumn = GetIdColumnName(tableName);

            return $"DELETE FROM dbo.[{tableName}] WHERE {idColumn} = @{idColumn}";
        }

        public bool SaveChanges(string tableName)
        {
            try
            {
                _connection.Open();

                DataTable table = GetTable(tableName);

                SqlCommand updateCommand = new SqlCommand(GenerateUpdateSql(table), _connection);
                CreateParameters(table, updateCommand);
                CreateIdParameter(updateCommand, table, false);
                _adapter.UpdateCommand = updateCommand;

                SqlCommand insertCommand = new SqlCommand(GenerateInsertSql(table), _connection);
                CreateParameters(table, insertCommand);
                CreateIdParameter(insertCommand, table, true);
                _adapter.InsertCommand = insertCommand;

                SqlCommand deleteCommand = new SqlCommand(GenerateDeleteSql(table), _connection);
                CreateIdParameter(deleteCommand, table, false);
                _adapter.DeleteCommand = deleteCommand;

                _adapter.Update(table);

                _connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

                if (_connection.State == ConnectionState.Open)
                    _connection.Close();

                return false;
            }
        }
    }
}
