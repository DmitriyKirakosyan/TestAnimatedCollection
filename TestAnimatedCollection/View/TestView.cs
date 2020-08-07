using System;
using MvvmCross.Platforms.Ios.Views;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Binding.BindingContext;
using TestAnimatedCollection.ViewModel;
using TestAnimatedCollection.View.Source;
using Foundation;
using UIKit;

namespace TestAnimatedCollection.View
{
    [MvxFromStoryboard("Main")]
    [MvxRootPresentation(WrapInNavigationController = true)]
    public partial class TestView : MvxViewController<TestViewModel>
    {
        private CollectionViewSource collectionViewSource;

        public TestView(IntPtr intPtr) : base(intPtr)
        {
        }

        public TestView(NSCoder coder) : base(coder)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            SetupCollectionView();

            SetupBindings();
        }

        partial void AddOneTapped(Foundation.NSObject sender)
        {
            ViewModel.AddItems.Execute(1);
        }
        partial void AddTwoTapped(Foundation.NSObject sender)
        {
            ViewModel.AddItems.Execute(2);
        }
        partial void RemoveOneTapped(Foundation.NSObject sender)
        {
            ViewModel.RemoveRandomItems.Execute(1);
        }
        partial void RemoveTwoTapped(Foundation.NSObject sender)
        {
            ViewModel.RemoveRandomItems.Execute(2);
        }

        private void SetupCollectionView()
        {
            var collectionViewFlowLayout = new UICollectionViewFlowLayout();
            collectionViewFlowLayout.ScrollDirection = UICollectionViewScrollDirection.Horizontal;
            collectionViewFlowLayout.ItemSize = new CoreGraphics.CGSize(44, 44);

            collectionView.CollectionViewLayout = collectionViewFlowLayout;

            collectionViewSource = new CollectionViewSource(collectionView);
            collectionView.Source = collectionViewSource;
        }

        private void SetupBindings()
        {
            using (var set = this.CreateBindingSet<TestView, TestViewModel>())
            {
                set.Bind(collectionViewSource).To(vm => vm.Items);
                set.Bind(itemsCountLabel).To(vm => vm.ItemsCount);
            }
        }
    }
}

