using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class UserControl_CL_SelectCategory_Ctrl : System.Web.UI.UserControl
{
    #region PROPERTY
    private int counter = 0;
    private int row = 3;
    private string _SubcategoryHtml;

    public string SubcategoryHtml
    {
        get { return _SubcategoryHtml; }
        set { _SubcategoryHtml = value; }
    }

    
    private string _PrevCategory = "";

    public string PrevCategory
    {
        get { return _PrevCategory; }
        set { _PrevCategory = value; }
    }

    private bool _IsCorporateControlPanel;

    public bool IsCorporateControlPanel
    {
        get { return _IsCorporateControlPanel; }
        set { _IsCorporateControlPanel = value; }
    }

    #endregion PROPERTY

    #region CONTROL LOAD METHODS


    private void Load_BS_Subcategories()
    {
        //try
        //{
        //    using (BC_Product bcProductProfile = new BC_Product())
        //    {

        //        DataTable dt = bcProductProfile.Load_BS_Subcategories();
        //        if (dt.Rows.Count > 0)
        //        {

        //            grvCorporateCategory.DataSource = dt;
        //            counter = dt.Rows.Count;
        //            grvCorporateCategory.DataBind();
                    
        //        }
        //        else
        //        {
        //            lblSystemMessage.Text = "No Category available";
        //        }

        //    }
        //}
        //catch (Exception Exp)
        //{
        //    lblSystemMessage.Text = Exp.Message.ToString();
        //}
    }

    private void Load_CL_Categories()
    {
        try
        {
            using (BC_Product bcProductProfile = new BC_Product())
            {

                DataTable dt = bcProductProfile.Load_CL_Categories();
                if (dt.Rows.Count > 0)
                {

                    grvClassifiedCategory.DataSource = dt;
                    grvClassifiedCategory.DataBind();

                }
                else
                {
                    lblSystemMessage.Text = "No Category available";
                }

            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }
    }


    #endregion CONTROL LOAD METHODS


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!IsCorporateControlPanel)
            {
                this.Load_CL_Categories();
                
            }
            pnlClassifiedCategory.Visible = !IsCorporateControlPanel;
            //this.Load_BS_Subcategories();
        }
    }
    protected void grvCorporateCategory_RowCreated(object sender, GridViewRowEventArgs e)
    {
        

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            
            counter--;
            
            string _NewCategory = (string)DataBinder.Eval(e.Row.DataItem, "Category");
            string Subcategory = (string)DataBinder.Eval(e.Row.DataItem, "Subcategory");

            int CID = (Int32)DataBinder.Eval(e.Row.DataItem, "CategoryID");
            int SCID = (Int32)DataBinder.Eval(e.Row.DataItem, "SubcategoryID");
            
            
            if (_PrevCategory == _NewCategory)
            {
                if (CID == 7)
                {
                    SubcategoryHtml += "<a href='RealEstateAE.aspx?mode=0&pi=-1&CID=" + CID.ToString() + "&SCID=" + SCID.ToString() + "' class='onHoverBlue'>";
                }
                else
                {
                    SubcategoryHtml += "<a href='Product_Management.aspx?CID=" + CID.ToString() + "&SCID=" + SCID.ToString() + "' class='onHoverBlue'>";
                }
                SubcategoryHtml += Subcategory + "</a><br/>";
                
            }
            else
            {
                
                if (PrevCategory == "")
                {
                    SubcategoryHtml += "<table cellpadding='5' cellspacing='5'><tr><td valign='top'>";
                    SubcategoryHtml += "<strong class='colortitle'>" + _NewCategory + "</strong ><br/><br/>";
                    if (CID == 7)
                    {
                        SubcategoryHtml += "<a href='RealEstateAE.aspx?mode=0&pi=-1&CID=" + CID.ToString() + "&SCID=" + SCID.ToString() + "' class='onHoverBlue'>";
                    }
                    else
                    {
                        SubcategoryHtml += "<a href='Product_Management.aspx?CID=" + CID.ToString() + "&SCID=" + SCID.ToString() + "' class='onHoverBlue'>";
                    }
                    SubcategoryHtml += Subcategory + "</a><br/>";
                }
                else
                {
                    SubcategoryHtml += "</td>";
                    
                    if (row > 0)
                    {
                        
                    }
                    else
                    {
                        SubcategoryHtml += "</tr><tr>";
                        row = 4;
                    }
                    row--;

                    SubcategoryHtml += "<td valign='top'>";
                    SubcategoryHtml += "<strong class='colortitle'>" + _NewCategory + "</strong ><br/><br/>";

                    if (CID == 7)
                    {
                        SubcategoryHtml += "<a href='RealEstateAE.aspx?mode=0&pi=-1&CID=" + CID.ToString() + "&SCID=" + SCID.ToString() + "' class='onHoverBlue'>";
                    }
                    else
                    {
                        SubcategoryHtml += "<a href='Product_Management.aspx?CID=" + CID.ToString() + "&SCID=" + SCID.ToString() + "' class='onHoverBlue'>";
                    }
                    SubcategoryHtml += Subcategory + "</a><br/>";
                }
                
            }
            PrevCategory = _NewCategory;
            if (counter == 0)
            {
                SubcategoryHtml += "</td></tr></table>";
                PlaceHolder ph = (PlaceHolder)e.Row.FindControl("ph");
                Literal lit = new Literal();
                lit.Text = SubcategoryHtml;
                ph.Controls.Add(lit);

            }
            
            
        }
        
    }



}
