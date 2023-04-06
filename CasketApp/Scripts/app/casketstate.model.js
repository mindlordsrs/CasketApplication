(function (ko, datacontext) {
    datacontext.casketstate = casketstate;

    function casketstate(data) {
        var self = this;
        data = data || {};

        //  State model contains persistent fields (health status and scheduled maintenance start date)
        self.working = ko.observable(data.working);
        self.workStartTime = ko.observable(data.workStartTime);

        //  Also it contains error message and json-representation conversion method
        self.errorMessage = ko.observable();
        //self.dateInputEnabled = ko.computed(function () {
        //    return !self.working;
        //});

        self.toJson = function () { return ko.toJSON(self) };
    };

})(ko, casketStateApp.datacontext);