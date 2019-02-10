# FreezingFruitFoot
The swagger UI page should load after you build and run the project. If not build and run and go to this route  Swagger URL: https://localhost:44395/swagger/index.html
(A solution clean and rebuild pre-test runs is suggested to get update and delete unit tests to pass)
Assumptions
1.	Authentication was not necessary
2.	No values of the objects defined in the JSON are nullable. 
3.	Some things I would do if this was a real project: 
a.	Write more tests to assert on all possible outcomes 
b.	Adjust unit tests / build configurations to ditch the required a re-build,
c.	Implement the async pattern
d.	Add some model validation on insert
e.	In depth notes
f.	Separate the Agents and Customers repository
g.	Separate the shared models and repository objects into separate projects

Questions for PM / PO / ScrumMaster
1.	Is authentication necessary?
2.	What fields are required for agency and customer data?
3.	Do you expect this API’s functionality to expand beyond this set of data?
4.	How many API consumers are expected?
