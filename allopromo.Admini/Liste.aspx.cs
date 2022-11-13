using allopromo.Admini.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace allopromo.Admini
{
    public partial class Liste : Page
    {
        public SortDirection direction
        {
            get
            {
                if (ViewState["directionState"] == null)
                {
                    ViewState["directionState"] = SortDirection.Ascending;
                }
                return (SortDirection)ViewState["directionState"];
            }
            set
            {
                ViewState["directionState"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    //gvResultatRechercheDemandes.DataSource = BindGridView();
                    //usersListGridView.Visible = true;
                    //usersListGridView.DataSource = GetUsers();

                    //listeUsersGridView35.DataSource = GetUsers(); //BindGridView();
                    //listeUsersGridView35.DataBind();

                    //gvResultatRechercheDemandes.DataBind();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private object BindGridView()
        {
            return null;
        }
        //private void gvResultatRechercheDemandes_PagesIndexChanging(object source,
        //   System.Web.UI.WebControls.GridViewPageEventArgs e)
        //{
        //    try
        //    {
        //        listeUsersGridView.PageIndex = e.NewPageIndex;
        //        if (Session["SortedView"] != null)
        //        {
        //            listeUsersGridView.DataSource = Session["SortedView"];
        //            listeUsersGridView.DataBind();
        //        }
        //        else
        //        {
        //            listeUsersGridView.DataSource = BindGridView();
        //            listeUsersGridView.DataBind();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //this.GererErreurTechnique(ex);
        //    }
        //}
        protected void gvResultatRechercheDemande_Sorting(object source, GridViewSortEventArgs e)
        {
            string sortingDirection = string.Empty;
            if (direction == SortDirection.Ascending)
            {
                direction = SortDirection.Descending;
                sortingDirection = "DESC";
            }
            else
            {
                direction = SortDirection.Ascending;
                sortingDirection = "ASC";
            }
            //DataSourceView sortedView = new DataView((DataTable)BindGridView());
        }
    }
}