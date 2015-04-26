function CarTypeViewModel(serverModel) {
    var self = this;
    self.Id = ko.observable();
    self.Name = ko.observable();
    self.IsSelected = ko.observable();

    ko.mapping.fromJS(serverModel, {}, self);
}