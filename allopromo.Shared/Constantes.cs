using System;
using System.Collections.Generic;
using System.Text;

namespace allopromo.Shared
{
    public class Constantes
    {
        public class jh
        {
        }
        public class CodeRechercheDemande
        {
            public static string RD_ALM { get; set; }
        }

        public class BoutonAppel
        {
            public static string MENU_GERER_QUALITE { get; set; }
        }
        public class CodeRechercher
        {
            public static string RD_CRQ { get; set; }
            public static string RD_GEN { get; set; }

        }
        public class Parametres
        {
            public class TypeDRC
            {
                public static string Valeurs { get; set; }
            }
        }
        public class ApiInfo
        {
            public static string API_BASE = "http://localhost:61602/";
            public static string API_BASE2 = "https://localhost:44367";
            public static string apiStr2 = "https://allo.promo";
            public static string apiUrl = "api/v1/user/"; //{ get; set; }
            public static int MyProperty { get; set; }
            public static string API_CREATE_DEPARTMENT = "api/v1/department/create";
            public static string API_GET_DEPARTMENTS = "api/v1/departments";
            public static string API_GET_DEPARTMENT = "api/v1/department";
            public static string API_DELETE_DEPARTMENT = "api/v1/department/delete";

            public static string API_STORE_CREATE = "api/v1/store";
            public static string API_STORE_GET  = "api/v1/store";
        }
    }
}
