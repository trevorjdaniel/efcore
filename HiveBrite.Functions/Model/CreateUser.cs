using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiveBrite.Functions.Model
{
    // 60691
    public class CreateUpdateUser
    {
        public User user { get; set; }
    }

    public class User
    {

        public string email { get; set; }
        public List<int> sub_network_ids { get; set; } = new List<int>();

        public string external_id { get; set; }
        public string email2 { get; set; }

        // User Postal
        public string personaladdress_1 { get; set; }
        public string personaladdress_2 { get; set; }
        public string personaladdress_3 { get; set; }
        public string personalcity { get; set; }
        public string personalstate { get; set; }
        public string personalpostal_code { get; set; }
        public string personalcountry { get; set; }
        //public bool userpostal_personaldefault_billing_address { get; set; }
        //public string userpostal_personalcreated_at { get; set; }
        //public string userpostal_personalupdated_at { get; set; }
        //public string userpostal_workaddress_1 { get; set; }
        //public string userpostal_workaddress_2 { get; set; }
        //public string userpostal_workaddress_3 { get; set; }
        //public string userpostal_workcity { get; set; }
        //public string userpostal_workstate { get; set; }
        //public string userpostal_workpostal_code { get; set; }
        //public string userpostal_workcountry { get; set; }
        //public bool userpostal_workdefault_billing_address { get; set; }
        //public string userpostal_workcreated_at { get; set; }
        //public string userpostal_workupdated_at { get; set; }
        //public string userextended_updated_at { get; set; }
        //public string useremail2 { get; set; }
        //public string useremail3 { get; set; }
        //public string userprimary_email_choice { get; set; }

        public string firstname { get; set; }
        public string lastname { get; set; }

        //public string usermaidenname { get; set; }
        //public string userprefix_name { get; set; }
        //public string usersuffix_name { get; set; }
        //public string userexternal_id { get; set; }
        //public string usersso_identifier { get; set; }
        //public string userprevious_id { get; set; }

        public bool is_active { get; set; }


        //public string usergender { get; set; }
        //public string userbirthday { get; set; }
        //public string userbirthplace { get; set; }
        //public string userheadline { get; set; }
        //public string usersummary { get; set; }
        //public string usercreated_at { get; set; }
        //public string userupdated_at { get; set; }
        //public int[] usercitizenship_ids { get; set; }
        //public object[] usercitizenship_country_codes { get; set; }
        //public bool userdeceased { get; set; }
        //public string userdeceased_at { get; set; }
        //public bool userdo_not_contact { get; set; }
        //public string usermobile_perso { get; set; }
        //public string usermobile_pro { get; set; }
        //public string userlandline_perso { get; set; }
        //public string userlandline_pro { get; set; }
        //public string userpreferred_postal_address { get; set; }
        //public int userrole_id { get; set; }
        //public string userawards { get; set; }
        //public string userlinkedin_profile_url { get; set; }
        //public string userwebsite { get; set; }
        //public string userskype { get; set; }
        //public string userbbm { get; set; }
        //public string usertwitter { get; set; }
        //public string usertimezone { get; set; }
        //public string userfacebook_profile_url { get; set; }
        //public string userhonorary_title { get; set; }
        //public string userlocale { get; set; }
        //public string usershare_email { get; set; }
        //public string usershare_email2 { get; set; }
        //public string usershare_email3 { get; set; }
        //public string usershare_postal_address_personal { get; set; }
        //public string usershare_postal_address_work { get; set; }
        //public string usershare_nationalities { get; set; }
        //public string usershare_resume { get; set; }
        //public string usershare_mobile_pro { get; set; }
        //public string usershare_mobile_perso { get; set; }
        //public string usershare_landline_pro { get; set; }
        //public string usershare_landline_perso { get; set; }
        //public object[] usercustom_attributes { get; set; }
        //public string userphoto { get; set; }
        //public string userresume { get; set; }
        //public string usernotify_after_create { get; set; }
    }

}
