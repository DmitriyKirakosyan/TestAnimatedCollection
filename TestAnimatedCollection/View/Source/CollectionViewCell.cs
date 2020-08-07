using System;
using MvvmCross.Platforms.Ios.Binding.Views;
using MvvmCross.Binding.BindingContext;
using TestAnimatedCollection.ViewModel;

namespace TestAnimatedCollection.View.Source
{
    public partial class CollectionViewCell : MvxCollectionViewCell
    {
        public static readonly string Key = nameof(CollectionViewCell);

        protected CollectionViewCell(IntPtr handle) : base(handle)
        {
            SetupBindings();
        }

        private void SetupBindings()
        {
            this.DelayBind(() =>
            {
                using (var set = this.CreateBindingSet<CollectionViewCell, ItemViewModel>())
                {
                    set.Bind(titleLabel).To(vm => vm.Number);
                }
            });
        }
    }
}
