using DesignPatternChallengeState.Context;
using DesignPatternChallengeState.State;

namespace DesignPatternChallengeState.ConcreteState
{
    public class CancelledState : IOrderState
    {
        public void ProcessPayment(Order order)
        {
            Console.WriteLine($"\n[{order.OrderId}] Processando pagamento...");
            Console.WriteLine($"❌ Pedido foi cancelado. Crie novo pedido.");
        }

        public void Ship(Order order, string trackingCode)
        {
            Console.WriteLine($"\n[{order.OrderId}] Tentando enviar pedido...");
            Console.WriteLine($"❌ Não é possível enviar pedido cancelado");
        }

        public void Deliver(Order order)
        {
            Console.WriteLine($"\n[{order.OrderId}] Registrando entrega...");
            Console.WriteLine($"❌ Pedido cancelado não pode ser entregue");
        }

        public void Cancel(Order order)
        {
            Console.WriteLine($"\n[{order.OrderId}] Tentando cancelar pedido...");
            Console.WriteLine($"❌ Pedido já está cancelado!");
        }

        public void RequestReturn(Order order)
        {
            Console.WriteLine($"\n[{order.OrderId}] Solicitando devolução...");
            Console.WriteLine($"❌ Pedido cancelado não pode ser devolvido.");
        }
    }
}
