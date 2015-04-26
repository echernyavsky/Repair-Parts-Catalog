function CountryViewModel(serverModel) {
    var self = this;
    self.Code = ko.observable();
    self.Name = ko.observable();
    self.Id = ko.observable();

    ko.mapping.fromJS(serverModel, {}, self);
}