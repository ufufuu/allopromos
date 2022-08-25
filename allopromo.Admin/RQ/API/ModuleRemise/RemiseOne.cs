using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace allopromo.Admin.RQ.API.ModuleRemise
{
    public class RemiseOne
    {
        // Creation manuelle d une Reception 
        //cas Utilisation  - Etape par Etape 

        //REQ_03
        // REQ ? 06 ?, 11 ?, ...
        //Effectuer la Recherche du detenteur
        
        public DetenteurResponse RechercherDetenteur(string detenteurName,
            string institutionName, Guid detenteurId)
        {
            return new DetenteurResponse();
        }
    }
    public class DetenteurResponse
    {
        public int detenteurId { get; set; }
        public string detenteurName { get; set; }
        public string? detenteurOldName { get; set; }
    }
    public class DetenteurSearch
    {
        public string detenteurName { get; set; }
        public string institutionName { get; set; }
        public Guid detenteurId { get; set; }
    }
    public class ProprietaireDesBiens
    {
        public int RAD { get; set; }
        public string Name { get; set; }
        public string ? NEQ { get; set; }
    }
}
