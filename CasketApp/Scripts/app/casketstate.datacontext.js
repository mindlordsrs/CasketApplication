window.casketStateApp = window.casketStateApp || {};

//  Initialize the context
window.casketStateApp.datacontext = (function () {

    //  Context can save and get the system state
	var datacontext = {
		getState: getState,
		postState: postState
	};

	return datacontext;

    //  Get system state
	function getState(stateObservable, errorObservable) {
		return ajaxRequest("get", stateUrl())
            .done(getSucceeded)
            .fail(getFailed);

        //  Create state model and return it
		function getSucceeded(data) {
		    var state = new createState(data);
			stateObservable(state);
		}

        //  Get error message
		function getFailed() {
			errorObservable("Error retrieving state.");
		}
	}
	function createState(data) {
		return new datacontext.casketstate(data); // casketstate is defined in casketstate.model.js
	}

    //  Save system state
	function postState(state) {
		clearErrorMessage(state);
		return ajaxRequest("post", stateUrl(), state)
            .done(function (result) {

            })
            .fail(function () {
                state.errorMessage("Error saving state.");
            });
	}

	// Private
	function clearErrorMessage(entity) { entity.errorMessage(null); }
	function ajaxRequest(type, url, data, dataType) { // ajax request send helper
		var options = {
			dataType: dataType || "json",
			contentType: "application/json",
			cache: false,
			type: type,
			data: data ? data.toJson() : null
		};
		var antiForgeryToken = $("#antiForgeryToken").val();
		if (antiForgeryToken) {
			options.headers = {
				'RequestVerificationToken': antiForgeryToken
			}
		}
		return $.ajax(url, options);
	}
	// Url of a webapi, allowing to manage the system state
	function stateUrl() { return "/api/casketstate/"; }
	

})();