using MvvmCross.ViewModels;
using TestAnimatedCollection.ViewModel;

namespace TestAnimatedCollection
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            RegisterAppStart<TestViewModel>();
        }
    }
}
