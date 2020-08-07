using System;
using System.Collections.Generic;
using System.Linq;
using MvvmCross.ViewModels;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.Commands;

namespace TestAnimatedCollection.ViewModel
{
    public class TestViewModel : MvxNavigationViewModel
    {
        private MvxObservableCollection<ItemViewModel> items;

        private int nextItemNum = 1;

        public MvxObservableCollection<ItemViewModel> Items
        {
            get => items;
            set
            {
                SetProperty(ref items, value);
            }
        }

        public int ItemsCount => Items.Count;

        public MvxCommand<int> AddItems;
        public MvxCommand<int> RemoveRandomItems;

        public TestViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService): base(logProvider, navigationService)
        {
            items = new MvxObservableCollection<ItemViewModel>(Enumerable.Range(1, 6).Select(i => new ItemViewModel(i)));
            nextItemNum = items.Count + 1;

            AddItems = new MvxCommand<int>(AddItemsExecute);
            RemoveRandomItems = new MvxCommand<int>(RemoveRandomItemsExecute);
        }

        private void AddItemsExecute(int count)
        {
            if (count == 1)
            {
                Items.Add(new ItemViewModel(nextItemNum));
                nextItemNum++;
            }
            else
            {
                var range = Enumerable.Range(nextItemNum, count).Select(i => new ItemViewModel(i));
                Items.AddRange(range);

                nextItemNum += count;
            }

            RaisePropertyChanged(() => ItemsCount);
        }

        private void RemoveRandomItemsExecute(int count)
        {
            var rnd = new Random();

            if (count == 1)
            {
                Items.RemoveAt(rnd.Next(items.Count - 1));
            }
            else if (count == Items.Count)
            {
                Items.Clear();
            }
            else if (count < Items.Count)
            {
                var indices = new List<int>();

                for (int i = 0; i < count; ++i)
                {
                    int rndIndex;
                    do
                    {
                        rndIndex = rnd.Next(items.Count - 1);
                    } while (indices.Contains(rndIndex));

                    indices.Add(rndIndex);

                }

                var toRemove = indices.Select(i => items.ElementAt(i)).ToList();

                Items.RemoveItems(toRemove);
            }

            RaisePropertyChanged(() => ItemsCount);
        }
    }
}
