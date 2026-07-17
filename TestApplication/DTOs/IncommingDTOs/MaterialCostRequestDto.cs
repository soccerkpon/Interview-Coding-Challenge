namespace TestApplication.DTOs.IncommingDTOs
{
	public class MaterialCostRequestDto
	{
		public decimal UnitCost { get; set; }
		public int Quantity { get; set; }
		public bool IncludeWaste { get; set; }
	}
}
