using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using allopromo;
using System.Web.UI.WebControls;
using allopromo.Admini.Model;
using allopromo.Core.Model;
using allopromo.Core.Abstract;
using System.Threading.Tasks;

namespace allopromo.Admini.UserControls
{
    public partial class ucRechercherUsers : System.Web.UI.UserControl
    {
        protected string m_typeRecherche;
        public string typeRecherche
        {
            get
            {
                return m_typeRecherche;
            }
            set
            {
                m_typeRecherche = value;
            }
        }
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
        private void BindGridView()
        {
            usersListGridView.DataSource = GetUsers();
            usersListGridView.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            BindGridView();
            //try
            //{
            //    if (Request.QueryString.Equals(Constantes.Parametres.TypeDRC.Valeurs))//.ALERTE_MEDIA)
            //    {
            //        this.typeRecherche = Constantes.CodeRechercheDemande.RD_ALM;
            //    }
            //    else if (Request.QueryString.Equals(Constantes.BoutonAppel.MENU_GERER_QUALITE))
            //    {
            //        this.typeRecherche = Constantes.CodeRechercher.RD_CRQ;
            //    }
            //    else
            //    {
            //        this.typeRecherche = Constantes.CodeRechercher.RD_GEN;
            //    }
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }
        private void gvResultatRechercheDemandes_PagesIndexChanging(object source, 
            System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            try
            {
                if (Session["SortedView"] != null)
                {
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
            }
        }
        protected void gvResultatRechercheDemande_Sorting(object source, GridViewSortEventArgs e)
        {
            string sortingDirection = string.Empty;
            if(direction == SortDirection.Ascending)
            {
                direction = SortDirection.Descending;
                sortingDirection = "DESC";
            }
            else
            {
                direction = SortDirection.Ascending;
                sortingDirection = "ASC";
            }
            //DataSourceView sortedView = new DataView(BindGridView());
        }
        private List<UserDto> GetUsers()
        {
            //var users = new List<UserDto>();
            //var db = new AppDbContext();
            //IUserService userService = new UserService(null);

            IStoreService storeService = new StoreService(null);

            return null;
        }
    }
}

//defaul property defined using indexes ?
//VB :  default property ?
//Structured erro handling in C#, unstructured error h in vb ?
//Vb. Shadowing ?
