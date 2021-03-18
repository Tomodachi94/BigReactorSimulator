using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Converters;
using BigReactorSimulator.BigReactor;
using BigReactorSimulator.Tiles;
using REghZyFramework.Utilities;

namespace BigReactorSimulator.Views.ReactorCosts
{
    public class ReactorCostsViewModel : BaseViewModel
    {
        public ObservableCollection<CostableItemViewModel> Items { get; }
        public readonly Dictionary<TileType, CostableItemViewModel> ItemTypes;

        public ReactorCostsViewModel()
        {
            Items = new ObservableCollection<CostableItemViewModel>(new List<CostableItemViewModel>(8));
            ItemTypes = new Dictionary<TileType, CostableItemViewModel>();
        }

        public CostableItemViewModel CreateCostable(TileType type, int amount)
        {
            return new CostableItemViewModel(type, amount);
        }

        public void AddCostableItem(CostableItemViewModel item)
        {
            Items.Add(item);
            ItemTypes.Add(item.ItemType, item);
        }

        public void AddCostable(TileType type, int amount)
        {
            AddCostableItem(CreateCostable(type, amount));
        }

        public void ClearItems()
        {
            Items.Clear();
            ItemTypes.Clear();
        }

        public CostableItemViewModel GetCostable(TileType type)
        {
            if (ItemTypes.TryGetValue(type, out CostableItemViewModel cost))
                return cost;
            return null;
        }

        public void AddCasingReactor(int lengthTotal, int widthTotal, int heightTotal, int otherBlocks, int controlRods)
        {
            AddCostable(
                TileType.BlockReactorCase, 
                BasicCalculator.CalculateCasingReactor(lengthTotal, widthTotal, heightTotal, otherBlocks, controlRods));
        }

        public void AddCoolant(TileType liquidType, int totalHeight, int surfaceTiles)
        {
            int totalCount = (totalHeight - 2) * surfaceTiles;
            AddCostable(liquidType, totalCount);
        }

        public void AddFuelRods(int totalHeight, int surfaceTiles)
        {
            int totalCount = (totalHeight - 2) * surfaceTiles;
            AddCostable(TileType.BlockReactorFuelRod, totalCount);
        }

        public void AddControlRods(int fuelRods)
        {
            AddCostable(TileType.BlockReactorControlRod, fuelRods);
        }
    }
}
