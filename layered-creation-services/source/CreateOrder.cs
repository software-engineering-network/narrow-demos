namespace LayeredCreation.Services;

public record CreateOrder(params LineItem[] LineItems);
