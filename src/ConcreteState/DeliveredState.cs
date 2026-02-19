using DesignPatternChallengeState.Context;
using DesignPatternChallengeState.State;

namespace DesignPatternChallengeState.ConcreteState
{
    public class DeliveredState : IOrderState
    {
        public void ProcessPayment(Order order)
        {
            Console.WriteLine($"\n[{order.OrderId}] Processando pagamento...");
            Console.WriteLine($"❌ Não é possível processar pagamento. Pedido já está entregue");
        }

        public void Ship(Order order, string trackingCode)
        {
            Console.WriteLine($"\n[{order.OrderId}] Tentando enviar pedido...");
            Console.WriteLine($"❌ Pedido já foi entregue!");
        }

        public void Deliver(Order order)
        {
            Console.WriteLine($"\n[{order.OrderId}] Registrando entrega...");
            Console.WriteLine($"❌ Pedido já foi entregue em {order.DeliveredDate:dd/MM/yyyy}");
        }

        public void Cancel(Order order)
        {
            Console.WriteLine($"\n[{order.OrderId}] Tentando cancelar pedido...");
            Console.WriteLine($"❌ Pedido já entregue. Solicite devolução se necessário.");
        }

        public void RequestReturn(Order order)
        {
            Console.WriteLine($"\n[{order.OrderId}] Solicitando devolução...");
            if (order.DeliveredDate == null) return;

            var daysSinceDelivery = (DateTime.Now - order.DeliveredDate.Value).Days;
            if (daysSinceDelivery <= 7)
            {
                order.SetState(new ReturnedState());
                Console.WriteLine($"✅ Devolução aprovada! Prazo dentro de 7 dias.");
                Console.WriteLine($"   Reembolso: R$ {order.TotalAmount:N2}");
                Console.WriteLine($"   Status: Devolvido");
            }
            else
            {
                Console.WriteLine($"❌ Prazo de devolução expirado ({daysSinceDelivery} dias)");
            }
        }
    }
}
