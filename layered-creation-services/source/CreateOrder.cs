namespace LayeredCreation.Services;

public record CreateOrder(params CandidateLineItem[] LineItems);

public record CandidateLineItem(string Sku, decimal Price, ushort Quantity);
