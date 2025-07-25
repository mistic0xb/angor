using Angor.Contexts.Funding.Founder;

namespace AngorApp.Sections.Founder.Details;

public interface IInvestmentChild
{
    DateTime CreatedOn { get; }
    public string InvestorNostrPubKey { get; }
    public IAmountUI Amount { get; }
    public InvestmentStatus Status { get; set; }
}