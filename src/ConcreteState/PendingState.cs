using DesignPatternChallengeState.Context;
using DesignPatternChallengeState.State;

namespace DesignPatternChallengeState.ConcreteState
{
    public class PendingState : IOrderState
    {
        public void ProcessPayment(Order order)
        {
            Console.WriteLine($"\n[{order.OrderId}] Processando pagamento...");
            order.SetState(new PaidState());
            Console.WriteLine($"✅ Pagamento confirmado! Total: R$ {order.TotalAmount:N2}");
            Console.WriteLine($"   Status: Pago");
        }

        public void Ship(Order order, string trackingCode)
        {
            Console.WriteLine($"\n[{order.OrderId}] Tentando enviar pedido...");
            Console.WriteLine($"❌ Pedido ainda não foi pago!");
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
            Console.WriteLine($"✅ Pedido cancelado. Nenhuma cobrança realizada.");
            Console.WriteLine($"   Status: Cancelado");
        }

        public void RequestReturn(Order order)
        {
            Console.WriteLine($"\n[{order.OrderId}] Solicitando devolução...");
            Console.WriteLine($"❌ Pedido ainda não foi entregue. Use cancelamento.");
        }
    }
}
