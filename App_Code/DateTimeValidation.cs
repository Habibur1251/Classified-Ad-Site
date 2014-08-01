using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using System.Globalization;

/// <summary>
/// Summary description for DateTimeValidation
/// </summary>
public class DateTimeValidation
{
	public DateTimeValidation()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public class Date_Validation
    {   // For Validation of Date
        public Boolean date_Validate(string s_str)
        {
            bool b_isTrue = true;
            int i_length = s_str.Length;
            int j = 0;
            string s_day = String.Empty;
            string s_month = String.Empty;
            string s_year = String.Empty;
            string s = String.Empty;
            string s_temp = String.Empty;

            try
            {
                if (i_length != 10)
                {
                    i_length = 0;
                    s_str = String.Empty;
                  
                    return false;
                }

                for (int i = 0; i < i_length; i++)
                {
                    if ((s_str.Substring(i, 1) == "1") || (s_str.Substring(i, 1) == "2") || (s_str.Substring(i, 1) == "3") || (s_str.Substring(i, 1) == "4") ||
                        (s_str.Substring(i, 1) == "5") || (s_str.Substring(i, 1) == "6") || (s_str.Substring(i, 1) == "7") || (s_str.Substring(i, 1) == "8") ||
                        (s_str.Substring(i, 1) == "9") || (s_str.Substring(i, 1) == "0") || (s_str.Substring(i, 1) == "/"))
                    {
                        if (s_str.Substring(i, 1) == "/")
                        {
                            j += 1;
                            if (j > 2)
                            {
                               
                                s_str = String.Empty;
                                i_length = 0;
                                return false;
                            }
                        }
                    }
                }
                j = 0;
                s_str = s_str + "/";
                for (int i = 0; i < i_length + 1; i++)
                {
                    s = s_str.Substring(i, 1);
                    if (s != "/")
                    {
                        s_temp += s;
                    }
                    else
                    {
                        j += 1;
                        if (j == 1)
                        {
                            s_day = s_temp;
                            s_temp = String.Empty;
                        }
                        if (j == 2)
                        {
                            s_month = s_temp;
                            s_temp = String.Empty;
                        }
                        if (j == 3)
                        {
                            s_year = s_temp;
                            s_temp = String.Empty;
                        }
                    }
                }

                if (s_day == String.Empty)
                {
                  
                    return false;
                }
                else if (Convert.ToInt16(s_day) < 1)
                {
                   
                    return false;
                }
                else if (s_day.Length < 2)
                {
                   
                    return false;
                }

                if (s_month == String.Empty)
                {
                    
                    return false;
                }
                else if (Convert.ToInt16(s_month) < 1 || Convert.ToInt16(s_month) > 12)
                {
                    
                    return false;
                }
                else if (s_month.Length < 2)
                {
                    
                    return false;
                }
                else if ((s_month == "04" || s_month == "06" || s_month == "09" || s_month == "11") && Convert.ToInt16(s_day) > 30)
                {
                   
                    return false;
                }
                else if ((s_month == "01" || s_month == "03" || s_month == "05" || s_month == "07" || s_month == "08" ||
                s_month == "10" || s_month == "12") && Convert.ToInt16(s_day) > 31)
                {
                   
                    return false;
                }

                if (s_year == String.Empty)
                {
                   
                    return false;
                }
                else if (Convert.ToInt16(s_year) < 1754)
                {
                   
                    return false;
                }
                else if (s_year.Length < 4)
                {
                    
                    return false;
                }
                else
                {
                    if (s_month == "02")
                    {
                        if (Convert.ToInt16(s_year) % 4 != 0)
                        {
                            if (Convert.ToInt16(s_day) > 28)
                            {
                               
                                return false;
                            }
                        }
                        else if (Convert.ToInt16(s_year) % 400 == 0)
                        {
                            if (Convert.ToInt16(s_day) > 29)
                            {
                               
                                return false;
                            }
                        }
                        else if (Convert.ToInt16(s_year) % 100 == 0)
                        {
                            if (Convert.ToInt16(s_day) > 28)
                            {
                                return false;
                            }
                        }
                        else if (Convert.ToInt16(s_year) % 4 == 0)
                        {
                            if (Convert.ToInt16(s_day) > 29)
                            {
                                
                                return false;
                            }
                        }
                    }
                }
            }
            catch (System.ArgumentException ex)
            {
              
            }
            finally
            {
                //nothing;
            }
            return b_isTrue;
        }

        // For Date Format -- DD/MM/YYYY
        public String date_Format_Front_End(DateTime d)
        {
            string s_string = "";
            try
            {
                s_string = d.ToString("dd/MM/yyyy", DateTimeFormatInfo.InvariantInfo);
            }
            catch (System.ArgumentException ex)
            {
                
            }
            finally
            {
                //nothing;
            }
            return s_string;
        }

        // For Date Format -- MM/DD/YYYY
        public String date_Format_Back_End(string s_str)
        {
            try
            {
                s_str = s_str.Substring(3, 2) + "/" + s_str.Substring(0, 2) + "/" + s_str.Substring(6, 4);
            }
            catch (System.ArgumentException ex)
            {
                
            }
            finally
            {
                //nothing;
            }
            return s_str;
        }
    }
}
