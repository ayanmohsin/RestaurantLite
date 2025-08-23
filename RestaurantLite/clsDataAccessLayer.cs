using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantLite
{
    public class clsDataAccessLayer
    {
        public string SaveImages(DataSet pDataSet)
        {
            string lstrError = "";

            try
            {
                SqlCeConnection sqlCn = sqlcn();
                sqlCn.Open();
                Dictionary<string, SqlCeParameter> bt = new Dictionary<string, SqlCeParameter>();
                DataTable dtb = pDataSet.Tables[0];
                string strQuery = "Select * from " + dtb.TableName + " Where 1=2";
                DataTable dtbColumnExists = GetDataSet(strQuery, ref lstrError).Tables[0];
                string strColumn = "";
                string strValues = "";
                SqlCeParameter[] sqlPMCollection = new SqlCeParameter[dtb.Columns.Count];
                string strPKColumn = "";
                foreach (DataColumn dtColumn in dtb.Columns)
                {
                    if (dtbColumnExists.Columns.Contains(dtColumn.ColumnName))
                    {


                        if (dtColumn.AutoIncrement == false)
                        {
                            strColumn += dtColumn.ColumnName + ",";
                            strValues += "@" + dtColumn.ColumnName + ",";
                        }
                        else
                        {
                            strPKColumn = dtColumn.ColumnName;
                        }
                    }
                }
                if (strColumn != "")
                {
                    strColumn = strColumn.Remove(strColumn.Length - 1);
                    strValues = strValues.Remove(strValues.Length - 1);
                }
                string strInsert = "Insert into " + dtb.TableName + "(" + strColumn + ")values(" + strValues + ")";
                int iParameter = 0;
                foreach (DataColumn dtColumn in dtb.Columns)
                {

                    if (dtbColumnExists.Columns.Contains(dtColumn.ColumnName))
                    {

                        if (dtColumn.AutoIncrement == false)
                        {
                            SqlCeParameter picparameter;

                            picparameter = new SqlCeParameter();
                            picparameter.ParameterName = dtColumn.ColumnName;

                            #region Add Values
                            if (dtColumn.DataType == typeof(byte[]))
                            {
                                if (dtb.Rows[0][dtColumn.ColumnName].ToString() != "")
                                {
                                    byte[] arr = (byte[])dtb.Rows[0][dtColumn.ColumnName];
                                    picparameter.SqlDbType = SqlDbType.Image;
                                    picparameter.Value = arr;
                                }
                                else
                                {
                                    picparameter.SqlDbType = SqlDbType.Image;
                                    picparameter.Value = DBNull.Value;
                                }


                            }
                            if (dtColumn.DataType == typeof(int))
                            {
                                object oRecNo = dtb.Rows[0][dtColumn.ColumnName];
                                int iRecNo = 0;
                                if (oRecNo != null)
                                {
                                    if (oRecNo.ToString() != "")
                                    {
                                        iRecNo = Convert.ToInt32(oRecNo);
                                    }
                                }
                                int iRecord = iRecNo;
                                picparameter.SqlDbType = SqlDbType.Int;
                                picparameter.Value = iRecord;
                            }
                            if (dtColumn.DataType == typeof(string))
                            {
                                string value = (string)dtb.Rows[0][dtColumn.ColumnName];
                                picparameter.SqlDbType = SqlDbType.VarChar;
                                picparameter.Value = value;
                            }
                            if (dtColumn.DataType == typeof(DateTime))
                            {
                                DateTime value = (DateTime)dtb.Rows[0][dtColumn.ColumnName];
                                picparameter.SqlDbType = SqlDbType.DateTime;
                                picparameter.Value = value;
                            }
                            if (dtColumn.DataType == typeof(Boolean))
                            {
                                Boolean value = (Boolean)dtb.Rows[0][dtColumn.ColumnName];
                                picparameter.SqlDbType = SqlDbType.Bit;
                                picparameter.Value = value;
                            }
                            #endregion
                            sqlPMCollection[iParameter] = picparameter;
                            iParameter += 1;
                        }
                    }
                }
                SqlCeCommand cmd = new SqlCeCommand(strInsert, sqlCn);

                foreach (SqlCeParameter sqlPm in sqlPMCollection)
                {
                    if (sqlPm != null)
                    {
                        cmd.Parameters.Add(sqlPm);
                    }

                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                sqlCn.Dispose();
                lstrError = "OK";
            }
            catch (Exception ex)
            {
                lstrError = ex.Message;
            }
            return lstrError;
        }

        private SqlCeConnection sqlcn()
        {
            SqlCeConnection cn = new SqlCeConnection();
            string strAppFolder = "";
            strAppFolder= ConfigurationManager.AppSettings["Database"];
            string dbPath = ConfigurationManager.AppSettings["Database"];

            //strAppFolder = @"D:\Database\RestaurantLite.sdf";
            cn.ConnectionString = @"Data Source='" + strAppFolder + "';Password=toxic2225411;Persist Security Info=True";
            return cn;
        }

        public DataSet GetDataSet(string strQry, ref string strError)
        {
            DataSet ds = new DataSet();
            SqlCeConnection psqlcn = sqlcn();
            try
            {
                string strQuery;
                strQuery = strQry;
                psqlcn.Open();
                string []strSplit = strQuery.Split(';');
                foreach (string item in strSplit)
                {
                    if (item != "")
                    {
                        DataTable dtb = new DataTable();

                        SqlCeDataAdapter adpt = new SqlCeDataAdapter(item, psqlcn);
                        adpt.SelectCommand.CommandTimeout = 0;
                        adpt.Fill(dtb);
                        ds.Tables.Add(dtb.Copy());
                    }    
                }
                //if (strUserId == gstrUserId && strPwd == gstrPwd)
                //{
                psqlcn.Close();
                psqlcn.Dispose();
                strError = "OK";
                //}
            }
            catch (Exception ex)
            {
                psqlcn.Close();
                strError = ex.Message.ToString();
                psqlcn.Dispose();
                ds = null;
            }
            return ds;


        }

        public class OurResult
        {
            public int ErrorNumber { get; set; }
            public string ErrorString { get; set; }
            public string ModuleName { get; set; }
            public string ModuleFunctionName { get; set; }
            public int resultValue { get; set; }

        }
        public static T CleanValueNew<T>(object value)
        {
            if (value == null || value.ToString() == "")
            {
                if (typeof(T) == typeof(int))
                    return (T)(object)0;
                else if (typeof(T) == typeof(decimal))
                    return (T)(object)0m;
                else if (typeof(T) == typeof(double))
                    return (T)(object)0.0;
                else if (typeof(T) == typeof(string))
                    return (T)(object)"";
                else if (typeof(T) == typeof(bool))
                    return (T)(object)false;
                else
                    return default(T); // for custom reference types
            }

            return (T)Convert.ChangeType(value, typeof(T));
        }
        public OurResult MultipleDML(string strQuery, string strUserId, string strPwd)
        {
            OurResult lResult = new OurResult();
            SqlCeConnection db = sqlcn();
            SqlCeTransaction transaction;
            db.Open();
            transaction = db.BeginTransaction();
            try
            {
                string[] strQry = strQuery.Split(';');
                for (int i = 0; i < strQry.Length; i++)
                {
                    if (strQry[i] != "")
                    {
                        string strQ = strQry[i];
                        SqlCeCommand cmd = new SqlCeCommand(strQ, db, transaction);
                        lResult.resultValue = cmd.ExecuteNonQuery();
                    }
                }
                transaction.Commit();
                lResult.ErrorNumber = -1;
                lResult.ErrorString = "OK";
                lResult.ModuleName = "Exchange";
                lResult.ModuleFunctionName = "MultipleDML";
                return lResult;

            }
            catch (SqlException sqlError)
            {
                lResult.ErrorNumber = sqlError.HResult;
                lResult.ErrorString = sqlError.Message;
                lResult.ModuleName = "Exchange";
                lResult.ModuleFunctionName = "MultipleDML";
                transaction.Rollback();

            }
            db.Close();
            return lResult;
        }

    }
}
