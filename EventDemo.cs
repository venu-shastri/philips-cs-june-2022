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
        public Order(string id)
        {
            this.orderId = Guid.Parse(id); 
            
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
        // List<Action<Guid, OrderState>> _observers = new List<Action<Guid, OrderState>>();
        public event Action<Guid, OrderState> OnOrderStateChanged;
        //Dependency Inversion
        ILogger _logger;

        /*
        public void Subscribe/Add_Observer(Action<Guid,OrderState> observer)
        {
            this.Observers += observer;
        }
        public void UnSubscribe/Remove_Observers(Action<Guid,OrderState> observer)
        {
            this.Observers -= observer;

        }
        */
        public OrderManager(ILogger logger)
        {
            this._logger = logger;
            Order _orderOne = new Order("0f85c228-3e66-428b-a127-c8d9a6e71ccd");
            this.UpdateOrder(_orderOne.OrderId, OrderState.CREATED);

            Order _orderTwo = new Order("8eba56ca-3c2c-4330-93e8-d7c5083fbe3d");
            this.UpdateOrder(_orderTwo.OrderId, OrderState.CREATED);

            Order _orderThree = new Order("3d74b662-87ab-41f7-a637-8a35abcdf23d");
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
           // this._logger.Write($"Order ID : {id},state : {state}");
            this.NotifyAllTheObservers(id,state);
        }
        private void NotifyAllTheObservers(Guid id,OrderState state)
        {
            //for(int i = 0; i < _observers.Count; i++)
            //{
            //    _observers[i].Invoke(id, state);
            //}
            if (this.OnOrderStateChanged != null)
            {
                this.OnOrderStateChanged.Invoke(id, state);
            }
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
   
    public interface ILogger
    {
        void Write(string messgae);
    }
    public class ConsoleLogger:ILogger
    {
        public void Write(string messgae)
        {
            Console.WriteLine(messgae);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            OrderDashoard _dashBoard = new OrderDashoard();
            Action<Guid, OrderState> observerWrapper = new Action<Guid, OrderState>(_dashBoard.Display); 
            OrderManager _mgr = new OrderManager(new ConsoleLogger());
            //_mgr.Subscribe(observerWrapper);
            _mgr.OnOrderStateChanged += observerWrapper;// _mgr.Add_obsevers(observerWrapper);
            
            _mgr.UpdateOrder(Guid.Parse("0f85c228-3e66-428b-a127-c8d9a6e71ccd"), OrderState.PROCESSED);
            System.Threading.Thread.Sleep(2000);
            _mgr.UpdateOrder(Guid.Parse("0f85c228-3e66-428b-a127-c8d9a6e71ccd"), OrderState.COMPLETED);
            System.Threading.Thread.Sleep(2000);
            _mgr.UpdateOrder(Guid.Parse("3d74b662-87ab-41f7-a637-8a35abcdf23d"), OrderState.CANCELLED);




        }
    }
