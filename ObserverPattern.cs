public enum OrderState
    {
        CREATED, PROCESSED, CANCELLED, COMPLETED
    }
    public class Order
    {
        private OrderState state;
        private Guid orderId;
        /*
        public Guid OrderId
        {
            get { return this.orderId; }
            set { this.orderId = value; }
        }

        // Expression body definitions for properties
        public Guid OrderId
        {
            get => orderId;
            set => orderId = value;
        }
        */

        //ReadOnly Propoerties
        public Guid OrderId => this.orderId;
        public Order()
        {
            this.orderId = Guid.NewGuid();
            
        }

        /*
        public void ChangeOrderState(OrderState newState)
        {
            this.state = newState;
        }
        */

        //Expression Body Methods 
        public void ChangeOrderState(OrderState newState) => this.state = newState;
    }
    public class OrderManager
    {
        List<Order> _orders = new List<Order>();
        public OrderManager()
        {
            Order _orderOne = new Order();
            this.UpdateOrder(_orderOne.OrderId, OrderState.CREATED);

            Order _orderTwo = new Order();
            this.UpdateOrder(_orderTwo.OrderId, OrderState.CREATED);

            Order _orderThree = new Order();
            this.UpdateOrder(_orderThree.OrderId, OrderState.CREATED);

            _orders.Add(_orderOne);
            _orders.Add(_orderOne);
            _orders.Add(_orderOne);
        }
        public void UpdateOrder(Guid id,OrderState state)
        {
            //Search 
            //Update
            //Notify OrderDashboard


        }
    }

    //Observer
    public class OrderDashoard
    {
        public void Display(Guid id, OrderState state)
        {
            // + , StringBuilder, string.Format()
            // String Interpollation
            string message = $"Order Id:{id.ToString()},State:{state}";
            Console.WriteLine(message);

        }
    }
   

    class Program
    {
        static void Main(string[] args)
        {
        OrderManager _mgr = new OrderManager();
        }
    }
