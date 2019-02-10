# FreezingFruitFoot
The swagger UI page should load after you build and run the project. If not build, run, then go to this route: https://localhost:44395/swagger/index.html

Unit tests are included.

Assumptions
1.	Authentication was not necessary
2.	No values of the objects defined in the provided JSON are nullable. 
3.	Some things I would do if this was a real project: 
    a.	Write more tests to assert on all possible outcomes 
    b.	Implement the async pattern
    c.	Add model validation on insert
    d.	In depth notes
    e.	Separate the Agents and Customers repository
    f.	Separate the shared models and repository objects into separate projects

Questions for PM / PO / ScrumMaster
1.	Is authentication necessary?
2.	What fields are required for agency and customer data?
3.	Do you expect this API’s functionality to expand beyond this set of data?
4.	How many API consumers are expected?
5.  Expected turn around time
6.  Service Level Agreement 
