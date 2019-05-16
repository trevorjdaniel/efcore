using System;
using System.Collections.Generic;
using System.Text;

namespace HiveBrite.Functions.Model
{
    public class CompanyProfile
    {
        public Company company { get; set; }
    }

    public class Company
    {
        public int id { get; set; }
        public string name { get; set; }
        public object corporate_name { get; set; }
        public object company_identifier { get; set; }
        public object group_name { get; set; }
        public object company_number { get; set; }
        public object juridiction { get; set; }
        public object siret_nb { get; set; }
        public object siren_nb { get; set; }
        public object website_url { get; set; }
        public object blog_rss_url { get; set; }
        public object twitter_id { get; set; }
        public object facebook_id { get; set; }
        public object contact_info_phone1 { get; set; }
        public object contact_info_phone2 { get; set; }
        public object contact_info_fax { get; set; }
        public object short_description { get; set; }
        public object long_description { get; set; }
        public object founded_year { get; set; }
        public object video_url { get; set; }
        public object angel_list_url { get; set; }
        public object linkedin_url { get; set; }
        public object linkedin_id { get; set; }
        public object admin_comment { get; set; }
        public object annual_revenue { get; set; }
        public object external_job_board { get; set; }
        public string status { get; set; }
        public string activity_status { get; set; }
        public object code_naf { get; set; }
        public object email { get; set; }
        public bool do_not_contact { get; set; }
        public object code_ape_id { get; set; }
        public object xing_id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public object postal_location { get; set; }
        public object billing_location { get; set; }
    }

}
