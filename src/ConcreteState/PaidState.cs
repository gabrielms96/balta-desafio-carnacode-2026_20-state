using DesignPatternChallengeState.Context;
using DesignPatternChallengeState.State;

namespace DesignPatternChallengeState.ConcreteState
{
    public class PaidState : IOrderState
    {
        public void ProcessPayment(Order order)
        {
            Console.WriteLine($"\n[{order.OrderId}] Processando pagamento...");
            Console.WriteLine($"❌ Pedido já foi pago!");
        }

        public void Ship(Order order, string trackingCode)
        {
            Console.WriteLine($"\n[{order.OrderId}] Tentando enviar pedido...");
            order.TrackingCode = trackingCode;
            order.ShippedDate = DateTime.Now;
            order.SetState(new ShippedState());
            Console.WriteLine($"✅ Pedido enviado!");
            Console.WriteLine($"   Código de rastreamento: {order.TrackingCode}");
            Console.WriteLine($"   Status: Enviado");
        }

        public void Deliver(Order order)
        {
            Console.WriteLine($"\n[{order.OrderId}] Registrando entrega...");
            Console.WriteLine($"❌ Pedido ainda não foi enviado!");
        }

        public void Cancel(Order order)
        {
            Console.WriteLine($"\n[{order.OrderId}] Tentando cancelar pedido...");
            order.SetState(new CancelledState());
            Console.WriteLine($"✅ Pedido cancelado. Reembolso será processado.");
            Console.WriteLine($"   Valor: R$ {order.TotalAmount:N2}");
            Console.WriteLine($"   Status: Cancelado");
        }

        public void RequestReturn(Order order)
        {
            Console.WriteLine($"\n[{order.OrderId}] Solicitando devolução...");
            Console.WriteLine($"❌ Pedido ainda não foi entregue. Use cancelamento.");
        }
    }
}
