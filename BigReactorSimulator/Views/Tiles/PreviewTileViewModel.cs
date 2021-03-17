using BigReactorSimulator.Tiles;

namespace BigReactorSimulator.Views.Tiles
{
    public class PreviewTileViewModel : TileViewModel
    {
        public PreviewTileViewModel()
        {
            base.CanDragChangeTile = false;
        }

        public override void OnClick()
        {
            TileSelector.SelectedTile = CurrentType;
        }
    }
}
