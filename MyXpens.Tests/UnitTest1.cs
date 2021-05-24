using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using MyXpens.Models;
using Xunit;

namespace MyXpens.Tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(1, "2021-01-01")]
        public void Fixture_Simple(int amount, string payDate)
        {
            var fixture = new Fixture();

            var sut = fixture.Build<Payment>()
                .With(p => p.Amount, amount)
                .With(p => p.PayDate, DateTime.Parse(payDate))
                .Create();

            var description = sut.Description;

            Assert.True(!string.IsNullOrWhiteSpace(description));
        }

        [Theory] // , AutoData] - if no inline-data
        [InlineAutoData(1, "2021-01-01")]
        public void Inline_AutoData(int amount, string payDate, Payment sut)
        {
            sut.Amount = amount;
            sut.PayDate = DateTime.Parse(payDate);

            var description = sut.Description;

            Assert.True(!string.IsNullOrWhiteSpace(description));
        }

        [Theory, MyAutoData]
        public void MyAutoData_Attribute(Payment sut)
        {
            var description = sut.Description;

            Assert.True(!string.IsNullOrWhiteSpace(description));
        }
    }

    // =========================================================

    internal class MyAutoDataAttribute : AutoDataAttribute
    {
        public MyAutoDataAttribute() : base(Create)
        { }

        private static IFixture Create()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var payment = fixture.Create<Payment>();

            fixture.Inject(payment);

            return fixture;
        }
    }
}
