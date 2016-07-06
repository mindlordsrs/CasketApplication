//  Инициализируем модель представления
window.casketStateApp.casketStateViewModel = (function (ko, datacontext) {
    
    var state = ko.observable(),
        error = ko.observable(),
        saveState = function (vm) {
            datacontext.postState(vm.state())
                .then(saveSucceeded)
                .fail(saveFailed);

            function saveSucceeded() {
                showState(vm);
            }
            function saveFailed() {
                error("Save failed");
            }
        },
        showState = function (vm) {
        };

    datacontext.getState(state, error); // начальная загрузка состояния

    //  Модель представления состоит из модели состояния, сообщения об ошибке, и метода 'Сохранить состояние'
    return {
        state: state,
        error: error,
        saveState: saveState
    };

})(ko, casketStateApp.datacontext);

//  Регистрируем модель представления
ko.applyBindings(window.casketStateApp.casketStateViewModel);
