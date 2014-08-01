using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Globalization;

//namespace DAL
//{
    public class DbBaseClass : IDisposable
    {
        #region Private Fields
        private CultureInfo _cioSql;
        private SqlDataAdapter dbAdapter;
        #endregion

        #region Properties
        public CultureInfo SqlCultureInfo
        {
            get { return _cioSql; }
            set { _cioSql = value; }
        } // end SqlCultureInfo
        #endregion Properties

        #region Constructor(s)
        public DbBaseClass(string strConnectionString)
        {
            _cioSql = new CultureInfo("en-US");

            dbAdapter = new SqlDataAdapter();
            dbAdapter.SelectCommand = new SqlCommand();
            dbAdapter.SelectCommand.Connection = new SqlConnection(strConnectionString);

            dbAdapter.SelectCommand.Connection.Open();
        } // end constructor
        #endregion Constructor(s)

        #region Destructor(s)
        /// <summary>
        ///     Dispose of this object's resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(true); // as a service to those who might inherit from us
        } // end Dispose

        /// <summary>
        ///		Free the instance variables of this object.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
                return; // we're being collected, so let the GC take care of this object

            if (dbAdapter != null)
            {
                if (dbAdapter.SelectCommand != null)
                {
                    if (dbAdapter.SelectCommand.Connection != null)
                    {
                        dbAdapter.SelectCommand.Connection.Dispose();
                    } // end nested-nested if

                    dbAdapter.SelectCommand.Dispose();
                } // end nested if

                dbAdapter.Dispose();
                dbAdapter = null;
            } // end if
        } // end Dispose
        #endregion Destructor(s)

        #region Main Methods
        protected int ExecuteNonQueryStoredProcedure(string strProcedureName, Hashtable htParams)
        {
            if (dbAdapter == null)
            {
                throw new System.ObjectDisposedException(GetType().FullName);
            } // end if

            Initialize();

            int intResult = 0;

            SqlCommand dbCommand = dbAdapter.SelectCommand;
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

        protected DataTable ExecuteStoredProcedureDataTable(string strProcedureName, Hashtable htParams)
        {
            if (dbAdapter == null)
            {
                throw new System.ObjectDisposedException(GetType().FullName);
            } // end if

            Initialize();

            DataTable dtResult = new DataTable();

            SqlCommand dbCommand = dbAdapter.SelectCommand;
            dbCommand.CommandText = strProcedureName;
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.CommandTimeout = 0;

            AddParameters(ref dbCommand, htParams);

            try
            {
                dbAdapter.Fill(dtResult);
            }
            catch (System.Exception se)
            {
                throw se;
            } // end try-catch

            return dtResult;
        } // end ExecuteStoredProcedureDataTable

        protected object ExecuteStoredProcedureScalar(string strProcedureName, Hashtable htParams)
        {
            if (dbAdapter == null)
            {
                throw new System.ObjectDisposedException(GetType().FullName);
            } // end if

            Initialize();

            object objResult = null;

            SqlCommand dbCommand = dbAdapter.SelectCommand;
            dbCommand.CommandText = strProcedureName;
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.CommandTimeout = 0;

            AddParameters(ref dbCommand, htParams);

            try
            {
                objResult = dbCommand.ExecuteScalar();
            }
            catch (System.Exception se)
            {
                throw se;
            } // end try-catch

            return objResult;
        } // end ExecuteStoredProcedureScalar

        protected SqlDataReader ExecuteStoredProcedureDataReader(string strProcedureName, Hashtable htParams)
        {
            if (dbAdapter == null)
            {
                throw new System.ObjectDisposedException(GetType().FullName);
            } // end if

            Initialize();

            SqlDataReader sdrResult = null;

            SqlCommand dbCommand = dbAdapter.SelectCommand;
            dbCommand.CommandText = strProcedureName;
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.CommandTimeout = 0;

            AddParameters(ref dbCommand, htParams);

            try
            {
                sdrResult = dbCommand.ExecuteReader();
            }
            catch (System.Exception se)
            {
                throw se;
            } // end try-catch

            return sdrResult;
        } // end ExecuteStoredProcedureDataReader
        #endregion Main Methods

        #region Secondary Methods
        private void Initialize()
        {
            dbAdapter.SelectCommand.Parameters.Clear();
        } // end Initialize

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
        #endregion Secondary Methods
    } // end class BaseClass

//}
