(function (ko, datacontext) {
    datacontext.casketstate = casketstate;

    function casketstate(data) {
        var self = this;
        data = data || {};

        //  Модель состояния содержит хранимые свойства (признак работоспособности системы и дата начала запланированных работ)
        self.working = ko.observable(data.working);
        self.workStartTime = ko.observable(data.workStartTime);

        //  Также содержит сообщение об ошибке и метод для конвертации в Json-представление
        self.errorMessage = ko.observable();
        //self.dateInputEnabled = ko.computed(function () {
        //    return !self.working;
        //});

        self.toJson = function () { return ko.toJSON(self) };
    };

})(ko, casketStateApp.datacontext);