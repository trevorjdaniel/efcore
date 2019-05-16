using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;
using NetForumXwebSvc;
using System.Linq;
using NetForums.Functions.Model;

namespace NetForums.Functions
{
    public class Engine
    {
        public static async Task<AuthenticateResponse> AuthenticateClient(string username, string password)
        {
            netForumXMLSoapClient client = new netForumXMLSoapClient();
            AuthenticateResponse response = await client.AuthenticateAsync(username, password);
            return response;
        }

        public static async Task<ExecuteMethodResponse> ExecuteMethodAsync(AuthenticateResponse authenticateResponse, string serviceName, string methodName, List<Parameter> parameters)
        {
            netForumXMLSoapClient client = new netForumXMLSoapClient();
            ExecuteMethodResponse response = await client.ExecuteMethodAsync(authenticateResponse.AuthorizationToken, serviceName, methodName, parameters.ToArray());
            return response;
        }

        public static async Task<List<Interest>> GetInterests(AuthenticateResponse authenticateResponse, DateTime dtLastSync)
        {
            List<Parameter> parameters = new List<Parameter>()
            {
                new Parameter
                {
                    Name = "dtLastSync",
                    Value = dtLastSync.ToString("MM-dd-yyyy")
                }
            };

            ExecuteMethodResponse result = await ExecuteMethodAsync(authenticateResponse, "NetForumSync", "SyncHBInterests", parameters);

            List<Interest> results = new List<Interest>();

            foreach (XElement xElement in result.ExecuteMethodResult.Elements())
            {
                results.Add(new Interest
                {
                    cst_recno = GetElementValue(xElement, "cst_recno"),
                    itc_code = GetElementValue(xElement, "itc_code"),
                    itc_description = GetElementValue(xElement, "itc_description")
                });
            }
            return results;
        }

        public static async Task<List<Activity>> GetActivities(AuthenticateResponse authenticateResponse)
        {
            List<Parameter> parameters = new List<Parameter>();
            ExecuteMethodResponse result = await ExecuteMethodAsync(authenticateResponse, "NetForumSync", "SyncActivities", parameters);

            List<Activity> results = new List<Activity>();

            foreach (XElement xElement in result.ExecuteMethodResult.Elements())
            {
                results.Add(new Activity
                {
                    Committee = GetElementValue(xElement, "committee"),
                    EndDate = !string.IsNullOrEmpty(GetElementValue(xElement, "enddate")) ? Convert.ToDateTime(GetElementValue(xElement, "enddate")) : new DateTime(1900, 1, 1),
                    Name = GetElementValue(xElement, "name"),
                    Period = GetElementValue(xElement, "period"),
                    Position = GetElementValue(xElement, "position"),
                    Recno = GetElementValue(xElement, "recno"),
                    StartDate = !string.IsNullOrEmpty(GetElementValue(xElement, "startdate")) ? Convert.ToDateTime(GetElementValue(xElement, "startdate")) : new DateTime(1900, 1, 1)
                });
            }

            return results;
        }

        public static async Task<List<HBIndividual>> SyncHBmembersdate(AuthenticateResponse authenticateResponse, DateTime dtLastSync)
        {
            List<Parameter> parameters = new List<Parameter>()
            {
                new Parameter
                {
                    Name = "dtLastSync",
                    Value = dtLastSync.ToString("MM-dd-yyyy")
                }
            };

            ExecuteMethodResponse result = await ExecuteMethodAsync(authenticateResponse, "NetForumSync", "SyncHBMembersDate", parameters);

            List<HBIndividual> results = new List<HBIndividual>();

            foreach (XElement xElement in result.ExecuteMethodResult.Elements())
            {
                results.Add(new HBIndividual
                {
                    cst_eml_address_dn = GetElementValue(xElement, "cst_eml_address_dn"),
                    cst_ixo_title_dn = GetElementValue(xElement, "cst_ixo_title_dn"),
                    cst_org_name_dn = GetElementValue(xElement, "cst_org_name_dn"),
                    cst_recno = GetElementValue(xElement, "cst_recno"),
                    ind_badge_name = GetElementValue(xElement, "ind_badge_name"),
                    ind_first_name = GetElementValue(xElement, "ind_first_name"),
                    ind_last_name = GetElementValue(xElement, "ind_last_name"),
                    mbt_code = GetElementValue(xElement, "mbt_code"),
                    org_id_ext = GetElementValue(xElement, "org_id_ext")
                });
            }

            return results;
        }

