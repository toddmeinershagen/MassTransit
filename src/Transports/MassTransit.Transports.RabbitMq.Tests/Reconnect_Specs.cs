namespace MassTransit.Transports.RabbitMq.Tests
{
    using System;
    using System.Threading;
    using BusConfigurators;
    using Magnum.Extensions;
    using NUnit.Framework;
    using TestFramework;

    [TestFixture, Explicit]
    public class When_the_broker_service_is_shut_down :
        Given_a_rabbitmq_bus
    {
        Semaphore _waiter = new Semaphore(0, 10000);
        int _count;

        protected override void ConfigureServiceBus(Uri uri, ServiceBusConfigurator configurator)
        {
            base.ConfigureServiceBus(uri, configurator);

            configurator.Subscribe(s =>
                {
                    s.Handler<A>(message =>
                    {
                        _count++;
                        Console.WriteLine("Received: {0}", message.Id);
                        _waiter.Release();
                    });
                });
        }

        [Test]
        public void Should_reconnect_when_it_comes_back_up()
        {
            for (int i = 0; i < 1000; i++)
            {
                try
                {
                    LocalBus.Publish(new A());

                    _waiter.WaitOne(1000);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            Assert.AreEqual(100, _count);
        }

        class A
        {
            public A()
            {
                Id = Guid.NewGuid();
            }

            public Guid Id { get; set; }
        }
    }
}
