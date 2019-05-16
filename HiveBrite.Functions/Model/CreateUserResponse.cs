using System;
using System.Collections.Generic;
using System.Text;

namespace HiveBrite.Functions.Model
{

    public class CreateUpdateUserResponse : CreateWrapper
    {
        public CreateUpdateUserR user { get; set; }
    }

    public class CreateUpdateUserR
    {
        public int id { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public List<int> sub_network_ids { get; set; }
        public DateTime extended_updated_at { get; set; }
        public object email2 { get; set; }
        public object email3 { get; set; }
        public string primary_email_choice { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public object maidenname { get; set; }
        public object prefix_name { get; set; }
        public object suffix_name { get; set; }
        public object external_id { get; set; }
        public object sso_identifier { get; set; }
        public object previous_id { get; set; }
        public bool is_active { get; set; }
        public object gender { get; set; }
        public object birthday { get; set; }
        public object birthplace { get; set; }
        public object headline { get; set; }
        public object summary { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public object confirmed_at { get; set; }
        public object[] citizenship_ids { get; set; }
        public object[] citizenship_country_codes { get; set; }
        public bool deceased { get; set; }
        public object deceased_at { get; set; }
        public CreateUpdatePhotoR photo { get; set; }
        public bool do_not_contact { get; set; }
        public object mobile_perso { get; set; }
        public object mobile_pro { get; set; }
        public object landline_perso { get; set; }
        public object landline_pro { get; set; }
        public object postal_personal { get; set; }
        public object postal_work { get; set; }
        public object preferred_postal_address { get; set; }
        public int role_id { get; set; }
        public object awards { get; set; }
        public object linkedin_profile_url { get; set; }
        public object website { get; set; }
        public object skype { get; set; }
        public object bbm { get; set; }
        public object twitter { get; set; }
        public string timezone { get; set; }
        public object facebook_profile_url { get; set; }
        public object honorary_title { get; set; }
        public object live_location { get; set; }
        public object resume { get; set; }
        public object locale { get; set; }
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
        public List<CreateUpdateRCustom_Attributes> custom_attributes { get; set; }
    }

    public class CreateUpdatePhotoR
    {
        public string largeurl { get; set; }
        public string mediumurl { get; set; }
        public string thumburl { get; set; }
        public string miniurl { get; set; }
        public string friendurl { get; set; }
        public string iconurl { get; set; }
    }

    public class CreateUpdateRCustom_Attributes
    {
        public int id { get; set; }
        public string name { get; set; }
        public object value { get; set; }
        public string type { get; set; }
    }


}
