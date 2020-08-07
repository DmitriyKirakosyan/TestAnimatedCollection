using Foundation;
using UIKit;
using MvvmCross.Platforms.Ios.Binding.Views;

namespace TestAnimatedCollection.View.Source
{
    public class CollectionViewSource : MvxCollectionViewSourceAnimated
    {
        public CollectionViewSource(UICollectionView collectionView)
            : base(collectionView)
        {
        }

        protected override UICollectionViewCell GetOrCreateCellFor(UICollectionView collectionView, NSIndexPath indexPath, object item)
        {
            return collectionView.DequeueReusableCell(CollectionViewCell.Key, indexPath) as CollectionViewCell;
        }
    }
}
