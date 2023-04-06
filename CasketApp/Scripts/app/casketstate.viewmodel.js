//  Initialize the view model
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

    datacontext.getState(state, error); // Initial state loading

    //  View model consists of a state model, error message and 'Save state' method
    return {
        state: state,
        error: error,
        saveState: saveState
    };

})(ko, casketStateApp.datacontext);

//  Register a view model
ko.applyBindings(window.casketStateApp.casketStateViewModel);
