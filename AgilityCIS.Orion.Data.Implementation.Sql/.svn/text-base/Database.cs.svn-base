/* Any mods n this layer should be rebuilt and uploaded on the bin folder of Agility Site*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgilityCIS.Orion.Data.Interfaces;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Configuration;
using System.Data;
using AgilityCIS.Orion.Services.DataContracts;
using System.Data.SqlClient;

namespace AgilityCIS.Orion.Data.Implementation.Sql
{
    public class Database : IDatabase
    {
        #region Fields (1)

        SqlDatabase database = default(SqlDatabase);

        #endregion Fields

        #region Constructors (1)

        public Database()
        {
            database = new SqlDatabase(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        }

        #endregion Constructors

        #region Methods (23)

        // Public Methods (23) 

        public bool DeleteCustomer(string customerNo)
        {
            bool retVal = false;
            try
            {
                //dbc_remove_cust @seq_party_id =112399
                object[] parameters = new object[1];
                parameters[0] = customerNo;
                var result = database.ExecuteScalar("dbc_remove_cust", parameters);

                // This is dirty and this cannot be predicted until confirming what exactly does the stored proc return.
                try
                {
                    int rowsAffected = (int)result;
                    if (rowsAffected > 0)
                        retVal = true;
                }
                catch
                {
                    // Ignore as now it cannot be predicted.
                    throw new Exception(result.ToString());
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return retVal;
        }

        public List<AddressType> GetAddressTypes()
        {
            List<AddressType> addressTypes = new List<AddressType>();
            try
            {
                StringBuilder query = new StringBuilder();
                query.Append(" SELECT  crm_address_type.seq_addr_type_id ,           crm_address_type.address_type ,           crm_address_type.address_type_desc     FROM crm_address_type      WHERE ( crm_address_type.active = 'Y') -- for address type (postal address,street address, residential address) ");
                DataSet ds = database.ExecuteDataSet(System.Data.CommandType.Text, query.ToString());
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        addressTypes.Add(new AddressType
                        {
                            AddressTypeId = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["seq_addr_type_id"])) ? int.Parse(Convert.ToString(ds.Tables[0].Rows[i]["seq_addr_type_id"])) : 0,
                            AddressTypeCode = Convert.ToString(ds.Tables[0].Rows[i]["address_type"]),
                            AddressTypeDesc = Convert.ToString(ds.Tables[0].Rows[i]["address_type_desc"])
                        });
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return addressTypes;
        }

        public List<BillingCycle> GetBillingCycles()
        {
            List<BillingCycle> billingCycles = new List<BillingCycle>();
            try
            {
                StringBuilder query = new StringBuilder();
                query.Append("SELECT  nc_billing_cycle.seq_bill_cycle_id ,  nc_billing_cycle.bill_cycle_code ,nc_billing_cycle.bill_cycle_desc  FROM nc_billing_cycle WHERE ( nc_billing_cycle.active = 'Y' )  ORDER BY nc_billing_cycle.bill_cycle_code ASC  ");
                DataSet ds = database.ExecuteDataSet(System.Data.CommandType.Text, query.ToString());
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        billingCycles.Add(new BillingCycle
                        {
                            BillingCycleId = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["seq_bill_cycle_id"])) ? int.Parse(Convert.ToString(ds.Tables[0].Rows[i]["seq_bill_cycle_id"])) : 0,
                            BillingCycleCode = Convert.ToString(ds.Tables[0].Rows[i]["bill_cycle_code"]),
                            BillingCycleDesc = Convert.ToString(ds.Tables[0].Rows[i]["bill_cycle_desc"])
                        });
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return billingCycles;
        }

        public List<BillingUnit> GetBillingUnits()
        {
            List<BillingUnit> billingUnits = new List<BillingUnit>();
            try
            {
                StringBuilder query = new StringBuilder();
                query.Append("SELECT DISTINCT nc_bill_option.seq_bill_type_id,           nc_bill_option.bill_type,           nc_bill_option.bill_type_desc      FROM nc_bill_option  ORDER BY nc_bill_option.bill_type DESC  ");
                DataSet ds = database.ExecuteDataSet(System.Data.CommandType.Text, query.ToString());
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        billingUnits.Add(new BillingUnit
                        {
                            BillingUnitId = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["seq_bill_type_id"])) ? int.Parse(Convert.ToString(ds.Tables[0].Rows[i]["seq_bill_type_id"])) : 0,
                            BillingUnitCode = Convert.ToString(ds.Tables[0].Rows[i]["bill_type"]),
                            BillingUnitDesc = Convert.ToString(ds.Tables[0].Rows[i]["bill_type_desc"])
                        });
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return billingUnits;
        }

        public List<CardType> GetCardTypes()
        {
            List<CardType> cardTypes = new List<CardType>();
            try
            {
                StringBuilder query = new StringBuilder();
                query.Append("SELECT  ar_credit_card_type.credit_card_type_code ,           ar_credit_card_type.credit_card_desc     FROM ar_credit_card_type   ORDER BY ar_credit_card_type.credit_card_type_code          ASC ");
                DataSet ds = database.ExecuteDataSet(System.Data.CommandType.Text, query.ToString());
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        cardTypes.Add(new CardType
                        {
                            CardTypeCode = Convert.ToString(ds.Tables[0].Rows[i]["credit_card_type_code"]),
                            CardTypeDesc = Convert.ToString(ds.Tables[0].Rows[i]["credit_card_desc"]),
                        });
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return cardTypes;
        }

        public List<Company> GetCompanies()
        {
            List<Company> companies = new List<Company>();
            try
            {
                StringBuilder query = new StringBuilder();
                query.Append("SELECT  crm_district.district_id ,             crm_district.district_code ,             crm_district.district_desc          FROM crm_district                WHERE ( crm_district.active = 'Y' )            ORDER BY crm_district.district_code          ASC");
                DataSet ds = database.ExecuteDataSet(System.Data.CommandType.Text, query.ToString());
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        companies.Add(new Company
                        {
                            CompanyId = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["district_id"])) ? int.Parse(Convert.ToString(ds.Tables[0].Rows[i]["district_id"])) : 0,
                            CompanyCode = Convert.ToString(ds.Tables[0].Rows[i]["district_code"]),
                            CompanyDesc = Convert.ToString(ds.Tables[0].Rows[i]["district_desc"])
                        });
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return companies;
        }

        public List<CreditCheckScore> GetCreditCheckScores()
        {
            List<CreditCheckScore> creditCheckScores = new List<CreditCheckScore>();
            try
            {
                StringBuilder query = new StringBuilder();
                query.Append("SELECT  nc_int_credit_check.seq_int_crd_chk_id ,           nc_int_credit_check.score ,           nc_int_credit_check.score_desc ,           nc_int_credit_check.bond_reqd_yn ,           nc_int_credit_check.bond_amount     FROM nc_int_credit_check      WHERE ( nc_int_credit_check.active = 'Y' )  ORDER BY nc_int_credit_check.score          ASC  ");
                DataSet ds = database.ExecuteDataSet(System.Data.CommandType.Text, query.ToString());
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        creditCheckScores.Add(new CreditCheckScore
                        {
                            CreditCheckScoreId = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["seq_int_crd_chk_id"])) ? int.Parse(Convert.ToString(ds.Tables[0].Rows[i]["seq_int_crd_chk_id"])) : 0,
                            BondAmount = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["bond_amount"])) ? double.Parse(Convert.ToString(ds.Tables[0].Rows[i]["bond_amount"])) : 0,
                            CreditCheckScoreDesc = Convert.ToString(ds.Tables[0].Rows[i]["score_desc"]),
                            Score = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["score"])) ? int.Parse(Convert.ToString(ds.Tables[0].Rows[i]["score"])) : 0,
                            IsBondReqd = (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["bond_reqd_yn"]))) && (Convert.ToString(ds.Tables[0].Rows[i]["bond_reqd_yn"]) == "Y") ? true : false

                        });
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return creditCheckScores;
        }

        public List<CreditControlStatus> GetCreditControlStatus()
        {
            List<CreditControlStatus> creditControlStatuses = new List<CreditControlStatus>();
            try
            {
                StringBuilder query = new StringBuilder();
                query.Append("SELECT  nc_credit_control_status.seq_credit_status_id ,           nc_credit_control_status.seq_credit_status_code ,           nc_credit_control_status.seq_credit_status_desc     FROM nc_credit_control_status");
                DataSet ds = database.ExecuteDataSet(System.Data.CommandType.Text, query.ToString());
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        creditControlStatuses.Add(new CreditControlStatus
                        {
                            CreditControlStatusId = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["seq_credit_status_id"])) ? int.Parse(Convert.ToString(ds.Tables[0].Rows[i]["seq_credit_status_id"])) : 0,
                            CreditControlStatusDesc = Convert.ToString(ds.Tables[0].Rows[i]["seq_credit_status_desc"]),
                            CreditControlStatusCode = Convert.ToString(ds.Tables[0].Rows[i]["seq_credit_status_code"])
                        });
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return creditControlStatuses;
        }

        public CustomerDetails GetCustomerDetails(int customerNo)
        {
            CustomerDetails custDetails = new CustomerDetails();
            try
            {
                StringBuilder query = new StringBuilder();
                query.Append("  SELECT pty.seq_party_id,");
                query.Append(" eh.seq_element_type_id,");
                query.Append(" pty.party_code,");
                query.Append(" pty.party_name,");
                query.Append(" pty.first_name,");
                query.Append(" pty.last_name,");
                query.Append(" pty.initials,");
                query.Append(" pty.phone_no,");
                query.Append(" pty.std_code,");
                query.Append(" pty.fax_no,");
                query.Append(" pty.email_address,");
                query.Append(" pty.web_address,");
                query.Append(" pty.street_addr_no,");
                query.Append(" pty.street_post_code,");
                query.Append(" pty.postal_post_code,");
                query.Append(" pty.street_addr_1,");
                query.Append(" pty.street_addr_2,");
                query.Append(" pty.street_addr_3,");
                query.Append(" pty.street_addr_4,");
                query.Append(" pty.street_addr_5,");
                query.Append(" pty.postal_addr_1,");
                query.Append(" pty.postal_addr_2,");
                query.Append(" pty.postal_addr_3,");
                query.Append(" pty.postal_addr_4,");
                query.Append("pty.postal_addr_5,");
                query.Append("pty.notes,");
                query.Append(" pty.active,");
                query.Append(" pty.insert_datetime,");
                query.Append(" pty.insert_user,");
                query.Append(" pty.insert_process,");
                query.Append(" pty.update_datetime,");
                query.Append(" pty.update_user,");
                query.Append(" pty.update_process,");
                query.Append(" eh.element_id,");
                query.Append(" eh.element_struct_code,");
                query.Append(" eh.parent_id,");
                query.Append(" eh.parent_element_struct_code,");
                query.Append(" cli.seq_comp_type_id,");
                query.Append(" cli.seq_industry_id,");
                query.Append(" cli.seq_client_priority_id,");

                // Pay method
                query.Append(" cli.seq_pay_method_id,");

                //Billing cycle
                query.Append(" cli.seq_bill_cycle_id,");

                // Credit check id
                query.Append(" cli.seq_int_crd_chk_id,");

                // Delivery mode id
                query.Append(" cli.seq_inv_del_mode_id,");

                // Invoice style id
                query.Append(" cli.seq_inv_style_id,");

                // Tax indicator id
                query.Append(" cli.seq_tax_ind_id,");
                query.Append(" cli.password,");
                query.Append(" cli.employer,");
                query.Append(" cli.alert,");
                query.Append(" cli.estimate_date,");
                query.Append(" cli.auck_employ,");
                query.Append(" cli.nz_employ,");
                query.Append(" cli.annual_sale,");
                query.Append(" cli.mobile_user,");
                query.Append("cli.connect_call,");
                query.Append(" cli.credit_reseller_flag,");
                query.Append(" cli.date_received,");
                query.Append("cli.seq_staff_id,");
                query.Append("cli.credit_limit,");
                query.Append("cli.stop_credit_flag,");
                query.Append(" cli.bank,");
                query.Append(" cli.bank_branch,");
                query.Append(" cli.bank_account_no,");
                query.Append(" cli.credit_card_type_code,");
                query.Append(" cli.credit_card_name,");
                query.Append(" cli.credit_card_no,");
                query.Append(" cli.credit_card_expiry,");
                query.Append(" cli.credit_card_verif_no,");
                query.Append(" cli.prompt_payment_discount,");
                query.Append(" cli.bill_notes,");
                query.Append(" cli.avg_monthly_spend,");
                query.Append(" stf.party_code,");
                query.Append(" stf.party_name,");
                query.Append(" ind.industry_code,");
                query.Append(" ind.industry_desc,");
                query.Append(" override_name = 'N',");
                query.Append(" cli.additional_svce_0800,");
                query.Append(" cli.additional_svce_ccard,");
                query.Append(" cli.additional_svce_power,");
                query.Append(" cli.additional_svce_tolls,");
                query.Append(" cli.seq_pcms_int_status_id,");
                query.Append(" cli.calling_card_reseller,");

                // Credit status id
                query.Append(" cli.seq_credit_status_id,");
                query.Append(" cli.bond,");
                query.Append(" cli.developer,");
                query.Append(" cli.alert_expires,");
                query.Append(" cli.alert_expiry_date,");
                query.Append(" cli.agc_rewards,");
                query.Append(" cli.correspondence_by_email,");
                query.Append(" cli.correspondence_by_post,");
                query.Append(" cli.date_details_confirmed,");
                query.Append(" cli.bank_account_name,");

                // District id or Company name
                query.Append(" cli.district_id,");
                query.Append(" cli.trading_name,");

                // Bill type/unit id
                query.Append(" cli.seq_bill_type_id,");
                query.Append("cli.rest_assn_num,");

                // Treatment type id
                query.Append(" cli.treat_type_id");
                query.Append(" FROM dbo.nc_client             cli");
                query.Append(" JOIN dbo.crm_party             pty ON cli.seq_party_id = pty.seq_party_id");
                query.Append("  JOIN dbo.crm_element_hierarchy eh  ON cli.seq_party_id = eh.element_id");
                query.Append(" LEFT JOIN");
                query.Append("	 dbo.crm_party             stf ON cli.seq_staff_id = stf.seq_party_id");
                query.Append(" LEFT JOIN");
                query.Append("	 dbo.nc_industry           ind ON cli.seq_industry_id = ind.seq_industry_id");
                query.Append(" WHERE cli.seq_party_id = " + customerNo + "");
                DataSet ds = database.ExecuteDataSet(System.Data.CommandType.Text, query.ToString());
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    custDetails.SeqPartyId = Convert.ToString(ds.Tables[0].Rows[0]["seq_party_id"]).Trim();
                    custDetails.SeqPartyTypeId = Convert.ToString(ds.Tables[0].Rows[0]["seq_element_type_id"]).Trim();
                    custDetails.CustomerNo = Convert.ToString(ds.Tables[0].Rows[0]["party_code"]);
                    custDetails.CustomerName = Convert.ToString(ds.Tables[0].Rows[0]["party_name"]);
                    custDetails.CustomerFName = Convert.ToString(ds.Tables[0].Rows[0]["first_name"]).Trim();
                    custDetails.CustomerLName = Convert.ToString(ds.Tables[0].Rows[0]["last_name"]).Trim();
                    custDetails.CustomerInitial = Convert.ToString(ds.Tables[0].Rows[0]["initials"]).Trim();
                    custDetails.Phone = Convert.ToString(ds.Tables[0].Rows[0]["phone_no"]).Trim();
                    custDetails.STDCode = Convert.ToString(ds.Tables[0].Rows[0]["std_code"]).Trim();
                    custDetails.Fax = Convert.ToString(ds.Tables[0].Rows[0]["fax_no"]).Trim();
                    custDetails.EMailAddress = Convert.ToString(ds.Tables[0].Rows[0]["email_address"]).Trim();
                    custDetails.WebAddress = Convert.ToString(ds.Tables[0].Rows[0]["web_address"]).Trim();
                    custDetails.StreetAddrNo = Convert.ToString(ds.Tables[0].Rows[0]["street_addr_no"]).Trim();
                    custDetails.StreetPostCode = Convert.ToString(ds.Tables[0].Rows[0]["street_post_code"]).Trim();
                    custDetails.PostalPostCode = Convert.ToString(ds.Tables[0].Rows[0]["postal_post_code"]).Trim();
                    custDetails.StreetAddr1 = Convert.ToString(ds.Tables[0].Rows[0]["street_addr_1"]).Trim();
                    custDetails.StreetAddr2 = Convert.ToString(ds.Tables[0].Rows[0]["street_addr_2"]).Trim();
                    custDetails.StreetAddr3 = Convert.ToString(ds.Tables[0].Rows[0]["street_addr_3"]).Trim();
                    custDetails.StreetAddr4 = Convert.ToString(ds.Tables[0].Rows[0]["street_addr_4"]).Trim();
                    custDetails.StreetAddr5 = Convert.ToString(ds.Tables[0].Rows[0]["street_addr_5"]).Trim();
                    custDetails.PostalAddr1 = Convert.ToString(ds.Tables[0].Rows[0]["postal_addr_1"]).Trim();
                    custDetails.PostalAddr2 = Convert.ToString(ds.Tables[0].Rows[0]["postal_addr_2"]).Trim();
                    custDetails.PostalAddr3 = Convert.ToString(ds.Tables[0].Rows[0]["postal_addr_3"]).Trim();
                    custDetails.PostalAddr4 = Convert.ToString(ds.Tables[0].Rows[0]["postal_addr_4"]).Trim();
                    custDetails.PostalAddr5 = Convert.ToString(ds.Tables[0].Rows[0]["postal_addr_5"]).Trim();
                    custDetails.Notes = Convert.ToString(ds.Tables[0].Rows[0]["notes"]).Trim();
                    custDetails.TradingName = Convert.ToString(ds.Tables[0].Rows[0]["trading_name"]).Trim();
                    custDetails.RestaurantAssnNo = Convert.ToString(ds.Tables[0].Rows[0]["rest_assn_num"]).Trim();
                    custDetails.PromptPayDisc = Convert.ToString(ds.Tables[0].Rows[0]["prompt_payment_discount"]).Trim();
                    if (Convert.ToString(ds.Tables[0].Rows[0]["active"]) == "Y")
                    {
                        custDetails.IsActive = true;
                    }
                    else
                    {
                        custDetails.IsActive = false;
                    }


                    custDetails.SeqPayMethodId = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["seq_pay_method_id"])) ? int.Parse(Convert.ToString(ds.Tables[0].Rows[0]["seq_pay_method_id"])) : 0;
                    custDetails.SeqBillCycleId = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["seq_bill_cycle_id"])) ? int.Parse(Convert.ToString(ds.Tables[0].Rows[0]["seq_bill_cycle_id"])) : 0;
                    custDetails.SeqCreditCheckId = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["seq_int_crd_chk_id"])) ? int.Parse(Convert.ToString(ds.Tables[0].Rows[0]["seq_int_crd_chk_id"])) : 0;
                    custDetails.SeqBillCycle = new BillingCycle
                    {
                        BillingCycleId = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["seq_bill_cycle_id"])) ? int.Parse(Convert.ToString(ds.Tables[0].Rows[0]["seq_bill_cycle_id"])) : 0
                    };

                    custDetails.AccMgr = new Party
                    {
                        SeqPartyId = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["seq_staff_id"])) ? int.Parse(Convert.ToString(ds.Tables[0].Rows[0]["seq_staff_id"])) : 0
                    };

                    custDetails.Type = new TreatmentType
                   {
                       TreatmentTypeId = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["treat_type_id"])) ? int.Parse(Convert.ToString(ds.Tables[0].Rows[0]["treat_type_id"])) : 0
                   };

                    custDetails.PmtMethod = new PayMethod
                    {
                        PayMethodId = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["seq_pay_method_id"])) ? int.Parse(Convert.ToString(ds.Tables[0].Rows[0]["seq_pay_method_id"])) : 0
                    };

                    custDetails.CreditCtrlStatus = new CreditControlStatus
                    {
                        CreditControlStatusId = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["seq_credit_status_id"])) ? int.Parse(Convert.ToString(ds.Tables[0].Rows[0]["seq_credit_status_id"])) : 0
                    };

                    custDetails.CreditCardType = new CardType
                    {
                        CardTypeCode = Convert.ToString(ds.Tables[0].Rows[0]["credit_card_type_code"])

                    };

                    custDetails.InvDelivery = new InvoiceDelivery
                    {
                        InvoiceDeliveryId = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["seq_inv_del_mode_id"])) ? int.Parse(Convert.ToString(ds.Tables[0].Rows[0]["seq_inv_del_mode_id"])) : 0

                    };

                    custDetails.InvStyle = new InvoiceStyle
                    {
                        InvoiceStyleId = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["seq_inv_style_id"])) ? int.Parse(Convert.ToString(ds.Tables[0].Rows[0]["seq_inv_style_id"])) : 0

                    };

                    custDetails.CustType = new CustomerType
                    {
                        CustomerTypeId = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["seq_element_type_id"])) ? int.Parse(Convert.ToString(ds.Tables[0].Rows[0]["seq_element_type_id"])) : 0

                    };

                    custDetails.CustCompany = new Company
                    {
                        CompanyId = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["district_id"])) ? int.Parse(Convert.ToString(ds.Tables[0].Rows[0]["district_id"])) : 0

                    };


                    custDetails.Score = new CreditCheckScore
                    {
                        CreditCheckScoreId = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["seq_int_crd_chk_id"])) ? int.Parse(Convert.ToString(ds.Tables[0].Rows[0]["seq_int_crd_chk_id"])) : 0
                    };

                    custDetails.IndustryDetails = new Industry
                    {
                        IndustryId = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["seq_industry_id"])) ? int.Parse(Convert.ToString(ds.Tables[0].Rows[0]["seq_industry_id"])) : 0,
                        IndustryCode = Convert.ToString(ds.Tables[0].Rows[0]["industry_code"]),
                        IndustryDesc = Convert.ToString(ds.Tables[0].Rows[0]["industry_desc"])
                    };

                    custDetails.SeqPriority = new Priority
                    {
                        PriorityId = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["seq_client_priority_id"])) ? int.Parse(Convert.ToString(ds.Tables[0].Rows[0]["seq_client_priority_id"])) : 0
                    };

                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["agc_rewards"])))
                    {
                        custDetails.AgcRewards = Convert.ToDateTime(Convert.ToString(ds.Tables[0].Rows[0]["agc_rewards"]));
                    }

                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["date_details_confirmed"])))
                    {
                        custDetails.DateDetailsConfirmed = Convert.ToDateTime(Convert.ToString(ds.Tables[0].Rows[0]["date_details_confirmed"]));
                    }

                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["alert_expiry_date"])))
                    {
                        custDetails.AlertExpiryDate = Convert.ToDateTime(Convert.ToString(ds.Tables[0].Rows[0]["alert_expiry_date"]));
                    }

                    custDetails.SeqTaxIndId = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["seq_tax_ind_id"])) ? int.Parse(Convert.ToString(ds.Tables[0].Rows[0]["seq_tax_ind_id"])) : 0;
                    custDetails.BondAmt = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["bond"])) ? double.Parse(Convert.ToString(ds.Tables[0].Rows[0]["bond"])) : 0;

                    custDetails.Password = Convert.ToString(ds.Tables[0].Rows[0]["password"]).Trim();
                    custDetails.Employer = Convert.ToString(ds.Tables[0].Rows[0]["employer"]).Trim();
                    custDetails.Alert = Convert.ToString(ds.Tables[0].Rows[0]["alert"]).Trim();
                    custDetails.EstimateDate = Convert.ToString(ds.Tables[0].Rows[0]["estimate_date"]).Trim();
                    custDetails.CreditLimit = Convert.ToString(ds.Tables[0].Rows[0]["credit_limit"]).Trim();
                    custDetails.Bank = Convert.ToString(ds.Tables[0].Rows[0]["bank"]).Trim();
                    custDetails.BankBranch = Convert.ToString(ds.Tables[0].Rows[0]["bank_branch"]).Trim();
                    custDetails.BankAccNo = Convert.ToString(ds.Tables[0].Rows[0]["bank_account_no"]).Trim();
                    custDetails.CreditCardTypeCode = Convert.ToString(ds.Tables[0].Rows[0]["credit_card_type_code"]).Trim();
                    custDetails.CreditCardName = Convert.ToString(ds.Tables[0].Rows[0]["credit_card_name"]).Trim();
                    custDetails.CreditCardNo = Convert.ToString(ds.Tables[0].Rows[0]["credit_card_no"]).Trim();
                    custDetails.CreditCardExpiry = Convert.ToString(ds.Tables[0].Rows[0]["credit_card_expiry"]).Trim();
                    custDetails.CreditCardVerifyNo = Convert.ToString(ds.Tables[0].Rows[0]["credit_card_verif_no"]).Trim();
                    custDetails.CreditCardNo = Convert.ToString(ds.Tables[0].Rows[0]["credit_card_no"]).Trim();
                    custDetails.BillNotes = Convert.ToString(ds.Tables[0].Rows[0]["bill_notes"]).Trim();
                    custDetails.AvgMonthlySpend = Convert.ToString(ds.Tables[0].Rows[0]["avg_monthly_spend"]).Trim();
                    if (Convert.ToString(ds.Tables[0].Rows[0]["override_name"]) == "Y")
                    {
                        custDetails.IsNameOverride = true;
                    }
                    else
                    {
                        custDetails.IsNameOverride = false;
                    }

                    if (Convert.ToString(ds.Tables[0].Rows[0]["developer"]) == "Y")
                    {
                        custDetails.IsDeveloper = true;
                    }
                    else
                    {
                        custDetails.IsDeveloper = false;
                    }

                    if (Convert.ToString(ds.Tables[0].Rows[0]["alert_expires"]) == "Y")
                    {
                        custDetails.IsAlertExpires = true;
                    }
                    else
                    {
                        custDetails.IsAlertExpires = false;
                    }

                    if (Convert.ToString(ds.Tables[0].Rows[0]["correspondence_by_email"]) == "Y")
                    {
                        custDetails.IsCorrespondenceByEMail = true;
                    }
                    else
                    {
                        custDetails.IsCorrespondenceByEMail = false;
                    }

                    if (Convert.ToString(ds.Tables[0].Rows[0]["correspondence_by_post"]) == "Y")
                    {
                        custDetails.IsCorrespondenceByPost = true;
                    }
                    else
                    {
                        custDetails.IsCorrespondenceByPost = false;
                    }

                    custDetails.BankAccName = Convert.ToString(ds.Tables[0].Rows[0]["bank_account_name"]).Trim();
                    custDetails.SeqBillTypeId = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["seq_bill_type_id"])) ? int.Parse(Convert.ToString(ds.Tables[0].Rows[0]["seq_bill_type_id"])) : 0;

                    custDetails.TreatmentTypeId = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["treat_type_id"])) ? int.Parse(Convert.ToString(ds.Tables[0].Rows[0]["treat_type_id"])) : 0;
                    custDetails.SeqTaxIndicator = new TaxIndicator
                    {
                        TaxIndicatorId = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["seq_tax_ind_id"])) ? int.Parse(Convert.ToString(ds.Tables[0].Rows[0]["seq_tax_ind_id"])) : 0

                    };

                    custDetails.SeqBillingUnit = new BillingUnit
                    {
                        BillingUnitId = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["seq_bill_type_id"])) ? int.Parse(Convert.ToString(ds.Tables[0].Rows[0]["seq_bill_type_id"])) : 0
                    };
                    //

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return custDetails;

        }

        public CustomerSummary GetCustomerSummaryDetails(int seqPartyId)
        {
            CustomerSummary custSummary = new CustomerSummary();
            try
            {
                object[] parameters = new object[1];
                parameters[0] = seqPartyId;
                DataSet ds = database.ExecuteDataSet("dbp_summary_details", parameters);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    custSummary.DecisionMakerName = Convert.ToString(ds.Tables[0].Rows[0]["decision_maker_name"]);
                    custSummary.BillingContactName = Convert.ToString(ds.Tables[0].Rows[0]["billing_contact_name"]);
                    custSummary.SeqPartyId = Convert.ToString(seqPartyId);
                    custSummary.AccMgrName = Convert.ToString(ds.Tables[0].Rows[0]["acc_mgr_name"]);

                    custSummary.AvgMonthlySpend = Convert.ToString(ds.Tables[0].Rows[0]["avg_monthly_spend"]);

                    custSummary.CreditStatusCode = Convert.ToString(ds.Tables[0].Rows[0]["seq_credit_status_code"]);

                    custSummary.CurrPeriod = Convert.ToString(ds.Tables[0].Rows[0]["current_period"]);

                    custSummary.CustomerName = Convert.ToString(ds.Tables[0].Rows[0]["party_name"]);

                    custSummary.CustomerNo = Convert.ToString(ds.Tables[0].Rows[0]["party_code"]);

                    custSummary.DistrictCode = Convert.ToString(ds.Tables[0].Rows[0]["district_code"]);
                    custSummary.Fax = Convert.ToString(ds.Tables[0].Rows[0]["fax_no"]);
                    custSummary.Phone = Convert.ToString(ds.Tables[0].Rows[0]["phone_no"]);
                    custSummary.PostalAddr1 = Convert.ToString(ds.Tables[0].Rows[0]["postal_addr_1"]);
                    custSummary.PostalAddr2 = Convert.ToString(ds.Tables[0].Rows[0]["postal_addr_2"]);
                    custSummary.PostalAddr3 = Convert.ToString(ds.Tables[0].Rows[0]["postal_addr_3"]);
                    custSummary.PostalPostCode = Convert.ToString(ds.Tables[0].Rows[0]["postal_post_code"]);
                    custSummary.StreetAddr1 = Convert.ToString(ds.Tables[0].Rows[0]["street_addr_1"]);
                    custSummary.StreetAddr2 = Convert.ToString(ds.Tables[0].Rows[0]["street_addr_2"]);
                    custSummary.StreetAddr3 = Convert.ToString(ds.Tables[0].Rows[0]["street_addr_3"]);
                    custSummary.StreetAddrNo = Convert.ToString(ds.Tables[0].Rows[0]["street_addr_no"]);
                    custSummary.StreetPostCode = Convert.ToString(ds.Tables[0].Rows[0]["street_post_code"]);

                    custSummary.TotalAmt = Convert.ToString(ds.Tables[0].Rows[0]["total_amount"]);

                    custSummary.OverdueAmt = Convert.ToString(ds.Tables[0].Rows[0]["overdue_amount"]);

                    custSummary.CurrAmt = Convert.ToString(ds.Tables[0].Rows[0]["current_amount"]);

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return custSummary;
            // exec dbo.dbp_summary_details N'79377'
        }

        public List<CustomerType> GetCustomerTypes()
        {
            List<CustomerType> customerTypes = new List<CustomerType>();
            try
            {
                StringBuilder query = new StringBuilder();
                query.Append("SELECT  crm_party_type.seq_party_type_id ,           crm_party_type.party_type ,           crm_party_type.party_type_desc     FROM crm_party_type      WHERE ( crm_party_type.active = 'Y' ) And          ( crm_party_type.element_struct_code = 'CLIENT' )  ORDER BY crm_party_type.party_type_desc          ASC ");
                DataSet ds = database.ExecuteDataSet(System.Data.CommandType.Text, query.ToString());
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        customerTypes.Add(new CustomerType
                        {
                            CustomerTypeId = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["seq_party_type_id"])) ? int.Parse(Convert.ToString(ds.Tables[0].Rows[i]["seq_party_type_id"])) : 0,
                            CustomerTypeCode = Convert.ToString(ds.Tables[0].Rows[i]["party_type"]),
                            CustomerTypeDesc = Convert.ToString(ds.Tables[0].Rows[i]["party_type_desc"])
                        });
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return customerTypes;
        }

        public List<Industry> GetIndustries()
        {
            List<Industry> industries = new List<Industry>();
            try
            {
                StringBuilder query = new StringBuilder();
                query.Append("SELECT  nc_industry.seq_industry_id ,           nc_industry.industry_code ,           nc_industry.industry_desc     FROM nc_industry      WHERE ( nc_industry.active = 'Y' )  ");
                DataSet ds = database.ExecuteDataSet(System.Data.CommandType.Text, query.ToString());
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        industries.Add(new Industry
                        {
                            IndustryId = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["seq_industry_id"])) ? int.Parse(Convert.ToString(ds.Tables[0].Rows[i]["seq_industry_id"])) : 0,
                            IndustryCode = Convert.ToString(ds.Tables[0].Rows[i]["industry_code"]),
                            IndustryDesc = Convert.ToString(ds.Tables[0].Rows[i]["industry_desc"])
                        });
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return industries;
        }

        public List<InvoiceDelivery> GetInvoiceDeliveries()
        {
            //
            List<InvoiceDelivery> invoiceDeliveries = new List<InvoiceDelivery>();
            try
            {
                StringBuilder query = new StringBuilder();
                query.Append("SELECT  nc_inv_deliver_mode.seq_inv_del_mode_id ,           nc_inv_deliver_mode.inv_del_mode_code ,           nc_inv_deliver_mode.inv_del_mode_desc     FROM nc_inv_deliver_mode      WHERE ( nc_inv_deliver_mode.active = 'Y' )  ORDER BY nc_inv_deliver_mode.inv_del_mode_desc          ASC  ");
                DataSet ds = database.ExecuteDataSet(System.Data.CommandType.Text, query.ToString());
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        invoiceDeliveries.Add(new InvoiceDelivery
                        {
                            InvoiceDeliveryId = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["seq_inv_del_mode_id"])) ? int.Parse(Convert.ToString(ds.Tables[0].Rows[i]["seq_inv_del_mode_id"])) : 0,
                            InvoiceDeliveryCode = Convert.ToString(ds.Tables[0].Rows[i]["inv_del_mode_code"]),
                            InvoiceDeliveryDesc = Convert.ToString(ds.Tables[0].Rows[i]["inv_del_mode_desc"]),
                        });
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return invoiceDeliveries;
        }

        public List<InvoiceStyle> GetInvoiceStyles()
        {
            List<InvoiceStyle> invoiceStyles = new List<InvoiceStyle>();
            try
            {
                StringBuilder query = new StringBuilder();
                query.Append("SELECT  nc_invoice_style.seq_inv_style_id , nc_invoice_style.inv_style_code , nc_invoice_style.inv_style_desc , convert(numeric(4),inv_style_code) num_code     FROM nc_invoice_style      WHERE ( nc_invoice_style.active = 'Y' )  ORDER BY 4 ASC   ");
                DataSet ds = database.ExecuteDataSet(System.Data.CommandType.Text, query.ToString());
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        invoiceStyles.Add(new InvoiceStyle
                        {
                            InvoiceStyleId = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["seq_inv_style_id"])) ? int.Parse(Convert.ToString(ds.Tables[0].Rows[i]["seq_inv_style_id"])) : 0,
                            InvoiceStyleCode = Convert.ToString(ds.Tables[0].Rows[i]["inv_style_code"]),
                            InvoiceStyleDesc = Convert.ToString(ds.Tables[0].Rows[i]["inv_style_desc"]),
                            NumCode = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["num_code"])) ? int.Parse(Convert.ToString(ds.Tables[0].Rows[i]["num_code"])) : 0,
                        });
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return invoiceStyles;
        }

        public List<Party> GetParties()
        {
            List<Party> parties = new List<Party>();
            try
            {
                StringBuilder query = new StringBuilder();
                query.Append("SELECT distinct p.seq_party_id,  p.party_code,   p.party_name,p.first_name,p.last_name FROM crm_element_hierarchy eh join crm_party p on p.seq_party_id = eh.element_id ");
                query.Append("WHERE (eh.element_struct_code = 'STAFF' AND  eh.active = 'Y' AND  (p.party_name LIKE '%' OR p.party_code LIKE '%' OR p.party_code LIKE ('SF' + '%')))");
                query.Append("ORDER BY p.last_name ASC, p.first_name ASC  ");
                DataSet ds = database.ExecuteDataSet(System.Data.CommandType.Text, query.ToString());
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        parties.Add(new Party
                        {
                            SeqPartyId = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["seq_party_id"])) ? int.Parse(Convert.ToString(ds.Tables[0].Rows[i]["seq_party_id"])) : 0,
                            PartyCode = Convert.ToString(ds.Tables[0].Rows[i]["party_code"]),
                            PartyName = Convert.ToString(ds.Tables[0].Rows[i]["party_name"]),
                            FirstName = Convert.ToString(ds.Tables[0].Rows[i]["first_name"]),
                            LastName = Convert.ToString(ds.Tables[0].Rows[i]["last_name"])
                        });
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return parties;
        }

        public List<PayMethod> GetPaymentMethods()
        {
            List<PayMethod> paymentMethods = new List<PayMethod>();
            try
            {
                StringBuilder query = new StringBuilder();
                query.Append("SELECT  nc_payment_method.seq_pay_method_id ,           nc_payment_method.pay_method_code ,           nc_payment_method.pay_method_desc ,           nc_payment_method.req_credit_card_flag ,           nc_payment_method.req_bank_ac_flag     FROM nc_payment_method      WHERE ( nc_payment_method.active = 'Y' )  ORDER BY nc_payment_method.pay_method_code          ASC");
                DataSet ds = database.ExecuteDataSet(System.Data.CommandType.Text, query.ToString());
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        paymentMethods.Add(new PayMethod
                        {
                            PayMethodId = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["seq_pay_method_id"])) ? int.Parse(Convert.ToString(ds.Tables[0].Rows[i]["seq_pay_method_id"])) : 0,
                            PayMethodCode = Convert.ToString(ds.Tables[0].Rows[i]["pay_method_code"]),
                            PayMethodDesc = Convert.ToString(ds.Tables[0].Rows[i]["pay_method_desc"]),
                            IsBankAccReqd = (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["req_bank_ac_flag"]))) && (Convert.ToString(ds.Tables[0].Rows[i]["req_bank_ac_flag"]) == "Y") ? true : false,
                            IsCreditCardReqd = (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["req_credit_card_flag"]))) && (Convert.ToString(ds.Tables[0].Rows[i]["req_credit_card_flag"]) == "Y") ? true : false
                        });
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return paymentMethods;
        }

        public List<Priority> GetPriorities()
        {
            List<Priority> priorities = new List<Priority>();
            try
            {
                StringBuilder query = new StringBuilder();
                query.Append(" SELECT  nc_client_priority.seq_client_priority_id , nc_client_priority.client_priority_code ,           nc_client_priority.client_priority_desc ,           nc_client_priority.priority ,           nc_client_priority.active FROM nc_client_priority  WHERE ( nc_client_priority.active = 'Y' )  ORDER BY nc_client_priority.client_priority_code  ASC  ");
                DataSet ds = database.ExecuteDataSet(System.Data.CommandType.Text, query.ToString());
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        priorities.Add(new Priority
                        {
                            PriorityId = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["seq_client_priority_id"])) ? int.Parse(Convert.ToString(ds.Tables[0].Rows[i]["seq_client_priority_id"])) : 0,
                            PriorityDesc = Convert.ToString(ds.Tables[0].Rows[i]["client_priority_desc"]),
                            PriorityCode = Convert.ToString(ds.Tables[0].Rows[i]["client_priority_code"])
                        });
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return priorities;
        }

        public List<RecentCustomerSearchResult> GetRecentCustSearchResults(int seqPartyId)
        {
            List<RecentCustomerSearchResult> results = new List<RecentCustomerSearchResult>();
            try
            {
                object[] parameters = new object[2];
                parameters[0] = seqPartyId;
                parameters[1] = 5;// This needs to be asked 
                DataSet ds = database.ExecuteDataSet("dbc_retrieve_mru_list", parameters);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        results.Add(new RecentCustomerSearchResult
                        {
                            SeqPartyId = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["seq_party_id"])) ? int.Parse(Convert.ToString(ds.Tables[0].Rows[i]["seq_party_id"])) : 0,
                            OrderNo = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["mru_order_number"])) ? int.Parse(Convert.ToString(ds.Tables[0].Rows[i]["mru_order_number"])) : 0,
                            SearchSeqPartyId = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["mru_seq_party_id"])) ? int.Parse(Convert.ToString(ds.Tables[0].Rows[i]["mru_seq_party_id"])) : 0,
                            SearchSeqPartyCode = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["mru_party_code"])) ? int.Parse(Convert.ToString(ds.Tables[0].Rows[i]["mru_party_code"])) : 0,
                            Display = Convert.ToString(ds.Tables[0].Rows[i]["mru_party_display"])
                        });
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return results;
        }

        public List<TaxIndicator> GetTaxIndicators()
        {
            List<TaxIndicator> taxIndicators = new List<TaxIndicator>();
            try
            {
                StringBuilder query = new StringBuilder();
                query.Append("sELECT  nc_tax_indicator.seq_tax_ind_id ,           nc_tax_indicator.tax_ind_code ,           nc_tax_indicator.tax_ind_desc     FROM nc_tax_indicator      WHERE ( nc_tax_indicator.active = 'Y' )  ORDER BY nc_tax_indicator.tax_ind_desc          ASC ");
                DataSet ds = database.ExecuteDataSet(System.Data.CommandType.Text, query.ToString());
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        taxIndicators.Add(new TaxIndicator
                        {
                            TaxIndicatorId = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["seq_tax_ind_id"])) ? int.Parse(Convert.ToString(ds.Tables[0].Rows[i]["seq_tax_ind_id"])) : 0,
                            TaxIndicatorCode = Convert.ToString(ds.Tables[0].Rows[i]["tax_ind_code"]),
                            TaxIndicatorDesc = Convert.ToString(ds.Tables[0].Rows[i]["tax_ind_desc"]),
                        });
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return taxIndicators;
        }

        public List<TreatmentType> GetTreatmentTypes()
        {
            List<TreatmentType> treatmentTypes = new List<TreatmentType>();
            try
            {
                StringBuilder query = new StringBuilder();
                query.Append("SELECT ar_treatment_type.treat_type_id,              ar_treatment_type.treat_type_code        FROM ar_treatment_type     	WHERE ar_treatment_type.active = 'Y'  ");
                DataSet ds = database.ExecuteDataSet(System.Data.CommandType.Text, query.ToString());
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        treatmentTypes.Add(new TreatmentType
                        {
                            TreatmentTypeId = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["treat_type_id"])) ? int.Parse(Convert.ToString(ds.Tables[0].Rows[i]["treat_type_id"])) : 0,
                            TreatmentTypeCode = Convert.ToString(ds.Tables[0].Rows[i]["treat_type_code"])
                        });
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return treatmentTypes;
        }

        public User Login(User user)
        {
            StringBuilder query = new StringBuilder();
            query.Append("select sys_user_id as UserId from bfc_sys_user where user_login ='" + user.UserName + "' and user_password ='" + user.Password + "' and active ='Y' ");
            query.Append("SELECT distinct rtrim(bfc_process.system_id), ");
            query.Append("rtrim(bfc_process.process_id), ");
            query.Append("bfc_process.process_type, ");
            query.Append("bfc_process.process_desc, ");
            query.Append("bfc_process.short_desc, ");
            query.Append("bfc_process.bitmap_graphic, ");
            query.Append("bfc_process.active, ");
            query.Append("bfc_process.insert_datetime, ");
            query.Append("bfc_process.insert_user, ");
            query.Append("bfc_process.insert_process, ");
            query.Append("bfc_process.update_datetime, ");
            query.Append("bfc_process.update_user, ");
            query.Append("bfc_process.update_process, ");
            query.Append("bfc_process.menu_sort_order, ");
            query.Append("bfc_process.hot_key ");
            query.Append("FROM bfc_process, ");
            query.Append("sec_group_process, ");
            query.Append("security_user_group, ");
            query.Append("bfc_sys_user ");
            query.Append("WHERE ( sec_group_process.system_id = bfc_process.system_id ) and ");
            query.Append("( sec_group_process.process_id = bfc_process.process_id ) and ");
            query.Append("( sec_group_process.sec_group_id = security_user_group.sec_group_id ) and ");
            query.Append("( bfc_sys_user.sys_user_id = security_user_group.sys_user_id ) and ");
            query.Append("( ( bfc_process.process_type = 'MENUOPTION' ) AND ");
            query.Append("( bfc_sys_user.user_login = '" + user.UserName + "' ) AND ");
            query.Append("( sec_group_process.select_option = 'Y' ) AND ");
            query.Append("( bfc_process.system_id = 'CMS2' )) ");
            query.Append("ORDER BY bfc_process.menu_sort_order ASC, ");
            query.Append("bfc_process.short_desc ASC   ");
            DataSet ds = database.ExecuteDataSet(System.Data.CommandType.Text, query.ToString());
            if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
            {
                //0th index is login table
                if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0]["UserId"] != null)
                {
                    user.UserId = int.Parse(ds.Tables[0].Rows[0]["UserId"].ToString());
                    if (ds.Tables.Count > 1)
                    {
                        user.Modules = new List<Module>();
                        // 1st index table is active module names
                        for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                        {
                            //1st index column is module name
                            user.Modules.Add(new Module { ModuleName = Convert.ToString(ds.Tables[1].Rows[i][1]) });
                        }
                    }
                }
            }

            return user;
        }

        public bool SaveCustomerDetails(CustomerDetails customerDetails)
        {
            bool retVal = false;
            try
            {
                StringBuilder query = new StringBuilder();
                query.Append("UPDATE crm_party set");

                if (!string.IsNullOrEmpty(customerDetails.CustomerFName))
                {
                    query.Append(" first_name = '" + customerDetails.CustomerFName.Replace("'", "''").Trim() + "',");
                }

                if (!string.IsNullOrEmpty(customerDetails.CustomerLName))
                {
                    query.Append(" last_name = '" + customerDetails.CustomerLName.Replace("'", "''").Trim() + "',");
                }

                if (!string.IsNullOrEmpty(customerDetails.CustomerInitial))
                {
                    query.Append(" initials = '" + customerDetails.CustomerInitial.Replace("'", "''").Trim() + "',");
                }

                if (!string.IsNullOrEmpty(customerDetails.Phone))
                {
                    query.Append(" phone_no = '" + customerDetails.Phone.Replace("'", "''").Trim() + "',");
                }

                if (!string.IsNullOrEmpty(customerDetails.Fax))
                {
                    query.Append(" fax_no = '" + customerDetails.Fax.Replace("'", "''").Trim() + "',");
                }

                if (!string.IsNullOrEmpty(customerDetails.EMailAddress))
                {
                    query.Append(" email_address = '" + customerDetails.EMailAddress.Replace("'", "''").Trim() + "',");
                }

                if (!string.IsNullOrEmpty(customerDetails.WebAddress))
                {
                    query.Append(" web_address = '" + customerDetails.WebAddress.Replace("'", "''").Trim() + "',");
                }

                if (!string.IsNullOrEmpty(customerDetails.StreetAddrNo))
                {
                    query.Append("street_addr_no = '" + customerDetails.StreetAddrNo.Replace("'", "''").Trim() + "',");
                }

                if (!string.IsNullOrEmpty(customerDetails.PostalPostCode))
                {
                    query.Append(" postal_post_code = '" + customerDetails.PostalPostCode.Replace("'", "''").Trim() + "',");
                }

                if (!string.IsNullOrEmpty(customerDetails.StreetAddr1))
                {
                    query.Append("street_addr_1 = '" + customerDetails.StreetAddr1.Replace("'", "''").Trim() + "',");
                }

                if (!string.IsNullOrEmpty(customerDetails.StreetAddr2))
                {
                    query.Append(" street_addr_2 = '" + customerDetails.StreetAddr2.Replace("'", "''").Trim() + "',");
                }

                if (!string.IsNullOrEmpty(customerDetails.StreetAddr3))
                {
                    query.Append(" street_addr_3 = '" + customerDetails.StreetAddr3.Replace("'", "''").Trim() + "',");
                }

                if (!string.IsNullOrEmpty(customerDetails.PostalAddr1))
                {
                    query.Append(" postal_addr_1 = '" + customerDetails.PostalAddr1.Replace("'", "''").Trim() + "',");
                }

                if (!string.IsNullOrEmpty(customerDetails.PostalAddr2))
                {
                    query.Append(" postal_addr_2 = '" + customerDetails.PostalAddr2.Replace("'", "''").Trim() + "',");
                }

                if (!string.IsNullOrEmpty(customerDetails.PostalAddr3))
                {
                    query.Append(" postal_addr_3 = '" + customerDetails.PostalAddr3.Replace("'", "''").Trim() + "',");
                }

                query.Append(" notes = '" + customerDetails.Notes + "', update_datetime =  '" + DateTime.UtcNow + "',");

                if (customerDetails.STDCode != null)
                {
                    query.Append(" std_code =  '" + customerDetails.STDCode.Replace("'", "''").Trim() + "',");
                }

                if (customerDetails.TradingName != null)
                {
                    query.Append(" trading_name =  '" + customerDetails.TradingName.Replace("'", "''").Trim() + "',");
                }


                if (customerDetails.CustomerName != null)
                {
                    query.Append(" party_name =  '" + customerDetails.CustomerName.Replace("'", "''").Trim() + "',");
                }
                query.Append(" update_user = '" + customerDetails.UpdatedBy + "', update_process = 'CMS2' WHERE seq_party_id = " + customerDetails.SeqPartyId + " ");
                int rowsAffected = database.ExecuteNonQuery(CommandType.Text, query.ToString());


                //CLIENT TABLE
                // Finance details query
                query = new StringBuilder();
                query.Append("UPDATE nc_client SET update_user = '" + customerDetails.UpdatedBy + "', update_process = '" + customerDetails.UpdateProcess + "',");
                if (customerDetails.PmtMethod != null && customerDetails.PmtMethod.PayMethodId != 0)
                {
                    query.Append(" seq_pay_method_id = " + customerDetails.PmtMethod.PayMethodId + ",");
                }

                if (customerDetails.IndustryDetails != null && customerDetails.IndustryDetails.IndustryId != 0)
                {
                    query.Append(" seq_industry_id = " + customerDetails.IndustryDetails.IndustryId + ",");
                }

                if (customerDetails.AvgMonthlySpend != null)
                {
                    query.Append(" avg_monthly_spend =  '" + customerDetails.AvgMonthlySpend.Replace("'", "''").Trim() + "',");
                }

                if (!string.IsNullOrEmpty(customerDetails.PromptPayDisc))
                {
                    query.Append(" prompt_payment_discount =  '" + customerDetails.PromptPayDisc.Replace("'", "''").Trim() + "',");
                }

                query.Append(" bond =  '" + customerDetails.BondAmt + "',");

                if (customerDetails.TradingName != null)
                {
                    query.Append(" trading_name =  '" + customerDetails.TradingName.Replace("'", "''").Trim() + "',");
                }

                if (customerDetails.Employer != null)
                {
                    query.Append(" employer =  '" + customerDetails.Employer.Replace("'", "''").Trim() + "',");
                }


                if (customerDetails.SeqBillingUnit != null && customerDetails.SeqBillingUnit.BillingUnitId != 0)
                {
                    query.Append("seq_bill_type_id =  " + customerDetails.SeqBillingUnit.BillingUnitId + ",");
                }

                if (customerDetails.SeqBillCycle != null && customerDetails.SeqBillCycle.BillingCycleId != 0)
                {
                    query.Append("seq_bill_cycle_id =  " + customerDetails.SeqBillCycle.BillingCycleId + ",");
                }

                if (customerDetails.Score != null && customerDetails.Score.CreditCheckScoreId != 0)
                {
                    query.Append(" seq_int_crd_chk_id =  " + customerDetails.Score.CreditCheckScoreId + ",");
                }

                if (customerDetails.InvDelivery != null && customerDetails.InvDelivery.InvoiceDeliveryId != 0)
                {
                    query.Append("seq_inv_del_mode_id = " + customerDetails.InvDelivery.InvoiceDeliveryId + ",");
                }

                if (customerDetails.InvStyle != null && customerDetails.InvStyle.InvoiceStyleId != 0)
                {
                    query.Append(" seq_inv_style_id =  " + customerDetails.InvStyle.InvoiceStyleId + ",");
                }

                if (customerDetails.SeqPriority != null && customerDetails.SeqPriority.PriorityId != 0)
                {
                    query.Append(" seq_client_priority_id =  " + customerDetails.SeqPriority.PriorityId + ",");
                }

                if (customerDetails.SeqTaxIndicator != null && customerDetails.SeqTaxIndicator.TaxIndicatorId != 0)
                {
                    query.Append(" seq_tax_ind_id =  " + customerDetails.SeqTaxIndicator.TaxIndicatorId + ",");
                }

                if (customerDetails.AlertExpiryDate != null && customerDetails.AlertExpiryDate.HasValue)
                {
                    query.Append(" alert_expiry_date =  '" + customerDetails.AlertExpiryDate.Value + "',");
                }

                if (customerDetails.AgcRewards != null && customerDetails.AgcRewards.HasValue)
                {
                    query.Append(" agc_rewards =  '" + customerDetails.AgcRewards.Value + "',");
                }

                if (customerDetails.IsAlertExpires)
                {
                    query.Append(" alert_expires = 'Y',");
                }
                else
                {
                    query.Append(" alert_expires = 'N',");
                }

                if (customerDetails.IsDeveloper)
                {
                    query.Append(" developer = 'Y',");
                }
                else
                {
                    query.Append(" developer = 'N',");
                }

                if (customerDetails.IsCorrespondenceByEMail)
                {
                    query.Append(" correspondence_by_email = 'Y',");
                }
                else
                {
                    query.Append(" correspondence_by_email = 'N',");
                }

                if (customerDetails.IsCorrespondenceByPost)
                {
                    query.Append(" correspondence_by_post = 'Y',");
                }
                else
                {
                    query.Append(" correspondence_by_post = 'N',");
                }

                if (customerDetails.DateDetailsConfirmed != null && customerDetails.DateDetailsConfirmed.HasValue)
                {
                    query.Append("date_details_confirmed =  '" + customerDetails.DateDetailsConfirmed.Value + "',");
                }

                if (!string.IsNullOrEmpty(customerDetails.RestaurantAssnNo))
                {
                    query.Append(" rest_assn_num =  '" + customerDetails.RestaurantAssnNo.Replace("'", "''").Trim() + "',");
                }

                if (customerDetails.AccMgr != null && customerDetails.AccMgr.SeqPartyId != 0)
                {
                    query.Append(" seq_staff_id =  " + customerDetails.AccMgr.SeqPartyId + ",");
                }

                if (!string.IsNullOrEmpty(customerDetails.Password))
                {
                    query.Append("password = ' " + customerDetails.Password.Replace("'", "''").Trim() + "',");
                }


                if (!string.IsNullOrEmpty(customerDetails.Alert))
                {
                    query.Append(" alert = '" + customerDetails.Alert.Replace("'", "''").Trim() + "',");
                }


                if (!string.IsNullOrEmpty(customerDetails.CreditLimit))
                {
                    query.Append(" credit_limit =  " + customerDetails.CreditLimit.Replace("'", "''").Trim() + ",");
                }


                if (!string.IsNullOrEmpty(customerDetails.Bank))
                {
                    query.Append(" bank = '" + customerDetails.Bank.Replace("'", "''").Trim() + "',");
                }

                if (!string.IsNullOrEmpty(customerDetails.BankBranch))
                {
                    query.Append(" bank_branch = '" + customerDetails.BankBranch.Replace("'", "''").Trim() + "',");
                }

                if (!string.IsNullOrEmpty(customerDetails.BankAccNo))
                {
                    query.Append(" bank_account_no = '" + customerDetails.BankAccNo.Replace("'", "''").Trim() + "',");
                }

                if (customerDetails.CreditCardType != null && customerDetails.CreditCardType.CardTypeCode != string.Empty)
                {
                    query.Append(" credit_card_type_code = '" + customerDetails.CreditCardType.CardTypeCode.Replace("'", "''").Trim() + "',");
                }

                if (!string.IsNullOrEmpty(customerDetails.CreditCardName))
                {
                    query.Append(" credit_card_name = '" + customerDetails.CreditCardName.Replace("'", "''").Trim() + "',");
                }

                if (!string.IsNullOrEmpty(customerDetails.CreditCardNo))
                {
                    query.Append(" credit_card_no = '" + customerDetails.CreditCardNo.Replace("'", "''").Trim() + "',");
                }

                if (!string.IsNullOrEmpty(customerDetails.CreditCardExpiry))
                {
                    query.Append(" credit_card_expiry = '" + customerDetails.CreditCardExpiry.Replace("'", "''").Trim() + "',");
                }

                if (!string.IsNullOrEmpty(customerDetails.CreditCardVerifyNo))
                {
                    query.Append(" credit_card_verif_no = '" + customerDetails.CreditCardVerifyNo.Replace("'", "''").Trim() + "',");
                }

                if (!string.IsNullOrEmpty(customerDetails.BillNotes))
                {
                    query.Append(" bill_notes = '" + customerDetails.BillNotes.Replace("'", "''").Trim() + "',");
                }

                if (customerDetails.CreditCtrlStatus != null && customerDetails.CreditCtrlStatus.CreditControlStatusId != 0)
                {
                    query.Append(" seq_credit_status_id =  " + customerDetails.CreditCtrlStatus.CreditControlStatusId + ",");
                }

                if (!string.IsNullOrEmpty(customerDetails.BankAccName))
                {
                    query.Append(" bank_account_name = '" + customerDetails.BankAccName.Replace("'", "''").Trim() + "',");
                }

                query.Append(" treat_type_id =  " + customerDetails.Type.TreatmentTypeId + ",  update_datetime = '" + DateTime.UtcNow + "'  WHERE seq_party_id = " + customerDetails.SeqPartyId + " ");
                rowsAffected = database.ExecuteNonQuery(CommandType.Text, query.ToString());

                query = new StringBuilder();
                query.Append("  UPDATE crm_element_hierarchy SET update_datetime = '" + DateTime.UtcNow + "', update_user = '" + customerDetails.UpdatedBy + "', update_process = '" + customerDetails.UpdateProcess + "',");
                if (customerDetails.Type != null && customerDetails.CustType.CustomerTypeId != 0)
                {
                    query.Append(" seq_element_type_id =  '" + customerDetails.CustType.CustomerTypeId + "'");
                }

                query.Append("WHERE element_id = " + customerDetails.SeqPartyId + " AND element_struct_code = 'CLIENT' AND parent_id = 3 AND parent_element_struct_code = 'COMPANY'");
                rowsAffected = database.ExecuteNonQuery(CommandType.Text, query.ToString());
                if (rowsAffected > 0)
                {
                    retVal = true;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return retVal;
        }

        // To get list of active/inactive options of customer module
        /*     public void GetCustomerOptions()
             {
            

     SELECT distinct rtrim(bfc_process.system_id),   
              rtrim(bfc_process.process_id),   
              bfc_process.process_type,   
              bfc_process.process_desc,   
              bfc_process.short_desc,   
              bfc_process.bitmap_graphic,   
              bfc_process.active,   
              bfc_process.insert_datetime,   
              bfc_process.insert_user,   
              bfc_process.insert_process,   
              bfc_process.update_datetime,   
              bfc_process.update_user,   
              bfc_process.update_process,   
              bfc_process.menu_sort_order,   
              bfc_process.hot_key  
         FROM bfc_process,   
              sec_group_process,   
              security_user_group,   
              bfc_sys_user  
        WHERE ( sec_group_process.system_id = bfc_process.system_id ) and  
              ( sec_group_process.process_id = bfc_process.process_id ) and  
              ( sec_group_process.sec_group_id = security_user_group.sec_group_id ) and  
              ( bfc_sys_user.sys_user_id = security_user_group.sys_user_id ) and  
              ( ( bfc_process.process_type = 'CUSTOPTION' ) AND  
              ( bfc_sys_user.user_login = 'CGVAKDEV' ) AND  
              ( sec_group_process.select_option = 'Y' ) AND
        ( bfc_process.system_id = 'CMS2' ))   
     ORDER BY bfc_process.menu_sort_order ASC,   
              bfc_process.short_desc ASC   

     go

             }*/
        public List<Customer> SearchCustomers(Services.DataContracts.Criteria.CustomerSearchCriteria criteria)
        {
            /*exec dbo.dbp_nc_client_search_results N'1',N'CLIENT',N'CUSTNO',N'client name',N'phone',N'streetname',N'METERNO',N'CONTACT',N'155439',N'premise',default,default,default,default,default,N'no:',N'Y',N'salescode',N'properyt',N'Y',N'',N'',N'',N'',N'',N'',N'',N'',N'',N'',N'',N'',N'',N'',N''*/
            List<Customer> customers = new List<Customer>();
            try
            {
                object[] parameters = new object[35];
                parameters[0] = 1;
                parameters[1] = "CLIENT";
                if (!string.IsNullOrEmpty(criteria.CustomerNo))
                {
                    parameters[2] = criteria.CustomerNo;
                }
                else
                {
                    parameters[2] = null;
                }

                parameters[3] = criteria.ClientName;// != string.Empty ? criteria.ClientName : null;
                parameters[4] = criteria.Phone;// != string.Empty ? criteria.Phone : null;
                parameters[5] = criteria.StreetName;// != string.Empty ? criteria.StreetName : null;
                parameters[6] = criteria.MeterNo;//meter no


                parameters[7] = criteria.Contact;//  != string.Empty ? criteria.Contact : null;//contact
                parameters[8] = criteria.StaffId;
                parameters[9] = criteria.Premise;
                parameters[10] = null;
                parameters[11] = null;
                parameters[12] = "";
                parameters[13] = "";
                parameters[14] = "";
                parameters[15] = criteria.StreetNo;//  != string.Empty ? criteria.StreetNo : null;
                if (criteria.IsCurrentAccount)// Curr acc
                {
                    parameters[16] = "Y";
                }
                else
                {
                    parameters[16] = "N";
                }
                parameters[17] = criteria.SalesCode;//  != string.Empty ? criteria.SalesCode : null; ;//salescode
                parameters[18] = criteria.PropertyName;//  != string.Empty ? criteria.PropertyName : null;//property
                if (criteria.IsInclLease)// Incl lease
                {
                    parameters[19] = "Y";
                }
                else
                {
                    parameters[19] = "N";
                }
                parameters[20] = "";
                parameters[21] = "";
                parameters[22] = "";
                parameters[23] = "";
                parameters[24] = "";
                parameters[25] = "";
                parameters[26] = "";
                parameters[27] = "";
                parameters[28] = "";
                parameters[29] = "";
                parameters[30] = "";
                parameters[31] = "";
                parameters[32] = "";
                parameters[33] = "";
                parameters[34] = "";

                DataSet ds = database.ExecuteDataSet("dbp_nc_client_search_results", parameters);
                if (ds != null && ds.Tables != null)
                {
                    string customerNo;
                    Customer customer;
                    List<Product> products = new List<Product>();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (string.IsNullOrEmpty(Convert.ToString((ds.Tables[0].Rows[i]["account_status"]))))
                            continue;

                        customerNo = Convert.ToString(ds.Tables[0].Rows[i]["party_code"]);
                        if (customers.Exists(sel => sel.CustomerNo == customerNo))
                        {
                            customer = customers.FirstOrDefault(sel => sel.CustomerNo == customerNo);
                            if (customer != null)
                            {
                                customer.Products.Add(new Product
                                {
                                    Icon = Convert.ToString(ds.Tables[0].Rows[i]["icon"]),
                                    ProductDesc = Convert.ToString(ds.Tables[0].Rows[i]["product_type_desc"]),
                                    SiteAddress = Convert.ToString(ds.Tables[0].Rows[i]["site_address"]),
                                    ProductID = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["seq_product_item_id"]).Trim()) ? int.Parse(Convert.ToString(ds.Tables[0].Rows[i]["seq_product_item_id"])) : 0,
                                    SeqPartyId = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["seq_party_id"]).Trim()) ? int.Parse(Convert.ToString(ds.Tables[0].Rows[i]["seq_party_id"])) : 0
                                });
                            }
                        }
                        else
                        {
                            products = new List<Product>();
                            products.Add(new Product
                            {
                                Icon = Convert.ToString(ds.Tables[0].Rows[i]["icon"]),
                                ProductDesc = Convert.ToString(ds.Tables[0].Rows[i]["product_type_desc"]),
                                SiteAddress = Convert.ToString(ds.Tables[0].Rows[i]["site_address"]),
                                ProductID = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["seq_product_item_id"]).Trim()) ? int.Parse(Convert.ToString(ds.Tables[0].Rows[i]["seq_product_item_id"])) : 0,
                                SeqPartyId = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["seq_party_id"]).Trim()) ? int.Parse(Convert.ToString(ds.Tables[0].Rows[i]["seq_party_id"])) : 0
                            });
                            customers.Add(new Customer
                            {
                                CustomerName = Convert.ToString(ds.Tables[0].Rows[i]["party_name"]),
                                CustomerNo = Convert.ToString(ds.Tables[0].Rows[i]["party_code"]),
                                Products = products
                            });
                        }

                    }

                }
                else
                {
                    throw new Exception("No results found");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return customers;
        }

        #endregion Methods

        /*
         Company names
          SELECT  crm_district.district_id ,             crm_district.district_code ,             crm_district.district_desc          FROM crm_district                WHERE ( crm_district.active = 'Y' )            ORDER BY crm_district.district_code          ASC  --- supply company
         * 
         * Company Type
         * SELECT  crm_party_type.seq_party_type_id ,           crm_party_type.party_type ,           crm_party_type.party_type_desc     FROM crm_party_type      WHERE ( crm_party_type.active = 'Y' ) And          ( crm_party_type.element_struct_code = 'CLIENT' )  ORDER BY crm_party_type.party_type_desc          ASC --- For customer type
         * Address Type
         SELECT  crm_address_type.seq_addr_type_id ,           crm_address_type.address_type ,           crm_address_type.address_type_desc     FROM crm_address_type      WHERE ( crm_address_type.active = 'Y') -- for address type (postal address,street address, residential address)
         * Billing unit
         * SELECT DISTINCT nc_bill_option.seq_bill_type_id,           nc_bill_option.bill_type,           nc_bill_option.bill_type_desc      FROM nc_bill_option  ORDER BY nc_bill_option.bill_type DESC  -- Billing Unit
         * 
         * Update company details
         * UPDATE nc_client SET update_datetime = {ts '2011-02-19 10:05:11.623'}, update_user = 'CGVAKDEV', update_process = 'CMS2', seq_industry_id = 170, seq_client_priority_id = 8, seq_pay_method_id = 14, seq_bill_cycle_id = 1, seq_int_crd_chk_id = 13, seq_inv_del_mode_id = 3, seq_inv_style_id = 1, seq_tax_ind_id = 4, password = '    pass', alert = '    Alert', seq_staff_id = 99715, credit_limit = 3000.0000, credit_card_type_code = 'BANKCARD', credit_card_expiry = '', bill_notes = '    Billing notes', seq_credit_status_id = 7, developer = 'Y', alert_expires = 'Y', alert_expiry_date = {ts '2011-05-19 00:00:00.000'}, agc_rewards = {ts '2011-02-01 00:00:00.000'}, correspondence_by_email = 'Y', correspondence_by_post = 'Y', date_details_confirmed = {ts '2011-02-21 00:00:00.000'}, trading_name = 'Trading Name', seq_bill_type_id = 2, rest_assn_num = 'Rest numb', treat_type_id = 7 WHERE seq_party_id = 140022 
           UPDATE crm_party SET party_name = 'Company Name', phone_no = '4131', std_code = '080', postal_post_code = 'Post code', postal_addr_1 = 'Postal Address1', postal_addr_2 = 'Postal add2', postal_addr_3 = 'Postal Add3', notes = 'Notest', update_datetime = {ts '2011-02-19 10:05:10.923'}, update_user = 'CGVAKDEV', update_process = 'CMS2' WHERE seq_party_id = 140022 
         * 
         * Update residentila details
         */


        public List<Contact> GetContacts(int seqPartyId)
        {
            List<Contact> contacts = new List<Contact>();
            try
            {
                StringBuilder query = new StringBuilder();
                query.Append(" SELECT p.seq_party_id,");
                query.Append("  p.party_code,");
                query.Append("  p.party_name,");
                query.Append("  p.first_name,");
                query.Append("  p.last_name,");
                query.Append("  p.initials,");
                query.Append(" p.title,");
                query.Append("  p.active,");
                query.Append("  account_authority = IsNull(pfaa.active, 'N'),");
                query.Append("  bill_contact = IsNull(pfbc.active, 'N'),");
                query.Append("  eh.seq_element_type_id seq_party_type_id");
                query.Append("  FROM dbo.crm_element_hierarchy eh");
                query.Append("  JOIN dbo.crm_party             p    ");
                query.Append("  ON p.seq_party_id = eh.element_id AND p.active = 'Y'");
                query.Append(" LEFT JOIN");
                query.Append("  dbo.crm_party_flag        pfaa ");
                query.Append("  ON p.seq_party_id = pfaa.seq_party_id ");
                query.Append(" AND pfaa.seq_party_flag_type_id = (SELECT seq_party_flag_type_id FROM dbo.crm_party_flag_type WHERE flag_type = 'DECISION')");
                query.Append("  LEFT JOIN");
                query.Append(" 	 dbo.crm_party_flag        pfbc ");
                query.Append("  ON p.seq_party_id = pfbc.seq_party_id ");
                query.Append(" AND pfbc.seq_party_flag_type_id = (SELECT seq_party_flag_type_id FROM dbo.crm_party_flag_type WHERE flag_type = 'BILL')");
                query.Append("  WHERE eh.parent_id = " + seqPartyId + " AND eh.parent_element_struct_code = 'CLIENT' AND eh.element_struct_code = 'CONTACT'");
                query.Append(" ORDER BY p.first_name, p.last_name");
                DataSet ds = database.ExecuteDataSet(System.Data.CommandType.Text, query.ToString());
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    Contact contact = null;
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        contact = new Contact
                        {
                            FName = Convert.ToString(ds.Tables[0].Rows[i]["first_name"]),
                            Initials = Convert.ToString(ds.Tables[0].Rows[i]["initials"]),
                            LName = Convert.ToString(ds.Tables[0].Rows[i]["last_name"]),
                            PartyCode = Convert.ToString(ds.Tables[0].Rows[i]["party_code"]),
                            PartyId = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["seq_party_id"])) ? int.Parse(Convert.ToString(ds.Tables[0].Rows[i]["seq_party_id"])) : 0,
                            PartyName = Convert.ToString(ds.Tables[0].Rows[i]["party_name"]),
                            PartyTypeId = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["seq_party_type_id"])) ? int.Parse(Convert.ToString(ds.Tables[0].Rows[i]["seq_party_type_id"])) : 0,
                            Title = Convert.ToString(ds.Tables[0].Rows[i]["title"])
                        };

                        if (Convert.ToString(ds.Tables[0].Rows[0]["account_authority"]) == "Y")
                        {
                            contact.IsAccAuth = true;
                        }
                        else
                        {
                            contact.IsAccAuth = false;
                        }

                        if (Convert.ToString(ds.Tables[0].Rows[0]["active"]) == "Y")
                        {
                            contact.IsActive = true;
                        }
                        else
                        {
                            contact.IsActive = false;
                        }

                        if (Convert.ToString(ds.Tables[0].Rows[0]["bill_contact"]) == "Y")
                        {
                            contact.IsBillingContact = true;
                        }
                        else
                        {
                            contact.IsBillingContact = false;
                        }

                        contacts.Add(contact);
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return contacts;
        }
    }
}
