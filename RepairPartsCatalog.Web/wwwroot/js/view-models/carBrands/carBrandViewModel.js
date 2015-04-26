function CarBrandViewModel(serverModel, countries) {
    var self = this;
    self.Id = ko.observable();
    self.Name = ko.observable();
    self.CountryName = ko.observable();
    self.CountryId = ko.observable();
    self.ImageUrl = ko.observable();
    self.Countries = countries;

    if (serverModel != null) {
        ko.mapping.fromJS(serverModel, {}, self);
    };

    self.AddNewBrand = function () {
        var ajax = CatalogApp.utilities.ajaxHelper,
            ajaxOptions = {
                url: window.urls.createBrand,
                data: ko.mapping.toJSON(self)
            };

        ajax.post(ajaxOptions)
            .done(function (result) {
                self.modal.close(result);
            });
    };

    self.format = function(country) {
        return country.Name();
    };
}

CarBrandViewModel.prototype.template = 'addBrand-template';