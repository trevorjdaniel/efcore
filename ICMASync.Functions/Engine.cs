using HiveBrite.Functions.Model;
using NetForums.Functions.Model;
using NetForumXwebSvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Net.Http;
using ICMASync.Data;

namespace ICMASync.Functions
{
    /// <summary>
    /// When you have a lot of parameters it's always better to wrap them in params class
    /// </summary>
    public class EngineSyncParams
    {
        public string NetforumsUsername { get; }
        public string NetforumsPassword { get; }
        public DateTime LastSyncDate { get; }
        public string HivebriteBaseUrl { get; }
        public string HivebriteAdminEmail { get; }
        public string HivebritePassword { get; }
        public string HivebriteClientId { get; }
        public string HivebriteClientSecret { get; }
        public int HivebriteSubNetworkId { get; }

        public EngineSyncParams(string netforums_Username,
            string netforums_password, DateTime lastSyncDate, string hivebrite_BaseUrl, string hivebrite_AdminEmail,
            string hivebrite_Password, string hivebrite_ClientId, string hivebrite_ClientSecret,
            int hivebrite_SubNetworkId)
        {
            NetforumsUsername = netforums_Username;
            NetforumsPassword = netforums_password;
            LastSyncDate = lastSyncDate;
            HivebriteBaseUrl = hivebrite_BaseUrl;
            HivebriteAdminEmail = hivebrite_AdminEmail;
            HivebritePassword = hivebrite_Password;
            HivebriteClientId = hivebrite_ClientId;
            HivebriteClientSecret = hivebrite_ClientSecret;
            HivebriteSubNetworkId = hivebrite_SubNetworkId;
        }
    }

    public class Engine
    {
        private readonly IBaseContextFactory _baseContextFactory;

        public Engine(IBaseContextFactory baseContextFactory)
        {
            _baseContextFactory = baseContextFactory;
        }

        public async Task Sync(EngineSyncParams @params)
        {
            // I need to be able to access the database here....
            // The database is in the ICMASync.Data project.

            // Please provide code to enable me to "Test" table in the "Trev" column
            using (var baseContext = _baseContextFactory.Create())
            {
                //Use baseContext
            }

            // Authenticate against NetForums
            AuthenticateResponse authenticateResponse = await NetForums.Functions.Engine.AuthenticateClient(@params.NetforumsUsername, @params.NetforumsPassword);

            // Netforums: get a list of users from NetForums since last sync date by running netforums function SyncHBmembersdate
            // this will give me a list new members in NetForums  since the last sync
            List<HBIndividual> netforums_Individuals = await NetForums.Functions.Engine.SyncHBmembersdate(authenticateResponse, @params.LastSyncDate);

            // Netforums: get a list of interests from NetForums updated since the last sync date
            // a distinct list of possible interests using SyncHBInterestsDate
            List<Interest> netforums_Interests = await NetForums.Functions.Engine.SyncHBInterestsDate(authenticateResponse, @params.LastSyncDate);

            // HB: get all the users that have had their records updated using Engine.ListUsers with a the sync date
            // this will include the intersts when full_profile is set to TRUE using Engine.ListUsers


            // SYNC MEMBERS
            // push all members returned by SyncHBmembersdate into HB - don't user firstname > use badge name
            // sub network id will always be hard coded
            // different on sandbox and live
            // based on email address

            // get HB authentication information
            HBAuthData hBAuthData = HiveBrite.Functions.Engine.Authorize(@params.HivebriteBaseUrl, @params.HivebriteAdminEmail, @params.HivebritePassword, @params.HivebriteClientId, @params.HivebriteClientSecret);

            // get a list of users in HB
            List<HBUser> hivebrite_users = HiveBrite.Functions.Engine.ListUsers(hBAuthData, @params.HivebriteBaseUrl, null, true);

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
                                @params.HivebriteSubNetworkId
                            },
                            external_id = individual.cst_recno,
                            email2 = individual.email2
                        }
                    };

                    // create the user in HB
                    CreateUpdateUserResponse userResponse = HiveBrite.Functions.Engine.CreateUpdateUser(hBAuthData, @params.HivebriteBaseUrl, userToCreate, HttpMethod.Post);
                }
            }

            // SYNC INTERESTS
            // TBD
        }
    }
}
