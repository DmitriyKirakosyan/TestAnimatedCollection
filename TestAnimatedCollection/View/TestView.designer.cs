// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace TestAnimatedCollection.View
{
	[Register ("TestView")]
	partial class TestView
	{
		[Outlet]
		UIKit.UICollectionView collectionView { get; set; }

		[Outlet]
		UIKit.UILabel itemsCountLabel { get; set; }

		[Action ("AddOneTapped:")]
		partial void AddOneTapped (Foundation.NSObject sender);

		[Action ("AddTwoTapped:")]
		partial void AddTwoTapped (Foundation.NSObject sender);

		[Action ("RemoveOneTapped:")]
		partial void RemoveOneTapped (Foundation.NSObject sender);

		[Action ("RemoveTwoTapped:")]
		partial void RemoveTwoTapped (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (collectionView != null) {
				collectionView.Dispose ();
				collectionView = null;
			}

			if (itemsCountLabel != null) {
				itemsCountLabel.Dispose ();
				itemsCountLabel = null;
			}
		}
	}
}
