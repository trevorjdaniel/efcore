using System;
using System.Collections.Generic;
using System.Text;

namespace HiveBrite.Functions.Model
{
    public class CreateUserInterestsResponse : CreateWrapper
    {
        public CreateUserInterestsResponseUser user { get; set; }
    }

    public class CreateUserInterestsResponseUser
    {
        public int id { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public List<int> sub_network_ids { get; set; }
        public DateTime extended_updated_at { get; set; }
        public string email2 { get; set; }
        public string email3 { get; set; }
        public string primary_email_choice { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string maidenname { get; set; }
        public object prefix_name { get; set; }
        public object suffix_name { get; set; }
        public string external_id { get; set; }
        public object sso_identifier { get; set; }
        public string previous_id { get; set; }
        public bool is_active { get; set; }
        public string gender { get; set; }
        public object birthday { get; set; }
        public string birthplace { get; set; }
        public string headline { get; set; }
        public string summary { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime confirmed_at { get; set; }
        public object[] citizenship_ids { get; set; }
        public object[] citizenship_country_codes { get; set; }
        public bool deceased { get; set; }
        public object deceased_at { get; set; }
        public CreateUserInterestsResponsePhoto photo { get; set; }
        public bool do_not_contact { get; set; }
        public object mobile_perso { get; set; }
        public object mobile_pro { get; set; }
        public object landline_perso { get; set; }
        public object landline_pro { get; set; }
        public Postal_Personal postal_personal { get; set; }
        public Postal_Work postal_work { get; set; }
        public object preferred_postal_address { get; set; }
        public int role_id { get; set; }
        public string awards { get; set; }
        public string linkedin_profile_url { get; set; }
        public string website { get; set; }
        public string skype { get; set; }
        public object bbm { get; set; }
        public string twitter { get; set; }
        public string timezone { get; set; }
        public string facebook_profile_url { get; set; }
        public object honorary_title { get; set; }
        public Live_Location live_location { get; set; }
        public object resume { get; set; }
        public string locale { get; set; }
        public string share_email { get; set; }
        public string share_email2 { get; set; }
        public string share_email3 { get; set; }
        public string share_postal_address_personal { get; set; }
        public string share_postal_address_work { get; set; }
        public string share_nationalities { get; set; }
        public string share_resume { get; set; }
        public object share_mobile_pro { get; set; }
        public object share_mobile_perso { get; set; }
        public object share_landline_pro { get; set; }
        public object share_landline_perso { get; set; }
        public List<CreateUserInterestsResponseCustom_Attributes> custom_attributes { get; set; }
    }

    public class CreateUserInterestsResponsePhoto
    {
        public string largeurl { get; set; }
        public string mediumurl { get; set; }
        public string thumburl { get; set; }
        public string miniurl { get; set; }
        public string friendurl { get; set; }
        public string iconurl { get; set; }
    }

    public class Postal_Personal
    {
        public int id { get; set; }
        public string address_1 { get; set; }
        public string address_2 { get; set; }
        public string address_3 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postal_code { get; set; }
        public string country { get; set; }
        public bool default_billing_address { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int user_id { get; set; }
    }

    public class Postal_Work
    {
        public int id { get; set; }
        public string address_1 { get; set; }
        public string address_2 { get; set; }
        public string address_3 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postal_code { get; set; }
        public string country { get; set; }
        public bool default_billing_address { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int user_id { get; set; }
    }

    public class Live_Location
    {
        public string city { get; set; }
        public string country { get; set; }
        public string country_code { get; set; }
        public string address { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
    }

    public class CreateUserInterestsResponseCustom_Attributes
    {
        public int id { get; set; }
        public string name { get; set; }
        public string[] value { get; set; }
        public string type { get; set; }
    }

}
