namespace WhereAreTheAffordableGoodAreas.Models
{
    public class LowerLayerSuperOutputArea
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public LocalAuthorityDistrict LocalAuthorityDistrict { get; set; }
        public IndexOfMultipleDeprivation IndexOfMultipleDeprivation { get; set; }
    }
}