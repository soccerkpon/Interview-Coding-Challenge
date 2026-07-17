# Interview Coding Challenge
This application was intentionally designed to be simplistic, open to refactoring, and not fully implemented for the expansion of new features. There is room for the candidate to completely refactor portions of the application to meet the needs of each coding challenge below. It's up to the candidate to interpret the requirements and devise a solid plan for implementing each feature into the existing code.

It consists of two independent scenarios, each exposed through Swagger with its own controller, service, interface, and DTOs. Each controller implements an interface which executes a service to perform a simple calculation. The unit tests provide good examples for testing each service.

## Scenario 1 - Material Cost Calculator
`POST /api/materialcost/calculate` calculates the cost of a material from a unit cost and quantity, optionally adding a flat waste allowance.

- Request (`MaterialCostRequestDto`): `UnitCost`, `Quantity`, `IncludeWaste`
- Response (`MaterialCostResponseDto`): `MaterialCost`, `WasteAmount`, `TotalCost`

Business rules:
- `MaterialCost = UnitCost * Quantity`
- `WasteAmount = MaterialCost * 0.05` when `IncludeWaste` is true, otherwise `0`
- `TotalCost = MaterialCost + WasteAmount`

## Scenario 2 - Saw Waste Calculator
`POST /api/sawwaste/calculate` calculates the leftover waste when a board is cut into pieces.

- Request (`SawWasteRequestDto`): `BoardLength`, `CutLengths`
- Response (`SawWasteResponseDto`): `WasteLength`

Business rules:
- `WasteLength = BoardLength - Sum(CutLengths)`

The Saw Waste calculator intentionally does not account for kerf loss, invalid cuts, negative values, or the difference between reusable offcuts and scrap waste.

CODING CHALLENGES:

1. Write an HTTP GET endpoint that returns the material cost for a request passing unit cost, quantity, and whether to include waste, reusing the waste rate defined in the service.

2. Modify the existing Saw Waste HTTP POST endpoint or write a new one that accounts for kerf loss by subtracting a fixed blade width for each cut before calculating the remaining waste.

3. Incorporate validation into the Saw Waste service that handles invalid input, such as negative values or cut lengths whose total exceeds the board length, and returns an appropriate response.

4. Extend the Saw Waste response to distinguish reusable offcuts from scrap waste based on a minimum reusable length.
