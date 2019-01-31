using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace MainApp.Helpers
{
    public class SqlServerHelper
    {
        #region Databases
        public static List<string> GetDatabaseList(string serverName)
        {
            //try/catch
            Server server = new Server(serverName);
            List<string> databases = new List<string>();
            foreach (Database db in server.Databases)
            {
                databases.Add(db.Name);
            }
            return databases;
        }
        #endregion

        #region Tables
        public static List<Table> GetTableList(string serverName, string databaseName)
        {
            Server server = new Server(serverName);
            Database database = server.Databases[databaseName];
            List<Table> tables = new List<Table>();
            foreach (Table table in database.Tables)
            {
                tables.Add(table);
            }
            return tables;
        }
        #endregion

        #region Table
        public static Table GetTable(string serverName, string databaseName, string tableName)
        {
            Server server = new Server(serverName);
            Database database = server.Databases[databaseName];
            Table tableToShow = new Table();
            foreach (Table table in database.Tables)
            {
                if (table.Name == tableName)
                    tableToShow = table;
            }
            return tableToShow;
        }
        #endregion

        #region Views
        public static List<View> GetViewlist(string serverName, string databaseName, string schemaName = "")
        {
            Server server = new Server(serverName);
            Database database = server.Databases[databaseName];
           
            foreach (Schema item in database.Schemas)
            {
                var name = item.Name;
            }
            List<View> views = new List<View>();
            foreach (View view in database.Views)
            {
                if(view.Schema == "Custom")
                    views.Add(view);
            }
            return views;
        }
        #endregion

        #region Columns
        public static List<Column> GetColumnList(string serverName, string databaseName, Table table = null, View view = null)
        {
            Server server = new Server(serverName);
            Database database = server.Databases[databaseName];
            List<Column> columns = new List<Column>();
            if (table != null)
            {
                foreach (Column column in table.Columns)
                {
                    columns.Add(column);
                }
            }
    
            if (view != null)
            {
                foreach (Column column in view.Columns)
                {
                    columns.Add(column);
                }
            }

            return columns;
        }
        #endregion

        #region Types
        //all types need to be added
        public static Type GetDotNetType(Column column)
        {
            switch (column.DataType.SqlDataType)
            {
                case (SqlDataType.DateTime):
                    return typeof(DateTime);

                case (SqlDataType.DateTime2):
                    return typeof(DateTime);

                case (SqlDataType.Real):
                    return typeof(Single);

                case (SqlDataType.Float):
                    return typeof(double);

                case (SqlDataType.Decimal):
                    return typeof(decimal);

                case (SqlDataType.Int):
                    return typeof(Int32);

                case (SqlDataType.SmallInt):
                    return typeof(Int16);

                case (SqlDataType.TinyInt):
                    return typeof(Int16);

                case (SqlDataType.Bit):
                    return typeof(bool);

                case (SqlDataType.VarChar):
                    return typeof(String);

                case (SqlDataType.NVarChar):
                    return typeof(String);

                case (SqlDataType.Char):
                    return typeof(String);

                case (SqlDataType.SysName):
                    return typeof(String);

                case (SqlDataType.VarBinary):
                    return typeof(Byte[]);

                default:
                    return typeof(String);
            }
        }
        #endregion
    }
}
