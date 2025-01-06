# Interview Coding Challenge
This application was intentionally designed to be simplistic, open to refactoring, and not fully implemented for the expansion of new features. There is room for the candidate to completely refactor portions of the application to meet the needs of each coding challenge below. It's up to the candidate to interpret the requirements and devise a solid plan for implementing each feature into the existing code.

It consists of one controller with a swagger endpoint to calculate interest for 1 person that has up to 3 different credit cards. There are 4 scenarios defined in the unit tests that provide good examples for testing the controller. The controller calls the interface which in turn calls the service to calculate the simple interest.

CODING CHALLENGES:

1. Write an HTTP GET endpoint to return the interest for a single card passing amount owed and using the correct interest rate defined in the service.
 
2. Modify the existing HTTP POST endpoint or write a new one that takes a payment amount by card to be subtracted from the statement balance before calculating the interest.

3. Modify the existing HTTP POST endpoint to incorporate dates and fees into the service that checks if customer's last payment was over 30 days ago and adds a $10 fee to the interest owed.
