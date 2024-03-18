# TestDrivenApplication
This application was built using Test Driven techniques using .NET Core 7!

It consists of one controller with a swagger endpoint to calculate interest for 1 person that has up to 3 different credit cards. There are 4 scenarios defined in the unit tests that provide good examples for testing the controller. The controller calls the interface wich in turn calls the service to calculate the simple interest.

CODING CHALLENGES:

### Basic 
Write an HTTP GET endpoint to return the interest for a single card passing amount owed and using the correct interest rate defined in the service.

### Intermediate 
Modify the existing HTTP endpoint or write a new one that takes a payment amount by card to be subtracted from the statement balance before calculating the interest.

### Advanced 
Incorporate dates and fees into the service that checks if customer's last payment was over 30 days ago and adds a $10 fee to the interest owed.
Inside of the controller there are three coding challenges defined. One for beginners, one for intermediate, and one advanced. This is designed to be used for interviews.
