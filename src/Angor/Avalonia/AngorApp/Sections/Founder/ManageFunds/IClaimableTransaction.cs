namespace AngorApp.Sections.Founder.ManageFunds;

public interface IClaimableTransaction
{
    public IAmountUI Amount { get; }
    public string Address { get; }
    public ClaimStatus ClaimStatus { get; }
    public bool IsClaimable => ClaimStatus == ClaimStatus.Unspent;
}