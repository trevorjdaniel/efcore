using HiveBrite.Functions.Model;
using NetForums.Functions.Model;
using NetForumXwebSvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Net.Http;
using Microsoft.EntityFrameworkCore;
using ICMASync.Data.Context;

namespace ICMASync.Functions
{
    public class Engine
    {
        public static async Task Sync(string netforums_Username, string netforums_password, DateTime lastSyncDate, string hivebrite_BaseUrl, string hivebrite_AdminEmail, string hivebrite_Password, string hivebrite_ClientId, string hivebrite_ClientSecret, int hivebrite_SubNetworkId)
        {
            
            // I need to be able to access the database here....
            // The database is in the ICMASync.Data project.

            // Please provide code to enable me to "Test" table in the "Trev" column





            // Authenticate against NetForums
            AuthenticateResponse authenticateResponse = await NetForums.Functions.Engine.AuthenticateClient(netforums_Username, netforums_password);

            // Netforums: get a list of users from NetForums since last sync date by running netforums function SyncHBmembersdate
            // this will give me a list new members in NetForums  since the last sync
            List<HBIndividual> netforums_Individuals = await NetForums.Functions.Engine.SyncHBmembersdate(authenticateResponse, lastSyncDate);

            // Netforums: get a list of interests from NetForums updated since the last sync date
            // a distinct list of possible interests using SyncHBInterestsDate
            List<Interest> netforums_Interests = await NetForums.Functions.Engine.SyncHBInterestsDate(authenticateResponse, lastSyncDate);

            // HB: get all the users that have had their records updated using Engine.ListUsers with a the sync date
            // this will include the intersts when full_profile is set to TRUE using Engine.ListUsers


            // SYNC MEMBERS
            // push all members returned by SyncHBmembersdate into HB - don't user firstname > use badge name
            // sub network id will always be hard coded
            // different on sandbox and live
            // based on email address

            // get HB authentication information
            HBAuthData hBAuthData = HiveBrite.Functions.Engine.Authorize(hivebrite_BaseUrl, hivebrite_AdminEmail, hivebrite_Password, hivebrite_ClientId, hivebrite_ClientSecret);

            // get a list of users in HB
            List<HBUser> hivebrite_users = HiveBrite.Functions.Engine.ListUsers(hBAuthData, hivebrite_BaseUrl, null, true);

            foreach (HBIndividual individual in netforums_Individuals)
            {
                // check if this individual already exists in HB based on the email address
                HBUser hBUser = hivebrite_users.Where(x => x.email == individual.cst_eml_address_dn).FirstOrDefault();

                // if the user doesn't exist in HB then create it
                if (hBUser == null)
                {
                    // build the HB user object
                    CreateUpdateUser userToCreate = new CreateUpdateUser
                    {
                        user = new User
                        {
                            email = individual.cst_eml_address_dn,
                            firstname = individual.ind_badge_name,
                            is_active = true,
                            lastname = individual.ind_last_name,
                            sub_network_ids = new List<int>
                            {
                                hivebrite_SubNetworkId
                            },
                            external_id = individual.cst_recno,
                            email2 = individual.email2
                        }
                    };

                    // create the user in HB
                    CreateUpdateUserResponse userResponse = HiveBrite.Functions.Engine.CreateUpdateUser(hBAuthData, hivebrite_BaseUrl, userToCreate, HttpMethod.Post);
                }
            }

            // SYNC INTERESTS
            // TBD
        }
    }
}
