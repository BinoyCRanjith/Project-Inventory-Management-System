using Newtonsoft.Json;
using OneTeamAptitudeMVC.Web.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace OneTeamAptitudeMVC.AptitudeCore
{
    public class DbRepository
    {

        public DbResponseBase<TResult> GetResponse<TResult>(DbRequestBase request) where TResult : class
        {
            string connectionString = OneTeamApptitudeConstantClasss.connectionString;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(request.ProcedureName, con);

            DbParameter[] parametersArray = new DbParameter[] {
                cmd.CreateParameter(),
                cmd.CreateParameter(),
                cmd.CreateParameter(),
                cmd.CreateParameter(),
                cmd.CreateParameter(),
                cmd.CreateParameter()
            };

            parametersArray[0].ParameterName = "@Json";
            parametersArray[0].Value = request.InputJson;

            parametersArray[1].ParameterName = "@RetVal";
            parametersArray[1].DbType = DbType.Int32;
            parametersArray[1].Direction = ParameterDirection.Output;
            parametersArray[1].Size = Int32.MaxValue;
            parametersArray[1].Value = DBNull.Value;

            parametersArray[2].ParameterName = "@DataType";
            parametersArray[2].DbType = DbType.Int32;
            parametersArray[2].Direction = ParameterDirection.Output;
            parametersArray[2].Size = Int32.MaxValue;
            parametersArray[2].Value = DBNull.Value;

            parametersArray[3].ParameterName = "@ErrorNumber";
            parametersArray[3].DbType = DbType.Int32;
            parametersArray[3].Direction = ParameterDirection.Output;
            parametersArray[3].Size = Int32.MaxValue;
            parametersArray[3].Value = DBNull.Value;

            parametersArray[4].ParameterName = "@ErrorMessage";
            parametersArray[4].DbType = DbType.String;
            parametersArray[4].Size = 2000;
            parametersArray[4].Direction = ParameterDirection.Output;
            parametersArray[4].Value = DBNull.Value;

            parametersArray[5].ParameterName = "@JsonOutput";
            parametersArray[5].DbType = DbType.String;
            parametersArray[5].Size = 200000;
            parametersArray[5].Direction = ParameterDirection.Output;
            parametersArray[5].Value = DBNull.Value;


            cmd.Parameters.AddRange(parametersArray);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            TResult model = default(TResult);

            try
            {
                #region Execute Stored Procedure.
                switch (request.RequestType)
                {
                    case DbRequestType.Insert:
                    case DbRequestType.Update:
                    case DbRequestType.Delete:
                        //int returnValue = database.ExecuteNonQuery(cmd);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        break;
                    case DbRequestType.Scalar:
                        con.Open();
                        model = (TResult)cmd.ExecuteScalar();
                        con.Close();
                        break;
                    case DbRequestType.Select:
                        con.Open();
                        cmd.ExecuteNonQuery();
                        model = JsonConvert.DeserializeObject<TResult>(parametersArray[5].Value.ToString());

                        con.Close();

                        break;
                    default:
                        break;
                }
                #endregion
            }

            catch (Exception ex)
            {
                return new DbResponseBase<TResult>
                {
                    Data = null,
                    ErrorMessage = ex.Message,
                    ErrorNumber = -10,
                    Status = false,

                };
            }

            return new DbResponseBase<TResult>
            {
                Data = model,
                ErrorMessage = parametersArray[4].Value == null ? "" : parametersArray[4].Value.ToString(),
                ErrorNumber = (Int32)parametersArray[3].Value,
                Status = (Int32)parametersArray[3].Value == 0 ? true : false,
                RetVal = (Int32)parametersArray[1].Value
            };
        }

    }
}