using System.Runtime.Serialization;

namespace LoanAssesmentApi
{

    public enum ValidatorDecision
    {
        Qualified,
        Unqualified,
        Unknown
    }

    public enum CitizenshipStatus
    {
        Citizen,
        PermanentResident
    }
}
