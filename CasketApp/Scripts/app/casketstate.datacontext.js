window.casketStateApp = window.casketStateApp || {};

//  Инициализируем контекст
window.casketStateApp.datacontext = (function () {

    //  Контекст умеет сохранять и получать состояние
	var datacontext = {
		getState: getState,
		postState: postState
	};

	return datacontext;

    //  Получить состояние
	function getState(stateObservable, errorObservable) {
		return ajaxRequest("get", stateUrl())
            .done(getSucceeded)
            .fail(getFailed);

        //  Создать модель состояния и вернуть её
		function getSucceeded(data) {
		    var state = new createState(data);
			stateObservable(state);
		}

        //  Вернуть сообщение об ошибке
		function getFailed() {
			errorObservable("Error retrieving state.");
		}
	}
	function createState(data) {
		return new datacontext.casketstate(data); // casketstate определен в casketstate.model.js
	}

    //  Сохранить состояние
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
	function ajaxRequest(type, url, data, dataType) { // Хелпер для отправки ajax запросов
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
	// Адрес webapi, предоставляющего возможность управления состоянием системы
	function stateUrl() { return "/api/casketstate/"; }
	

})();