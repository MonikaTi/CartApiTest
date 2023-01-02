using CartApi.Controllers;
using CartApi.Models;
using CartApi.Services;
using Moq;
using NUnit.Framework;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace CartApi.Test;

public class Tests
{

    [Test]
    public void Test1()
    {
        var paymentServiceMock = new Mock<IPaymentService>();
        var shipmentServiceMock = new Mock<IShipmentService>();
        var cartServiceMock = new Mock<ICartService>();
        var cardMock = new Mock<ICard>();
        var addressInfoMock = new Mock<IAddressInfo>();

        paymentServiceMock.Setup(x => x.Charge(It.IsAny<double>(), cardMock.Object)).Returns(true);
        var cartController = new CartController(cartServiceMock.Object, paymentServiceMock.Object, shipmentServiceMock.Object);

        var result = cartController.CheckOut(cardMock.Object, addressInfoMock.Object);

        shipmentServiceMock.Verify(x => x.Ship(addressInfoMock.Object, cartServiceMock.Object.Items()));
        Assert.AreEqual("charged", result);
    }
}