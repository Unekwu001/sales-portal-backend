using API.Data.Enums;
using Data.Models.AgentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dtos
{
    public class ViewCustomerOrderByIdDto
    {
        public string CustomerType { get; set; }    
        public string OrderReferenceNumber { get; set; } // orderId
        public string PaymentReferenceNumber { get; set; }
        public string OrderDateAndTime { get; set; }
        public string PlanName { get; set; } 
        public string TermsAndConditions { get; set; }
        public string PlanTypeName { get; set; }
        public string Price { get; set; }
        public string PlanModemAndInstallationAmount { get; set; }
        public string WhoReferredYou { get; set; }
        public int? NumberOfMonthsPaidFor {  get; set; }
        public string SalesAgentName { get; set; }
        public string CustomerName { get; set; }
        public GenderEnum? Gender { get; set; }  
        public string DateOfBirth { get; set; }
        public string Occupation {  get; set; }
        public string Email {  get; set; }
        public string PhoneNumber { get; set; }      
        public string Address { get; set; }
        public string TypeOfBuilding { get; set; }
        public string BillingInformation { get; set; }
        public string Photograph {  get; set; }
        public string GovernmentID { get; set; }
        public string UtilityBill { get; set; }
        public string PersonalDataConsent { get; set; } 
        public string PrivacyPolicy { get; set; } 

        //for Smes
        public string CertificateOfIncorporation { get; set; }
        public string LetterOfIntroduction { get; set; }
        public string TypeOfBusiness { get; set; }
        public string AddressOfBusiness { get; set;}

    }
}
