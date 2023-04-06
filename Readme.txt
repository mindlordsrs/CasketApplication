The archive contains the source code of the WEB application and the test application.
Design:
     The WEB application contains a data access layer, a logic layer and a presentation layer.
     The data access layer has its own contract, described in the DataAccess.Contracts project. Implementation - DataAccess.Simple (keeping state in memory).
     The logic layer is the application page controller (HomeController) and the WEB API controller (CasketStateController)
     The presentation layer is jscript running on the client side.
System status data is provided through the web interface. The output is Json in the following format:
{
   "working" = <bool>,
   "workStartTime" = <nullable datetime>
}
Address: <site>/api/casketstate

PS No tests, no centralized exception handling, no dependency injection. And a lot of good things have not been done either.
Any high-quality project, of course, should include all this, but you have to balance between quality and the resources spent.
