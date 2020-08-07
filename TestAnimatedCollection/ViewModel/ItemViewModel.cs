using MvvmCross.ViewModels;

namespace TestAnimatedCollection.ViewModel
{
    public class ItemViewModel : MvxViewModel
    {

        private int number;
        public int Number
        {
            get => number;
            set
            {
                SetProperty(ref number, value);
            }
        }

        public ItemViewModel(int number)
        {
            Number = number;
        }
    }
}