namespace Sales.Infrastructure
{
    using Sales.ViewModels;

    //Only objective is to instance the MainViewModel
    public class InstanceLocator
    {
        public MainViewModel Main { get; set; }

        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }

    }
}
