using allopromoDataAccess.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace allopromo.Model.DTO
{
    public class UserDTO
    {
        public string userName { get; set; }
        public string userPassword { get; set; }
    }
    public class UserDTOConverter
    {
        public UserDTO UserToDTO(ApplicationUser user)
        {
            UserDTO storeDTO = new UserDTO();
            return storeDTO;
        }
        public ApplicationUser ConvertToAppUser(UserDTO user)
        {
            var appUser = new ApplicationUser();
            appUser.UserName = user.userName;
            appUser.PasswordHash = user.userPassword;
            return appUser;
        }
        public List<UserDTO> ConvertToUsersDTO(List<ApplicationUser> users)
        {
            List<UserDTO> usersDTO = new List<UserDTO>();
            foreach(var user in users)
            {
                //usersDTO.Add(ConvertToUsersDTO(user));
            }
            return usersDTO;
        }
    }
}
// lundi 02 aout 11h30 ->
//2160 rue lavoisier - saintefioy- michel udon - bottewx de securite ----
//cours numero1 
//
//2
//mercredii 04 aout : @ 11h30
///
//360 $ chaque ---
// 10 blocs de 4 heures
//200 $ rabais ----3400$
// contenu formation::
// 1----ronde deseuite ----inspection de securite ---- camion dseul transmission ----
//2 -----remorque ---- sans remorque ----- 