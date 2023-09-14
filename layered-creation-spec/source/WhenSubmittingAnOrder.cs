﻿using FluentAssertions;
using FluentAssertions.Execution;
using LayeredCreation.Services;
using LayeredCreation.Services.Basic;
using LayeredCreation.Spec.Basic;

namespace LayeredCreation.Spec;

public class WhenCreatingAnOrder
{
    #region Requirements

    [Fact]
    public void ThenOrderIsExpected()
    {
        var service = new OrderService(new MockOrderRepository());
        var createOrder = new CreateOrder(
            new CandidateLineItem("ABC123", 9.99m, 3),
            new CandidateLineItem("DEF456", 19.99m, 2),
            new CandidateLineItem("GHI789", 99.99m, 1)
        );

        var orderId = service.Create(createOrder);
        var order = service.Find(orderId);

        using var scope = new AssertionScope();
        order.Id.Should().NotBeEmpty();
        order.LineItems.Should().HaveCount(3);
        order.LineItems.Should().AllSatisfy(
            li =>
            {
                li.Id.Should().NotBeEmpty();
                li.OrderId.Should().Be(orderId);
            }
        );
    }

    #endregion
}
