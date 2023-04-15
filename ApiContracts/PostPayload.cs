using LoanAssesmentApi.Constants;
using LoanAssesmentApi.CustomValidatorAttributes;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LoanAssesmentApi.ApiContracts
{
    public class PostPayload
    {
        [NamesRequired]
        public string FirstName { get; set; }

        [NamesRequired]
        public string LastName { get; set; }

        [ContactsRequired]
        public string EmailAddress { get; set; }

        [ContactsRequired]
        [PhoneNumber(CountryCode = "AU")]
        public string PhoneNumber { get; set; }

        [BusinessNumber]
        public string BusinessNumber { get; set; }

        [LoanAmountRange(Minimum = 10001, Maximum = 99999)]
        public decimal LoanAmount { get; set; }

        [CitizenshipStatus]
        public string CitizenshipStatus { get; set; }

        [TimeTrading(Minimum = 2, Maximum = 19)] 
        public int TimeTrading { get; set;}

        [AcceptedCountryCode] 
        public string CountryCode { get; set;}

        [AcceptedIndustry]
        public string Industry { get; set; }
    }
}
