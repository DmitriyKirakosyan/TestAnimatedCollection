## MvvmCross + Xamarin.ios + MvxCollectionViewSourceAnimated sample app

This project is used to reproduce the MvxCollectionViewSourceAnimated bug while using MvxObservableCollection.RemoveItems on iOS platform.

How to reproduce:
1) Scroll the CollectionView back and forward
2) Tap Add Two items
3) Tap Remove two items
4) Observe collection view and the "Items Count" label

**Actual:**

Getting log:
```
"[UICollectionView] Invalid update: invalid number of items in section 0.  The number of items contained in an existing section after the update (4) must be equal to the number of items contained in that section before the update (6), plus or minus the number of items inserted or deleted from that section (0 inserted, 0 deleted) and plus or minus the number of items moved into or out of that section (0 moved in, 0 moved out). - will perform reloadData. UICollectionView instance: <UICollectionView: 0x7fe8249dea00; frame = (80 224; 254 44); clipsToBounds = YES; autoresize = RM+BM; gestureRecognizers = <NSArray: 0x600000ec3120>; layer = <CALayer: 0x6000004a5160>; contentOffset: {4.5, 0}; contentSize: {314, 44}; adjustedContentInset: {0, 0, 0, 0}; layout: <UICollectionViewFlowLayout: 0x7fe821e20ce0>; dataSource: <TestAnimatedCollection_View_Source_CollectionViewSource: 0x6000002c5870>>; currentUpdate: [UICollectionViewUpdate - 0x7fe821d36dd0: old:<UICollectionViewData: 0x6000039087e0> new<UICollectionViewData: 0x6000039bb100> items:<(
)>]
```
And collection view is displaying a wrong number of items.

**Expected:**

Collection view should display a correct number of items received from the view model.