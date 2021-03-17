using BigReactorSimulator.Tiles;

namespace BigReactorSimulator.Views.Tiles
{
    public class ChangableTileViewModel : TileViewModel
    {
        public ChangableTileViewModel()
        {
            base.CanDragChangeTile = true;
        }

        public override void OnClick()
        {
            this.ChanceTileTexture(TileSelector.SelectedTile);
        }
    }
}