        public static async Task<List<Interest>> SyncHBInterestsDate(AuthenticateResponse authenticateResponse, DateTime dtLastSync)
        {
            List<Parameter> parameters = new List<Parameter>()
            {
                new Parameter
                {
                    Name = "dtLastSync",
                    Value = dtLastSync.ToString("MM-dd-yyyy")
                }
            };

            ExecuteMethodResponse result = await ExecuteMethodAsync(authenticateResponse, "NetForumSync", "SyncHBInterestsDate", parameters);

            List<Interest> results = new List<Interest>();

            foreach (XElement xElement in result.ExecuteMethodResult.Elements())
            {
                results.Add(new Interest
                {
                    cst_recno = GetElementValue(xElement, "cst_recno"),
                    itc_code = GetElementValue(xElement, "itc_code"),
                    itc_description = GetElementValue(xElement, "itc_description"),
                    itr_delete_flag = GetElementValue(xElement, "itr_delete_flag")
                });
            }

            return results;
        }

        public static async Task<List<Domain>> GetDomains(AuthenticateResponse authenticateResponse, int recono = 0)
        {
            List<Parameter> parameters = new List<Parameter>()
            {
                new Parameter
                {
                    Name = "recno",
                    Value = recono.ToString()
                }
            };

            ExecuteMethodResponse result = await ExecuteMethodAsync(authenticateResponse, "NetForumSync", "SyncDomains", parameters);

            List<Domain> results = new List<Domain>();

            foreach (XElement xElement in result.ExecuteMethodResult.Elements())
            {
                results.Add(new Domain
                {
                    Cst_Key = GetElementValue(xElement, "cst_key"),
                    Cst_Name_Cp = GetElementValue(xElement, "cst_name_cp"),
                    Cst_Recno = GetElementValue(xElement, "cst_recno"),
                    Url_Code = GetElementValue(xElement, "url_code")
                });
            }

            return results;
        }

        public static async Task GetNewOrganisations(AuthenticateResponse authenticateResponse, DateTime lastSyncDate)
        {
            List<Parameter> parameters = new List<Parameter>()
            {
                new Parameter
                {
                    Name = "dtLastOrgSync",
                    Value = lastSyncDate.ToString("MM-dd-yyyy")
                }
            };

            ExecuteMethodResponse result = await ExecuteMethodAsync(authenticateResponse, "NetForumSync", "SyncOrganizations", parameters);
        }

        public static async Task<List<Education>> GetEducation(AuthenticateResponse authenticateResponse, int recno = 0)
        {
            List<Parameter> parameters = new List<Parameter>()
            {
                new Parameter
                {
                    Name = "recno",
                    Value = recno.ToString()
                }
            };

            ExecuteMethodResponse result = await ExecuteMethodAsync(authenticateResponse, "NetForumSync", "SyncEducation", parameters);

            List<Education> results = new List<Education>();

            foreach (XElement xElement in result.ExecuteMethodResult.Elements())
            {
                results.Add(new Education
                {
                    Deg_Date = !string.IsNullOrEmpty(GetElementValue(xElement, "deg_date")) ? Convert.ToDateTime(GetElementValue(xElement, "deg_date")) : new DateTime(1900, 1, 1),
                    Cst_Recno = GetElementValue(xElement, "cst_recno"),
                    Deg_Institution_Ext = GetElementValue(xElement, "deg_institution_ext"),
                    Deg_State_Ext = GetElementValue(xElement, "deg_state_ext"),
                    Det_Code = GetElementValue(xElement, "det_code")
                });
            }

            return results;
        }

        public static string GetElementValue(XElement element, string elementName)
        {
            XElement child = element.Element(elementName);
            return child != null ? child.Value : string.Empty;
        }

        public static async Task<List<JobHistory>> GetJobHistory(AuthenticateResponse authenticateResponse, string contactId = "0")
        {
            List<Parameter> parameters = new List<Parameter>()
            {
                new Parameter
                {
                    Name = "recno",
                    Value = contactId
                }
            };

            ExecuteMethodResponse result = await ExecuteMethodAsync(authenticateResponse, "NetForumSync", "SyncJobHistory", parameters);

            List<JobHistory> results = new List<JobHistory>();

            foreach (XElement xElement in result.ExecuteMethodResult.Elements())
            {
                results.Add(new JobHistory
                {
                    cst_key = GetElementValue(xElement, "cst_key"),
                    cst_recno = GetElementValue(xElement, "cst_recno"),
                    i02_country = GetElementValue(xElement, "cst_recno"),
                    i02_end_date = !string.IsNullOrEmpty(GetElementValue(xElement, "i02_end_date")) ? Convert.ToDateTime(GetElementValue(xElement, "i02_end_date")) : new DateTime(1900, 1, 1),
                    i02_job_title = GetElementValue(xElement, "i02_job_title"),
                    i02_local_government_flag = GetElementValue(xElement, "i02_local_government_flag"),
                    i02_org_name = GetElementValue(xElement, "i02_org_name"),
                    i02_province = GetElementValue(xElement, "i02_province"),
                    i02_start_date = !string.IsNullOrEmpty(GetElementValue(xElement, "i02_start_date")) ? Convert.ToDateTime(GetElementValue(xElement, "i02_start_date")) : new DateTime(1900, 1, 1),
                    i02_state = GetElementValue(xElement, "i02_state")
                });
            }

            return results;
        }

