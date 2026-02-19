using DesignPatternChallengeState.ConcreteState;
using DesignPatternChallengeState.State;

namespace DesignPatternChallengeState.Context
{
    public class Order
    {
        public string OrderId { get; set; }
        public decimal TotalAmount { get; set; }
        public string TrackingCode { get; set; } = string.Empty;
        public DateTime? ShippedDate { get; set; }
        public DateTime? DeliveredDate { get; set; }

        private IOrderState _currentState;

        public Order(string orderId, decimal totalAmount)
        {
            OrderId = orderId;
            TotalAmount = totalAmount;
            _currentState = new PendingState();
        }

        public void SetState(IOrderState newState)
        {
            _currentState = newState;
        }

        public void ProcessPayment() => _currentState.ProcessPayment(this);
        public void Ship(string trackingCode) => _currentState.Ship(this, trackingCode);
        public void Deliver() => _currentState.Deliver(this);
        public void Cancel() => _currentState.Cancel(this);
        public void RequestReturn() => _currentState.RequestReturn(this);
    }
}
