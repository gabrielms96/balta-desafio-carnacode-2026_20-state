using DesignPatternChallengeState.Context;
using DesignPatternChallengeState.State;

namespace DesignPatternChallengeState.ConcreteState
{
    public class ReturnedState : IOrderState
    {
        public void ProcessPayment(Order order)
        {
            Console.WriteLine($"\n[{order.OrderId}] Processando pagamento...");
            Console.WriteLine($"❌ Operação inválida para estado Devolvido");
        }

        public void Ship(Order order, string trackingCode)
        {
            Console.WriteLine($"\n[{order.OrderId}] Tentando enviar pedido...");
            Console.WriteLine($"❌ Operação inválida para estado Devolvido");
        }

        public void Deliver(Order order)
        {
            Console.WriteLine($"\n[{order.OrderId}] Registrando entrega...");
            Console.WriteLine($"❌ Operação inválida para estado Devolvido");
        }

        public void Cancel(Order order)
        {
            Console.WriteLine($"\n[{order.OrderId}] Tentando cancelar pedido...");
            Console.WriteLine($"❌ Operação inválida para estado Devolvido");
        }

        public void RequestReturn(Order order)
        {
            Console.WriteLine($"\n[{order.OrderId}] Solicitando devolução...");
            Console.WriteLine($"❌ Devolução já processada!");
        }
    }
}
