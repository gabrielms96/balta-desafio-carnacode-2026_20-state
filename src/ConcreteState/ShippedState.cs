using DesignPatternChallengeState.Context;
using DesignPatternChallengeState.State;

namespace DesignPatternChallengeState.ConcreteState
{
    public class ShippedState : IOrderState
    {
        public void ProcessPayment(Order order)
        {
            Console.WriteLine($"\n[{order.OrderId}] Processando pagamento...");
            Console.WriteLine($"❌ Não é possível processar pagamento. Pedido já está enviado");
        }

        public void Ship(Order order, string trackingCode)
        {
            Console.WriteLine($"\n[{order.OrderId}] Tentando enviar pedido...");
            Console.WriteLine($"❌ Pedido já foi enviado em {order.ShippedDate:dd/MM/yyyy}");
        }

        public void Deliver(Order order)
        {
            Console.WriteLine($"\n[{order.OrderId}] Registrando entrega...");
            order.DeliveredDate = DateTime.Now;
            order.SetState(new DeliveredState());
            Console.WriteLine($"✅ Pedido entregue com sucesso!");
            Console.WriteLine($"   Data: {order.DeliveredDate:dd/MM/yyyy HH:mm}");
            Console.WriteLine($"   Status: Entregue");
        }

        public void Cancel(Order order)
        {
            Console.WriteLine($"\n[{order.OrderId}] Tentando cancelar pedido...");
            Console.WriteLine($"❌ Pedido já enviado. Use processo de devolução.");
        }

        public void RequestReturn(Order order)
        {
            Console.WriteLine($"\n[{order.OrderId}] Solicitando devolução...");
            Console.WriteLine($"❌ Aguarde a entrega para solicitar devolução.");
        }
    }
}