        public static async Task<List<Award>> GetAwards(AuthenticateResponse authenticateResponse)
        {
            List<Parameter> parameters = new List<Parameter>();

            ExecuteMethodResponse result = await ExecuteMethodAsync(authenticateResponse, "NetForumSync", "SyncAwards", parameters);

            List<Award> results = new List<Award>();

            foreach (XElement xElement in result.ExecuteMethodResult.Elements())
            {
                results.Add(new Award
                {
                    awe_date_presented = !string.IsNullOrEmpty(GetElementValue(xElement, "awe_date_presented")) ? Convert.ToDateTime(GetElementValue(xElement, "awe_date_presented")) : new DateTime(1900, 1, 1),
                    awe_notes = GetElementValue(xElement, "awe_notes"),
                    awh_name = GetElementValue(xElement, "awh_name"),
                    cst_recno = GetElementValue(xElement, "cst_recno")
                });
            }

            return results;
        }

        public static async Task<List<Group>> GetGroupSync2(AuthenticateResponse authenticateResponse)
        {
            List<Parameter> parameters = new List<Parameter>();

            ExecuteMethodResponse result = await ExecuteMethodAsync(authenticateResponse, "NetForumSync", "SyncGroups2", parameters);

            List<Group> results = new List<Group>();

            foreach (XElement xElement in result.ExecuteMethodResult.Elements())
            {
                results.Add(new Group
                {
                    cst_recno = GetElementValue(xElement, "cst_recno"),
                    description = GetElementValue(xElement, "description"),
                    end_date = !string.IsNullOrEmpty(GetElementValue(xElement, "end_date")) ? Convert.ToDateTime(GetElementValue(xElement, "end_date")) : new DateTime(1900, 1, 1),
                    group_name = GetElementValue(xElement, "group_name"),
                    group_type = GetElementValue(xElement, "group_type"),
                    position = GetElementValue(xElement, "position")
                });
            }

            return results;
        }

        public static async Task SyncContacts2(AuthenticateResponse authenticateResponse, string contactId)
        {
            List<Parameter> parameters = new List<Parameter>()
            {
                new Parameter
                {
                    Name = "strContactID",
                    Value = contactId
                }
            };

            ExecuteMethodResponse result = await ExecuteMethodAsync(authenticateResponse, "NetForumSync", "SyncIndividualSelect", parameters);
        }

        public static async Task<List<IndividualDate>> GetNewSyncs2(AuthenticateResponse authenticateResponse, DateTime lastSyncDate)
        {
            List<Parameter> parameters = new List<Parameter>()
            {
                new Parameter
                {
                    Name = "dtLastSync",
                    Value = lastSyncDate.ToString("MM-dd-yyyy")
                }
            };

            ExecuteMethodResponse result = await ExecuteMethodAsync(authenticateResponse, "NetForumSync", "SyncIndividualDate", parameters);

            List<IndividualDate> results = new List<IndividualDate>();

            foreach (XElement xElement in result.ExecuteMethodResult.Elements())
            {
                results.Add(new IndividualDate
                {
                    cst_add_date = !string.IsNullOrEmpty(GetElementValue(xElement, "cst_add_date")) ? Convert.ToDateTime(GetElementValue(xElement, "cst_add_date")) : new DateTime(1900, 1, 1),
                    cst_change_date = !string.IsNullOrEmpty(GetElementValue(xElement, "cst_change_date")) ? Convert.ToDateTime(GetElementValue(xElement, "cst_change_date")) : new DateTime(1900, 1, 1),
                    cst_recno = GetElementValue(xElement, "cst_recno"),
                    eml_add_date = !string.IsNullOrEmpty(GetElementValue(xElement, "eml_add_date")) ? Convert.ToDateTime(GetElementValue(xElement, "eml_add_date")) : new DateTime(1900, 1, 1),
                    ind_add_date = !string.IsNullOrEmpty(GetElementValue(xElement, "ind_add_date")) ? Convert.ToDateTime(GetElementValue(xElement, "ind_add_date")) : new DateTime(1900, 1, 1),
                    ind_change_date = !string.IsNullOrEmpty(GetElementValue(xElement, "ind_change_date")) ? Convert.ToDateTime(GetElementValue(xElement, "ind_change_date")) : new DateTime(1900, 1, 1),
                    ind_cst_key = GetElementValue(xElement, "ind_cst_key")
                });
            }

            return results;
        }

        public static async Task SyncOrgs(AuthenticateResponse authenticateResponse, string orgId)
        {
            List<Parameter> parameters = new List<Parameter>()
            {
                new Parameter
                {
                    Name = "strOrgID",
                    Value = orgId
                }
            };

            ExecuteMethodResponse result = await ExecuteMethodAsync(authenticateResponse, "NetForumSync", "SyncOrganizationsSelect", parameters);
        }
    }
}
