namespace LoanAssesmentApi.Validators.PhoneNumber
{
    public class AustraliaPhoneNumberValidator : ICountryPhoneNumberValidator
    {
        private readonly string _phoneNumber;
        private readonly List<string> _mobileNumberCodes = new List<string> { "04", "+614" };
        private readonly List<string> _landLineNumberCodes = new List<string> { "02", "03", "07", "08" };
        public AustraliaPhoneNumberValidator(string phoneNumber)
        {
            _phoneNumber = phoneNumber;
        }

        public bool IsValid()
        {
            return IsValidMobileNumber() || IsValidLandLineNumber();
        }

        private bool IsValidMobileNumber()
        {
            bool result = false;

            if (IsValidMobileNumberCode())
            {
                string trimedNumbers = _phoneNumber.TrimStart(_mobileNumberCodes.Single(s=> _phoneNumber.StartsWith(s)).ToCharArray());
                result = IsValidPrecedingNumbers(trimedNumbers);
            }

            return result;
        }

        private bool IsValidLandLineNumber()
        {
            bool result = false;
            if (IsValidLandLineNumberCode())
            {
                string trimedNumbers = _phoneNumber.TrimStart(_landLineNumberCodes.Single(s => _phoneNumber.StartsWith(s)).ToCharArray());
                result = IsValidPrecedingNumbers(trimedNumbers);
            }

            return result;
        }

        private bool IsValidMobileNumberCode()
        {
            return _mobileNumberCodes.Any(s=> _phoneNumber.StartsWith(s));
        }

        private bool IsValidLandLineNumberCode()
        {
            return _landLineNumberCodes.Any(s => _phoneNumber.StartsWith(s));
        }

        private bool IsValidPrecedingNumbers(string trimedNumbers)
        {
            return trimedNumbers.Length == 8 && int.TryParse(trimedNumbers, out _);
        }
    }
}
