using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Collections;
using System.Data.SqlClient;

public class UTLDBHandler : IDisposable
{
    private SqlDataAdapter objDataAdapter;
    

    public UTLDBHandler(string strConnectionString)
	{
        objDataAdapter = new SqlDataAdapter();
        objDataAdapter.SelectCommand = new SqlCommand();
        objDataAdapter.SelectCommand.Connection = new SqlConnection(strConnectionString);
        objDataAdapter.SelectCommand.Connection.Open();
	}
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(true);
    }
    protected virtual void Dispose(bool blnDisposing)
    {
        if (!blnDisposing)
        {
            return;
        }
        else
        {
            if (objDataAdapter != null)
            {
                if (objDataAdapter.SelectCommand != null)
                {
                    if (objDataAdapter.SelectCommand.Connection != null)
                    {
                        objDataAdapter.SelectCommand.Connection.Dispose();
                    }

                    objDataAdapter.SelectCommand.Dispose();
                }

                objDataAdapter.Dispose();
                objDataAdapter = null;
            }
        }
    }
    private void Initialize()
    {
        objDataAdapter.SelectCommand.Parameters.Clear();
    }
    protected DataTable ExecuteQuery(string strProcedureName, ArrayList arlSQLParameters)
    {
        if (objDataAdapter == null)
        {
            throw new System.ObjectDisposedException(GetType().FullName);
        }

        this.Initialize();

        DataTable objDataTable = new DataTable();

        SqlCommand objCommand = objDataAdapter.SelectCommand;
        objCommand.CommandText = strProcedureName;
        objCommand.CommandType = CommandType.StoredProcedure;

        if (arlSQLParameters != null)
        {
            for (int i = 0; i < arlSQLParameters.Count; i++)
            {
                objCommand.Parameters.Add(arlSQLParameters[i]);
            }
        }

        objDataAdapter.Fill(objDataTable);
        return objDataTable;
    }
    protected int ExecuteActionQuery(string strProcedureName, ArrayList arlSQLParameters)
    {
        if (objDataAdapter == null)
        {
            throw new System.ObjectDisposedException(GetType().FullName);
        }

        this.Initialize();

        int intResult = 0;

        SqlCommand objCommand = objDataAdapter.SelectCommand;
        objCommand.CommandText = strProcedureName;
        objCommand.CommandType = CommandType.StoredProcedure;

        if (arlSQLParameters != null)
        {
            for (int i = 0; i < arlSQLParameters.Count; i++)
            {
                objCommand.Parameters.Add(arlSQLParameters[i]);
            }
        }
        
        intResult = objCommand.ExecuteNonQuery();
        return intResult;
    }

    private void AddParameters(ref SqlCommand dbCommand, Hashtable htParams)
    {
        if (htParams != null)
        {
            IEnumerator e = htParams.GetEnumerator();

            while (e.MoveNext())
            {
                DictionaryEntry de = (DictionaryEntry)e.Current;
                SqlParameter sqlParam = new SqlParameter(de.Key.ToString(), de.Value);

                dbCommand.Parameters.Add(sqlParam);
            } // end while
        } // end if
    } // end AddParameters


    protected int ExecuteNonQueryStoredProcedure(string strProcedureName, Hashtable htParams)
    {
        if (objDataAdapter == null)
        {
            throw new System.ObjectDisposedException(GetType().FullName);
        } // end if

        Initialize();

        int intResult = 0;

        SqlCommand dbCommand = objDataAdapter.SelectCommand;
        dbCommand.CommandText = strProcedureName;
        dbCommand.CommandType = CommandType.StoredProcedure;
        dbCommand.CommandTimeout = 0;


        AddParameters(ref dbCommand, htParams);

        try
        {
            intResult = dbCommand.ExecuteNonQuery();
        }
        catch (System.Exception se)
        {
            string strErrorMsg = "An error occured calling " + strProcedureName + ": " + se.Message;

            if (htParams != null)
            {
                foreach (DictionaryEntry de in htParams)
                {
                    strErrorMsg += "<br>";
                    strErrorMsg += de.Key + "=" + de.Value;
                }
            } // end if

            throw se;
        } // end try-catch

        return intResult;
    } // end ExecuteNonQueryStoredProcedure

    protected int ExecuteActionQuery(string strProcedureName, ArrayList arlSQLParameters, string strOutputParameterName)
    {
        string strOutputValue = string.Empty;

        if (objDataAdapter == null)
        {
            throw new System.ObjectDisposedException(GetType().FullName);
        }

        this.Initialize();

        int intResult = 0;

        SqlCommand objCommand = objDataAdapter.SelectCommand;
        objCommand.CommandText = strProcedureName;
        objCommand.CommandType = CommandType.StoredProcedure;

        if (arlSQLParameters != null)
        {
            for (int i = 0; i < arlSQLParameters.Count; i++)
            {
                objCommand.Parameters.Add(arlSQLParameters[i]);
            }
        }

        SqlParameter outParameter = new SqlParameter();
        outParameter.ParameterName = strOutputParameterName;
        outParameter.Direction = ParameterDirection.Output;
        outParameter.DbType = DbType.Int32;
        objCommand.Parameters.Add(outParameter);

        intResult = objCommand.ExecuteNonQuery();

        if (intResult > 0)
        {
            strOutputValue = objCommand.Parameters[strOutputParameterName].Value.ToString();
        }
        else
        {
            strOutputValue = intResult.ToString();
        }
        
        return Convert.ToInt32(strOutputValue);
    }
}
